using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sislocacao.bancodados;
using MySql.Data.MySqlClient;
using sislocacao.Helpers;

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

                comando.Parameters.AddWithValue("@data", devolucao.DataS);
                comando.Parameters.AddWithValue("@hora", devolucao.HoraS);
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
        public int IdCli(Devolucao dev)
        {
            try
            {
                var id = 0;

                var comando = _conn.Query();

                comando.CommandText = "Select id_cli_fk as idClI from Retirada where (id_ret = @id);";

                comando.Parameters.AddWithValue("@id", dev.FkRetirada);
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt32("idCli");
                }
                reader.Close();
                
                return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            

        }
        public int IdFunc(Devolucao dev)
        {
            try
            {
                var id = 0;

                var comando = _conn.Query();

                comando.CommandText = "Select id_func_fk as idFunc from Retirada where (id_ret = @id);";

                comando.Parameters.AddWithValue("@id", dev.FkRetirada);
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt32("idFunc");
                }
                reader.Close();

                return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }



        }
        public int IdDev()
        {
            try
            {
                var id = 0;

                var comando = _conn.Query();

                comando.CommandText = "Select max(id_dev) as idDev from Devolucao;";

                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt32("idDev");
                }
                reader.Close();

                return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }



        }
    }
   
    
}
