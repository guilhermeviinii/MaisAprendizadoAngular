using MaisAprendizado.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MaisAprendizado.Data
{
    public class CursoData : Data
    {
        //Create - INSERT
        public void Create(Curso curso)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"EXEC AdicionarCurso @IdProfessor, @Nome, @Preco, @CargaHoraria";
            cmd.Parameters.AddWithValue("@IdProfessor", curso.PessoaId);
            cmd.Parameters.AddWithValue("@Nome", curso.Nome);
            cmd.Parameters.AddWithValue("@Preco", curso.Preco);
            cmd.Parameters.AddWithValue("@CargaHoraria", curso.CargaHoraria);
            cmd.ExecuteNonQuery();
        }
        //Read - SELECT
        public List<Curso> Read()
        {
            List<Curso> lista = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"SELECT * FROM Cursos ORDER BY Nome";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Curso curso = new Curso();
                curso.IdCurso = (int)reader["CursoId"];
                curso.Nome = (string)reader["Nome"];
                curso.Preco = (decimal)reader["Preco"];
                curso.IdPessoa = (int)reader["ProfessorId"];
                lista.Add(curso);
            }
            return lista;
        }
        //Read - SELECT (por nome)
        public List<Curso> Consulta()
        {
            Pessoa pessoa = new Pessoa();
            List<Curso> lista = new List<Curso>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"SELECT c.*, p.Nome AS Professor FROM Cursos c LEFT JOIN Pessoas p
                                    ON c.ProfessorId = p.PessoaId";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Curso curso = new Curso();
                curso.IdCurso = (int)reader["CursoId"];
                curso.Nome = (string)reader["Nome"];
                curso.Preco = (decimal)reader["Preco"];
                pessoa.Nome = (string)reader["Professor"];
                lista.Add(curso);
            }
            return lista;
        }
        public List<Curso> BuscarCursoPorNome(string nome)
        {
            nome = nome + "%";
            Pessoa pessoa = new Pessoa();
            List<Curso> lista = new List<Curso>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"select * from Cursos where nome like upper(@nomeCurso)";
            cmd.Parameters.AddWithValue("@nomeCurso", nome);
             SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Curso curso = new Curso();
                curso.IdCurso = (int)reader["CursoId"];
                curso.Nome = (string)reader["Nome"];
                curso.Preco = (decimal)reader["Preco"];
                lista.Add(curso);
            }
            return lista;
        }
        //Update - UPDATE
        public void Update(Curso curso)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"UPDATE Cursos SET Nome = @Nome, Preco = @Preco, CargaHoraria = @CargaHoraria 
                                    WHERE CursoId = @IdCurso";
            cmd.Parameters.AddWithValue("@Nome", curso.Nome);
            cmd.Parameters.AddWithValue("@Preco", curso.Preco);
            cmd.Parameters.AddWithValue("@CargaHoraria", curso.CargaHoraria);
            cmd.ExecuteNonQuery();
        }
        //Delete - DELETE
        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"DELETE FROM Cursos WHERE @id = CursoId";
            cmd.Parameters.AddWithValue("@CursoId", id);
            cmd.ExecuteNonQuery();
        }
    }
}
