using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace Farmacop
{
    public partial class RecPassForm : Form
    {
        List<string> AccountsToActive;
        bool Correct = false;
        string accountandemail = "";

        public RecPassForm()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (Correct)
            {
                if (!accountandemail.Equals(""))
                {
                    try
                    {
                        int newPass = new Random().Next(999999);
                        string subject = "Recuperar contraseña";
                        string body = "Su nueva contraseña es " + newPass.ToString("000000");
                        string mailto = accountandemail.Split(':')[1];

                        Sesion.SendEmail(subject, body, mailto);
                        Sesion.DBConnection.UpdateUserPassWord(accountandemail.Split(':')[0], Sesion.StringToMD5(newPass.ToString("000000")));

                        MessageBox.Show("Se ha enviado un correo a su cuenta de correo con la nueva contraseña asignada.");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RecPassForm_Load(object sender, EventArgs e)
        {
            Sesion.DBConnection = new DAO();
            Sesion.Connect();
            AccountsToActive = Sesion.DBConnection.GetUserAccountAndEmailToRecPass();
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

        private void RecPassForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Sesion.Disconnect();
        }

        public void CheckAccount(string account)
        {
            bool find = false;
            foreach (string EmtoActive in AccountsToActive)
            {
                if (account.Equals(EmtoActive.Split(':')[0]))
                {
                    find = true;
                    accountandemail = EmtoActive;
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
                accountandemail = "";
                Correct = false;
            }

            AccountsToActive = Sesion.DBConnection.GetUserAccountAndEmailToRecPass();
        }
    }
}
