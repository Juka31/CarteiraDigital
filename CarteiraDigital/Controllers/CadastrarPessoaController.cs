using CarteiraDigital.Entidades;
using CarteiraDigital.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CarteiraDigital.Controllers
{
    public class CadastrarPessoaController : Controller
    {


        private readonly PessoasRepositorio pessoasRepositorio;

        public CadastrarPessoaController(NHibernate.ISession session) => pessoasRepositorio = new PessoasRepositorio(session);
        public ActionResult CadastrarPessoa()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CadastrarPessoa(Tabela_Pessoas tabela_pessoas)
        {

            if (ModelState.IsValid)
            {
                await pessoasRepositorio.Add(tabela_pessoas);
                return View(tabela_pessoas);
            }

            return View(tabela_pessoas);
        }
        public ActionResult Delete(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

