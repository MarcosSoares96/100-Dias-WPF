using ClosedXML.Excel;
using ExcelCadastro.Models;
using System.Drawing;

namespace ExcelCadastro.Services
{
    public class ExcelService
    {
        private readonly string _filePath;

        public ExcelService(string filePath)
        {
            _filePath = filePath;
            InicializarArquivo();
        }

        private void InicializarArquivo()
        {
            if (!File.Exists(_filePath))
            {
                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Produtos");

                // Criar cabeçalhos
                worksheet.Cell(1, 1).Value = "FORNECEDOR";
                worksheet.Cell(1, 2).Value = "CATEGORY";
                worksheet.Cell(1, 3).Value = "DESCRIPTION";
                worksheet.Cell(1, 4).Value = "PRESENTATION";
                worksheet.Cell(1, 5).Value = "SPECIFICATIONS";
                worksheet.Cell(1, 6).Value = "THERAPEUTIC AREA/INDICATION";
                worksheet.Cell(1, 7).Value = "REGULATORY STATUS/OBSERVATION";
                worksheet.Cell(1, 8).Value = "DOSAGE";

                // Formatar cabeçalhos
                var headerRange = worksheet.Range(1, 1, 1, 8);
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.BackgroundColor = XLColor.LightBlue;
                headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                worksheet.Columns().AdjustToContents();
                workbook.SaveAs(_filePath);
            }
        }

        public void AdicionarProduto(Product produto)
        {
            using var workbook = new XLWorkbook(_filePath);
            var worksheet = workbook.Worksheet(1);

            var ultimaLinha = worksheet.LastRowUsed()?.RowNumber() ?? 1;
            var novaLinha = ultimaLinha + 1;

            worksheet.Cell(novaLinha, 1).Value = produto.Fornecedor;
            worksheet.Cell(novaLinha, 2).Value = produto.Category;
            worksheet.Cell(novaLinha, 3).Value = produto.Description;
            worksheet.Cell(novaLinha, 4).Value = produto.Presentation;
            worksheet.Cell(novaLinha, 5).Value = produto.Specifications;
            worksheet.Cell(novaLinha, 6).Value = produto.TherapeuticArea;
            worksheet.Cell(novaLinha, 7).Value = produto.RegulatoryStatus;
            worksheet.Cell(novaLinha, 8).Value = produto.Dosage;

            worksheet.Columns().AdjustToContents();
            workbook.Save();
        }

        public List<Product> ObterTodosProdutos()
        {
            var produtos = new List<Product>();

            if (!File.Exists(_filePath))
                return produtos;

            using var workbook = new XLWorkbook(_filePath);
            var worksheet = workbook.Worksheet(1);

            var linhas = worksheet.RowsUsed().Skip(1); // Pular cabeçalho

            foreach (var linha in linhas)
            {
                var produto = new Product
                {
                    Fornecedor = linha.Cell(1).GetString(),
                    Category = linha.Cell(2).GetString(),
                    Description = linha.Cell(3).GetString(),
                    Presentation = linha.Cell(4).GetString(),
                    Specifications = linha.Cell(5).GetString(),
                    TherapeuticArea = linha.Cell(6).GetString(),
                    RegulatoryStatus = linha.Cell(7).GetString(),
                    Dosage = linha.Cell(8).GetString()
                };
                produtos.Add(produto);
            }

            return produtos;
        }
    }
}
