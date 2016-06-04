using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Farmacop
{
    public partial class PrescriptionPanel : UserControl
    {
        List<Prescription> RecepiesShowing = new List<Prescription>();
        DataGridViewButtonColumn BtnModColumn;
        DataGridViewButtonColumn BtnShowColumn;
        DataGridViewButtonColumn BtnDeleteColumn;

        public PrescriptionPanel()
        {
            InitializeComponent();
            SetTableSize();
            GetData();
        }

        public void GetData()
        {
            RecGridView.DataSource = null;
            RecepiesShowing.Clear();
            try
            {
                Session.Recepies = ReadPrescData(Session.DBConnection.GetAllPrescriptions());
                RecepiesShowing.AddRange(Session.Recepies.ToArray());
                RecGridView.DataSource = RecepiesShowing;
            
                RecGridView.Columns.Remove(BtnModColumn);
                RecGridView.Columns.Remove(BtnShowColumn);
                RecGridView.Columns.Remove(BtnDeleteColumn);
                RecGridView.Width -= (80 * 3);
                BtnModColumn = null;
                BtnShowColumn = null;
                BtnDeleteColumn = null;
                SetTableSize();
            }
            catch(Exception e) {
                MessageBox.Show("Error al obtener los datos de las recetas.");
            }
        }

        public List<Prescription> ReadPrescData(string data)
        {
            List<Prescription> thelist = new List<Prescription>();
            JObject jobject = JObject.Parse(data);
            JToken jdata = jobject["data"];

            for (int i = 0; i < jdata.Count<JToken>(); i++)
            {
                Prescription ptemp = new Prescription(int.Parse(jdata[i]["ID"].ToString()), jdata[i]["Paciente"].ToString(), jdata[i]["Medico"].ToString(),
                    DateTime.Parse(jdata[i]["FechaInic"].ToString()).ToShortDateString(), DateTime.Parse(jdata[i]["FechaFin"].ToString()).ToShortDateString(),
                    jdata[i]["Medicamento"].ToString(), int.Parse(jdata[i]["Dosis"].ToString()));
                thelist.Add(ptemp);
            }

            return thelist;
        }

        public void SetTableSize()
        {
            BtnModColumn = new DataGridViewButtonColumn()
            {
                Name = "Modify",
                Width = 80,
                HeaderText = "Modificar",
                Text = "Modificar",
                UseColumnTextForButtonValue = true
            };
            

            BtnShowColumn = new DataGridViewButtonColumn()
            {
                Name = "Control",
                Width = 80,
                HeaderText = "Ver tomas",
                Text = "Ver",
                UseColumnTextForButtonValue = true
            };
            

            BtnDeleteColumn = new DataGridViewButtonColumn()
            {
                Name = "Delete",
                Width = 80,
                HeaderText = "Eliminar",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true
            };

            RecGridView.Columns.Add(BtnModColumn);
            RecGridView.Columns.Add(BtnShowColumn);
            RecGridView.Columns.Add(BtnDeleteColumn);
            RecGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            RecGridView.EnableHeadersVisualStyles = false;
            RecGridView.Width += (80 * 3);
            RecGridView.Left = (this.Width / 2) - (RecGridView.Width / 2);
        }

        private void RecGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (RecGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                Prescription recTemp = RecepiesShowing[e.RowIndex];
                if (RecGridView.Columns[e.ColumnIndex].Name.Equals("Modify"))
                {
                    //Modify
                    new ModPrescriptionForm(recTemp).ShowDialog();
                    GetData();
                }
                else
                {
                    if (RecGridView.Columns[e.ColumnIndex].Name.Equals("Control"))
                    {
                        //Control
                        new FormControls(recTemp).ShowDialog();
                        GetData();
                    }
                    else
                    {
                        //Delete
                        if(DialogResult.Yes == MessageBox.Show("¿Está seguro que desea eliminar la receta del paciente '" + recTemp.Paciente + "' con el medicamento " + recTemp.Medicamento + "?","Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Question))  
                        {
                            if (Session.DBConnection.DeleteRecepie(recTemp))
                            {
                                MessageBox.Show("Receta eliminada");
                                GetData();
                            }
                        }
                        
                    }
                }
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Recepies = ReadPrescData(Session.DBConnection.GetAllPrescriptions());
                List<Prescription> filtered = new List<Prescription>();

                foreach (Prescription temp in Session.Recepies)
                {
                    if (temp.Paciente.ToLower().Contains(txtPatient.Text.ToLower()) && temp.Medico.ToLower().Contains(txtMedic.Text.ToLower()) && temp.Medicamento.ToLower().Contains(txtMedicament.Text.ToLower()))
                    {
                        filtered.Add(temp);
                    }
                }

                RecGridView.DataSource = filtered;
                RecepiesShowing = filtered;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al obtener los datos de las recetas.");
            }
        }

        private void AddRecep_Click(object sender, EventArgs e)
        {
            new AddPrescription().ShowDialog();
            GetData();
        }
    }
}
