using ArtCulture.Models;
using ArtCulture.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ArtCulture.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(
            IUsuarioService usuarioService
            )
        {
            _usuarioService = usuarioService;

        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(int? id)
        {
            bool alerta = false;
            ViewBag.Alerta = alerta;
            if (id != null)
            {


                if (id == 0)
                {

                    HttpContext.Session.SetString("usuarioLogado", string.Empty);
                    HttpContext.Session.SetString("usuarioId", string.Empty);
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginValidar(Usuario usuario)
        {
            var resposta = _usuarioService.LoginValidar(usuario);

            if (resposta.Status == 0)
            {

            }
            else
            {
                HttpContext.Session.SetString("usuarioLogado", JsonConvert.SerializeObject(resposta.Resultado));
                return Redirect("/Home/Perfil");
            }
            return Redirect("/Usuario/Login");

        }


        [HttpPost]
        public IActionResult CadastrarUsuario(Usuario usuario)
        {
            var resposta = _usuarioService.CadastrarUsuario(usuario);


            HttpContext.Session.SetString("usuarioLogado", usuario.Nome);
            HttpContext.Session.SetString("usuarioId", usuario.Id.ToString());


            return Redirect("/");

            //return View(resposta);

            /* 
               [HttpPost]
            public IActionResult LoginValidar(Usuario usuario)
            {
                var resposta = _usuarioService.

                if (login)
                {
                    HttpContext.Session.SetString("UsernameLogged", user.Name);
                    HttpContext.Session.SetString("UsernameLoggedId", user.Id_User.ToString());

                    return RedirectToAction("Menu", "Home");

                }
                else
                {
                    TempData["LoginMessage"] = "Dados de login inválidos!";
                    return RedirectToAction("Login");
                }
            }

            [HttpPost]
            public IActionResult Login()
            {
                return View();
            }
            */
        }
    }
}
