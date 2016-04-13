namespace Farmacop
{
    partial class RecepiePanel
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
            ((System.ComponentModel.ISupportInitialize)(this.RecGridView)).BeginInit();
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
            this.RecGridView.Location = new System.Drawing.Point(23, 172);
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
            // RecepiePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RecGridView);
            this.Name = "RecepiePanel";
            this.Size = new System.Drawing.Size(1027, 639);
            ((System.ComponentModel.ISupportInitialize)(this.RecGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView RecGridView;
    }
}
