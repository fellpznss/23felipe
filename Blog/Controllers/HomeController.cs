
using System.Collections.Generic;
using Blog.DAO;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers


{
    public class HomeController : Controller
    {
        private PostDAO dao;

        public HomeController (PostDAO dao)
        {
            this.dao = dao;
        }

        //GET:	Home
        public IActionResult Index()
        {
            
            IList<Post> publicados = dao.ListaPublicados();
            return View(publicados);
        }

        public IActionResult Busca(string termo)
        {
            
            IList<Post> termoBuscado = dao.BuscaPeloTermo(termo);
            return View("Index",termoBuscado);
        }
    }
}
