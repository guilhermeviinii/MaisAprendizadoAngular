using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaisAprendizado.Models
{
    public class CompraCurso
    {
        public int IdCompra { get; set; }
        public int IdCurso { get; set; }
        public int Quantidade { get; set; }
        public int Status { get; set; }
        public decimal Valor { get; set; }
    }
}
