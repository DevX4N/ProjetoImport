namespace ProjetoImport
{
    partial class Menu
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.MCliente = new System.Windows.Forms.Button();
            this.MFornecedor = new System.Windows.Forms.Button();
            this.MEstoque = new System.Windows.Forms.Button();
            this.Clientes = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MCliente
            // 
            this.MCliente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MCliente.BackgroundImage")));
            this.MCliente.FlatAppearance.BorderSize = 0;
            this.MCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MCliente.Location = new System.Drawing.Point(23, 19);
            this.MCliente.Margin = new System.Windows.Forms.Padding(0);
            this.MCliente.Name = "MCliente";
            this.MCliente.Size = new System.Drawing.Size(50, 50);
            this.MCliente.TabIndex = 0;
            this.MCliente.UseVisualStyleBackColor = true;
            this.MCliente.Click += new System.EventHandler(this.MCliente_Click);
            // 
            // MFornecedor
            // 
            this.MFornecedor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MFornecedor.BackgroundImage")));
            this.MFornecedor.FlatAppearance.BorderSize = 0;
            this.MFornecedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MFornecedor.Location = new System.Drawing.Point(189, 19);
            this.MFornecedor.Name = "MFornecedor";
            this.MFornecedor.Size = new System.Drawing.Size(50, 50);
            this.MFornecedor.TabIndex = 1;
            this.MFornecedor.UseVisualStyleBackColor = true;
            this.MFornecedor.Click += new System.EventHandler(this.MFornecedor_Click);
            // 
            // MEstoque
            // 
            this.MEstoque.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MEstoque.BackgroundImage")));
            this.MEstoque.FlatAppearance.BorderSize = 0;
            this.MEstoque.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MEstoque.Location = new System.Drawing.Point(106, 19);
            this.MEstoque.Margin = new System.Windows.Forms.Padding(0);
            this.MEstoque.Name = "MEstoque";
            this.MEstoque.Size = new System.Drawing.Size(50, 50);
            this.MEstoque.TabIndex = 2;
            this.MEstoque.UseVisualStyleBackColor = true;
            this.MEstoque.Click += new System.EventHandler(this.MEstoque_Click);
            // 
            // Clientes
            // 
            this.Clientes.AutoSize = true;
            this.Clientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Clientes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Clientes.Location = new System.Drawing.Point(29, 80);
            this.Clientes.Margin = new System.Windows.Forms.Padding(0);
            this.Clientes.Name = "Clientes";
            this.Clientes.Size = new System.Drawing.Size(44, 13);
            this.Clientes.TabIndex = 3;
            this.Clientes.Text = "Clientes";
            this.Clientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(110, 80);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Estoque";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(186, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fornecedor";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 104);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Clientes);
            this.Controls.Add(this.MEstoque);
            this.Controls.Add(this.MFornecedor);
            this.Controls.Add(this.MCliente);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Menu SG Master ||";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.LocationChanged += new System.EventHandler(this.Menu_LocationChanged);
            this.Resize += new System.EventHandler(this.Menu_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MCliente;
        private System.Windows.Forms.Button MFornecedor;
        private System.Windows.Forms.Button MEstoque;
        private System.Windows.Forms.Label Clientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

