using MySql.Data.MySqlClient;
using sislocacao.bancodados;
using sislocacao.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sislocacao.Models
{
    internal class CaixaDAO
    {
        private static conexao _conn = new conexao();

        public void Insert(Caixa caixa)
        {

            try
            {
                var comando = _conn.Query();

                comando.CommandText = "insert into Caixa values (null, @data, @valorpag, @fkPag, @fkFunc, @fkCli, @fkDev);";

                comando.Parameters.AddWithValue("@data", caixa.Data);
                comando.Parameters.AddWithValue("@valorpag", caixa.Valorpag);
                comando.Parameters.AddWithValue("@fkPag", caixa.fkPag);
                comando.Parameters.AddWithValue("@fkFunc", caixa.fkFunc);
                comando.Parameters.AddWithValue("@fkCli", caixa.fkCli);
                comando.Parameters.AddWithValue("@fkDev", caixa.fkDev);


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

        public List<Caixa> List()
        {
            try
            {
                var comando = _conn.Query();

                var lista = new List<Caixa>();

                comando.CommandText = "select * from Caixa;";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var Caixa = new Caixa();
                    Caixa.Id = reader.GetInt32("id_cai");
                    Caixa.Data = DAOHelper.GetString(reader, "data_cai");
                    Caixa.Valorpag = DAOHelper.GetString(reader, "valorpag_cai");
                    Caixa.fkPag = reader.GetInt32("id_pag_fk");
                    Caixa.fkPag = reader.GetInt32("id_func_fk");
                    Caixa.fkCli = reader.GetInt32("id_cli_fk");
                    Caixa.fkDev = reader.GetInt32("id_dev_fk");

                    lista.Add(Caixa);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
