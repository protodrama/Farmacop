namespace Farmacop
{
    partial class ModRecepieForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.SplitContainer splAlg;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModRecepieForm));
            this.TimeContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddAlg = new System.Windows.Forms.Button();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnMod = new System.Windows.Forms.Button();
            this.GpxTime = new System.Windows.Forms.GroupBox();
            this.txtFEnd = new System.Windows.Forms.TextBox();
            this.txtFInic = new System.Windows.Forms.TextBox();
            this.txtDs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFInic = new System.Windows.Forms.Label();
            this.btnAddMed = new System.Windows.Forms.Button();
            this.cbbxMed = new System.Windows.Forms.ComboBox();
            this.lblMed = new System.Windows.Forms.Label();
            this.TimeDataGrid = new System.Windows.Forms.DataGridView();
            this.txtPatName = new System.Windows.Forms.Label();
            this.lblTableTittle = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            splAlg = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(splAlg)).BeginInit();
            splAlg.Panel1.SuspendLayout();
            splAlg.Panel2.SuspendLayout();
            splAlg.SuspendLayout();
            this.panel1.SuspendLayout();
            this.GpxTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // splAlg
            // 
            splAlg.Dock = System.Windows.Forms.DockStyle.Fill;
            splAlg.Location = new System.Drawing.Point(3, 16);
            splAlg.Margin = new System.Windows.Forms.Padding(0);
            splAlg.Name = "splAlg";
            splAlg.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splAlg.Panel1
            // 
            splAlg.Panel1.Controls.Add(this.TimeContainer);
            // 
            // splAlg.Panel2
            // 
            splAlg.Panel2.Controls.Add(this.panel1);
            splAlg.Size = new System.Drawing.Size(170, 176);
            splAlg.SplitterDistance = 136;
            splAlg.SplitterWidth = 1;
            splAlg.TabIndex = 0;
            // 
            // TimeContainer
            // 
            this.TimeContainer.AutoScroll = true;
            this.TimeContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.TimeContainer.Location = new System.Drawing.Point(3, 0);
            this.TimeContainer.Name = "TimeContainer";
            this.TimeContainer.Size = new System.Drawing.Size(164, 134);
            this.TimeContainer.TabIndex = 0;
            this.TimeContainer.WrapContents = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnAddAlg);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(170, 39);
            this.panel1.TabIndex = 0;
            // 
            // btnAddAlg
            // 
            this.btnAddAlg.Location = new System.Drawing.Point(3, 3);
            this.btnAddAlg.Name = "btnAddAlg";
            this.btnAddAlg.Size = new System.Drawing.Size(83, 23);
            this.btnAddAlg.TabIndex = 5;
            this.btnAddAlg.Text = "Agregar";
            this.btnAddAlg.UseVisualStyleBackColor = true;
            this.btnAddAlg.Click += new System.EventHandler(this.btnAddAlg_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(47, 33);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(95, 13);
            this.lblUserName.TabIndex = 7;
            this.lblUserName.Text = "Usuario destinado:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(354, 341);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnMod
            // 
            this.btnMod.Location = new System.Drawing.Point(200, 341);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(75, 23);
            this.btnMod.TabIndex = 6;
            this.btnMod.Text = "Modificar";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // GpxTime
            // 
            this.GpxTime.Controls.Add(splAlg);
            this.GpxTime.Location = new System.Drawing.Point(443, 141);
            this.GpxTime.Name = "GpxTime";
            this.GpxTime.Size = new System.Drawing.Size(176, 195);
            this.GpxTime.TabIndex = 58;
            this.GpxTime.TabStop = false;
            this.GpxTime.Text = "Nuevas horas";
            // 
            // txtFEnd
            // 
            this.txtFEnd.Location = new System.Drawing.Point(148, 206);
            this.txtFEnd.Name = "txtFEnd";
            this.txtFEnd.Size = new System.Drawing.Size(100, 20);
            this.txtFEnd.TabIndex = 4;
            this.txtFEnd.Enter += new System.EventHandler(this.txtFEnd_Enter);
            // 
            // txtFInic
            // 
            this.txtFInic.Enabled = false;
            this.txtFInic.Location = new System.Drawing.Point(148, 163);
            this.txtFInic.Name = "txtFInic";
            this.txtFInic.Size = new System.Drawing.Size(100, 20);
            this.txtFInic.TabIndex = 2;
            // 
            // txtDs
            // 
            this.txtDs.Location = new System.Drawing.Point(148, 121);
            this.txtDs.MaxLength = 1;
            this.txtDs.Name = "txtDs";
            this.txtDs.Size = new System.Drawing.Size(100, 20);
            this.txtDs.TabIndex = 55;
            this.txtDs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDs_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "Dosis (mg):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "Fecha de fin:";
            // 
            // lblFInic
            // 
            this.lblFInic.AutoSize = true;
            this.lblFInic.Location = new System.Drawing.Point(60, 166);
            this.lblFInic.Name = "lblFInic";
            this.lblFInic.Size = new System.Drawing.Size(82, 13);
            this.lblFInic.TabIndex = 52;
            this.lblFInic.Text = "Fecha de inicio:";
            // 
            // btnAddMed
            // 
            this.btnAddMed.Location = new System.Drawing.Point(275, 76);
            this.btnAddMed.Name = "btnAddMed";
            this.btnAddMed.Size = new System.Drawing.Size(124, 23);
            this.btnAddMed.TabIndex = 0;
            this.btnAddMed.Text = "Nuevo medicamento";
            this.btnAddMed.UseVisualStyleBackColor = true;
            this.btnAddMed.Click += new System.EventHandler(this.btnAddMed_Click);
            // 
            // cbbxMed
            // 
            this.cbbxMed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbxMed.FormattingEnabled = true;
            this.cbbxMed.Location = new System.Drawing.Point(148, 76);
            this.cbbxMed.Name = "cbbxMed";
            this.cbbxMed.Size = new System.Drawing.Size(121, 21);
            this.cbbxMed.TabIndex = 50;
            // 
            // lblMed
            // 
            this.lblMed.AutoSize = true;
            this.lblMed.Location = new System.Drawing.Point(68, 79);
            this.lblMed.Name = "lblMed";
            this.lblMed.Size = new System.Drawing.Size(74, 13);
            this.lblMed.TabIndex = 49;
            this.lblMed.Text = "Medicamento:";
            // 
            // TimeDataGrid
            // 
            this.TimeDataGrid.AllowUserToAddRows = false;
            this.TimeDataGrid.AllowUserToDeleteRows = false;
            this.TimeDataGrid.AllowUserToResizeRows = false;
            this.TimeDataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.TimeDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TimeDataGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.TimeDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.TimeDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TimeDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.TimeDataGrid.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.TimeDataGrid.Location = new System.Drawing.Point(428, 26);
            this.TimeDataGrid.MultiSelect = false;
            this.TimeDataGrid.Name = "TimeDataGrid";
            this.TimeDataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.TimeDataGrid.RowHeadersVisible = false;
            this.TimeDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.TimeDataGrid.ShowEditingIcon = false;
            this.TimeDataGrid.Size = new System.Drawing.Size(201, 111);
            this.TimeDataGrid.TabIndex = 59;
            this.TimeDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TimeDataGrid_CellContentClick);
            // 
            // txtPatName
            // 
            this.txtPatName.AutoSize = true;
            this.txtPatName.Location = new System.Drawing.Point(148, 33);
            this.txtPatName.Name = "txtPatName";
            this.txtPatName.Size = new System.Drawing.Size(16, 13);
            this.txtPatName.TabIndex = 60;
            this.txtPatName.Text = "...";
            // 
            // lblTableTittle
            // 
            this.lblTableTittle.AutoSize = true;
            this.lblTableTittle.Location = new System.Drawing.Point(446, 8);
            this.lblTableTittle.Name = "lblTableTittle";
            this.lblTableTittle.Size = new System.Drawing.Size(122, 13);
            this.lblTableTittle.TabIndex = 61;
            this.lblTableTittle.Text = "Horario de tomas actual:";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(86, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(81, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ModRecepieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 378);
            this.ControlBox = false;
            this.Controls.Add(this.lblTableTittle);
            this.Controls.Add(this.txtPatName);
            this.Controls.Add(this.TimeDataGrid);
            this.Controls.Add(this.GpxTime);
            this.Controls.Add(this.txtFEnd);
            this.Controls.Add(this.txtFInic);
            this.Controls.Add(this.txtDs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFInic);
            this.Controls.Add(this.btnAddMed);
            this.Controls.Add(this.cbbxMed);
            this.Controls.Add(this.lblMed);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnMod);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModRecepieForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modidicar receta";
            splAlg.Panel1.ResumeLayout(false);
            splAlg.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(splAlg)).EndInit();
            splAlg.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.GpxTime.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TimeDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnMod;
        private System.Windows.Forms.GroupBox GpxTime;
        private System.Windows.Forms.FlowLayoutPanel TimeContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddAlg;
        private System.Windows.Forms.TextBox txtFEnd;
        private System.Windows.Forms.TextBox txtFInic;
        private System.Windows.Forms.TextBox txtDs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFInic;
        private System.Windows.Forms.Button btnAddMed;
        private System.Windows.Forms.ComboBox cbbxMed;
        private System.Windows.Forms.Label lblMed;
        private System.Windows.Forms.DataGridView TimeDataGrid;
        private System.Windows.Forms.Label txtPatName;
        private System.Windows.Forms.Label lblTableTittle;
        private System.Windows.Forms.Button btnDelete;
    }
}