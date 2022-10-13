using CarteiraDigital.Entidades;
using CarteiraDigital.Models;
using CarteiraDigital.Repositorio;
using CarteiraDigital.Ropositorio;
using FastReport.Export.PdfSimple;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarteiraDigital.Controllers
{
    public class HomeController : Controller
    {

        public readonly IWebHostEnvironment _webHostEnv;
        private readonly IEmail _email;
        private readonly PessoasRepositorio pessoasrepositorio;
        private readonly SaidaRepositorio saidaRepositorio;

        public HomeController(NHibernate.ISession session, IEmail email, IWebHostEnvironment webHostEnv)
        {
            saidaRepositorio = new SaidaRepositorio(session);
            pessoasrepositorio = new PessoasRepositorio(session);
            _email = email;
            _webHostEnv = webHostEnv;
        }


      

        public IActionResult Index()
        {
            return View(pessoasrepositorio.FindAll().ToList());
        }

        public async Task<ActionResult> EditarPessoa(int? pes_codigo)
        {
            if (pes_codigo == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            Tabela_Pessoas tabela_pessoas = await pessoasrepositorio.FindByID(pes_codigo.Value);
            if (tabela_pessoas == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return View(tabela_pessoas);
        }

        // POST: CadastrarPessoaController/Edit/5
        [HttpPost, ActionName("EditarPessoa")]
        public async Task<ActionResult> SalvarPessoa(Tabela_Pessoas tabela_pessoas)
        {
            try
            {
                if (tabela_pessoas.PES_SALDO < tabela_pessoas.PES_LIMITE)
                {
                    string assunto = "Alerta Saldo Perigoso";
                    string mensagem = "Olá " + tabela_pessoas.PES_NOME + " seu saldo está abaixo do limite de segurança. Recomendamos que atualize assim que possível";

                    _email.Enviar(tabela_pessoas.PES_EMAIL, assunto, mensagem);
                }

                await pessoasrepositorio.Update(tabela_pessoas);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public async Task<ActionResult> DeletarPessoa(int? pes_codigo)
        {
            if (pes_codigo == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            Tabela_Pessoas tabela_pessoas = await pessoasrepositorio.FindByID(pes_codigo.Value);
            if (tabela_pessoas == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return View(tabela_pessoas);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("DeletarPessoa")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeletarPessoaConfirmado(int pes_codigo)
        {
            await pessoasrepositorio.Remove(pes_codigo);
            return RedirectToAction("Index");
        }

        public IActionResult CreateReport()
        {
            var caminhoReport = Path.Combine(_webHostEnv.WebRootPath, @"reports\ReportMvc.frx");
            var reportFile = caminhoReport;
            var freport = new FastReport.Report();
            var customersList = pessoasrepositorio.FindAll().ToList();

            freport.Dictionary.RegisterBusinessObject(customersList, "customersList", 10, true);
            freport.Report.Save(reportFile);

            return Ok($" Relatorio gerado : {caminhoReport}");
        }

        public IActionResult ExportReport()
        {
            var caminhoReport = System.IO.Path.Combine(_webHostEnv.WebRootPath, @"reports\ReportMvc.frx");
            var reportFile = caminhoReport;
            var freport = new FastReport.Report();
            var customersList = pessoasrepositorio.FindAll().ToList();

            freport.Report.Load(reportFile);
            freport.Dictionary.RegisterBusinessObject(customersList, "customersList", 10, true);
            //freport.Report.Save(reportFile);
            freport.Prepare();

            var pdfExport = new PDFSimpleExport();

            using MemoryStream ms = new MemoryStream();
            pdfExport.Export(freport, ms);
            ms.Flush();

            return File(ms.ToArray(), "application/pdf", "Relatório.pdf");
            //return Ok($"Relatorio gerado: {caminhoReport}");
        }
    }
}



