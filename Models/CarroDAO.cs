using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using sislocacao.bancodados;
using sislocacao.Helpers;

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

        public List<Carro> List()
        {
            try
            {
                var comando = _conn.Query();

                var lista = new List<Carro>();

                comando.CommandText = "select * from Carro;";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var Carro = new Carro();
                    Carro.Id = reader.GetInt32("id_car");
                    Carro.Modelo = DAOHelper.GetString(reader, "modelo_car");
                    Carro.Cor = DAOHelper.GetString(reader, "cor_car");
                    Carro.Porta = DAOHelper.GetString(reader, "portas_car");
                    Carro.Placa = DAOHelper.GetString(reader, "placa_car");
                    Carro.Marca = DAOHelper.GetString(reader, "marca_car");
                    Carro.Status = DAOHelper.GetString(reader, "status_car");

                    lista.Add(Carro);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int PegarId(string nome)
        {
            var comando = _conn.Query();

            int Id = 0;

            comando.CommandText = "select id_car from Carro where (modelo_car = @nome);";

            comando.Parameters.AddWithValue("@nome", nome);

            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                var Carro = new Carro();
                Carro.Id = reader.GetInt32("id_car");

                Id = Carro.Id;

            }

            reader.Close();

            return Id;
        }
    }
}
