using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoImport
{
    public partial class Fornecedor : Form
    {
        private FbConnection con;
        private string _strConexao;
        private FornecedorService _fornecedorService;

        public Fornecedor(string strConexao)
        {
            InitializeComponent();

            _strConexao = strConexao;
            _fornecedorService = new FornecedorService(_strConexao, Gfornecedor);

            con = new FbConnection(strConexao);
            FbCommand comando = new FbCommand("SELECT * FROM TFORNECEDOR", con);
            FbDataAdapter data = new FbDataAdapter(comando);
            DataSet dataset = new DataSet();
            con.Open();
            data.Fill(dataset, "TFORNECEDOR");
            Gfornecedor.DataSource = dataset;
            Gfornecedor.DataMember = "TFORNECEDOR";
            con.Close();

            // Adiciona o evento MouseDown ao DataGridView
            Gfornecedor.MouseDown += new MouseEventHandler(Gfornecedor_MouseDown);

            // Adiciona os eventos Click aos itens do ContextMenuStrip
            ForImportarStrip.Click += new EventHandler(importarParaXlsFornecedorToolStripMenuItem_Click);
            ForExportarStrip.Click += new EventHandler(exportarParaXlsFornecedorToolStripMenuItem_Click);
        }

        private void Gfornecedor_MouseDown(object sender, MouseEventArgs e)
        {
            // Verifica se o botão direito do mouse foi clicado
            if (e.Button == MouseButtons.Right)
            {
                // Obtém o índice da célula que foi clicada
                var hitTestInfo = Gfornecedor.HitTest(e.X, e.Y);
                if (hitTestInfo.RowIndex >= 0 && hitTestInfo.ColumnIndex >= 0)
                {
                    // Seleciona a célula clicada
                    Gfornecedor.ClearSelection();
                    Gfornecedor.Rows[hitTestInfo.RowIndex].Cells[hitTestInfo.ColumnIndex].Selected = true;

                    // Exibe o ContextMenuStrip na posição do cursor
                    FImports.Show(Gfornecedor, e.Location);
                }
            }
        }

        private void importarParaXlsFornecedorToolStripMenuItem_Click(object sender, EventArgs e)
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

                        _fornecedorService.ImportarDeXlsParaGrid(nomeArquivo);

                        MessageBox.Show("Dados importados do Excel para o banco de dados com sucesso!", "Importação de Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao importar do Excel: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void exportarParaXlsFornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataSet dataset = (DataSet)Gfornecedor.DataSource;

            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "Arquivos Excel (*.xlsx)|*.xlsx|Todos os arquivos (*.*)|*.*";
                dialog.FileName = "fornecedores.xlsx"; // Nome padrão do arquivo
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // Diretório inicial

                // Mostra o diálogo para o usuário
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string nomeArquivo = dialog.FileName;

                    _fornecedorService.ExportarParaXls(dataset, nomeArquivo);

                    MessageBox.Show($"Dados exportados para '{nomeArquivo}' com sucesso!", "Exportar para Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
  (
      int nLeft,
      int nTop,
      int nRigth,
      int nBottom,
      int nWidthEllipse,
      int nHeightEllipse
  );

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
