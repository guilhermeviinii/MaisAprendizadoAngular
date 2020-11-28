using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaisAprendizado.Models
{
    public class Curso : Pessoa
    {
        public int? IdCurso { get; set; }

        public int PessoaId { get; set; }

    [Microsoft.AspNetCore.Mvc.FromForm(Name  = "Nome")]
        public string Nome { get; set; }
        public string ProfessorNome {get; set;}
        
        

        [Display(Name = "Preco")]
        public decimal Preco { get; set; }

        [Display(Name = "cargaHoraria")]
        public  decimal CargaHoraria { get; set; }

        public string Thumbnail {get; set; }
    }
}
