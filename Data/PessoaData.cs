using MaisAprendizado.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MaisAprendizado.Data
{
    public class PessoaData : Data
    {
        //Create-INSERT
        public int Create(Pessoa Pessoa)
        {
            int returnValue = -1;
            try {
            //cmd é um comando que permite executar uma query no Banco da Dados
            SqlCommand cmd = new SqlCommand();          
                //conecta com o banco de dados
                cmd.Connection = connectionDB;
                //Cria a string SQL
                cmd.CommandText = @"INSERT INTO Pessoas VALUES (@Nome, @Email, @DataNascimento, @Senha, @Telefone); SELECT CAST(scope_identity() AS int)";
                //Colocando os dados recebidos no banco de dados
                cmd.Parameters.AddWithValue("@Nome", Pessoa.Nome);
                cmd.Parameters.AddWithValue("@Email", Pessoa.Email);
                cmd.Parameters.AddWithValue("@DataNascimento", Pessoa.DataNascimento);
                cmd.Parameters.AddWithValue("@Senha", Pessoa.Senha);
                cmd.Parameters.AddWithValue("@Telefone", Pessoa.Telefone);
                //Executa a string SQL

                object returnObj = cmd.ExecuteScalar();
                if (returnObj != null)
                {
                    int.TryParse(returnObj.ToString(), out returnValue);
                }
                return returnValue;
            }
            catch(Exception error)
            {
                return returnValue;
            }


        }
        //Read - SELECT
        public List<Pessoa> Read()
        {
            List<Pessoa> lista = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connectionDB;
                cmd.CommandText = @"SELECT p.*, pp.* FROM Professores p inner join Pessoas pp on p.professorid = pp.pessoaid ORDER BY Nome";
                SqlDataReader reader = cmd.ExecuteReader();

                lista = new List<Pessoa>();
                while(reader.Read())
                {
                    Pessoa pessoa = new Pessoa();
                    Professor Professor = new Professor();
                    pessoa.PessoaId = (int)reader["PessoaId"];
                    pessoa.Nome = (string)reader["Nome"];
                    pessoa.Email = (string)reader["Email"];
                    pessoa.Senha = (string)reader["Senha"];
                    Professor.Credito = (decimal)reader["Credito"];
                    Professor.ProfessorId = (int)reader["ProfessorId"];
                    lista.Add(pessoa);
                    lista.Add(Professor);
                }
            }
            catch(SqlException sqlerror )
            {

            }
            return lista;
        }
        //Read - SELECT (Faz a busca pelo ID da pessoa)
        //Sobrecarga
        public Pessoa Read(int id)
        {
            Pessoa pessoa = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"SELECT * FROM Pessoas WHERE Id = @id";
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                pessoa = new Pessoa();
                pessoa.PessoaId = (int)reader["IdPessoa"];
                pessoa.Nome = (string)reader["Nome"];
                pessoa.Email = (string)reader["Email"];
                pessoa.Senha = (string)reader["Senha"];
            }
            return pessoa;
        }
        public Pessoa Get(string email, string senha)
        {
            Pessoa pessoa = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"SELECT * FROM Pessoas WHERE email = @Email and senha = @senha";
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@senha", senha);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                pessoa = new Pessoa();
                pessoa.PessoaId = (int)reader["PessoaId"];
                pessoa.Nome = (string)reader["Nome"];
                pessoa.Email = (string)reader["Email"];
                pessoa.Senha = (string)reader["Senha"];
                pessoa.DataNascimento = (DateTime)reader["dataNascimento"];
                pessoa.Telefone = (string)reader["Telefone"];
            }
            return pessoa;
        }
        //Update - UPDATE
        public void Update(Pessoa pessoa)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"UPDATE Pessoas SET Nome = @Nome, Email = @Email, DataNascimento = @DataNascimento,
                                Senha = @senha WHERE IdPessao = @PessoaId";
            cmd.Parameters.AddWithValue("@Nome", pessoa.Nome);
            cmd.Parameters.AddWithValue("@Email", pessoa.Email);
            cmd.Parameters.AddWithValue("@DataNascimento", pessoa.DataNascimento);
            cmd.Parameters.AddWithValue("@Senha", pessoa.Senha);
            cmd.ExecuteNonQuery();
        }
        //Delete - DELETE
        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"DELETE FROM Pessoas WHERE @id = PessoaId";
            cmd.Parameters.AddWithValue("@PessoaId", id);
            cmd.ExecuteNonQuery();
        }
    }
}
