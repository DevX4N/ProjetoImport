namespace ProjetoImport
{
    partial class Clientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clientes));
            this.Gcliente = new System.Windows.Forms.DataGridView();
            this.Cimports = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CliImportarStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.CliExportarStrip = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.Gcliente)).BeginInit();
            this.Cimports.SuspendLayout();
            this.SuspendLayout();
            // 
            // Gcliente
            // 
            this.Gcliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Gcliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Gcliente.Location = new System.Drawing.Point(13, 12);
            this.Gcliente.Name = "Gcliente";
            this.Gcliente.Size = new System.Drawing.Size(945, 540);
            this.Gcliente.TabIndex = 15;
            // 
            // Cimports
            // 
            this.Cimports.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CliImportarStrip,
            this.CliExportarStrip});
            this.Cimports.Name = "Cimports";
            this.Cimports.Size = new System.Drawing.Size(167, 48);
            // 
            // CliImportarStrip
            // 
            this.CliImportarStrip.Name = "CliImportarStrip";
            this.CliImportarStrip.Size = new System.Drawing.Size(166, 22);
            this.CliImportarStrip.Text = "Importar para .xls";
            // 
            // CliExportarStrip
            // 
            this.CliExportarStrip.Name = "CliExportarStrip";
            this.CliExportarStrip.Size = new System.Drawing.Size(166, 22);
            this.CliExportarStrip.Text = "Exportar para .xls";
            this.CliExportarStrip.Click += new System.EventHandler(this.exportarParaxlsToolStripMenuItem_Click);
            // 
            // Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 564);
            this.Controls.Add(this.Gcliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Clientes";
            this.Text = "Clientes";
            ((System.ComponentModel.ISupportInitialize)(this.Gcliente)).EndInit();
            this.Cimports.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Gcliente;
        private System.Windows.Forms.ContextMenuStrip Cimports;
        private System.Windows.Forms.ToolStripMenuItem CliImportarStrip;
        private System.Windows.Forms.ToolStripMenuItem CliExportarStrip;
    }
}