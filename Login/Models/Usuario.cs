using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Login.Models
{
  public class Usuario
  {
    [Key]  
    public int Id { get; set; }
    [Required(ErrorMessage = "Se nesecita un nombre de usuario.")]
    [Display(Name ="Usuario")]
    public string Usuario_nombre { get; set; }
    [Required(ErrorMessage = "Se nesecita una contraseña.")]
    [DataType(DataType.Password)]
    public string Contraseña { get; set; }
    [Display(Name = "E-Mail")]
    [Required(ErrorMessage = "Se nesecita un E-mail.")]
    [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3]\.)|(([\w-]+\.)+))([a-zA-Z{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Verifique su E-mail.")]
    public string Email { get; set; }

    
    public string Sexo { get; set; }
    
    public bool Activo { get; set; }
  }
}