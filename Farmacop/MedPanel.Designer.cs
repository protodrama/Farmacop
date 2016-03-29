namespace Farmacop
{
    partial class MedPanel
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
            this.grpbxAddM = new System.Windows.Forms.GroupBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.cbbxType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNewMedNm = new System.Windows.Forms.TextBox();
            this.grpbxModMed = new System.Windows.Forms.GroupBox();
            this.lblTypeMedMod = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtbxMedAMod = new System.Windows.Forms.TextBox();
            this.btnMod = new System.Windows.Forms.Button();
            this.cbbxTypeMod = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbxMedNewName = new System.Windows.Forms.TextBox();
            this.MedTable = new System.Windows.Forms.DataGridView();
            this.MedName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.grpbxAddM.SuspendLayout();
            this.grpbxModMed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MedTable)).BeginInit();
            this.SuspendLayout();
            // 
            // grpbxAddM
            // 
            this.grpbxAddM.Controls.Add(this.btnAgregar);
            this.grpbxAddM.Controls.Add(this.cbbxType);
            this.grpbxAddM.Controls.Add(this.label2);
            this.grpbxAddM.Controls.Add(this.label1);
            this.grpbxAddM.Controls.Add(this.txtNewMedNm);
            this.grpbxAddM.Location = new System.Drawing.Point(122, 32);
            this.grpbxAddM.Name = "grpbxAddM";
            this.grpbxAddM.Size = new System.Drawing.Size(612, 82);
            this.grpbxAddM.TabIndex = 0;
            this.grpbxAddM.TabStop = false;
            this.grpbxAddM.Text = "Agregar medicamento";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(493, 39);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // cbbxType
            // 
            this.cbbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbxType.FormattingEnabled = true;
            this.cbbxType.Items.AddRange(new object[] {
            "Analgésicos",
            "Ansiolíticos",
            "Antiácidos",
            "Antibióticos",
            "Anticoagulante",
            "Antidiarreicos",
            "Antigripales",
            "Antihistamínicos",
            "Antiinflamatorios",
            "Antimicóticos",
            "Antipiréticos",
            "Antisépticos",
            "Antitusivos",
            "Broncodilatadores",
            "Expectorantes",
            "Laxantes",
            "Mucolíticos"});
            this.cbbxType.Location = new System.Drawing.Point(321, 42);
            this.cbbxType.Name = "cbbxType";
            this.cbbxType.Size = new System.Drawing.Size(121, 21);
            this.cbbxType.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre del medicamento:";
            // 
            // txtNewMedNm
            // 
            this.txtNewMedNm.Location = new System.Drawing.Point(36, 42);
            this.txtNewMedNm.Name = "txtNewMedNm";
            this.txtNewMedNm.Size = new System.Drawing.Size(199, 20);
            this.txtNewMedNm.TabIndex = 0;
            // 
            // grpbxModMed
            // 
            this.grpbxModMed.Controls.Add(this.lblTypeMedMod);
            this.grpbxModMed.Controls.Add(this.label5);
            this.grpbxModMed.Controls.Add(this.label6);
            this.grpbxModMed.Controls.Add(this.txtbxMedAMod);
            this.grpbxModMed.Controls.Add(this.btnMod);
            this.grpbxModMed.Controls.Add(this.cbbxTypeMod);
            this.grpbxModMed.Controls.Add(this.label3);
            this.grpbxModMed.Controls.Add(this.label4);
            this.grpbxModMed.Controls.Add(this.txtbxMedNewName);
            this.grpbxModMed.Location = new System.Drawing.Point(122, 118);
            this.grpbxModMed.Name = "grpbxModMed";
            this.grpbxModMed.Size = new System.Drawing.Size(612, 144);
            this.grpbxModMed.TabIndex = 1;
            this.grpbxModMed.TabStop = false;
            this.grpbxModMed.Text = "Modificar medicamento";
            // 
            // lblTypeMedMod
            // 
            this.lblTypeMedMod.AutoSize = true;
            this.lblTypeMedMod.Location = new System.Drawing.Point(318, 44);
            this.lblTypeMedMod.Name = "lblTypeMedMod";
            this.lblTypeMedMod.Size = new System.Drawing.Size(16, 13);
            this.lblTypeMedMod.TabIndex = 13;
            this.lblTypeMedMod.Text = "...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(318, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Tipo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(184, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Nombre del medicamento a modificar:";
            // 
            // txtbxMedAMod
            // 
            this.txtbxMedAMod.Location = new System.Drawing.Point(36, 41);
            this.txtbxMedAMod.Name = "txtbxMedAMod";
            this.txtbxMedAMod.Size = new System.Drawing.Size(199, 20);
            this.txtbxMedAMod.TabIndex = 10;
            // 
            // btnMod
            // 
            this.btnMod.Location = new System.Drawing.Point(493, 65);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(75, 23);
            this.btnMod.TabIndex = 9;
            this.btnMod.Text = "Modificar";
            this.btnMod.UseVisualStyleBackColor = true;
            // 
            // cbbxTypeMod
            // 
            this.cbbxTypeMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbxTypeMod.FormattingEnabled = true;
            this.cbbxTypeMod.Items.AddRange(new object[] {
            "Analgésicos",
            "Ansiolíticos",
            "Antiácidos",
            "Antibióticos",
            "Anticoagulante",
            "Antidiarreicos",
            "Antigripales",
            "Antihistamínicos",
            "Antiinflamatorios",
            "Antimicóticos",
            "Antipiréticos",
            "Antisépticos",
            "Antitusivos",
            "Broncodilatadores",
            "Expectorantes",
            "Laxantes",
            "Mucolíticos"});
            this.cbbxTypeMod.Location = new System.Drawing.Point(321, 86);
            this.cbbxTypeMod.Name = "cbbxTypeMod";
            this.cbbxTypeMod.Size = new System.Drawing.Size(121, 21);
            this.cbbxTypeMod.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(318, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tipo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nombre del medicamento:";
            // 
            // txtbxMedNewName
            // 
            this.txtbxMedNewName.Location = new System.Drawing.Point(36, 86);
            this.txtbxMedNewName.Name = "txtbxMedNewName";
            this.txtbxMedNewName.Size = new System.Drawing.Size(199, 20);
            this.txtbxMedNewName.TabIndex = 5;
            // 
            // MedTable
            // 
            this.MedTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MedTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MedName,
            this.Type,
            this.Delete});
            this.MedTable.Location = new System.Drawing.Point(212, 303);
            this.MedTable.Name = "MedTable";
            this.MedTable.RowHeadersVisible = false;
            this.MedTable.Size = new System.Drawing.Size(424, 356);
            this.MedTable.TabIndex = 2;
            // 
            // MedName
            // 
            this.MedName.HeaderText = "Nombre";
            this.MedName.Name = "MedName";
            this.MedName.ReadOnly = true;
            this.MedName.Width = 200;
            // 
            // Type
            // 
            this.Type.HeaderText = "Tipo";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 120;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Eliminar";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            // 
            // MedPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MedTable);
            this.Controls.Add(this.grpbxModMed);
            this.Controls.Add(this.grpbxAddM);
            this.Name = "MedPanel";
            this.Size = new System.Drawing.Size(901, 662);
            this.grpbxAddM.ResumeLayout(false);
            this.grpbxAddM.PerformLayout();
            this.grpbxModMed.ResumeLayout(false);
            this.grpbxModMed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MedTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbxAddM;
        private System.Windows.Forms.TextBox txtNewMedNm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbxType;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.GroupBox grpbxModMed;
        private System.Windows.Forms.Button btnMod;
        private System.Windows.Forms.ComboBox cbbxTypeMod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbxMedNewName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtbxMedAMod;
        private System.Windows.Forms.Label lblTypeMedMod;
        private System.Windows.Forms.DataGridView MedTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn MedName;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
    }
}
