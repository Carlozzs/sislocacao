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
    internal class FuncionarioDAO
    {
        private static conexao _conn = new conexao();

        public void Insert(Funcionario func)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "insert into Funcionario values (null, @nome, @cpf, @rg, @data, @salario, @endereco, @celular, @funcao);";

                comando.Parameters.AddWithValue("@nome", func.Nome);
                comando.Parameters.AddWithValue("@cpf", func.CPF);
                comando.Parameters.AddWithValue("@rg", func.RG);
                comando.Parameters.AddWithValue("@data", func.DataNasc);
                comando.Parameters.AddWithValue("@salario", func.Salario);
                comando.Parameters.AddWithValue("@endereco", func.Endereco);
                comando.Parameters.AddWithValue("@celular", func.Celular);
                comando.Parameters.AddWithValue("@funcao", func.Funcao);

                var resultado = comando.ExecuteNonQuery();


                if (resultado == 0)
                {
                    throw new Exception("Deu erro no momento de inserir as informações");

                }
            }
            catch (Exception ex) { 
            
                throw ex;
            }
        }

        public List<Funcionario> List()
        {
            try
            {
                var comando = _conn.Query();

                var lista = new List<Funcionario>();

                comando.CommandText = "select * from Funcionario;";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var Funcionario = new Funcionario();
                    Funcionario.Id = reader.GetInt32("id_func");
                    Funcionario.Nome = DAOHelper.GetString(reader, "nome_func");
                    Funcionario.CPF = DAOHelper.GetString(reader, "cpf_func");
                    Funcionario.RG = DAOHelper.GetString(reader, "rg_func");
                    Funcionario.DataNasc = DAOHelper.GetDateTime(reader, "data_nascimento_func");
                    Funcionario.Salario = DAOHelper.GetDouble(reader, "salario_func");
                    Funcionario.Endereco = DAOHelper.GetString(reader, "endereco_func");
                    Funcionario.Celular = DAOHelper.GetString(reader, "celular_func");
                    Funcionario.Funcao = DAOHelper.GetString(reader, "funcao_func");

                    lista.Add(Funcionario);
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
