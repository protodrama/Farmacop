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
    public partial class AlgControl : UserControl
    {
        public AlgControl(string[] data)
        {
            InitializeComponent();
            this.AlgComboBox.Items.AddRange(data);
        }

        public string Text { get { return AlgComboBox.Text; } }
    }
}
