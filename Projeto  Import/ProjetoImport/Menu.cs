using FirebirdSql.Data.FirebirdClient;
using Microsoft.Win32;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;


namespace ProjetoImport
{
    public partial class Menu : Form
    {
        public string connectionString;
        private Form currentChildForm; // Referência ao formulário filho atualmente aberto
       
       


        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeft, int nTop, int nRigth, int nBottom, int nWidthEllipse, int nHeightEllipse);

        [DllImport("DwmApi")]
        private static extern int DwmSetWindowAttribute(IntPtr hwn, int attr, int[] attrValue, int attriSize);

        protected override void OnHandleCreated(EventArgs e)
        {
            if (DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
            {
                DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
            }
        }

        public Menu()
        {
            InitializeComponent();

            connectionString = $"DataSource=localhost;Database=C:\\SGBR\\Master\\BD\\BASESGMASTER1.FDB;Port=3050;User=SYSDBA;Password=masterkey;Charset=UTF8;Dialect=3;Connection lifetime=15;PacketSize=8192;ServerType=0;Unicode=True;Max Pool Size=1000";

            FbConnection connection = new FbConnection(connectionString);

          

            SystemEvents.DisplaySettingsChanged += new EventHandler(SystemEvents_DisplaySettingsChanged);

            // Associar o evento Load ao método Menu_Load
            this.Load += Menu_Load;

        }

      



        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            AdjustFormWidth();
        }

        private void AdjustFormWidth()
        {
            if (this.Top <= 0)
            {
                this.Width = Screen.PrimaryScreen.WorkingArea.Width;
                this.Left = 0;
            }
            else if (this.Width > Screen.PrimaryScreen.WorkingArea.Width)
            {
                this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            AdjustFormWidth();
            CarregarNomeEmitente();
        }

        private void CarregarNomeEmitente()
        {
            string query = "SELECT razaosocial FROM TEMITENTE";
            using (FbConnection connection = new FbConnection(connectionString))
            {
                connection.Open();
                using (FbCommand cmd = new FbCommand(query, connection))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        string nomeEmitente = result.ToString();
                        // Remove qualquer prefixo numérico seguido de espaço
                        nomeEmitente = Regex.Replace(nomeEmitente, @"^\d+\s*-\s*", "");
                        this.Text = $"Menu SG Master || {nomeEmitente}";
                    }
                }
            }
        }

        private void ShowChildForm(Form childForm, string dataGridName)
        {
            // Suspender o layout para melhorar o desempenho
            this.SuspendLayout();

            // Fecha o formulário filho atualmente aberto, se houver
            if (currentChildForm != null && !currentChildForm.IsDisposed)
            {
                currentChildForm.Hide();
            }

            // Posiciona e dimensiona o novo formulário filho
            childForm.StartPosition = FormStartPosition.Manual;
            childForm.Width = Screen.PrimaryScreen.WorkingArea.Width; // Ajusta a largura conforme a tela
            childForm.Left = 0; // Posiciona à esquerda da tela
            childForm.Top = this.Bottom; // Posiciona logo abaixo do formulário principal

            // Calcula a altura disponível descontando a barra de tarefas
            int taskbarHeight = Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.WorkingArea.Height;
            int availableHeight = Screen.PrimaryScreen.WorkingArea.Height - (this.Height + taskbarHeight / 12); // Ajuste adicional para descer mais

            childForm.Height = availableHeight; // Define a altura específica

            // Ajusta a DataGridView específica para preencher todo o formulário
            var dataGridView = childForm.Controls.Find(dataGridName, true).FirstOrDefault() as DataGridView;
            if (dataGridView != null)
            {
                dataGridView.Dock = DockStyle.Fill;
            }

            childForm.Show();

            // Atualiza a referência ao formulário filho atualmente aberto
            currentChildForm = childForm;

            // Retomar o layout após a manipulação
            this.ResumeLayout();
        }

        private void MCliente_Click(object sender, EventArgs e)
        {
            Clientes clientesForm = new Clientes(connectionString);
            ShowChildForm(clientesForm, "Gcliente");
        }

        private void MEstoque_Click(object sender, EventArgs e)
        {
            Estoque estoqueForm = new Estoque(connectionString);
            ShowChildForm(estoqueForm, "Gestoque");
        }

        private void MFornecedor_Click(object sender, EventArgs e)
        {
            Fornecedor fornecedorForm = new Fornecedor(connectionString);
            ShowChildForm(fornecedorForm, "Gfornecedor");
        }

        private void Menu_Resize(object sender, EventArgs e)
        {
            if (this.Width > Screen.PrimaryScreen.WorkingArea.Width)
            {
                this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            }

       

            AdjustFormWidth();
        }

        private void Menu_LocationChanged(object sender, EventArgs e)
        {
            // Verifica se o formulário está na parte superior da tela
            if (this.Top <= 0)
            {
                // Ajusta a largura do formulário para a largura da tela
                this.Width = Screen.PrimaryScreen.WorkingArea.Width;
                this.Left = 0; // Certifique-se de que o formulário esteja alinhado à esquerda

                AdjustFormWidth();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            SystemEvents.DisplaySettingsChanged -= new EventHandler(SystemEvents_DisplaySettingsChanged);
        }
    }
}
