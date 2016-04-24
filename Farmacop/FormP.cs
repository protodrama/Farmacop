using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;


namespace Farmacop
{
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
            Sesion.DBConnection = new DAO();
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

        private void lnkNewUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Lanzar formulario de modificación de contraseña cuando todo vaya ok
            FReg = new FormReg();
            FReg.ShowDialog();
        }

        private void PPage_ExitPressed()
        {
            ExitPressed();
        }
        #endregion

        #region Methods
        private void CheckLogin()
        {
            if (!tbxAccount.Text.Equals("") && !tbxPass.Text.Equals(""))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    if (Sesion.Connect())
                    {
                        try
                        {
                            string data = Sesion.DBConnection.GetCredentials(tbxAccount.Text);
                            if (data.Split(':')[2].Equals("Paciente"))
                                throw new Exception();
                            if (tbxAccount.Text.Equals(data.Split(':')[0])) {
                                if (CheckPassword(tbxPass.Text, data.Split(':')[1]))
                                {
                                    try {
                                        logged = true;
                                        GetUserData(tbxAccount.Text);
                                        this.Controls.Clear();
                                        PPage = new PrincipalPage();
                                        this.Controls.Add(PPage);
                                        //Sesion.DBConnection.UserConnect(Sesion.Account);
                                        PPage.ExitPressed += PPage_ExitPressed;
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
                            tbxAccount.Focus();
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

        private bool CheckPassword(string pass, string original)
        {
            string Cripto = Sesion.StringToMD5(pass);
            return Cripto.ToString().Equals(original);
        }

        private void GetUserData(string account)
        {
            try {
                string data = Sesion.DBConnection.GetUserData(account);
                string[] dataValues = data.Split(';');

                Sesion.Name = dataValues[0];
                Sesion.FirstSurname = dataValues[1];
                Sesion.SecondSurname = dataValues[2];
                Sesion.Account = dataValues[3];
                Sesion.PassWord = dataValues[4];
                Sesion.FNac = dataValues[5].Split(' ')[0].ToString();
                if (dataValues[6].Equals("Admin"))
                    Sesion.UserType = UserType.Admin;
                else
                    Sesion.UserType = UserType.Medico;
                Sesion.Email = dataValues[7];
            }
            catch(Exception e)
            {
                throw new Exception("Error al obtener los datos del usuario. Consulte con el administrador");
            }
        }

        #endregion

        private void FormP_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                PPage.listenerThread.Abort();
            }catch(Exception ex) { }
            if (Sesion.DBConnection.IsConnected)
            {
                Sesion.DBConnection.UserDisconnect(Sesion.Account);
                Sesion.DBConnection.Disconnect();
            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new RecPassForm().Show();
        }
    }
}
