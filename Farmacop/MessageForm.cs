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
    //Formulario que muestra el contenido de un mensaje

    public partial class MessageForm : Form
    {
        Message TMsg;

        public MessageForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor que recibe mensaje y si es recibido o enviado
        /// </summary>
        /// <param name="TheMSG">Mensaje a mostrar</param>
        /// <param name="IsSended">Si el mensaje es enviado por ti o recibido</param>
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

        //Abre el formulario de enviar mensaje para responder el mensaje que se muestra
        private void btnAnsw_Click(object sender, EventArgs e)
        {
            new NewMsgForm(TMsg.Emisor, TMsg.Asunto).ShowDialog();
            this.Close();
        }

        //Cierra el formulario
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
