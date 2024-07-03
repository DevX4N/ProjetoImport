namespace ProjetoImport
{
    partial class Estoque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Estoque));
            this.GEstoque = new System.Windows.Forms.DataGridView();
            this.EImports = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EsImportarStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.EsExportarStrip = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.GEstoque)).BeginInit();
            this.EImports.SuspendLayout();
            this.SuspendLayout();
            // 
            // GEstoque
            // 
            this.GEstoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GEstoque.Location = new System.Drawing.Point(12, 12);
            this.GEstoque.Name = "GEstoque";
            this.GEstoque.Size = new System.Drawing.Size(1007, 523);
            this.GEstoque.TabIndex = 11;
            // 
            // EImports
            // 
            this.EImports.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EsImportarStrip,
            this.EsExportarStrip});
            this.EImports.Name = "EImports";
            this.EImports.Size = new System.Drawing.Size(167, 48);
            // 
            // EsImportarStrip
            // 
            this.EsImportarStrip.Name = "EsImportarStrip";
            this.EsImportarStrip.Size = new System.Drawing.Size(166, 22);
            this.EsImportarStrip.Text = "Importar para .xls";
            // 
            // EsExportarStrip
            // 
            this.EsExportarStrip.Name = "EsExportarStrip";
            this.EsExportarStrip.Size = new System.Drawing.Size(166, 22);
            this.EsExportarStrip.Text = "Exportar para .xls";
            // 
            // Estoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 544);
            this.Controls.Add(this.GEstoque);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Estoque";
            this.Text = "Estoque";
            ((System.ComponentModel.ISupportInitialize)(this.GEstoque)).EndInit();
            this.EImports.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView GEstoque;
        private System.Windows.Forms.ContextMenuStrip EImports;
        private System.Windows.Forms.ToolStripMenuItem EsImportarStrip;
        private System.Windows.Forms.ToolStripMenuItem EsExportarStrip;
    }
}