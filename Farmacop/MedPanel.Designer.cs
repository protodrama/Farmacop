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
            this.btnReload = new System.Windows.Forms.Button();
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
            this.btnAgregar.TabIndex = 2;
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
            this.cbbxType.TabIndex = 1;
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
            this.txtbxMedAMod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtbxMedAMod.Location = new System.Drawing.Point(36, 41);
            this.txtbxMedAMod.Name = "txtbxMedAMod";
            this.txtbxMedAMod.Size = new System.Drawing.Size(199, 20);
            this.txtbxMedAMod.TabIndex = 3;
            this.txtbxMedAMod.TextChanged += new System.EventHandler(this.txtbxMedAMod_TextChanged);
            // 
            // btnMod
            // 
            this.btnMod.Location = new System.Drawing.Point(493, 65);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(75, 23);
            this.btnMod.TabIndex = 6;
            this.btnMod.Text = "Modificar";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
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
            this.cbbxTypeMod.TabIndex = 5;
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
            this.txtbxMedNewName.TabIndex = 4;
            // 
            // MedTable
            // 
            this.MedTable.AllowUserToAddRows = false;
            this.MedTable.AllowUserToDeleteRows = false;
            this.MedTable.AllowUserToResizeColumns = false;
            this.MedTable.AllowUserToResizeRows = false;
            this.MedTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.MedTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MedTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MedTable.Location = new System.Drawing.Point(309, 268);
            this.MedTable.Name = "MedTable";
            this.MedTable.RowHeadersVisible = false;
            this.MedTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MedTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MedTable.ShowEditingIcon = false;
            this.MedTable.Size = new System.Drawing.Size(203, 356);
            this.MedTable.TabIndex = 7;
            this.MedTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MedTable_CellContentClick);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(351, 630);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(105, 23);
            this.btnReload.TabIndex = 8;
            this.btnReload.Text = "Actualizar tabla";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // MedPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReload);
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
        private System.Windows.Forms.Button btnReload;
    }
}
