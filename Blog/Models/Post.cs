using System;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace Blog.Models
{
    public class Post
    {
        [Required (ErrorMessage= "Titulo Obrigatório")] [StringLength(50)]	[Display(Name="Título")]
        public string Titulo { get; set; }
         [Required (ErrorMessage= "Resumo Obrigatório")]
        public string Resumo { get; set; }
        public string Categoria { get; set; }
        public int ID {get; set;}
        public DateTime? DataPublicacao { get; set; }
        public bool Publicado { get; set; }
        public Usuario Autor { get; set; }
    }
}