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
        public PrincipalPage()
        {
            InitializeComponent();
        }

        #region Events
        private void PaginaPrincipal_SizeChanged(object sender, EventArgs e)
        {
            SplitPrincipal.Height = this.Height;
            SplitPrincipal.Width = this.Width;
            MenuPanel.Height = SplitPrincipal.Height;
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            switch (((FlowLayoutPanel)sender).Tag.ToString())
            {
                case "Profile":
                    break;
                case "Users":
                    break;
                case "Medic":
                    break;
                case "Recepies":
                    break;
                case "Control":
                    break;
                case "Logout":
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
                case "Control":
                    lblControl.ForeColor = Color.MediumBlue;
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
                    case "Control":
                        lblControl.ForeColor = Color.White;
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
                case "Control":
                    Menu5.BackColor = Color.White;
                    lblControl.ForeColor = Color.MediumBlue;
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
