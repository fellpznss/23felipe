using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Blog.Models;

public class Usuario
{

[Required]
public int id { get; set; }
[Required]
public string email { get; set; }   
[Required]
public string senha { get; set; }   
[Required]
public string nome { get; set; }    
public virtual IList<Post> Posts{ get; set; }

}