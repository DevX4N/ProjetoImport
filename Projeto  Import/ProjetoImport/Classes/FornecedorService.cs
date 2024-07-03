using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoImport
{
    public class FornecedorService
    {
        private string _conexao;
        private DataGridView _gridFornecedor;
        

        public FornecedorService(string conexao, DataGridView gridFornecedor)
        {
            _conexao = conexao;
            _gridFornecedor = gridFornecedor;
        }

        // Método para importar dados de arquivos Excel para a DataGridView
        public void ImportarDeXlsParaGrid(string[] nomesArquivos)
        {
            try
            {
                // Lista para armazenar os DataTables dos arquivos Excel
                var dataTables = new List<DataTable>();

                // Processamento paralelo dos arquivos Excel
                Parallel.ForEach(nomesArquivos, nomeArquivo =>
                {
                    using (var workbook = new XLWorkbook(nomeArquivo))
                    {
                        var worksheet = workbook.Worksheet(1);

                        // Converte os dados da planilha para um DataTable
                        var dataTable = ConvertToDataTable(worksheet);

                        // Adiciona o DataTable à lista (sincronizado para thread seguro)
                        lock (dataTables)
                        {
                            dataTables.Add(dataTable);
                        }
                    }
                });

                // Concatena os DataTables em um único DataTable
                DataTable mergedDataTable = MergeDataTables(dataTables);

                // Exibe os dados na DataGridView
                ExibirDadosNaGrid(mergedDataTable);
            }
            catch (Exception ex)
            {
                // Trata exceções, se necessário
                Console.WriteLine($"Erro ao importar arquivos Excel: {ex.Message}");
                throw; // ou retorna null, dependendo do tratamento desejado
            }
        }
      
        private DataTable ConvertToDataTable(IXLWorksheet worksheet)
        {
            DataTable dataTable = new DataTable(worksheet.Name);

            // Adiciona as colunas ao DataTable
            foreach (var firstRowCell in worksheet.FirstRow().CellsUsed())
            {
                dataTable.Columns.Add(firstRowCell.Value.ToString());
            }

            // Adiciona as linhas ao DataTable
            foreach (var row in worksheet.RowsUsed().Skip(1)) // Pula a primeira linha (cabeçalho)
            {
                DataRow dataRow = dataTable.NewRow();
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    dataRow[i] = row.Cell(i + 1).Value.ToString();
                }
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }

        // Método para mesclar vários DataTables em um único DataTable
        private DataTable MergeDataTables(List<DataTable> dataTables)
        {
            DataTable mergedDataTable = new DataTable();

            // Mescla os DataTables
            if (dataTables.Any())
            {
                mergedDataTable = dataTables.First().Copy();
                foreach (var dt in dataTables.Skip(1))
                {
                    mergedDataTable.Merge(dt);
                }
            }

            return mergedDataTable;
        }

        // Método para exibir dados em uma DataGridView
        private void ExibirDadosNaGrid(DataTable dataTable)
        {
            _gridFornecedor.Invoke((MethodInvoker)delegate
            {
                _gridFornecedor.DataSource = dataTable;
            });
        }


        public void ExportarParaXls(DataSet dataset, string nomeArquivo)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Fornecedores");

                    // Obtém a tabela TFORNECEDOR do DataSet
                    var dataTable = dataset.Tables["TFORNECEDOR"];

                    // Escreve os nomes das colunas
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value = dataTable.Columns[i].ColumnName;
                    }

                    // Escreve os dados das linhas
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataTable.Columns.Count; j++)
                        {
                            var cellValue = dataTable.Rows[i][j] != DBNull.Value ? dataTable.Rows[i][j].ToString() : string.Empty;
                            worksheet.Cell(i + 2, j + 1).Value = cellValue;
                        }
                    }

                    // Salva o arquivo Excel com o nome especificado
                    workbook.SaveAs(nomeArquivo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao exportar para Excel: {ex.Message}");
                return;
            }
        }

        public void ImportarDeXlsParaGrid(string nomeArquivo)
        {
            ImportarDeXlsParaGrid(new[] { nomeArquivo });
        }
    }
}
