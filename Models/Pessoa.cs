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

        public Pessoa(int PessoaId, string Nome, string Email, DateTime DataNascimento, string Senha, string Telefone)
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
        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(3)]
        public string Nome { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.DateTime)]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Senha { get; set; }


        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        //Construtor
       
    }
}
