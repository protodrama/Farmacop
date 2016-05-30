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
    public partial class FormControls : Form
    {
        Prescription RecToShow;
        List<Taken> TakenShowing = new List<Taken>();

        public FormControls()
        {
            InitializeComponent();
        }

        public FormControls(Prescription recepie)
        {
            InitializeComponent();
            RecToShow = recepie;
            foreach(Taken temp in RecToShow.GetControl())
            {
                if (DateTime.Parse(temp.Fecha) <= DateTime.Now)
                    TakenShowing.Add(temp);
            }
            TakenGridView.DataSource = TakenShowing;
            txtPatient.Text = RecToShow.Paciente;
            txtMedic.Text = RecToShow.Medicamento;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            new NewMsgForm(RecToShow.Paciente, "").ShowDialog();
        }
    }
}
