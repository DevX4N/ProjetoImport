namespace ProjetoImport
{
    partial class Fornecedor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fornecedor));
            this.Gfornecedor = new System.Windows.Forms.DataGridView();
            this.FImports = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ForImportarStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.ForExportarStrip = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.Gfornecedor)).BeginInit();
            this.FImports.SuspendLayout();
            this.SuspendLayout();
            // 
            // Gfornecedor
            // 
            this.Gfornecedor.AllowUserToAddRows = false;
            this.Gfornecedor.AllowUserToDeleteRows = false;
            this.Gfornecedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Gfornecedor.Location = new System.Drawing.Point(12, 12);
            this.Gfornecedor.Name = "Gfornecedor";
            this.Gfornecedor.ReadOnly = true;
            this.Gfornecedor.Size = new System.Drawing.Size(873, 523);
            this.Gfornecedor.TabIndex = 4;
            // 
            // FImports
            // 
            this.FImports.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ForImportarStrip,
            this.ForExportarStrip});
            this.FImports.Name = "FImports";
            this.FImports.Size = new System.Drawing.Size(167, 48);
            // 
            // ForImportarStrip
            // 
            this.ForImportarStrip.Name = "ForImportarStrip";
            this.ForImportarStrip.Size = new System.Drawing.Size(166, 22);
            this.ForImportarStrip.Text = "Importar para .xls";
            // 
            // ForExportarStrip
            // 
            this.ForExportarStrip.Name = "ForExportarStrip";
            this.ForExportarStrip.Size = new System.Drawing.Size(166, 22);
            this.ForExportarStrip.Text = "Exportar para .xls";
            // 
            // Fornecedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 547);
            this.Controls.Add(this.Gfornecedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Fornecedor";
            this.Text = "Fornecedor";
            ((System.ComponentModel.ISupportInitialize)(this.Gfornecedor)).EndInit();
            this.FImports.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView Gfornecedor;
        private System.Windows.Forms.ContextMenuStrip FImports;
        private System.Windows.Forms.ToolStripMenuItem ForImportarStrip;
        private System.Windows.Forms.ToolStripMenuItem ForExportarStrip;
    }
}