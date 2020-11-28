using MaisAprendizado.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MaisAprendizado.Data
{
    public class AulaGravadaData : Data
    {
        //Create - INSERT
        public void Create(AulaGravada aula)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"INSERT INTO Aula_gravada VALUES(@AulaId, @CursoId, @Titulo, @Descricao)";//Inserir tambem no curso espcifico
            cmd.Parameters.AddWithValue("@AulaId", aula.AulaId);
            cmd.Parameters.AddWithValue("@Titulo", aula.Titulo);
            cmd.Parameters.AddWithValue("@Descricao", aula.Descricao);
            cmd.ExecuteNonQuery();
        }
        //Read - SELECT
        public AulaGravada Read(int id)
        {
            AulaGravada aulagravada = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"SELECT * FROM Aula_Gravada WHERE AulaId = @id";
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                aulagravada = new AulaGravada();
                aulagravada.AulaId = (int)reader["AulaId"];
                aulagravada.Titulo = (string)reader["Titulo"];
                aulagravada.Descricao = (string)reader["Descricao"];
            }
            return aulagravada;
        }
        //Update - UPDATE
        public void Update(AulaGravada aula)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"UPDATE Aula_Gravada SET Titulo = @Titulo, Descricao = @Descricao";
            cmd.Parameters.AddWithValue("@Titulo", aula.Titulo);
            cmd.Parameters.AddWithValue("@Descricao", aula.Descricao);
            cmd.ExecuteNonQuery();
        }
        //Delete - DELETE
        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"DELETE FROM Aula_Gravada WHERE @id =AulaId";
            cmd.Parameters.AddWithValue("@AulaId", id);
            cmd.ExecuteNonQuery();
        }
    }
}
