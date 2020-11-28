using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaisAprendizado.Models
{
    public class Compra : Curso
    {
        public int CompraId { get; set; }
        public int PessoaId { get; set; }
        public int Status { get; set; }
        public string DataCompra { get; set; }

        public  decimal valor {get; set; }
        
    }
}
