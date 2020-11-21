using System.ComponentModel.DataAnnotations;

namespace MaisAprendizado.Models
{
    public class Aluno : Pessoa
    {
        public Pessoa Pessoa { get; set; }//is a

        
    }
}
