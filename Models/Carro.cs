using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sislocacao.Models
{
    public class Carro
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Porta { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Status { get; set; }
    }
}
