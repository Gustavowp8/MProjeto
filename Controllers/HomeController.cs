using Microsoft.AspNetCore.Mvc;
using MProjeto.Models;
using System.Linq;

namespace MProjeto.Controllers{
    public class HomeController : Controller
    {
        public IActionResult Index(){
            ViewBag.QtdeUsuaios = Usuario.Listagem.Count();
            return View();
        }

        [HttpGet]
        public IActionResult Cadastrar( int? id){
           if(id.HasValue && Usuario.Listagem.Any(u => u.IdUsuario == id))
           {
            var usuario = Usuario.Listagem.Single(u => u.IdUsuario == id);
            return View(usuario);
           }
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {

                Usuario.Salvar(usuario);
                return RedirectToAction("Usuarios");
        }

          public IActionResult Usuarios(){
            return View(Usuario.Listagem);
        }

         [HttpGet]
        public IActionResult Excluir( int? id){
           if(id.HasValue && Usuario.Listagem.Any(u => u.IdUsuario == id))
           {
            var usuario = Usuario.Listagem.Single(u => u.IdUsuario == id);
            return View(usuario);
           }
            return RedirectToAction("Usuarios");
        }

        [HttpPost]
        public IActionResult Excluir(Usuario usuario)
        {
            TempData["Excluiu"] = ViewBag.Excluiu = Usuario.Excluir(usuario.IdUsuario);
            return RedirectToAction("Usuarios");
        }
    }
}