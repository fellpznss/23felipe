using Blog.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

public class UsuarioController : Controller
{
    UsuarioDAO dao;

    public UsuarioController(UsuarioDAO dao)
    {
        this.dao = dao;
    }
    public IActionResult Login()
    {
        return View(new LoginViewModel());
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel lvm)
    {
        if (!ModelState.IsValid)
        {
            return View(lvm);
        }
        else
        {
            Usuario usuario = dao.Busca(lvm.Login, lvm.Senha);
            if (usuario == null)
            {
                ModelState.AddModelError("login.invalido", "Credenciais Erradas");
                return View(lvm);
            }

            else
            {
                HttpContext.Session.SetString("usuario", JsonConvert.SerializeObject(usuario));
                return RedirectToAction("Index", "Post", new { area = "Admin" });
            }

        }

    }
        public ActionResult Autentica(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = dao.Busca(lvm.Login, lvm.Senha);
                if (usuario != null)
                {
                    HttpContext.Session.SetString("usuario", JsonConvert.SerializeObject(usuario));
                    return RedirectToAction("Index", "Post", new { area = "Admin" });
                }
                else
                {
                    ModelState.AddModelError("login.Invalido", "Login	ou	senha	incorretos");
                }
            }
            return View("Login", lvm);
        }

        public IActionResult Novo()
        {
            return View(new RegistroViewModel());
        }

        [HttpPost]
        public IActionResult Salva (RegistroViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                dao.Salva(rvm.ToUsuario());
                return RedirectToAction("Index","Post", new {area="Admin"});
            }
            else
            {
                return View("Novo");
            }
        }

}

