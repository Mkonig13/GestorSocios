using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class membresia
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public int Valor { get; set; }

        public override string ToString()
        {
            return Tipo;
        }
    }
}
