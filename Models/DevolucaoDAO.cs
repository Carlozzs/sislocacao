using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sislocacao.bancodados;

namespace sislocacao.Models
{
    internal class DevolucaoDAO
    {
        private static conexao _conn = new conexao();

        public void Insert(Devolucao devolucao)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Insert into Devolucao values (null, @data, @hora, @km, @fkret, @fkcar)";

                comando.Parameters.AddWithValue("@data", devolucao.Data);
                comando.Parameters.AddWithValue("@hora", devolucao.Hora);
                comando.Parameters.AddWithValue("@km", devolucao.KmRodados);
                comando.Parameters.AddWithValue("@fkret", devolucao.FkRetirada);
                comando.Parameters.AddWithValue("@fkcar", devolucao.FkCar);


                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Deu erro no momento de salvar as informações");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
