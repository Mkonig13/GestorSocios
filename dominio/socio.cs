using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class socio
    {
        public int id {  get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string documento { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string domicilio { get; set; }  
        public string telefonoContacto { get; set; }
        public string email { get; set; }

        public membresia Tipo { get; set; }


    }
}
