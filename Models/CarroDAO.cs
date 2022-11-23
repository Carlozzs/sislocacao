using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sislocacao.bancodados;

namespace sislocacao.Models
{
    internal class CarroDAO
    {
        private static conexao _conn = new conexao();

        public void Insert(Carro carro)
        {
            
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "insert into Carro values (null, @modelo, @cor, @portas, @placa, @marca, @status);";

                comando.Parameters.AddWithValue("@modelo", carro.Modelo);
                comando.Parameters.AddWithValue("@cor", carro.Cor);
                comando.Parameters.AddWithValue("@portas", carro.Porta);
                comando.Parameters.AddWithValue("@placa", carro.Placa);
                comando.Parameters.AddWithValue("@marca", carro.Marca);
                comando.Parameters.AddWithValue("@status", carro.Status);
                

                var resultado = comando.ExecuteNonQuery();


                if (resultado == 0)
                {
                    throw new Exception("Deu erro no momento de inserir as informações");

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
