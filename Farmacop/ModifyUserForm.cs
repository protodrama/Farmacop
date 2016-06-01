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
    public partial class ModifyUserForm : Form
    {
        User UserToMod;
        MonthCalendar MyCalendar;
        List<string> algDeleted = new List<string>();

        public ModifyUserForm()
        {
            InitializeComponent();
        }

        public ModifyUserForm(User userToMod)
        {
            InitializeComponent();
            try
            {
                this.UserToMod = userToMod;
                txtName.Text = UserToMod.Nombre;
                txtFApl.Text = UserToMod.GetFApl();
                txtSApl.Text = UserToMod.GetSApl();
                txtFNac.Text = UserToMod.Nacimiento;
                txtemail.Text = UserToMod.GetEmail();
                if (UserToMod.Tipo.Equals("Admin"))
                    ComboboxType.SelectedItem = "Admin";
                if(UserToMod.Tipo.Equals("Medico"))
                    ComboboxType.SelectedItem = "Medico";
                if (UserToMod.Tipo.Equals("Paciente"))
                    ComboboxType.SelectedItem = "Paciente";
                UserToMod.Alergias = ReadAlg(Session.DBConnection.GetUserAlg(UserToMod.Cuenta));
                AlgDataGrid.DataSource = UserToMod.GetAlgList();
                AlgDataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
                AlgDataGrid.EnableHeadersVisualStyles = false;
                DataGridViewButtonColumn BtnDeleteColumn = new DataGridViewButtonColumn()
                {
                    Name = "Delete",
                    HeaderText = "Eliminar",
                    Text = "Eliminar",
                    UseColumnTextForButtonValue = true
                };
                AlgDataGrid.Columns.Add(BtnDeleteColumn);
            }
            catch (Exception e) { }
        }

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtName.Text.Trim().Equals("") && !txtFNac.Text.Trim().Equals("") && !txtFApl.Text.Trim().Equals("") && !txtSApl.Text.Trim().Equals("") && !txtemail.Text.Trim().Equals(""))
                {
                    if (CheckEmailFormat(txtemail.Text))
                    {
                        this.Cursor = Cursors.AppStarting;
                        if (Session.DBConnection.UpdateModUserData(txtName.Text, txtFApl.Text, txtSApl.Text, DateTime.Parse(txtFNac.Text).ToString("yyyy-MM-dd"), ComboboxType.SelectedItem.ToString(), UserToMod.Cuenta, txtemail.Text))
                        {
                            if (algDeleted.Count > 0)
                            {
                                foreach (string alg in algDeleted)
                                    Session.DBConnection.DeleteAlg(UserToMod.Cuenta, alg);
                            }
                            foreach (Control Ctemp in algContainer.Controls)
                            {
                                if (Ctemp is AlgControl)
                                {
                                    if (((AlgControl)Ctemp).GetText.Equals(""))
                                        continue;
                                    else
                                        Session.DBConnection.InsertAlg(UserToMod.Cuenta, ((AlgControl)Ctemp).GetText);
                                }
                            }
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Usuario modificado con éxito");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Error al actualizar usuario");
                            this.Cursor = Cursors.Default;
                        }
                    }
                    else
                        MessageBox.Show("El formato del Email no es correcto");
                }
                else
                {
                    MessageBox.Show("Todos los campos deben tener un valor");
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Error al modificar el usuario");
            }
        }

        private void txtFNac_Click(object sender, EventArgs e)
        {
            MyCalendar = new MonthCalendar()
            {
                Left = 330,
                Top = 110
            };
            MyCalendar.MouseLeave += MyCalendar_MouseLeave;
            MyCalendar.DateSelected += MyCalendar_DateSelected;
            MyCalendar.Leave += MyCalendar_Leave;
            this.Controls.Add(MyCalendar);
            MyCalendar.BringToFront();
            MyCalendar.Focus();
            txtFNac.Enabled = false;
        }

        private void MyCalendar_Leave(object sender, EventArgs e)
        {
            this.Controls.Remove(MyCalendar);
            txtFNac.Enabled = true;
        }

        private void MyCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtFNac.Enabled = true;
            txtFNac.Text = MyCalendar.SelectionRange.Start.ToString("dd/MM/yyyy");
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
                txtFNac.Text = UserToMod.Nacimiento;
            }
            this.Controls.Remove(MyCalendar);
        }

        private void MyCalendar_MouseLeave(object sender, EventArgs e)
        {
            this.Controls.Remove(MyCalendar);
            txtFNac.Enabled = true;
        }

        private void txtFNac_Enter(object sender, EventArgs e)
        {
            MyCalendar = new MonthCalendar()
            {
                Left = 330,
                Top = 110
            };
            MyCalendar.MouseLeave += MyCalendar_MouseLeave;
            MyCalendar.DateSelected += MyCalendar_DateSelected;
            MyCalendar.Leave += MyCalendar_Leave;
            this.Controls.Add(MyCalendar);
            MyCalendar.BringToFront();
            MyCalendar.Focus();
            txtFNac.Enabled = false;
        }

        private void AddAlgComboBox()
        {
            try
            {
                Session.MedList = ReadData(Session.DBConnection.GetAllMedicaments());
                List<string> MedNames = new List<string>();

                foreach (Medicament temp in Session.MedList)
                    if (!UserToMod.Alergias.Contains(temp.Nombre))
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

                algContainer.Controls.Add(new AlgControl(MedNames.ToArray()));
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al obtener los datos de los medicamentos");
            }
        }

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


        private void btnAddAlg_Click(object sender, EventArgs e)
        {
            AddAlgComboBox();
        }

        private void AlgDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (AlgDataGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if(DialogResult.Yes == MessageBox.Show("¿Desea eliminar la alergia del usuario?","Eliminando", MessageBoxButtons.YesNo,MessageBoxIcon.Question))
                {
                    algDeleted.Add(UserToMod.Alergias[e.RowIndex]);
                    UserToMod.Alergias.Remove(UserToMod.Alergias[e.RowIndex]);
                    AlgDataGrid.DataSource = UserToMod.GetAlgList();
                }
            }
        }

        private bool CheckEmailFormat(string email)
        {
            if (email.Contains("@") && !email.Contains(" "))
            {
                string[] data = email.Split('@');
                foreach (string tmp in data)
                    if (tmp.Trim().Equals(""))
                        return false;
                return true;
            }
            else
                return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(algContainer.Controls.Count > 0)
            {
                algContainer.Controls.Remove(algContainer.Controls[algContainer.Controls.Count - 1]);
            }
        }
    }
}
