using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaisAprendizado.Models
{
    public class Pessoa 
    {

         public Pessoa()
        {
        }

        public Pessoa(int PessoaId, string Nome, string Email, string DataNascimento, string Senha, string Telefone)
        {
            this.PessoaId = PessoaId;
            this.Nome = Nome;
            this.Email = Email;
            this.DataNascimento = DataNascimento;
            this.Senha = Senha;
            this.Telefone = Telefone;    
        }
        public int? PessoaId { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Data de nascimento")]
        public string DataNascimento { get; set; }

        [Display(Name = "Senha")]
        public string Senha { get; set; }


        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        //Construtor
       
    }
}
