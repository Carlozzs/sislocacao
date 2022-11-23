﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sislocacao.bancodados;

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
    }
}
