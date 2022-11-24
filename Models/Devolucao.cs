using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sislocacao.Models
{
    public class Devolucao
    {

        public int Id { get; set; }
        public DateTime? Data { get; set; }
        public DateTime? Hora { get; set; }
        public int KmRodados { get; set; }
        public int FkRetirada { get; set; }
        public int FkCar { get; set; }
        public string DataS { get; set; }
        public string HoraS { get; set; }

    }
}
