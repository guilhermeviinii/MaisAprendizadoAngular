using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MaisAprendizado.Models;
namespace MaisAprendizado.Data
{
    public class AlunoData : Data
    {
        //Create - INSERT
        public void Create(Aluno aluno)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"EXEC AdicionarAluno @Nome, @Email, @DataNascimetno, @Senha, @Telefone";
            cmd.Parameters.AddWithValue("@Nome", aluno.Nome);
            cmd.Parameters.AddWithValue("@Email", aluno.Email);
            cmd.Parameters.AddWithValue("@DataNascimento", aluno.DataNascimento);
            cmd.Parameters.AddWithValue("@Senha", aluno.Senha);
            cmd.Parameters.AddWithValue("@Nome", aluno.Telefone);
            cmd.ExecuteNonQuery();
        }
        //Read - SELECT
        public List<Aluno> Read()
            
        {
            List<Aluno> lista = null;
            lista = new List<Aluno>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"SELECT * FROM Alunos ORDER BY Nome";
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Aluno aluno = new Aluno();
                aluno.Nome = (string)reader["Nome"];
                aluno.Email = (string)reader["Email"];
                aluno.Senha = (string)reader["Senha"];
                lista.Add(aluno);
            }
            return lista;
        }
        //Read -SELECT (por id)
        public Aluno Read(int id)
        {
            Aluno aluno = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"SELECT * FROM Alunos WHERE @id = AlunoId";
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read());
            {
                aluno = new Aluno();
                aluno.PessoaId = (int)reader["AlunoId"];
                aluno.Nome = (string)reader["Nome"];
                aluno.Email = (string)reader["Email"];
                aluno.Senha = (string)reader["Senha"];
            }
            return aluno;
        }
        //Criar Update de aluno
        //Delete - DELETE
        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"DELETE FROM Pessoas WHERE @id = IdPessoa";
            cmd.Parameters.AddWithValue("@IdPessoa", id);
            cmd.ExecuteNonQuery();
        }
    }
}
