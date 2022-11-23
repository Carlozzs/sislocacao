using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sislocacao.Models
{
    public class Funcionario
    {
        public int Id {get; set; }
        public string Nome {get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string DataNasc { get; set; }
        public double Salario { get; set; }
        public string Endereco { get; set; }
        public string Celular { get; set; }
        public string Funcao { get; set; }
    }
}
