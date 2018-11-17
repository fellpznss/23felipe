using System.Collections.Generic;
using Blog.DAO;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Areas.Api.Controllers
{
    [Area("API")]
    [Route("/api/post")]
    [ApiController]
    public class PostApiController : ControllerBase
    {
        PostDAO dao;
        public PostApiController(PostDAO dao)
        {
            this.dao = dao;
        }

        [Route("lista")]
        [HttpGet]
        public IActionResult BuscaTodosPosts()
        {
            IList<Post> posts = dao.Lista();
            return Ok(posts);
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult BuscaPostPorId(int id)
        {
            return Ok(dao.BuscaPorId(id));
        }

        [Route("new")]
        [HttpPost]
        public IActionResult CadastraPost([FromBody] Post p)
        {
            dao.Adiciona(p);
            return CreatedAtAction("BuscaPostPorId", new {id = p.ID });
        }

    }
}
