using sislocacao.bancodados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using sislocacao.Helpers;

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
        public List<Retirada> list()
        {
            try
            {
                var comando = _conn.Query();

                var lista = new List<Retirada>();

                comando.CommandText = "select * from Retirada;";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var Retirada = new Retirada();
                    Retirada.Id = reader.GetInt32("id_ret");
                    Retirada.id_func_fk = reader.GetInt32("id_func_fk");
                    Retirada.dataHora = DAOHelper.GetDateTime(reader, "dataHora");
                    Retirada.id_cli_fk = reader.GetInt32("id_cli_fk");
                    Retirada.id_car_fk = reader.GetInt32("id_car_fk");
                    

                    lista.Add(Retirada);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Devolucao devolucao)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText= "delete from Retirada where (id_ret = @id)";

                comando.Parameters.AddWithValue("@id", devolucao.FkRetirada);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Não foi possivel excluir o registro de retirada");
                }

            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }
        
    }
    
}
