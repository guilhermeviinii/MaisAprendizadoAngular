using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaisAprendizado.Models
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public int IdPessoa { get; set; }
        public int Status { get; set; }
        public DateTime DataCompra { get; set; }
    }
}
