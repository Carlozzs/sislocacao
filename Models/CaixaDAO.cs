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

        public void Delete(Caixa Caixa)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "DELETE FROM Caixa WHERE (id_cai = @id)";

                comando.Parameters.AddWithValue("@id", Caixa.Id);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao deletar as informações");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Update(Caixa caixa)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "update Caixa set " +
                    "data_cai = @data, valorpag_cai = @valorpag, id_pag_fk = @fkPag, id_func_fk = @fkFunc, id_cli_fk = @fkCli, id_dev_fk = @fkDev where id_cai = @id;";

                comando.Parameters.AddWithValue("@id", caixa.Id);
                comando.Parameters.AddWithValue("@data", caixa.Data);
                comando.Parameters.AddWithValue("@valorpag", caixa.Valorpag);
                comando.Parameters.AddWithValue("@fkPag", caixa.fkPag);
                comando.Parameters.AddWithValue("@fkFunc", caixa.fkFunc);
                comando.Parameters.AddWithValue("@fkCli", caixa.fkCli);
                comando.Parameters.AddWithValue("@fkDev", caixa.fkDev);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
