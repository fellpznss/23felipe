
using System.ComponentModel.DataAnnotations;

public class RegistroViewModel
{


    [Required]
    public string Nome { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Senha { get; set; }
    [Required]
    [Compare("Senha")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirmação da	senha")]
    public string Confirmacao { get; set; }

    public Usuario ToUsuario()
    {
        Usuario u = new Usuario();
        u.nome = this.Nome;
        u.email = this.Email;
        u.senha = this.Senha;
        return u;
    }


}