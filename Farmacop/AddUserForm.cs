using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Farmacop
{
    public partial class AddUserForm : Form
    {
        List<string> Accounts;
        MonthCalendar mCalendar;

        public AddUserForm()
        {
            InitializeComponent();
            GetData();
            if(Session.UserType != UserType.Admin)
            {
                ComboboxType.Items.Clear();
                ComboboxType.Items.Add("Paciente");
            }
            AddAlgComboBox();
        }

        //Obtiene las cuentas de usuario ya en uso
        public void GetData()
        {
            try
            {
                Accounts = ReadUsersData(Session.DBConnection.GetAllUsersNameAccount());
            }
            catch(Exception e)
            {
                MessageBox.Show("Error al obtener los nombres de cuenta existentes. Consulte al administrador." + e.Message);
                this.Close();
            }
        }

        //Lee los datos de las cuentas obtenidas desde el servidor
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

        //Comprueba que todos los datos están introducidos y son correctos y agrega el usuario al entorno
        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtAccount.Text.Trim().Equals("") && !txtEmail.Text.Trim().Equals("") && !txtName.Text.Trim().Equals("") && !txtFApl.Text.Trim().Equals("") && !txtSApl.Text.Trim().Equals("") && !txtFNac.Text.Trim().Equals("") && !ComboboxType.Text.Trim().Equals(""))
                {
                    if (CheckEmailFormat(txtEmail.Text))
                    {
                        if (CheckAccountName(txtAccount.Text))
                        {
                            if (Session.DBConnection.InsertUserData(txtName.Text, txtFApl.Text, txtSApl.Text, DateTime.Parse(txtFNac.Text).ToString("yyyy-MM-dd"), ComboboxType.Text, txtAccount.Text, txtEmail.Text))
                            {
                                foreach (Control Ctemp in algContainer.Controls)
                                {
                                    if (Ctemp is AlgControl)
                                    {
                                        if (((AlgControl)Ctemp).GetText.Equals(""))
                                            continue;
                                        else
                                            Session.DBConnection.InsertAlg(txtAccount.Text, ((AlgControl)Ctemp).GetText);
                                    }
                                }
                                MessageBox.Show("Usuario insertado correctamente.");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Error al insertar el usuario");
                            }
                        }
                        else
                        {
                            MessageBox.Show("El nombre de usuario ya esta en uso, pruebe otro.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El formato del Email no es correcto.");
                    }
                }
                else
                {
                    MessageBox.Show("Se debe añadir valor a todos los campos.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al insertar el usuario");
            }
            
        }

        //Cierra el formulario
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Comprueba el nombre de cuenta que se está utilizando
        private bool CheckAccountName(string account)
        {
            if (Accounts.Contains(account))
                return false;
            else if (account.Equals(Session.Account))
                return false;
            else
                return true;
        }

        //Carga un calendario utilizado para seleccionar la fecha de nacimiento
        private void txtFNac_Click(object sender, EventArgs e)
        {
            mCalendar = new MonthCalendar()
            {
                Left = 150,
                Top = 160
            };
            mCalendar.MouseLeave += MCalendar_MouseLeave;
            mCalendar.DateSelected += MCalendar_DateSelected;
            mCalendar.Leave += MCalendar_Leave;
            this.Controls.Add(mCalendar);
            mCalendar.BringToFront();
            mCalendar.Focus();
            txtFNac.Enabled = false;

        }

        private void MCalendar_Leave(object sender, EventArgs e)
        {
            this.Controls.Remove(mCalendar);
            txtFNac.Enabled = true;
        }

        private void MCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtFNac.Enabled = true;
            txtFNac.Text = mCalendar.SelectionRange.Start.ToString("dd/MM/yyyy");
            try
            {
                DateTime Date = DateTime.Parse(txtFNac.Text);
                if (Date.Date > DateTime.Now.Date)
                    throw new Exception();
                else
                    if (DateTime.Now.Year - Date.Date.Year >= 200)
                    throw new Exception();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Fecha fuera de rango (Fecha actual como máximo).", "Error");
                txtFNac.Text = "";
            }
            this.Controls.Remove(mCalendar);
        }

        private void MCalendar_MouseLeave(object sender, EventArgs e)
        {
            this.Controls.Remove(mCalendar);
            txtFNac.Enabled = true;
        }

        //Carga un calendario utilizado para seleccionar la fecha de nacimiento
        private void txtFNac_Enter(object sender, EventArgs e)
        {
            mCalendar = new MonthCalendar()
            {
                Left = 300,
                Top = 160
            };
            mCalendar.MouseLeave += MCalendar_MouseLeave;
            mCalendar.DateSelected += MCalendar_DateSelected;
            mCalendar.Leave += MCalendar_Leave;
            this.Controls.Add(mCalendar);
            mCalendar.BringToFront();
            mCalendar.Focus();
            txtFNac.Enabled = false;
        }
        
        private void btnAddAlg_Click(object sender, EventArgs e)
        {
            AddAlgComboBox();
        }

        //Agrega un control de alergia a la lista
        private void AddAlgComboBox()
        {
            try
            {
                Session.MedList = ReadData(Session.DBConnection.GetAllMedicaments());
                List<string> MedNames = new List<string>();

                foreach (Medicament temp in Session.MedList)
                    MedNames.Add(temp.Nombre);

                foreach (Control Ctemp in algContainer.Controls)
                {
                    if (Ctemp is AlgControl)
                    {
                        if (((AlgControl)Ctemp).GetText.Equals(""))
                            return;
                        if (MedNames.Contains(((AlgControl)Ctemp).GetText))
                            MedNames.Remove(((AlgControl)Ctemp).GetText);
                    }
                }

                if (MedNames.Count > 0)
                    algContainer.Controls.Add(new AlgControl(MedNames.ToArray()));
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al obtener los datos de los medicamentos");
            }

        }

        //Lee los medicamentos del mensaje recibido por el servidor
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

        //Comprueba el formato del email del usuario
        private bool CheckEmailFormat(string email)
        {
            return Regex.IsMatch(email, @"\A(?:[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?\.)+[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?)\Z");
        }

        //Elimina un control de alergia de la lista
        private void btnDel_Click(object sender, EventArgs e)
        {
            if(algContainer.Controls.Count > 0)
            {
                algContainer.Controls.Remove(algContainer.Controls[algContainer.Controls.Count - 1]);
            }
        }
    }
}
