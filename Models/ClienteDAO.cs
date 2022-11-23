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
    internal class ClienteDAO
    {
        private static conexao _conn = new conexao();

        public void Insert(Cliente cliente)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "insert into cliente values(null, @nome, @EstadoCivil, @CPF, @RG, " +
                    "@DataNasc, @telefone);";

                comando.Parameters.AddWithValue("@nome", cliente.Nome);
                comando.Parameters.AddWithValue("@EstadoCivil", cliente.EstadoCivil);
                comando.Parameters.AddWithValue("@CPF", cliente.CPF);
                comando.Parameters.AddWithValue("@RG", cliente.RG);
                comando.Parameters.AddWithValue("@DataNasc", cliente.DataNascimento);
                comando.Parameters.AddWithValue("@telefone", cliente.Telefone);


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
        public void Update(Cliente cliente)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "update cliente set " +
                    "nome_cli = @nome, cpf_cli = @CPF, rg_cli = @RG, " +
                    "telefone_cli = @telefone, estado_civil_cli = @EstadoCivil, data_nascimento_cli = @DataNasc where (id_cli = @id);";
      
                comando.Parameters.AddWithValue("@id", cliente.Id);
                comando.Parameters.AddWithValue("@nome", cliente.Nome);
                comando.Parameters.AddWithValue("@EstadoCivil", cliente.EstadoCivil);
                comando.Parameters.AddWithValue("@CPF", cliente.CPF);
                comando.Parameters.AddWithValue("@RG", cliente.RG);
                comando.Parameters.AddWithValue("@DataNasc", cliente.DataNascimento);
                comando.Parameters.AddWithValue("@telefone", cliente.Telefone);


                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao atualizar as informações");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Cliente> List()
        {
            try
            {
                var lista = new List<Cliente>();
                var comando = _conn.Query();

                comando.CommandText = "select * from cliente;";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var cliente = new Cliente();
                    cliente.Id = reader.GetInt32("id_cli");
                    cliente.Nome = DAOHelper.GetString(reader, "nome_cli");
                    cliente.CPF = DAOHelper.GetString(reader, "cpf_cli");
                    cliente.RG = DAOHelper.GetString(reader, "rg_cli");
                    cliente.Telefone = DAOHelper.GetString(reader, "telefone_cli");
                    cliente.EstadoCivil = DAOHelper.GetString(reader, "estado_civil_cli");
                    cliente.DataNascimento = DAOHelper.GetDateTime(reader, "data_nascimento_cli");

                    lista.Add(cliente);
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

            comando.CommandText = "select id_cli from Cliente where (nome_cli = @nome);";

            comando.Parameters.AddWithValue("@nome", nome);

            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                var Cliente = new Cliente();
                Cliente.Id = reader.GetInt32("id_cli");

                Id = Cliente.Id;

            }

            reader.Close();

            return Id;
        }

    }
}
