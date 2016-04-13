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

        public RecepiePanel()
        {
            InitializeComponent();
            GetData();
        }

        public void GetData()
        {
            Sesion.Recepies = Sesion.DBConnection.GetAllRecepies();
            RecGridView.DataSource = Sesion.Recepies;

            DataGridViewButtonColumn BtnModColumn = new DataGridViewButtonColumn()
            {
                Name = "Modify",
                Width = 80,
                HeaderText = "Modificar",
                Text = "Modificar",
                UseColumnTextForButtonValue = true
            };
            RecGridView.Columns.Add(BtnModColumn);
            RecGridView.Width += BtnModColumn.Width;

            DataGridViewButtonColumn BtnShowColumn = new DataGridViewButtonColumn()
            {
                Name = "Control",
                Width = 80,
                HeaderText = "Ver tomas",
                Text = "Ver",
                UseColumnTextForButtonValue = true
            };
            RecGridView.Columns.Add(BtnShowColumn);
            RecGridView.Width += BtnShowColumn.Width;

            DataGridViewButtonColumn BtnDeleteColumn = new DataGridViewButtonColumn()
            {
                Name = "Delete",
                Width = 80,
                HeaderText = "Eliminar",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true
            };
            RecGridView.Columns.Add(BtnDeleteColumn);
            RecGridView.Width += BtnDeleteColumn.Width;

            RecGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            RecGridView.EnableHeadersVisualStyles = false;
            RecGridView.Left = (this.Width / 2) - (RecGridView.Width / 2);

        }

        private void RecGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
