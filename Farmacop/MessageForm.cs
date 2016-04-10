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
    public partial class MessageForm : Form
    {
        Message TMsg;

        public MessageForm()
        {
            InitializeComponent();
        }

        public MessageForm(Message TheMSG, bool IsSended)
        {
            InitializeComponent();
            if (IsSended)
            {
                this.Controls.Remove(btnAnsw);
                btnClose.Left = this.Width / 2 - btnClose.Width / 2;
            }
            TMsg = TheMSG;
            txtSender.Text = TMsg.Emisor;
            txtMatter.Text = TMsg.Asunto;
            txtMsg.Text = TMsg.Mensaje;
        }

        private void btnAnsw_Click(object sender, EventArgs e)
        {
            new NewMsgForm(TMsg.Emisor, TMsg.Asunto).ShowDialog();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
