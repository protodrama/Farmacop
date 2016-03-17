using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Security.Cryptography;

namespace Farmacop
{
    
    public partial class Form : System.Windows.Forms.Form
    {
        #region fields
        PrincipalPage PPage = null;
        public static string HOST = "jfrodriguez.pw";
        public static string DB = "FarmacopDB";
        public static string USER = "clientuser";
        public static string PASS = "hx3CfFQFdrRJVRsd";
        bool logged = false;
        DAO DBConection;     //Conector a la base de datos
        #endregion

        #region Initialize
        public Form()
        {
            InitializeComponent();
            CenterLoginContent();
            DBConection = new DAO();
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
        #endregion

        #region Methods
        private void CheckLogin()
        {
            if (!tbxEmail.Text.Equals("") && !tbxPass.Text.Equals(""))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    if (DBConection.Conectar(HOST, DB, USER, PASS))
                    {
                        try
                        {
                            string data = DBConection.GetCredentials(tbxEmail.Text);
                            if (data.Split(':')[2].Equals("Paciente"))
                                throw new Exception();
                            if (tbxEmail.Text.Equals(data.Split(':')[0])) {
                                if (CheckPassword(tbxPass.Text, data.Split(':')[1]))
                                {
                                    try {
                                        logged = true;
                                        this.Controls.Clear();
                                        PPage = new PrincipalPage();
                                        this.Controls.Add(PPage);
                                    }
                                    catch(Exception e)
                                    {
                                        SystemSounds.Beep.Play();
                                        MessageBox.Show(e.Message);
                                        this.Close();
                                    }
                                }
                                else
                                    throw new Exception();
                            }
                            else
                                throw new Exception();
                        }
                        catch(Exception ex)
                        {
                            SystemSounds.Beep.Play();
                            MessageBox.Show("El usuario o la contraseña no son correctos");
                            tbxEmail.Focus();
                        }
                    }

                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    SystemSounds.Beep.Play();
                    MessageBox.Show(ex.Number + ": " + ex.Message);
                }
            }
            else
            {
                SystemSounds.Beep.Play();
                if (tbxEmail.Text.Equals("") && tbxPass.Text.Equals(""))
                {
                    MessageBox.Show("Introduzca sus credenciales");
                    tbxEmail.Focus();
                }
                else if (tbxEmail.Text.Equals(""))
                {
                    MessageBox.Show("Indique su correo electrónico");
                    tbxEmail.Focus();
                }
                else if (tbxPass.Text.Equals(""))
                {
                    MessageBox.Show("Indique su contraseña");
                    tbxPass.Focus();
                }

            }
        }

        private bool CheckPassword(string clave, string original)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] TextoEnBytes = Encoding.UTF8.GetBytes(clave);

            byte[] CriptogramaBytes = md5.ComputeHash(TextoEnBytes);
            StringBuilder Criptograma = new StringBuilder();

            for (int i = 0; i < CriptogramaBytes.Length; i++)
            {
                Criptograma.Append(CriptogramaBytes[i].ToString("x2"));
            }

            return Criptograma.ToString().Equals(original);
        }

        private void GetUserData(string email)
        {
            try {
                string data = DBConection.GetUserData(email);
                string[] dataValues = data.Split(':');

                Sesion.Name = dataValues[0];
                Sesion.FirstSurname = dataValues[1];
                Sesion.SecondSurname = dataValues[2];
                Sesion.Email = dataValues[3];
                Sesion.PassWord = dataValues[4];
                if (dataValues[5].Equals("Admin"))
                    Sesion.UserType = UserType.Administrador;
                else
                    Sesion.UserType = UserType.Medico;
            }
            catch(Exception e)
            {
                throw new Exception("Error al obtener los datos del usuario. Consulte con el administrador");
            }
        }
        #endregion
    }
}
