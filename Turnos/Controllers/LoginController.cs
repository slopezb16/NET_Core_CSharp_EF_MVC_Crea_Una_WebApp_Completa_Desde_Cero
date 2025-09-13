using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Turnos.Models;
using Microsoft.AspNetCore.Http;

namespace Turnos.Controllers
{
    public class LoginController : Controller
    {
        private readonly TurnosContext _context;

        public LoginController(TurnosContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                //Encriptar Password
                string passWordEncriptado = Encriptar(login.Password);
                //Buscar en la base de datos
                var usuario = _context.Login.Where(u => u.Usuario == login.Usuario && u.Password == passWordEncriptado).FirstOrDefault();

                if (usuario != null)
                {
                    HttpContext.Session.SetString("usuario", usuario.Usuario);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["ErrorLogin"] = "Los datos ingresados son incorrectos";
                    return View("Index");
                }
            }

            return View("Index");
        }

        public string Encriptar(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    stringBuilder.Append(bytes[i].ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}