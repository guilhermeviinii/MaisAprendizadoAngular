using MaisAprendizado.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MaisAprendizado.Data
{
    public class CompraCursoData : Data
    {
        //Create - INSERT
        public void Create(CompraCurso compracurso, int IdCurso, int IdCompra)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"INSERT INTO Compra_Curso VALUES(@CompraId, @CursoId, @Quantidade, @Status, @Valor)";
            cmd.Parameters.AddWithValue("@CompraId", IdCompra);
            cmd.Parameters.AddWithValue("@CursoId", IdCurso);
            cmd.Parameters.AddWithValue("@Quantidade", compracurso.Quantidade);
            cmd.Parameters.AddWithValue("@Status", compracurso.Status);
            cmd.Parameters.AddWithValue("@Valor", compracurso.Status);
            cmd.ExecuteNonQuery();
        }
        //Read - 
        public List<CompraCurso> Read()
        {
            List<CompraCurso> lista = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"SELECT cc.* FROM Compra_Curso cc LEFT JOIN Compras c.CompraId = cc.CompraId ORDER BY c.DataCompra";
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                CompraCurso compracurso = new CompraCurso();
                compracurso.IdCompra = (int)reader["CompraId"];
                compracurso.IdCurso = (int)reader["CursoId"];
                compracurso.Quantidade = (int)reader["Quantidade"];
                compracurso.Status = (int)reader["Status"];
                compracurso.Valor = (decimal)reader["Valor"];
            }
            return lista;
        }
        //Update
        public void Update(CompraCurso compracurso)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"UPDATE Compra_Curso SET Quantidade = @Quantidade, Status = @Status, Valor = @Valor";
            cmd.Parameters.AddWithValue("@Quantidade", compracurso.Quantidade);
            cmd.Parameters.AddWithValue("@Status", compracurso.Status);
            cmd.Parameters.AddWithValue("@Valor", compracurso.Valor);
            cmd.ExecuteNonQuery();
        }
        
    }
}
