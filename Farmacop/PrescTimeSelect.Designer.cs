namespace Farmacop
{
    partial class PrescTimeSelect
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbbxHour = new System.Windows.Forms.ComboBox();
            this.cbbxMin = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbbxHour
            // 
            this.cbbxHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbxHour.FormattingEnabled = true;
            this.cbbxHour.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.cbbxHour.Location = new System.Drawing.Point(17, 3);
            this.cbbxHour.Name = "cbbxHour";
            this.cbbxHour.Size = new System.Drawing.Size(44, 21);
            this.cbbxHour.TabIndex = 0;
            // 
            // cbbxMin
            // 
            this.cbbxMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbxMin.FormattingEnabled = true;
            this.cbbxMin.Location = new System.Drawing.Point(79, 3);
            this.cbbxMin.Name = "cbbxMin";
            this.cbbxMin.Size = new System.Drawing.Size(44, 21);
            this.cbbxMin.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = ":";
            // 
            // RecepieTimeSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbxMin);
            this.Controls.Add(this.cbbxHour);
            this.Name = "RecepieTimeSelect";
            this.Size = new System.Drawing.Size(126, 33);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbxHour;
        private System.Windows.Forms.ComboBox cbbxMin;
        private System.Windows.Forms.Label label1;
    }
}
