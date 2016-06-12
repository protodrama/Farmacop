using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Farmacop
{
    public partial class AddPrescription : Form
    {
        List<string> Users;
        List<PrescTimeSelect> ListTime = new List<PrescTimeSelect>();
        MonthCalendar mCalendar;
        bool FInic = true;

        public AddPrescription()
        {
            InitializeComponent();
            GetData();
            GetMedNames();
        }

        //Obtiene la lista de nombres de usuario de la base de datos
        public void GetData()
        {
            List<string> names = ReadUsersData(Session.DBConnection.GetAllUsersNameAccount());
            Users = names;
            var source = new AutoCompleteStringCollection();
            source.AddRange(names.ToArray());
            txtTargetUser.AutoCompleteCustomSource = source;
            txtTargetUser.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTargetUser.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtFInic.Text = DateTime.Now.ToShortDateString();
            PrescTimeSelect select = new PrescTimeSelect();
            ListTime.Add(select);
            TimeContainer.Controls.Add(select);
        }

        //Lee los datos de los usuarios recibidos desde el servidor
        public List<string> ReadUsersData(string data)
        {
            List<string> userslist = new List<string>();
            JObject jsonobject = JObject.Parse(data);
            JToken jsondata = jsonobject["data"];

            for (int i = 0; i < jsondata.Count<JToken>(); i++)
            {
                JToken temp = jsondata[i];
                userslist.Add(temp["Cuenta"].ToString());
            }
            return userslist;
        }

        //Obtiene el nombre de los medicamentos del entorno
        public void GetMedNames()
        {
            try
            {
                cbbxMed.Items.Clear();
                List<Medicament> medlist = ReadData(Session.DBConnection.GetAllMedicaments());
                foreach (Medicament temp in medlist)
                    cbbxMed.Items.Add(temp.Nombre);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al obtener los datos de los medicamentos");
            }
        }

        //Lee los datos de los medicamentos recibidos desde el servidor
        public List<Medicament> ReadData(string jsondata)
        {
            List<Medicament> thelist = new List<Medicament>();
            JObject jobject = JObject.Parse(jsondata);
            JToken jdata = jobject["data"];

            for (int i = 0; i < jdata.Count<JToken>(); i++)
            {
                Medicament temp = new Medicament(jdata[i]["Nombre"].ToString(), jdata[i]["Tipo"].ToString());
                thelist.Add(temp);
            }

            return thelist;
        }

        //Cierra el formulario
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        //Agrega la receta a la base de datos.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!txtDs.Text.Trim().Equals("") && !txtFInic.Text.Trim().Equals("") && !txtFEnd.Text.Trim().Equals("") && !cbbxMed.Text.Trim().Equals(""))
            {
                int ds = int.Parse(txtDs.Text);
                if (ds > 0)
                {
                    List<string> time = new List<string>();
                    foreach (PrescTimeSelect temp in ListTime)
                    {
                        if (!time.Contains(temp.Time))
                            time.Add(temp.Time);
                    }
                    if (time.Count > 0)
                    {
                        string hours = string.Empty;
                        foreach (string tmp in time)
                            hours += "\n" + tmp;
                        string msg = @"¿Desea crear una receta para el usuario " + txtTargetUser.Text + "?\nMedicamento: " + cbbxMed.Text +
                            "\nDosis: " + txtDs.Text + "\nFecha de inicio: " + txtFInic.Text + "\nFecha fin: " + txtFEnd.Text + "\nHorario de tomas:" + hours;
                        if (DialogResult.Yes == MessageBox.Show(msg, "Creando receta", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            this.Cursor = Cursors.AppStarting;
                            try
                            {
                                if (!CheckRecepies(Session.DBConnection.CheckBeforeAddPresciption(txtTargetUser.Text, cbbxMed.Text, DateTime.Parse(txtFInic.Text).ToString("yyyy-MM-dd"))))
                                {
                                    if (Session.DBConnection.AddRecepie(txtTargetUser.Text, Session.Account, cbbxMed.Text, txtFInic.Text, txtFEnd.Text, txtDs.Text, time))
                                    {
                                        this.Cursor = Cursors.Default;
                                        MessageBox.Show("Receta añadida correctamente");
                                        this.Close();
                                    }
                                    else
                                    {
                                        this.Cursor = Cursors.Default;
                                        MessageBox.Show("Error al añadir la receta.");
                                    }
                                }
                                else
                                {
                                    this.Cursor = Cursors.Default;
                                    MessageBox.Show("El paciente ya tiene una receta con el medicamento indicado activa actualmente.");
                                }
                            }
                            catch (Exception ex)
                            {
                                this.Cursor = Cursors.Default;
                                MessageBox.Show("Error al añadir la receta.");
                            }
                        }
                    }
                    else
                        MessageBox.Show("La receta debe tener al menos una hora de toma");
                }
                else
                    MessageBox.Show("La dosis no puede ser 0");
            }
            else
                MessageBox.Show("Debes indicar un valor para todos los campos");
        }

        //Comprueba si existen recetas activas para el mismo medicamento antes de agregar la receta
        public bool CheckRecepies(string data)
        {
            JObject jobject = JObject.Parse(data);
            JToken jdata = jobject["data"];
            int temp = int.Parse(jdata[0]["count(*)"].ToString());       

            return temp > 0;
        }

        //Lee los datos de las alergias del usuario al que se destina la receta
        public List<string> ReadAlg(string data)
        {
            List<string> thelist = new List<string>();
            JObject jobject = JObject.Parse(data);
            JToken jdata = jobject["data"];

            for (int i = 0; i < jdata.Count<JToken>(); i++)
            {
                string temp = jdata[i]["Nombre"].ToString();
                thelist.Add(temp);
            }

            return thelist;
        }

        private void txtTargetUser_TextChanged(object sender, EventArgs e)
        {
            
            if (Users.Contains(txtTargetUser.Text))
            {
                if (!Session.GettingData)
                {
                    GetMedNames();
                    btnAdd.Enabled = true;
                    grpRecData.Visible = true;
                    try
                    {
                        List<string> Alerg = ReadAlg(Session.DBConnection.GetUserAlg(txtTargetUser.Text));
                        foreach (string temp in Alerg)
                            cbbxMed.Items.Remove(temp);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al obtener las alergias del usuario");
                    }
                }
            }
            else
            {
                btnAdd.Enabled = false;
                grpRecData.Visible = false;
                GetMedNames();
            }
            
        }

        //Abre el formulario que permite añadir medicamentos
        private void btnAddMed_Click(object sender, EventArgs e)
        {
            new AddNewMed().ShowDialog();
            GetMedNames();
        }

        private void txtDs_KeyPress(object sender, KeyPressEventArgs e)
        {
            string allowed = "0123456789\b";
            if (!allowed.Contains(e.KeyChar))
                e.Handled = true;
        }

        //Muestra un calendario para seleccionar las fechas
        private void txtFInic_Enter(object sender, EventArgs e)
        {
            FInic = true;
            mCalendar = new MonthCalendar()
            {
                Left = 160,
                Top = 150
            };
            mCalendar.MouseLeave += MCalendar_MouseLeave;
            mCalendar.DateSelected += MCalendar_DateSelected;
            this.Controls.Add(mCalendar);
            mCalendar.BringToFront();
            mCalendar.Focus();
            txtFInic.Enabled = false;
        }

        private void MCalendar_Leave(object sender, EventArgs e)
        {
            this.Controls.Remove(mCalendar);
            txtFInic.Enabled = true;
            txtFEnd.Enabled = true;
        }

        private void MCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtFInic.Enabled = true;
            txtFEnd.Enabled = true;
            if (FInic)
                txtFInic.Text = mCalendar.SelectionRange.Start.ToString("dd/MM/yyyy");
            else
                txtFEnd.Text = mCalendar.SelectionRange.Start.ToString("dd/MM/yyyy");
            try
            {
                if (FInic)
                {
                    DateTime Date = DateTime.Parse(txtFInic.Text);
                    if (Date.Date < DateTime.Now.Date)
                        throw new Exception("Fecha fuera de rango (Fecha actual como mínimo).");
                    else
                        txtFEnd.Text = "";
                }
                else
                {
                    DateTime Date = DateTime.Parse(txtFEnd.Text);
                    if (Date.Date < DateTime.Parse(txtFInic.Text).Date)
                        throw new Exception("La fecha de fin debe ser igual o superior a la fecha de inicio.");
                }

            }
            catch (Exception ex)
            {
                if (FInic)
                {
                    MessageBox.Show(ex.Message, "Error");
                    txtFInic.Text = DateTime.Now.ToShortDateString();
                }
                else
                {
                    MessageBox.Show(ex.Message, "Error");
                    txtFEnd.Text = "";
                }
            }
            this.Controls.Remove(mCalendar);
        }

        private void MCalendar_MouseLeave(object sender, EventArgs e)
        {
            this.Controls.Remove(mCalendar);
            txtFInic.Enabled = true;
            txtFEnd.Enabled = true;
        }

        //Muestra un calendario para seleccionar las fechas
        private void txtFEnd_Enter(object sender, EventArgs e)
        {
            FInic = false;
            mCalendar = new MonthCalendar()
            {
                Left = 160,
                Top = 150
            };
            mCalendar.MouseLeave += MCalendar_MouseLeave;
            mCalendar.DateSelected += MCalendar_DateSelected;
            this.Controls.Add(mCalendar);
            mCalendar.BringToFront();
            mCalendar.Focus();
            txtFEnd.Enabled = false;
        }

        //Agrega un control de selección de alergias a la lista
        private void btnAddAlg_Click(object sender, EventArgs e)
        {
            PrescTimeSelect select = new PrescTimeSelect();
            ListTime.Add(select);
            TimeContainer.Controls.Add(select);
        }

        //Elimina un control de selección de alergias de la lista
        private void btnDelete_Click(object sender, EventArgs e)
        { 
            if(ListTime.Count > 0){
                PrescTimeSelect temp = ListTime[ListTime.Count - 1];
                ListTime.Remove(temp);
                TimeContainer.Controls.Remove(temp);
            }
        }
    }
}
