using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSS_08_1.Models.ViwModel
{
    public class QueryViwModels
    {
        public int _Id { get; set; }
        public string _Email { get; set; }
        
        public int _Edad { get; set; }

    }

    public class AddUserViewModel
    {
        [Required]
        [Display(Name ="Nombre Corto")]
        public string _Nombre { get; set; }
        [Required]
        [Display(Name ="Correo Electronico")]
        [EmailAddress]
        [StringLength(100,ErrorMessage ="El {0} Debe de tener como maximo 100 caracteres",MinimumLength = 1)]
        public string _Email { get; set; }
        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string _Password { get; set; }
        [Required]
        [Display(Name = "Confirmar Contraseña")]
        [DataType(DataType.Password)]
        [Compare("_Password",ErrorMessage ="No Son Iguales...")]
        public string _ConfirmaPassword { get; set; }
        [Required]
        [Display(Name = "Edad")]
        public int _Edad { get; set; }
    }

}