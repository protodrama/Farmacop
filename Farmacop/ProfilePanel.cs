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
    }
}
