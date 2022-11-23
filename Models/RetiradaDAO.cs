using sislocacao.bancodados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sislocacao.Models
{
    internal class RetiradaDAO
    {
        private static conexao _conn = new conexao();

        public void Insert(Retirada retirada)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "insert into Retirada values (null, @dataHora, @funcFk, @cliFk, @carFk);";

                comando.Parameters.AddWithValue("@dataHora", retirada.dataHora2) ;
                comando.Parameters.AddWithValue("@funcFk", retirada.id_func_fk);
                comando.Parameters.AddWithValue("@cliFk", retirada.id_cli_fk);
                comando.Parameters.AddWithValue("@carFk", retirada.id_car_fk);

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
