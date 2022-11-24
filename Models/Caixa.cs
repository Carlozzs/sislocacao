using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sislocacao.Models
{
    public class Caixa
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public string Valorpag { get; set; }
        public int fkPag { get; set; }
        public int fkCli { get; set; }
        public int fkDev { get; set; }
        public int fkFunc { get; set; }
    }
}
