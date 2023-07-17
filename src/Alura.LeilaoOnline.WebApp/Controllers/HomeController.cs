using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Alura.LeilaoOnline.WebApp.Dados.Interfaces;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    public class HomeController : Controller
    {
        IHomeDao _homeDao;

        public HomeController(IHomeDao homeDao)
        {
            _homeDao = homeDao;
        }

        public IActionResult Index()
        {
            var categorias = _homeDao.BuscarCategoriasComInfoLeiloes();
            return View(categorias);
        }

        [Route("[controller]/StatusCode/{statusCode}")]
        public IActionResult StatusCodeError(int statusCode)
        {
            if (statusCode == 404) return View("404");
            return View(statusCode);
        }

        [Route("[controller]/Categoria/{categoria}")]
        public IActionResult Categoria(int categoria)
        {
            var categ = _homeDao.BuscarCategoriaPorId(categoria);
            return View(categ);
        }

        [HttpPost]
        [Route("[controller]/Busca")]
        public IActionResult Busca(string termo)
        {
            ViewData["termo"] = termo;
            var leiloes = _homeDao.BuscarLeiloesPorTermo(termo);
            return View(leiloes);
        }
    }
}
