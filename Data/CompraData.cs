using MaisAprendizado.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
namespace MaisAprendizado.Data
{
    public class CompraData : Data
    {
        public void Create(Compra compra, int aluno)
        {
            dynamic id = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connectionDB;
            cmd.CommandText = @"Exec adicionarCompra @PessoaId, @Valor";
            cmd.Parameters.AddWithValue("@PessoaId", compra.AlunoId);
            cmd.Parameters.AddWithValue("@Valor", compra.Preco);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    id = reader["CompraId"];

                }
            }
            cmd.CommandText = @"Exec AdicionarCompraCurso @CompraId, @CursoId,@Valor";
            cmd.Parameters.AddWithValue("@CompraId", id);
            cmd.Parameters.AddWithValue("@CursoId", compra.IdCurso);
            cmd.ExecuteNonQuery();



        }
    }
}
