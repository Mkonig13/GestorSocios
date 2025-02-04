using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace datos.mailServices
{ 
    class support:servicioCorreo
    {
        public support() {

            senderMail = "matikonig13@hotmail.com";
            password = "Matifeli2001";
            host = "smtp.live.com";
            port = 587;
            ssl = true;
            inicializar();
        }
    }
}

