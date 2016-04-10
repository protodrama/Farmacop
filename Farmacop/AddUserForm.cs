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
        List<string> Emails;
        MonthCalendar mCalendar;

        public AddUserForm()
        {
            InitializeComponent();
            GetData();
            if(Sesion.UserType != UserType.Admin)
            {
                ComboboxType.Items.Clear();
                ComboboxType.Items.Add("Paciente");
            }
        }

        public void GetData()
        {
            try
            {
                Emails = Sesion.DBConnection.GetAllUsersEmail();
            }
            catch(Exception e)
            {
                MessageBox.Show("Error al obtener los correos existentes. Consulte al administrador." + e.Message);
                this.Close();
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtEmail.Text.Equals("") && !txtName.Text.Equals("") && !txtFApl.Text.Equals("") && !txtSApl.Text.Equals("") && !txtFNac.Text.Equals("") && !ComboboxType.Text.Equals(""))
                {
                    if (CheckEmail(txtEmail.Text))
                    {
                        if (Sesion.DBConnection.InsertUserData(txtName.Text, txtFApl.Text, txtSApl.Text, DateTime.Parse(txtFNac.Text).ToString("yyyy-MM-dd"), ComboboxType.Text, txtEmail.Text))
                        {
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

        private bool CheckEmail(string email)
        {
            if (Emails.Contains(email))
                return false;
            else if (email.Equals(Sesion.Email))
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
    }
}
