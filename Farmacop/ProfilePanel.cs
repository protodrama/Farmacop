using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Farmacop
{
    public partial class ProfilePanel : UserControl
    {
        MonthCalendar mCalendar;

        public ProfilePanel()
        {
            InitializeComponent();
            Inicialize();
        }

        public void Inicialize()
        {
            lblName.Text = Sesion.Name;
            lblApl1.Text = Sesion.FirstSurname;
            lblApl2.Text = Sesion.SecondSurname;
            lblAccount.Text = Sesion.Account;
            lblFNac.Text = Sesion.FNac;
            if (Sesion.UserType == UserType.Admin)
                lblTUser.Text = "Admin";
            else
                lblTUser.Text = "Médico";
            txtEmail.Text = Sesion.Email;
        }

        private void btnModifyPass_Click(object sender, EventArgs e)
        {
            //Modify password if everything is ok
            try{
                if(!txtNewPass.Text.Equals("") && !txtNewPass2.Text.Equals("") && !txtOriginalPass.Text.Equals(""))
                {
                    if (Sesion.StringToMD5(txtOriginalPass.Text).Equals(Sesion.PassWord))
                    {
                        if (txtNewPass.Text.Equals(txtNewPass2.Text))
                        {
                            if (Sesion.DBConnection.UpdateUserPassWord(Sesion.Account, Sesion.StringToMD5(txtNewPass.Text)))
                                MessageBox.Show("Contraseña modificada con éxito");
                            else
                                throw new Exception("Error al modificar la contraseña");
                        }
                        else
                        {
                            throw new Exception("La nueva contraseña debe coincidir");
                        }
                    }
                    else
                    {
                        throw new Exception("La contraseña original no coincide");
                    }
                }
                else
                {
                    throw new Exception("Debes rellenar los tres campos");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                txtNewPass.Text = "";
                txtNewPass2.Text = "";
                txtOriginalPass.Text = "";
            }
        }

        private void btnModPData_Click(object sender, EventArgs e)
        {
            string Name, FApl, SApl, FNac, Email;

            if (txtbxName.Text.Trim().Equals(""))
                Name = Sesion.Name;
            else
                Name = txtbxName.Text;

            if (txtbxFApl.Text.Trim().Equals(""))
                FApl = Sesion.FirstSurname;
            else
                FApl = txtbxFApl.Text;

            if (txtbxSApl.Text.Trim().Equals(""))
                SApl = Sesion.SecondSurname;
            else
                SApl = txtbxSApl.Text;

            if (txtbxFNac.Text.Trim().Equals(""))
                FNac = DateTime.Parse(Sesion.FNac).ToString("yyyy-MM-dd");
            else
                FNac = DateTime.Parse(txtbxFNac.Text).ToString("yyyy-MM-dd");

            if (txtbxEmail.Text.Trim().Equals(""))
                Email = Sesion.Email;
            else
                Email = txtbxEmail.Text;

            if (!Name.Equals(Sesion.Name) || !FApl.Equals(Sesion.FirstSurname) || !SApl.Equals(Sesion.SecondSurname) || !FNac.Equals(DateTime.Parse(Sesion.FNac).ToString("yyyy-MM-dd")) || !Email.Equals(Sesion.Email))
            {
                if (Sesion.DBConnection.UpdateUserData(Name, FApl, SApl, FNac,Email, Sesion.Account))
                {
                    MessageBox.Show("Datos actualizados con éxito");
                    Sesion.Name = Name;
                    Sesion.FirstSurname = FApl;
                    Sesion.SecondSurname = SApl;
                    Sesion.FNac = DateTime.Parse(FNac).ToString("dd/MM/yyyy");
                    Sesion.Email = Email;
                    Inicialize();
                    txtbxFApl.Text = "";
                    txtbxFNac.Text = "";
                    txtbxName.Text = "";
                    txtbxSApl.Text = "";
                    txtbxEmail.Text = "";
                }
                else
                    MessageBox.Show("Error al actualizar los datos");
            }
        }

        private void MCalendar_MouseLeave(object sender, EventArgs e)
        {
            this.Controls.Remove(mCalendar);
            txtbxFNac.Enabled = true;
        }

        private void MCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtbxFNac.Enabled = true;
            txtbxFNac.Text = mCalendar.SelectionRange.Start.ToString("dd/MM/yyyy");
            try
            {
                DateTime Date = DateTime.Parse(txtbxFNac.Text);
                if (Date.Date > DateTime.Now.Date)
                    throw new Exception();
                else
                    if (DateTime.Now.Year - Date.Date.Year >= 200)
                    throw new Exception();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fecha fuera de rango (Fecha actual como máximo).", "Error");
                txtbxFNac.Text = "";
            }
            this.Controls.Remove(mCalendar);
        }

        private void txtbxFNac_Click(object sender, EventArgs e)
        {
            mCalendar = new MonthCalendar()
            {
                Left = 660,
                Top = 160
            };
            mCalendar.MouseLeave += MCalendar_MouseLeave;
            mCalendar.DateSelected += MCalendar_DateSelected;
            mCalendar.Leave += MCalendar_Leave;
            this.Controls.Add(mCalendar);
            mCalendar.BringToFront();
            mCalendar.Focus();
            txtbxFNac.Enabled = false;
        }

        private void MCalendar_Leave(object sender, EventArgs e)
        {
            this.Controls.Remove(mCalendar);
            txtbxFNac.Enabled = true;
        }

        private void txtbxFNac_Enter(object sender, EventArgs e)
        {
            mCalendar = new MonthCalendar()
            {
                Left = 660,
                Top = 160
            };
            mCalendar.MouseLeave += MCalendar_MouseLeave;
            mCalendar.DateSelected += MCalendar_DateSelected;
            mCalendar.Leave += MCalendar_Leave;
            this.Controls.Add(mCalendar);
            mCalendar.BringToFront();
            mCalendar.Focus();
            txtbxFNac.Enabled = false;
        }
    }
}
