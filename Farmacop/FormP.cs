using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using Newtonsoft.Json.Linq;

namespace Farmacop
{
    //Formulario contenedor de toda la aplicación
    public partial class FormP : Form
    {
        #region fields
        PrincipalPage PPage = null;
        FormReg FReg = null;
        bool logged = false;
        public event MyDelegate ExitPressed;
        #endregion

        #region Initialize
        public FormP()
        {
            InitializeComponent();
            CenterLoginContent();
            Session.DBConnection = new DAO();
            tbxPass.GotFocus += TbxPass_GotFocus;
        }


        //Posiciona los controles en el centro del formulario
        public void CenterLoginContent()
        {
            foreach(Control tmp in this.Controls)
                tmp.Location = new Point(this.Width / 2 - tmp.Width / 2,tmp.Location.Y);
        }
        #endregion

        #region Events
        //Comprobar credenciales
        private void btnConnect_Click(object sender, EventArgs e)
        {
            CheckLogin();
        }

        //Reorganiza los controles al cambiar de tamaño
        private void Formulario_Resize(object sender, EventArgs e)
        {
            if (!logged)
                CenterLoginContent();
            else {
                PPage.Height = this.Height;
                PPage.Width = this.Width;
            }
        }

        private void TbxPass_GotFocus(object sender, EventArgs e)
        {
            tbxPass.Text = "";
        }

        //Lanzar formulario de validación de cuenta
        private void lnkNewUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FReg = new FormReg();
            FReg.ShowDialog();
        }

        //Método que captura el evento de desconexión del usuario y lanza otro evento que será capturado por Program.cs
        private void PPage_ExitPressed()
        {
            ExitPressed();
        }
        #endregion

        #region Methods
        //Comprueba y obtiene los datos con las credenciales indicadas
        private void CheckLogin()
        {
            if (!tbxAccount.Text.Equals("") && !tbxPass.Text.Equals(""))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    JObject jobject = null;
                    try
                    {
                        jobject = JObject.Parse(Session.DBConnection.GetCredentials(tbxAccount.Text));
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error al conectar.");
                        return;
                    }
                    JToken dataObject;

                    dataObject = jobject["data"][0];
                    if (dataObject["Cuenta"].ToString() == "Paciente")
                    {
                        MessageBox.Show("El usuario o la contraseña no son correctos");
                        return;
                    }

                    if (tbxAccount.Text.Equals(dataObject["Cuenta"].ToString()))
                    {
                        if (CheckPassword(tbxPass.Text, dataObject["Contrasena"].ToString()))
                        {
                            Session.Apikey = dataObject["APIKEY"].ToString();
                            try
                            {
                                logged = true;
                                GetUserData(tbxAccount.Text);
                                this.Controls.Clear();
                                PPage = new PrincipalPage();
                                this.Controls.Add(PPage);
                                PPage.ExitPressed += PPage_ExitPressed;
                            }
                            catch (Exception e)
                            {
                                SystemSounds.Beep.Play();
                                MessageBox.Show(e.Message);
                                this.Close();
                            }
                        }
                        else
                            MessageBox.Show("El usuario o la contraseña no son correctos");
                    }
                    else
                        MessageBox.Show("El usuario o la contraseña no son correctos");


                }
                catch (Exception ex)
                {
                    SystemSounds.Beep.Play();
                    MessageBox.Show("El usuario o la contraseña no son correctos");
                    tbxAccount.Focus();
                }

            }
            else
            {
                SystemSounds.Beep.Play();
                if (tbxAccount.Text.Equals("") && tbxPass.Text.Equals(""))
                {
                    MessageBox.Show("Introduzca sus credenciales");
                    tbxAccount.Focus();
                }
                else if (tbxAccount.Text.Equals(""))
                {
                    MessageBox.Show("Indique su correo electrónico");
                    tbxAccount.Focus();
                }
                else if (tbxPass.Text.Equals(""))
                {
                    MessageBox.Show("Indique su contraseña");
                    tbxPass.Focus();
                }

            }
        }

        //Comprueba que la contraseña introducida es igual a la de la cuenta indicada
        private bool CheckPassword(string pass, string original)
        {
            string Cripto = Session.StringToMD5(pass);
            return Cripto.ToString().Equals(original);
        }

        //Obtiene los datos del usuario que se conecta
        private void GetUserData(string account)
        {
            JObject jobject = JObject.Parse(Session.DBConnection.GetUserData(account));
            JToken dataObject;
            try
            {
                dataObject = jobject["data"][0];
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los datos del usuario. Consulte con el administrador");
            }

            if (dataObject["Tipo"].ToString().Equals("Paciente"))
                throw new Exception("El usuario o la contraseña no son correctos");

            Session.Name = dataObject["Nombre"].ToString();
            Session.FirstSurname = dataObject["Apellido1"].ToString();
            Session.SecondSurname = dataObject["Apellido2"].ToString();
            Session.Account = dataObject["Cuenta"].ToString();
            Session.PassWord = dataObject["Contrasena"].ToString();
            Session.FNac = DateTime.Parse(dataObject["FechaNac"].ToString()).ToShortDateString();
            if (dataObject["Tipo"].ToString().Equals("Admin"))
                Session.UserType = UserType.Admin;
            else
                Session.UserType = UserType.Medico;
            Session.Email = dataObject["correo"].ToString();
        }

        #endregion
        
        //Para el hilo de la página principal que escucha los mensajes del usuario
        private void FormP_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                PPage.listenerThread.Abort();
            }catch(Exception ex) { }          
            
        }

        //Abre el formulario de recuperación de contraseña
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new RecPassForm().Show();
        }
    }
}
