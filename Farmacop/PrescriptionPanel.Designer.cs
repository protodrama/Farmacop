namespace Farmacop
{
    partial class PrescriptionPanel
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
            this.RecGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMedicament = new System.Windows.Forms.TextBox();
            this.txtMedic = new System.Windows.Forms.TextBox();
            this.txtPatient = new System.Windows.Forms.TextBox();
            this.lblApl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.AddRecep = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RecGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RecGridView
            // 
            this.RecGridView.AllowUserToAddRows = false;
            this.RecGridView.AllowUserToDeleteRows = false;
            this.RecGridView.AllowUserToResizeRows = false;
            this.RecGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.RecGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RecGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.RecGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.RecGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RecGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.RecGridView.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.RecGridView.Location = new System.Drawing.Point(30, 169);
            this.RecGridView.MultiSelect = false;
            this.RecGridView.Name = "RecGridView";
            this.RecGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.RecGridView.RowHeadersVisible = false;
            this.RecGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.RecGridView.ShowEditingIcon = false;
            this.RecGridView.Size = new System.Drawing.Size(623, 335);
            this.RecGridView.TabIndex = 3;
            this.RecGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RecGridView_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMedicament);
            this.groupBox1.Controls.Add(this.txtMedic);
            this.groupBox1.Controls.Add(this.txtPatient);
            this.groupBox1.Controls.Add(this.lblApl);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnFilter);
            this.groupBox1.Location = new System.Drawing.Point(219, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(507, 132);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrar";
            // 
            // txtMedicament
            // 
            this.txtMedicament.Location = new System.Drawing.Point(106, 86);
            this.txtMedicament.Name = "txtMedicament";
            this.txtMedicament.Size = new System.Drawing.Size(232, 20);
            this.txtMedicament.TabIndex = 10;
            // 
            // txtMedic
            // 
            this.txtMedic.Location = new System.Drawing.Point(106, 56);
            this.txtMedic.Name = "txtMedic";
            this.txtMedic.Size = new System.Drawing.Size(232, 20);
            this.txtMedic.TabIndex = 9;
            // 
            // txtPatient
            // 
            this.txtPatient.Location = new System.Drawing.Point(106, 26);
            this.txtPatient.Name = "txtPatient";
            this.txtPatient.Size = new System.Drawing.Size(232, 20);
            this.txtPatient.TabIndex = 8;
            // 
            // lblApl
            // 
            this.lblApl.AutoSize = true;
            this.lblApl.Location = new System.Drawing.Point(26, 89);
            this.lblApl.Name = "lblApl";
            this.lblApl.Size = new System.Drawing.Size(74, 13);
            this.lblApl.TabIndex = 7;
            this.lblApl.Text = "Medicamento:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Medico:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Paciente:";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(389, 54);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 3;
            this.btnFilter.Text = "Aplicar filtro";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // AddRecep
            // 
            this.AddRecep.Location = new System.Drawing.Point(97, 59);
            this.AddRecep.Name = "AddRecep";
            this.AddRecep.Size = new System.Drawing.Size(75, 54);
            this.AddRecep.TabIndex = 5;
            this.AddRecep.Text = "Nueva receta";
            this.AddRecep.UseVisualStyleBackColor = true;
            this.AddRecep.Click += new System.EventHandler(this.AddRecep_Click);
            // 
            // RecepiePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AddRecep);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RecGridView);
            this.Name = "RecepiePanel";
            this.Size = new System.Drawing.Size(1027, 639);
            ((System.ComponentModel.ISupportInitialize)(this.RecGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView RecGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMedicament;
        private System.Windows.Forms.TextBox txtMedic;
        private System.Windows.Forms.TextBox txtPatient;
        private System.Windows.Forms.Label lblApl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button AddRecep;
    }
}
