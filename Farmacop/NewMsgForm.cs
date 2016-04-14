﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Farmacop
{
    public partial class NewMsgForm : Form
    {
        List<string> Emails;
        public NewMsgForm()
        {
            InitializeComponent();
            try
            {
                Emails = Sesion.DBConnection.GetAllUsersNameAccount();
                var source = new AutoCompleteStringCollection();
                source.AddRange(Emails.ToArray());
                txtReceiver.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtReceiver.AutoCompleteCustomSource = source;
                txtReceiver.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            catch(Exception e)
            {
                MessageBox.Show("Error al obtener los correos. Consulte al administrador");
                this.Close();
            }
        }

        public NewMsgForm(string Sender,string matter)
        {
            InitializeComponent();
            txtReceiver.Text = Sender;
            txtReceiver.ReadOnly = true;
            txtMatter.Text = matter;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (CheckEmail())
            {
                if (!txtMatter.Text.Trim().Equals("") && !txtMsg.Text.Trim().Equals("") && !txtReceiver.Text.Trim().Equals(""))
                {
                    if (Sesion.DBConnection.InsertMsg(Sesion.Account, txtReceiver.Text, txtMatter.Text, txtMsg.Text))
                    {
                        MessageBox.Show("Mensaje enviado con éxito.");
                        this.Close();
                    }
                    else
                        MessageBox.Show("Error al enviar....");
                }
                else
                    MessageBox.Show("Se deben rellenar todos los campos para enviar el mensaje");
            }
            else
                MessageBox.Show("El nombre de cuenta indicado no es correcto.");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtReceiver_Leave(object sender, EventArgs e)
        {
            if (!CheckEmail())
            {
                MessageBox.Show("El nombre de cuenta indicado no es correcto.");
            }
        }

        private bool CheckEmail()
        {
            if (txtReceiver.Text.Equals(""))
                return true;
            if (Emails != null)
            {
                if (!Emails.Contains(txtReceiver.Text))
                {
                    return false;
                }
                else
                    return true;
            }
            else
                return true;
        }
    }
}