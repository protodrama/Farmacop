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
    public partial class ProfilePanel : UserControl
    {
        public ProfilePanel()
        {
            InitializeComponent();
        }

        private void btnModifyPass_Click(object sender, EventArgs e)
        {
            //Modify password if everything is ok
            try{
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
