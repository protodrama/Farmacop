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
    public partial class MedPanel : UserControl
    {
        DataGridViewButtonColumn BtnDeleteColumn;

        public MedPanel()
        {
            InitializeComponent();
            GetData();
            InicializeTable();
        }

        private void InicializeTable()
        {
            if(Sesion.UserType == UserType.Administrador)
            {
                BtnDeleteColumn = new DataGridViewButtonColumn()
                {
                    Name = "Delete",
                    Width = 80,
                    HeaderText = "Eliminar",
                    Text = "Eliminar"
                };
                MedTable.Columns.Add(BtnDeleteColumn);
                MedTable.Width += BtnDeleteColumn.Width;
                MedTable.Left -= BtnDeleteColumn.Width/2;
            }

        }

        private void GetData()
        {
            Sesion.MedList = Sesion.DBConnection.GetAllMedicaments();
            if (Sesion.MedList != null)
            {
                MedTable.DataSource = Sesion.MedList;
                List<string> names = new List<string>();
                foreach (Medicamento tmp in Sesion.MedList)
                    names.Add(tmp.Nombre);
                var source = new AutoCompleteStringCollection();
                source.AddRange(names.ToArray());
                txtbxMedAMod.AutoCompleteCustomSource = source;
                txtbxMedAMod.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //QUIERO QUE LAS PRIMERAS LETRAS ESTÉN SIEMPRE EN MAYÚSCULAS
            //StringBuilder Nombre = txtNewMedNm:
            //string Tipo;

            //if()
        }

        private void MedTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                Medicamento MedToDel = Sesion.MedList[e.RowIndex];

                if (DialogResult.Yes == MessageBox.Show("¿Seguro que quiere eliminar el medicamento?\nSe eliminará de forma permamente...", "Eliminar medicamento", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
                {
                    if (Sesion.DBConnection.DeleteMedicament(MedToDel.Nombre))
                    {
                        GetData();
                        MessageBox.Show("Medicamento eliminado correctamente");
                    }
                    else
                        MessageBox.Show("Error al eliminar el medicamento.");
                }
            }
        }
    }
}
