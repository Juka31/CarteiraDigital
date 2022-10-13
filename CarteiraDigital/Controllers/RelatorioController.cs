using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarteiraDigital.Controllers
{
    public class RelatorioController : Controller
    {
        public IActionResult Relatorio()
        {
            return View();
        }
    }
}