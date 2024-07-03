using FirebirdSql.Data.FirebirdClient;
using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoImport
{
    public partial class Estoque : Form
    {
        private FbConnection con;
        private string _strConexao;
        private EstoqueService _estoqueService;
       

        public Estoque(string strConexao)
        {
            InitializeComponent();
         

            _strConexao = strConexao;
            _estoqueService = new EstoqueService(_strConexao, GEstoque);
            con = new FbConnection(strConexao);
            FbCommand comando = new FbCommand("SELECT * FROM TESTOQUE", con);
            FbDataAdapter data = new FbDataAdapter(comando);
            DataSet dataset = new DataSet();
            con.Open();
            data.Fill(dataset, "TESTOQUE");
            GEstoque.DataSource = dataset;
            GEstoque.DataMember = "TESTOQUE";
            con.Close();

            // Adiciona o evento MouseDown ao DataGridView
            GEstoque.MouseDown += new MouseEventHandler(Gestoque_MouseDown);

            // Adiciona os eventos Click aos itens do ContextMenuStrip
            EsImportarStrip.Click += new EventHandler(importarParaXlsToolStripMenuItem_Click);
            EsExportarStrip.Click += new EventHandler(exportarParaXlsToolStripMenuItem_Click);
        }

        private void Gestoque_MouseDown(object sender, MouseEventArgs e)
        {
            // Verifica se o botão direito do mouse foi clicado
            if (e.Button == MouseButtons.Right)
            {
                // Obtém o índice da célula que foi clicada
                var hitTestInfo = GEstoque.HitTest(e.X, e.Y);
                if (hitTestInfo.RowIndex >= 0 && hitTestInfo.ColumnIndex >= 0)
                {
                    // Seleciona a célula clicada
                    GEstoque.ClearSelection();
                    GEstoque.Rows[hitTestInfo.RowIndex].Cells[hitTestInfo.ColumnIndex].Selected = true;

                    // Exibe o ContextMenuStrip na posição do cursor
                    EImports.Show(GEstoque, e.Location);
                }
            }
        }

        private  void importarParaXlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "Arquivos Excel (*.xlsx)|*.xlsx|Todos os arquivos (*.*)|*.*";
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string nomeArquivo = dialog.FileName;

                    try
                    {
                         _estoqueService.ImportarDeXlsParaGrid(nomeArquivo);
                        MessageBox.Show("Dados importados do Excel para o banco de dados com sucesso!", "Importação de Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao importar do Excel: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void exportarParaXlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataSet dataset = (DataSet)GEstoque.DataSource;

            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "Arquivos Excel (*.xlsx)|*.xlsx|Todos os arquivos (*.*)|*.*";
                dialog.FileName = "estoque.xlsx"; // Nome padrão do arquivo
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // Diretório inicial

                // Mostra o diálogo para o usuário
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string nomeArquivo = dialog.FileName;

                    // Chama o método para exportar para Excel
                    _estoqueService.ExportarParaXls(dataset, nomeArquivo);

                    MessageBox.Show($"Dados exportados para '{nomeArquivo}' com sucesso!", "Exportar para Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

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
    }
}
