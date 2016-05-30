using Newtonsoft.Json.Linq;
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
        string account = "";

        public RecPassForm()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (Correct)
            {
                if (!account.Equals(""))
                {
                    try
                    {
                        int newPass = new Random().Next(999999);

                        if (Session.DBConnection.RecPass(account, newPass))
                        {
                            MessageBox.Show("Se ha enviado un correo a su cuenta de correo con la nueva contraseña asignada.");
                            this.Close();
                        }
                        else
                            MessageBox.Show("Error al realizar la operación de recuperación de cuenta");
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
            Session.DBConnection = new DAO();
            try
            {
                AccountsToActive = getData(Session.DBConnection.GetUserAccountToRecPass());
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al obtener las cuentas");
            }
        }

        public List<string> getData(string data)
        {
            JObject jdata = JObject.Parse(data);
            JToken jobt = jdata["data"];
            List<string> names = new List<string>();
            for(int i = 0; i < jobt.Count<JToken>(); i++)
            {
                JToken temp = jobt[i];
                names.Add(temp["Cuenta"].ToString());
            }

            return names;
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

        public void CheckAccount(string account)
        {
            this.Cursor = Cursors.AppStarting;
            bool find = false;
            foreach (string EmtoActive in AccountsToActive)
            {
                if (account.Equals(EmtoActive))
                {
                    find = true;
                    this.account = EmtoActive;
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
                this.account = "";
                Correct = false;
            }

            try
            {
                AccountsToActive = getData(Session.DBConnection.GetUserAccountToRecPass());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener las cuentas");
            }
            this.Cursor = Cursors.Default;
        }
    }
}
