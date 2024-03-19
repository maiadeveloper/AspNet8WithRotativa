using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore.Options;
using Rotativa.AspNetCore;
using System.Diagnostics;
using WebAspNet8Rotativa.Models;

namespace WebAspNet8Rotativa.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Relatorio()
        {
            var pessoa = new Pessoa();

            pessoa.Id = 1;
            pessoa.Nome = "Luís Antônio O Maia";
            pessoa.Email = "luisaom@teste.com";

            string customSwitches = string.Format(
                   "--footer-left \"Data e hora impressão:" + @DateTime.Now + " | TI - Tecnologia da Informação\" " +
                    "--footer-font-name \"Open Sans\" " +
                    " --footer-line --footer-font-size \"8\" " +
                    "--footer-right \"Página [page] de [toPage]\"");

            var pdf = new ViewAsPdf(pessoa)
            {
                CustomSwitches = customSwitches,

                PageMargins = new Margins { Bottom = 20, Left = 15, Right = 15, Top = 20 },
                PageSize = Size.A4,
                PageOrientation = Orientation.Portrait,
                ViewName = "Relatorio"
            };

            return pdf;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
