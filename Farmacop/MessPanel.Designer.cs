namespace Farmacop
{
    partial class MessPanel
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
            this.MessGridView = new System.Windows.Forms.DataGridView();
            this.chbxSended = new System.Windows.Forms.CheckBox();
            this.chbxReaded = new System.Windows.Forms.CheckBox();
            this.btnNewMsg = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MessGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MessGridView
            // 
            this.MessGridView.AllowUserToAddRows = false;
            this.MessGridView.AllowUserToDeleteRows = false;
            this.MessGridView.AllowUserToResizeColumns = false;
            this.MessGridView.AllowUserToResizeRows = false;
            this.MessGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.MessGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MessGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.MessGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.MessGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MessGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.MessGridView.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.MessGridView.Location = new System.Drawing.Point(239, 117);
            this.MessGridView.MultiSelect = false;
            this.MessGridView.Name = "MessGridView";
            this.MessGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.MessGridView.RowHeadersVisible = false;
            this.MessGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MessGridView.ShowEditingIcon = false;
            this.MessGridView.Size = new System.Drawing.Size(402, 335);
            this.MessGridView.TabIndex = 3;
            this.MessGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MessGridView_CellContentClick);
            // 
            // chbxSended
            // 
            this.chbxSended.AutoSize = true;
            this.chbxSended.Location = new System.Drawing.Point(179, 56);
            this.chbxSended.Name = "chbxSended";
            this.chbxSended.Size = new System.Drawing.Size(70, 17);
            this.chbxSended.TabIndex = 4;
            this.chbxSended.Text = "Enviados";
            this.chbxSended.UseVisualStyleBackColor = true;
            this.chbxSended.CheckedChanged += new System.EventHandler(this.chbxSended_CheckedChanged);
            // 
            // chbxReaded
            // 
            this.chbxReaded.AutoSize = true;
            this.chbxReaded.Location = new System.Drawing.Point(264, 56);
            this.chbxReaded.Name = "chbxReaded";
            this.chbxReaded.Size = new System.Drawing.Size(59, 17);
            this.chbxReaded.TabIndex = 5;
            this.chbxReaded.Text = "Leídos";
            this.chbxReaded.UseVisualStyleBackColor = true;
            this.chbxReaded.CheckedChanged += new System.EventHandler(this.chbxReaded_CheckedChanged);
            // 
            // btnNewMsg
            // 
            this.btnNewMsg.Location = new System.Drawing.Point(67, 52);
            this.btnNewMsg.Name = "btnNewMsg";
            this.btnNewMsg.Size = new System.Drawing.Size(75, 23);
            this.btnNewMsg.TabIndex = 6;
            this.btnNewMsg.Text = "Redactar";
            this.btnNewMsg.UseVisualStyleBackColor = true;
            this.btnNewMsg.Click += new System.EventHandler(this.btnNewMsg_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(117, 89);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(149, 13);
            this.lblInfo.TabIndex = 7;
            this.lblInfo.Text = "Mostrando mensajes recibidos";
            // 
            // MessPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnNewMsg);
            this.Controls.Add(this.chbxReaded);
            this.Controls.Add(this.chbxSended);
            this.Controls.Add(this.MessGridView);
            this.Name = "MessPanel";
            this.Size = new System.Drawing.Size(989, 800);
            ((System.ComponentModel.ISupportInitialize)(this.MessGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView MessGridView;
        private System.Windows.Forms.CheckBox chbxSended;
        private System.Windows.Forms.CheckBox chbxReaded;
        private System.Windows.Forms.Button btnNewMsg;
        private System.Windows.Forms.Label lblInfo;
    }
}
