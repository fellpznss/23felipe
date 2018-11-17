using Blog.DAO;
using Blog.Filters;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace Blog.Areas.Admin.Controllers
{

    [Area("Admin")]
    [AutorizacaoFilter]
    public class PostController : Controller
    {
        PostDAO dAO;

        public PostController(PostDAO dao)
        {
            this.dAO = dao;
        }

        [HttpPost]
        [AutorizacaoFilter]
        public IActionResult Adiciona(Post post)
        {

            if (ModelState.IsValid)
            {

                dAO.Adiciona(post);
                return RedirectToAction("Index");

            }
            else
            {

                return View("Novo", post);

            }

        }

        public IActionResult Index()
        {

            return View(dAO.Lista());

        }

        [AutorizacaoFilter]
        public IActionResult Novo()
        {
            var model = new Post();
            return View(model);
        }

        [HttpPost]
        public IActionResult Categoria([Bind(Prefix = "id")]string categoria)
        {

            IList<Post> listaFiltrada = dAO.FiltraPorCategoria(categoria);
            return View("Index", listaFiltrada);
        }
        public IActionResult RemovePost(int id)
        {
            dAO.Remove(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult EditaPost(Post post)
        {
            if (ModelState.IsValid)
            {
                dAO.Edita(post);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Visualiza", post);
            }
        }
        public IActionResult Visualiza(int id)
        {
            Post post = dAO.BuscaPorId(id);
            return View(post);
        }
        public IActionResult PublicaPost(int id)
        {
            dAO.Publica(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CategoriaAutocomplete(string termoDigitado)
        {
            var model = dAO.ListaCategoriasQueContemTermo(termoDigitado);
            return Json(model);
        }



    }

}