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
    //Formulario que permite la validación de una cuenta
    public partial class FormReg : Form
    {
        List<string> AccountsToActive;
        bool Correct = false; 

        public FormReg()
        {
            InitializeComponent();
        }

        //Cierra el formulario
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Obtiene los nombres de cuenta que se pueden utilizar
        private void FormReg_Load(object sender, EventArgs e)
        {
            try
            {
                Session.DBConnection = new DAO();
                
                AccountsToActive = ReadData(Session.DBConnection.GetNonActiveUserEMailForRegist());
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al comprobar cuentas");
            }
        }

        private void txtAccount_Leave(object sender, EventArgs e)
        {
            if (!txtAccount.Text.Equals(""))
            {
                CheckAccount(txtAccount.Text);
            }
            else
                lblEmailMsg.Text = "";
        }

        //Comprueba que la cuenta indicada es correcta
        public void CheckAccount(string account)
        {
            bool find = false;
            foreach(string EmtoActive in AccountsToActive)
            {
                if (account.Equals(EmtoActive))
                {
                    find = true;
                    break;
                }
            }

            if (find)
            {
                lblEmailMsg.ForeColor = Color.Green;
                lblEmailMsg.Text = "Nombre de cuenta correcto";
                ImgTick.Image = Farmacop.Properties.Resources.Tick_verde;
                Correct = true;
            }
            else
            {
                lblEmailMsg.ForeColor = Color.Red;
                lblEmailMsg.Text = "El nombre de cuenta no coincide";
                ImgTick.Image = Farmacop.Properties.Resources.Cruz;
                Correct = false;
            }

            try
            {
                AccountsToActive = ReadData(Session.DBConnection.GetNonActiveUserEMailForRegist());
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al comprobar cuentas");
                this.Close();
            }
        }

        //Comprueba que todo está correctamente insertado y valida la cuenta
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (Correct)
            {
                try
                {
                    Cursor.Current = Cursors.AppStarting;
                    if (!txtNewPass.Text.Trim().Equals("") && !txtNewPass2.Text.Trim().Equals(""))
                    {
                        if (txtNewPass.Text.Equals(txtNewPass2.Text))
                        {
                            if (Session.DBConnection.ActivateUserWithPass(txtAccount.Text, txtNewPass.Text))
                            {
                                Cursor.Current = Cursors.Default;
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
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("El nombre de cuenta debe ser correcto");
            
            Cursor.Current = Cursors.Default;
        }

        //Lee los datos de las cuentas recibidos desde el servidor
        public List<string> ReadData(string data)
        {
            List<string> usersdata = new List<string>();
            JObject jdata = JObject.Parse(data);
            JToken users = jdata["data"];

            for(int i = 0; i < users.Count<JToken>(); i++)
            {
                usersdata.Add(users[i]["Cuenta"].ToString());
            }

            return usersdata;
        }
    }
}
