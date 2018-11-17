using System.Linq;
using Blog.Models;

namespace Blog.DAO
{

    public class UsuarioDAO
    {

        BlogContext context;

        public UsuarioDAO(BlogContext context)
        {
            this.context = context;
        }

        public Usuario Busca (string login, string senha)
        {
            return context.Usuarios.Where(u=>
                                    u.nome.Equals(login)&&u.senha.Equals(senha))
                                    .FirstOrDefault<Usuario>();
        }

        public void Salva(Usuario u)
        {
            context.Usuarios.Add(u);
            context.SaveChanges();
        }
    }
}