using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.DAO
{

    public class PostDAO
    {

        BlogContext context;

        public PostDAO(BlogContext context)
        {
            this.context = context;
        }

        public IList<Post> Lista()
        {
           
                return context.Posts.ToList();
            
        }

        public void Adiciona(Post p)
        {
            context.Posts.Add(p);
            context.SaveChanges();
        }

        public IList<Post> FiltraPorCategoria(string categoria)
        {
            
                var lista = context.Posts.Where(Post => Post.Categoria.Contains(categoria)).ToList();
                return lista;
            

        }

        public void Remove(int id)
        {
            
                Post post = context.Posts.Find(id);
                context.Posts.Remove(post);
                context.SaveChanges();
            
        }

        public void Edita(Post post)
        {
            
                context.Entry(post).State = EntityState.Modified;
                context.SaveChanges();
           
        }

        public Post BuscaPorId(int id)
        {
            
                Post post = context.Posts.Find(id);
                return post;
            
        }

        public void Publica (int id)
        {
           
                Post post = context.Posts.Find(id);
                post.Publicado = true;
                post.DataPublicacao = DateTime.Now;
                context.SaveChanges();
            
        }

        public	IList<string> ListaCategoriasQueContemTermo(string	termo)
            {
                    
						return	context.Posts
						.Where(p	=>	p.Categoria.Contains(termo))
						.Select(p	=>	p.Categoria)
						.Distinct()
						.ToList();
					
            }

        public IList<Post> ListaPublicados()
        {
           
					    return	context.Posts.Where(p	=>	p.Publicado)
						.OrderByDescending(p =>	p.DataPublicacao).ToList();
					

        }

        public IList<Post> BuscaPeloTermo(string termo)
        {
            
                return context.Posts.Where(p => p.Publicado && (p.Resumo.Contains(termo)||p.Titulo.Contains(termo)))
                .ToList();
            
        }

         public void Adiciona(Post p, Usuario u)
        {
            context.Usuarios.Attach(u);
            p.Autor = u;
            context.Posts.Add(p);
            context.SaveChanges();
        }
          

    }   
}