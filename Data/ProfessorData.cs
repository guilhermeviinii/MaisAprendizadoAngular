using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MaisAprendizado.Models;

namespace MaisAprendizado.Data
{
    public class ProfessorData : Data
    {
        //Create - INSERT
       
        public void Create(Professor professor)
        {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connectionDB;
                cmd.CommandText = @"EXEC AdicionarProfessor @Nome, @Email, @dataNascimento, @senha, @telefone";
                cmd.Parameters.AddWithValue("@Nome", professor.Nome);
                cmd.Parameters.AddWithValue("@Email", professor.Email);
                cmd.Parameters.AddWithValue("@dataNascimento", professor.DataNascimento);
                cmd.Parameters.AddWithValue("@senha", professor.Senha);
                cmd.Parameters.AddWithValue("@telefone", professor.Telefone);
                cmd.ExecuteNonQuery();
        }
        //Read - SELECT
        public List<Professor> Read()
        {
            List<Professor> lista = new List<Professor>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"SELEC * FROM Professores ORDER BY Nome";
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Professor professor = new Professor();
                professor.PessoaId = (int)reader["PessoaId"];
                professor.Nome = (string)reader["Nome"];
                professor.Email = (string)reader["Email"];
                professor.Senha = (string)reader["Senha"];

                lista.Add(professor);
            }
            return lista;
        }
        //Read - SELECT (id)
        public Professor Read(int id)
        {
            Professor professor = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"SELECT * FROM Professor WHERE @id = Id";
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                professor = new Professor();
                professor.PessoaId = (int)reader["Id"];
                professor.Nome = (string)reader["Nome"];
                professor.Email = (string)reader["Email"];
                professor.Senha = (string)reader["Senha"];
            }
            return professor;
        }
        //Updae - UPDATE
        public void Update(Professor professor)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"EXEC AlterarProfessor";
            cmd.Parameters.AddWithValue("@Nome", professor.Nome);
            cmd.Parameters.AddWithValue("@Email", professor.Email);
            cmd.Parameters.AddWithValue("@DataNascimento", professor.DataNascimento);
            cmd.Parameters.AddWithValue("@Senha", professor.Senha);
            cmd.ExecuteNonQuery();
        }
        //Delete - DELETE
        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"DELETE FROM Pessoas WHERE @id = Id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
