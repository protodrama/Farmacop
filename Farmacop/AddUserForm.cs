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

        public void GetData()
        {
            try
            {
                Accounts = Session.DBConnection.GetAllUsersNameAccount();
            }
            catch(Exception e)
            {
                MessageBox.Show("Error al obtener los nombres de cuenta existentes. Consulte al administrador." + e.Message);
                this.Close();
            }
        }

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CheckAccountName(string account)
        {
            if (Accounts.Contains(account))
                return false;
            else if (account.Equals(Session.Account))
                return false;
            else
                return true;
        }

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

        private void AddAlgComboBox()
        {
            Session.MedList = Session.DBConnection.GetAllMedicaments();
            List<string> MedNames = new List<string>();

            foreach (Medicament temp in Session.MedList)
                MedNames.Add(temp.Nombre);

            foreach (Control Ctemp in algContainer.Controls)
            {
                if (Ctemp is AlgControl){
                    if (((AlgControl)Ctemp).GetText.Equals(""))
                        return;
                    if (MedNames.Contains(((AlgControl)Ctemp).GetText))
                        MedNames.Remove(((AlgControl)Ctemp).GetText);
                }
            }

            if(MedNames.Count > 0)
                algContainer.Controls.Add(new AlgControl(MedNames.ToArray()));

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

        private void btnDel_Click(object sender, EventArgs e)
        {
            if(algContainer.Controls.Count > 0)
            {
                algContainer.Controls.Remove(algContainer.Controls[algContainer.Controls.Count - 1]);
            }
        }
    }
}
