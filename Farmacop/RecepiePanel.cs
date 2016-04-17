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
    public partial class RecepiePanel : UserControl
    {
        List<Recepie> RecepiesShowing = new List<Recepie>();
        DataGridViewButtonColumn BtnModColumn;
        DataGridViewButtonColumn BtnShowColumn;
        DataGridViewButtonColumn BtnDeleteColumn;

        public RecepiePanel()
        {
            InitializeComponent();
            SetTableSize();
            GetData();
        }

        public void GetData()
        {
            RecGridView.DataSource = null;
            RecepiesShowing.Clear();
            Sesion.Recepies = Sesion.DBConnection.GetAllRecepies();
            RecepiesShowing.AddRange(Sesion.Recepies.ToArray());
            RecGridView.DataSource = RecepiesShowing;
            try
            {
                RecGridView.Columns.Remove(BtnModColumn);
                RecGridView.Columns.Remove(BtnShowColumn);
                RecGridView.Columns.Remove(BtnDeleteColumn);
                RecGridView.Width -= (80 * 3);
                BtnModColumn = null;
                BtnShowColumn = null;
                BtnDeleteColumn = null;
                SetTableSize();
            }
            catch(Exception e) { }
            
            
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
                Recepie recTemp = RecepiesShowing[e.RowIndex];
                if (RecGridView.Columns[e.ColumnIndex].Name.Equals("Modify"))
                {
                    //ModifyForm = new ModifyUserForm(RecTemp);
                    //ModifyForm.ShowDialog();
                    
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
                            if (Sesion.DBConnection.DeleteRecepie(recTemp))
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
            Sesion.Recepies = Sesion.DBConnection.GetAllRecepies();
            List<Recepie> filtered = new List<Recepie>();

            foreach(Recepie temp in Sesion.Recepies)
            {
                if(temp.Paciente.ToLower().Contains(txtPatient.Text.ToLower()) && temp.Medico.ToLower().Contains(txtMedic.Text.ToLower()) && temp.Medicamento.ToLower().Contains(txtMedicament.Text.ToLower()))
                {
                    filtered.Add(temp);
                }
            }

            RecGridView.DataSource = filtered;
            RecepiesShowing = filtered;
        }

        private void AddRecep_Click(object sender, EventArgs e)
        {
            new AddRecepie().ShowDialog();
            GetData();
        }
    }
}
