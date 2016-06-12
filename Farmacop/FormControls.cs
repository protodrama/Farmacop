using Newtonsoft.Json.Linq;
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
    //Este formulario se utiliza para mostrar la lista de tomas hasta el día de hoy de una receta
    public partial class FormControls : Form
    {
        Prescription RecToShow;
        List<RecControl> TakenShowing = new List<RecControl>();

        public FormControls()
        {
            InitializeComponent();
        }

        //Constructor que recibe la receta a mostrar
        public FormControls(Prescription recepie)
        {
            InitializeComponent();
            try
            {
                RecToShow = recepie;
                txtPatient.Text = RecToShow.Paciente;
                txtMedic.Text = RecToShow.Medicamento + " " + RecToShow.Dosis + " mg";
                RecToShow.SetRControl(ReadControlData(Session.DBConnection.GetAllRecControl(RecToShow.getId())));
                TakenGridView.DataSource = RecToShow.GetControl();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al obtener el horario de tomas.");
            }
        }

        //Lee los datos de controles recibidos desde el servidor
        public List<RecControl> ReadControlData(string data)
        {
            List<RecControl> thelist = new List<RecControl>();
            JObject jobject = JObject.Parse(data);
            JToken jdata = jobject["data"];

            for (int i = 0; i < jdata.Count<JToken>(); i++)
            {
                RecControl rtemp = new RecControl(DateTime.Parse(jdata[i]["Fecha"].ToString()).ToShortDateString(), int.Parse(jdata[i]["Hora"].ToString()).ToString("00") + ":"
                    + int.Parse(jdata[i]["Minuto"].ToString()).ToString("00"), int.Parse(jdata[i]["Tomada"].ToString()) == 1);
                thelist.Add(rtemp);
            }

            return thelist;
        }

        //Cierra el formulario
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Permite mandar un mensaje al paciente de la receta
        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            new NewMsgForm(RecToShow.Paciente, "").ShowDialog();
        }
    }
}
