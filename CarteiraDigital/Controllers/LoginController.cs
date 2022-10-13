using CarteiraDigital.Ropositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CarteiraDigital.Controllers
{
    public class LoginController : Controller
    {
        private readonly UsuariosRepositorio usuariosRepositorio;

        public LoginController(NHibernate.ISession session) => usuariosRepositorio = new UsuariosRepositorio(session);

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Usuario, string Senha)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-Q4MPNMK;Initial Catalog=CarteiraDigital;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            string login = "SELECT * FROM Tabela_Usuario WHERE USUARIO='" + Usuario + "' AND SENHA='" + Senha + "'";
            cmd = new SqlCommand(login, con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                con.Close();
                return RedirectToAction("Index", "Home");

            }
            else
            {
                con.Close();
                return View();
            }
        }
    }
}