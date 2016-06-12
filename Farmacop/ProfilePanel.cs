using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Farmacop
{
    //Este control es el encargado de permitir al usuario manejar los datos de su cuenta
    public partial class ProfilePanel : UserControl
    {
        MonthCalendar mCalendar;

        public ProfilePanel()
        {
            InitializeComponent();
            Inicialize();
        }

        //Muestra los datos de la sesión
        public void Inicialize()
        {
            lblName.Text = Session.Name;
            lblApl1.Text = Session.FirstSurname;
            lblApl2.Text = Session.SecondSurname;
            lblAccount.Text = Session.Account;
            lblFNac.Text = Session.FNac;
            if (Session.UserType == UserType.Admin)
                lblTUser.Text = "Admin";
            else
                lblTUser.Text = "Médico";
            txtEmail.Text = Session.Email;
        }
        
        //Comprueba y modifica la contraseña del usuario
        private void btnModifyPass_Click(object sender, EventArgs e)
        {
            //Modify password if everything is ok
            try{
                if(!txtNewPass.Text.Equals("") && !txtNewPass2.Text.Equals("") && !txtOriginalPass.Text.Equals(""))
                {
                    if (Session.StringToMD5(txtOriginalPass.Text).Equals(Session.PassWord))
                    {
                        if (!txtNewPass.Text.Equals(txtOriginalPass.Text))
                        {
                            if (txtNewPass.Text.Equals(txtNewPass2.Text))
                            {
                                if (Session.DBConnection.UpdateUserPassWord(Session.StringToMD5(txtNewPass.Text)))
                                {
                                    MessageBox.Show("Contraseña modificada con éxito");
                                    Session.PassWord = Session.StringToMD5(txtNewPass.Text);
                                }
                                else
                                    throw new Exception("Error al modificar la contraseña");
                            }
                            else
                            {
                                throw new Exception("La nueva contraseña debe coincidir");
                            }
                        }
                        else
                            throw new Exception("La nueva contraseña coincide con la actual");
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

        //Comprueba y modifica los datos de la cuenta
        private void btnModPData_Click(object sender, EventArgs e)
        {
            string Name, FApl, SApl, FNac, Email;   

            if (txtbxName.Text.Trim().Equals(""))
                Name = Session.Name;
            else
                Name = txtbxName.Text;

            if (txtbxFApl.Text.Trim().Equals(""))
                FApl = Session.FirstSurname;
            else
                FApl = txtbxFApl.Text;

            if (txtbxSApl.Text.Trim().Equals(""))
                SApl = Session.SecondSurname;
            else
                SApl = txtbxSApl.Text;

            if (txtbxFNac.Text.Trim().Equals(""))
                FNac = DateTime.Parse(Session.FNac).ToString("yyyy-MM-dd");
            else
                FNac = DateTime.Parse(txtbxFNac.Text).ToString("yyyy-MM-dd");

            if (txtbxEmail.Text.Trim().Equals(""))
                Email = Session.Email;
            else
                Email = txtbxEmail.Text;

            if (CheckEmailFormat(Email))
            {
                try
                {
                    if (!Name.Equals(Session.Name) || !FApl.Equals(Session.FirstSurname) || !SApl.Equals(Session.SecondSurname) || !FNac.Equals(DateTime.Parse(Session.FNac).ToString("yyyy-MM-dd")) || !Email.Equals(Session.Email))
                    {
                        if (Session.DBConnection.UpdateUserData(Name, FApl, SApl, FNac, Email))
                        {
                            MessageBox.Show("Datos actualizados con éxito");
                            Session.Name = Name;
                            Session.FirstSurname = FApl;
                            Session.SecondSurname = SApl;
                            Session.FNac = DateTime.Parse(FNac).ToString("dd/MM/yyyy");
                            Session.Email = Email;
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
                catch(Exception ex)
                {
                    MessageBox.Show("Error al actualizar los datos. Consulta tu conexión.");
                }
            }
            else
                MessageBox.Show("El formato del Email no es correcto.");
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

        //Muestra un calendario para facilitar la selección de la fecha de nacimiento
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

        //Muestra un calendario para facilitar la selección de la fecha de nacimiento
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

        //Comprueba el formato del correo que se utiliza
        private bool CheckEmailFormat(string email)
        {
            return Regex.IsMatch(email, @"\A(?:[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?\.)+[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?)\Z");
        }
    }
}
