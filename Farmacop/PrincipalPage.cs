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
    public partial class PrincipalPage : UserControl
    {
        ProfilePanel Profilepanel;
        MedPanel Medpanel;
        UsersPanel UserPanel;
        MessPanel MessagePanel;
        public event MyDelegate ExitPressed;

        public PrincipalPage()
        {
            InitializeComponent();
            Profilepanel = new ProfilePanel();
            Panel2Containt.Controls.Add(Profilepanel);
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
                    Panel2Containt.Controls.Clear();
                    break;
                case "Messages":
                    lblTitle.Text = "Mensajes";
                    MessagePanel = new MessPanel();
                    Panel2Containt.Controls.Clear();
                    Panel2Containt.Controls.Add(MessagePanel);
                    break;
                case "Logout":
                    //Mostrar mensaje y cerrar app si acepta
                    if(DialogResult.Yes == MessageBox.Show("¿Seguro que desea desconectar?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        ExitPressed();
                    }
                    break;
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
