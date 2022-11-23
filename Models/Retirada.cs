using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sislocacao.Models
{
    public class Retirada
    {
        public string Nome { get; set; }

        public DateTime? dataHora { get; set; }
        public string dataHora2 { get; set; }
        public int id_func_fk { get; set; }
        public int id_cli_fk { get; set; }
        public int id_car_fk { get; set; }
        public int KmRodados { get; set; }


    }
}
