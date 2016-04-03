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
    public partial class FormReg : Form
    {
        List<string> EmailsToActive;
        bool Correct = false; 

        public FormReg()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormReg_Load(object sender, EventArgs e)
        {
            Sesion.DBConnection = new DAO();
            Sesion.Connect();
            EmailsToActive = Sesion.DBConnection.GetNonActiveUserEMailForRegist();
        }

        private void FormReg_FormClosing(object sender, FormClosingEventArgs e)
        {
            Sesion.Disconnect();
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (!txtEmail.Text.Equals(""))
            {
                CheckEmail(txtEmail.Text);
            }
            else
                lblEmailMsg.Text = "";
        }

        public void CheckEmail(string email)
        {
            bool find = false;
            foreach(string EmtoActive in EmailsToActive)
            {
                if (email.Equals(EmtoActive))
                {
                    find = true;
                    break;
                }
            }

            if (find)
            {
                lblEmailMsg.ForeColor = Color.Green;
                lblEmailMsg.Text = "Correo correcto";
                ImgTick.Image = Farmacop.Properties.Resources.Tick_verde;
                Correct = true;
            }
            else
            {
                lblEmailMsg.ForeColor = Color.Red;
                lblEmailMsg.Text = "El correo no coincide";
                ImgTick.Image = Farmacop.Properties.Resources.Cruz;
                Correct = false;
            }

            EmailsToActive = Sesion.DBConnection.GetNonActiveUserEMailForRegist();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (Correct)
            {
                if (!txtNewPass.Text.Equals("") && !txtNewPass2.Equals(""))
                {
                    if (txtNewPass.Text.Equals(txtNewPass2.Text))
                    {
                        if (Sesion.DBConnection.ActivateUserWithPass(txtEmail.Text, txtNewPass.Text))
                        {
                            MessageBox.Show("Cuenta activada con éxito");
                            this.Close();
                        }
                        else
                            MessageBox.Show("Error al activar la cuenta");
                    }
                    else
                        MessageBox.Show("Las contraseñas no coinciden");
                }
                else
                    MessageBox.Show("Introduzca todos los datos");
            }
            else
                MessageBox.Show("El correo debe ser correcto");
        }
    }
}
