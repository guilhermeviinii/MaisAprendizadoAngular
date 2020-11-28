using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaisAprendizado.Models
{
    public class AulaGravada
    {
        public int? AulaId { get; set; }
        //public int CursoId { get; set; }
        
        [Display(Name = "Titulo")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(3)]
        public string Titulo { get; set; }

        [Display(Name = "Descrição")]
        [MinLength(50)]
        [DataType(DataType.Text)]
        public string Descricao { get; set; }
    }
}
