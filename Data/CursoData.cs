using MaisAprendizado.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.IO;
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
            cmd.CommandText = @"Exec AdicionarCurso @IdProfessor, @Nome, @Preco, @CargaHoraria";
            cmd.Parameters.AddWithValue("@IdProfessor", curso.PessoaId);
            cmd.Parameters.AddWithValue("@Nome", curso.Nome);
            cmd.Parameters.AddWithValue("@Preco", curso.Preco);
            cmd.Parameters.AddWithValue("@CargaHoraria", curso.CargaHoraria);
            cmd.ExecuteNonQuery();
        }
        public static byte[] GetPhoto(string filePath)
        {
            FileStream stream = new FileStream(
                filePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);

            byte[] photo = reader.ReadBytes((int)stream.Length);

            reader.Close();
            stream.Close();

            return photo;
        }
        //Read - SELECT
        public List<Curso> Read()
        {
            List<Curso> lista = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"SELECT c.*,p.nome as ProfessorNome FROM Cursos c left join pessoas p on p.pessoaId = c.professorId ORDER BY Nome";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Curso curso = new Curso();
                curso.IdCurso = (int)reader["CursoId"];
                curso.Nome = (string)reader["Nome"];
                curso.Preco = (decimal)reader["Preco"];
                curso.Preco = (decimal)reader["cargarHoraria"];
                curso.PessoaId = (int)reader["ProfessorId"];
                curso.ProfessorNome = (string)reader["ProfessorNome"];
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
            cmd.CommandText = @"SELECT c.*, p.Nome AS ProfessorNome FROM Cursos c LEFT JOIN Pessoas p
                                    ON c.ProfessorId = p.PessoaId";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Curso curso = new Curso();
                curso.IdCurso = (int)reader["CursoId"];
                curso.Nome = (string)reader["Nome"];
                curso.Preco = (decimal)reader["Preco"];
                curso.CargaHoraria = (decimal)reader["cargaHoraria"];
                curso.ProfessorNome = (string)reader["ProfessorNome"];
                curso.PessoaId = (int)reader["ProfessorId"];
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
        public List<Curso> buscarTodosCursoPorId(int id)
        {
            Pessoa pessoa = new Pessoa();
            List<Curso> lista = new List<Curso>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"Select c.*, ca.alunoId as id from Cursos c 
                                        left join compra_curso cc on c.CursoId = cc.CursoId
                                        left join compras ca on ca.CompraId = cc.CompraId
                                        where ca.AlunoId = @id";
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Curso curso = new Curso();
                curso.PessoaId = (int)reader["id"];
                curso.IdCurso = (int)reader["CursoId"];
                curso.Nome = (string)reader["Nome"];
                curso.Preco = (decimal)reader["Preco"];
                lista.Add(curso);
            }
            return lista;
        }
        public List<Curso> buscarTodosCursoCriadoPorId(int id)
        {
            Pessoa pessoa = new Pessoa();
            List<Curso> lista = new List<Curso>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"Select c.* from cursos c where c.ProfessorId = @id";
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Curso curso = new Curso();
                curso.PessoaId = (int)reader["ProfessorId"];
                curso.IdCurso = (int)reader["CursoId"];
                curso.Nome = (string)reader["Nome"];
                curso.Preco = (decimal)reader["Preco"];
                curso.CargaHoraria = (decimal)reader["CargaHoraria"];
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
            cmd.Parameters.AddWithValue("@IdCurso", curso.IdCurso);
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
