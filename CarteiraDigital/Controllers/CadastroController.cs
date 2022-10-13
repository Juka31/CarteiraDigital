using Microsoft.AspNetCore.Mvc;
using NHibernate;
using System.Threading.Tasks;
using CarteiraDigital.Entidades;
using System;
using CarteiraDigital.Ropositorio;

namespace CarteiraDigital.Controllers
{
    public class CadastroController : Controller
    {
        private readonly UsuariosRepositorio usuariosRepositorio;
        public CadastroController(NHibernate.ISession session) => usuariosRepositorio = new UsuariosRepositorio(session);
        public ActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Cadastro(Tabela_Usuario tabela_Usuarios)
        {
            if (ModelState.IsValid)
            {
                await usuariosRepositorio.Add(tabela_Usuarios);
                return RedirectToAction("Index", "Login");
            }
            return View(tabela_Usuarios);
        }
    }
}
