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
            lblEmail.Text = Sesion.Email;
            lblFNac.Text = Sesion.FNac;
            if (Sesion.UserType == UserType.Administrador)
                lblTUser.Text = "Admin";
            else
                lblTUser.Text = "Médico";
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
                            if (Sesion.DBConnection.UpdateUserPassWord(Sesion.Email, Sesion.StringToMD5(txtNewPass.Text)))
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

        private void txtbxFNac_KeyPress(object sender, KeyPressEventArgs e)
        {
            string allowed = "1234567890/\b";

            if (!allowed.Contains(e.KeyChar))
                e.Handled = true;
        }

        private void txtbxFNac_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtbxFNac.Text != "")
                {
                    DateTime Date = DateTime.Parse(txtbxFNac.Text);
                    if (Date.Date > DateTime.Now.Date)
                        throw new Exception();
                    else
                        if (DateTime.Now.Year - Date.Date.Year >= 100)
                        throw new Exception();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Fecha incorrecta. Introduzca una fecha válida con el formato DD/MM/YYYY","Error");
                txtbxFNac.Text = "";
                txtbxFNac.Focus();
            }
        }

        private void btnModPData_Click(object sender, EventArgs e)
        {
            string Name, FApl, SApl, FNac;

            if (txtbxName.Text.Equals(""))
                Name = Sesion.Name;
            else
                Name = txtbxName.Text;

            if (txtbxFApl.Text.Equals(""))
                FApl = Sesion.FirstSurname;
            else
                FApl = txtbxFApl.Text;

            if (txtbxSApl.Text.Equals(""))
                SApl = Sesion.SecondSurname;
            else
                SApl = txtbxSApl.Text;

            if (txtbxFNac.Text.Equals(""))
                FNac = DateTime.Parse(Sesion.FNac).ToString("yyyy-MM-dd");
            else
                FNac = DateTime.Parse(txtbxFNac.Text).ToString("yyyy-MM-dd");

            if (Sesion.DBConnection.UpdateUserData(Name, FApl, SApl, FNac, Sesion.Email))
            {
                MessageBox.Show("Datos actualizados con éxito");
                Sesion.Name = Name;
                Sesion.FirstSurname = FApl;
                Sesion.SecondSurname = SApl;
                Sesion.FNac = DateTime.Parse(FNac).ToString("dd/MM/yyyy"); ;
                Inicialize();
                txtbxFApl.Text = "";
                txtbxFNac.Text = "";
                txtbxName.Text = "";
                txtbxSApl.Text = "";
            }
            else
                MessageBox.Show("Error al actualizar los datos");
        }
    }
}
