using System.ComponentModel.DataAnnotations;

public class LoginViewModel
{
    [Required][Display(Name="Usuário")]
    public string Login { get; set; }
    [Required][DataType(DataType.Password)]
    public string  Senha { get; set; }     
}