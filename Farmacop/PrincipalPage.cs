using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace Farmacop
{
    public partial class PrincipalPage : UserControl
    {
 
        public Thread listenerThread;
        ProfilePanel Profilepanel;
        MedPanel Medpanel;
        UsersPanel UserPanel;
        MessPanel MessagePanel;
        PrescriptionPanel RecPanel;
        public event MyDelegate ExitPressed;
        delegate void ChangeText(int value);
        int sleep = 10000;
        public int msgs = 0;

        public PrincipalPage()
        {
            InitializeComponent();
            Profilepanel = new ProfilePanel();
            Panel2Containt.Controls.Add(Profilepanel);
            listenerThread = new Thread(LookMsgs);
            listenerThread.Start();
        }

        public void LookMsgs()
        {
            while (true)
            {
                try
                {
                    JObject list = JObject.Parse(Session.DBConnection.GetNewMessages());
                    int count = list["data"].Count<JToken>();
                    SetTxt(count);
                }
                catch (Exception ex) { }
                Thread.Sleep(sleep);
            }
        }

        public void SetTxt(int msgs)
        {
            if (this.InvokeRequired) //preguntamos si la llamada se hace desde un hilo 
            {
                //si es así entonces volvemos a llamar a CambiarProgreso pero esta vez a través del delegado 
                //instanciamos el delegado indicandole el método que va a ejecutar 
                ChangeText delegado = new ChangeText(SetTxt);
                //ya que el delegado invocará a CambiarProgreso debemos indicarle los parámetros 
                object[] parametros = new object[] { msgs };
                //invocamos el método a través del mismo contexto del formulario (this) y enviamos los parámetros 
                this.Invoke(delegado, parametros);
            }
            else
            {
                if (msgs > 0)
                {
                    txtNumMsgs.Text = "" + msgs;
                    txtNumMsgs.Visible = true;
                }
                else
                {
                    txtNumMsgs.Visible = false;
                }
            }
            
        }

        #region Events
        private void PaginaPrincipal_SizeChanged(object sender, EventArgs e)
        {
            SplitPrincipal.Height = this.Height;
            SplitPrincipal.Width = this.Width;
            MenuPanel.Height = SplitPrincipal.Height;
            SplitContaint.Width = SplitPrincipal.Panel2.Width;
            TitlePanel.Width = SplitPrincipal.Panel2.Width;
            PanelTitle.Width = SplitPrincipal.Panel2.Width;
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Session.GettingData)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    switch (((Control)sender).Tag.ToString())
                    {
                        case "Profile":
                            lblTitle.Text = "Perfil";
                            Profilepanel = new ProfilePanel();
                            Panel2Containt.Controls.Clear();
                            Panel2Containt.Controls.Add(Profilepanel);
                            break;
                        case "Users":
                            lblTitle.Text = "Usuarios";
                            UserPanel = new UsersPanel();
                            Panel2Containt.Controls.Clear();
                            Panel2Containt.Controls.Add(UserPanel);
                            break;
                        case "Medic":
                            lblTitle.Text = "Medicamentos";
                            Medpanel = new MedPanel();
                            Panel2Containt.Controls.Clear();
                            Panel2Containt.Controls.Add(Medpanel);
                            break;
                        case "Recepies":
                            lblTitle.Text = "Recetas";
                            RecPanel = new PrescriptionPanel();
                            Panel2Containt.Controls.Clear();
                            Panel2Containt.Controls.Add(RecPanel);
                            break;
                        case "Messages":
                            lblTitle.Text = "Mensajes";
                            MessagePanel = new MessPanel();
                            Panel2Containt.Controls.Clear();
                            Panel2Containt.Controls.Add(MessagePanel);
                            txtNumMsgs.Visible = false;
                            break;
                        case "Logout":
                            //Mostrar mensaje y cerrar app si acepta
                            if (DialogResult.Yes == MessageBox.Show("¿Seguro que desea desconectar?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                            {
                                try
                                {
                                    listenerThread.Abort();
                                }
                                catch(Exception ex) { }
                                ExitPressed();
                            }
                            break;
                    }
                    Cursor.Current = Cursors.Default;
                }
            }
            catch(Exception ex)
            {
                Session.GettingData = false;
                MessageBox.Show(ex.Message);
            }
        }

        private void Menu_MouseEnter(object sender, EventArgs e)
        {
            ((FlowLayoutPanel)sender).BackColor = Color.White;

            switch (((FlowLayoutPanel)sender).Tag.ToString())
            {
                case "Profile":
                    lblProfile.ForeColor = Color.MediumBlue;
                    break;
                case "Users":
                    lblUsers.ForeColor = Color.MediumBlue;
                    break;
                case "Medic":
                    lblMedic.ForeColor = Color.MediumBlue;
                    break;
                case "Recepies":
                    lblRecepies.ForeColor = Color.MediumBlue;
                    break;
                case "Messages":
                    lblMessage.ForeColor = Color.MediumBlue;
                    break;
                case "Logout":
                    lblLogout.ForeColor = Color.MediumBlue;
                    break;
            }
            
        }

        private void Menu_MouseLeave(object sender, EventArgs e)
        {
                ((FlowLayoutPanel)sender).BackColor = Color.MediumBlue;
                switch (((FlowLayoutPanel)sender).Tag.ToString())
                {
                    case "Profile":
                        lblProfile.ForeColor = Color.White;
                        break;
                    case "Users":
                        lblUsers.ForeColor = Color.White;
                        break;
                    case "Medic":
                        lblMedic.ForeColor = Color.White;
                        break;
                    case "Recepies":
                        lblRecepies.ForeColor = Color.White;
                        break;
                    case "Messages":
                        lblMessage.ForeColor = Color.White;
                        break;
                    case "Logout":
                        lblLogout.ForeColor = Color.White;
                        break;
                }
        }

        private void lblMenu_MouseEnter(object sender, EventArgs e)
        {
            switch (((Label)sender).Tag.ToString())
            {
                case "Profile":
                    Menu1.BackColor = Color.White;
                    lblProfile.ForeColor = Color.MediumBlue;
                    break;
                case "Users":
                    Menu2.BackColor = Color.White;
                    lblUsers.ForeColor = Color.MediumBlue;
                    break;
                case "Medic":
                    Menu3.BackColor = Color.White;
                    lblMedic.ForeColor = Color.MediumBlue;
                    break;
                case "Recepies":
                    Menu4.BackColor = Color.White;
                    lblRecepies.ForeColor = Color.MediumBlue;
                    break;
                case "Messages":
                    Menu5.BackColor = Color.White;
                    lblMessage.ForeColor = Color.MediumBlue;
                    break;
                case "Logout":
                    Menu6.BackColor = Color.White;
                    lblLogout.ForeColor = Color.MediumBlue;
                    break;
            }
        }
        #endregion

        
    }
}
