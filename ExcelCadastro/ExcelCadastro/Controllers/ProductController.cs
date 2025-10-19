using ExcelCadastro.Models;
using ExcelCadastro.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExcelCadastro.Controllers
{
    public class ProductController : Controller
    {
        private readonly ExcelService _excelService;

        public ProductController()
        {
            var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), "Data");

            if (!Directory.Exists(caminhoPasta))
                Directory.CreateDirectory(caminhoPasta);

            var caminhoArquivo = Path.Combine(caminhoPasta, "produtos.xlsx");
            _excelService = new ExcelService(caminhoArquivo);
        }

        // GET: Product
        public IActionResult Index()
        {
            var produtos = _excelService.ObterTodosProdutos();
            return View(produtos);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product produto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _excelService.AdicionarProduto(produto);
                    TempData["Success"] = "Produto cadastrado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Erro ao salvar: {ex.Message}");
                }
            }
            return View(produto);
        }
    }
}
