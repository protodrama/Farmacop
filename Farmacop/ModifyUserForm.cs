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
                if (UserToMod.Tipo.Equals("Admin"))
                    ComboboxType.SelectedItem = "Admin";
                if(UserToMod.Tipo.Equals("Medico"))
                    ComboboxType.SelectedItem = "Medico";
                if (UserToMod.Tipo.Equals("Paciente"))
                    ComboboxType.SelectedItem = "Paciente";
                
            }
            catch (Exception e)
            {

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!txtName.Text.Equals("") && !txtFNac.Text.Equals("") && !txtFApl.Text.Equals("") && !txtSApl.Text.Equals(""))
            {
                if (Sesion.DBConnection.UpdateModUserData(txtName.Text, txtFApl.Text, txtSApl.Text, DateTime.Parse(txtFNac.Text).ToString("yyyy-MM-dd"), ComboboxType.SelectedItem.ToString(), UserToMod.Email))
                {
                    MessageBox.Show("Usuario modificado con éxito");
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben tener un valor");
            }
            this.Close();
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
    }
}
