using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaisAprendizado.Models
{
    public class Professor : Pessoa
    {

        public Professor()
        {

        }

        public Professor(int professorId, decimal credito)
        {
            this.ProfessorId = professorId;
            this.Credito = credito;

        }
        public int ProfessorId { get; set; }
        public decimal Credito { get; set; }
    }
}
