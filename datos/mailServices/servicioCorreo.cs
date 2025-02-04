using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace datos.mailServices
{
    public abstract class servicioCorreo
    {
        private SmtpClient cliente;
        protected string senderMail { get; set; }
        protected string password { get; set; }
        protected string host { get; set; }
        protected int port { get; set; }
        protected bool ssl { get; set; }

        protected void inicializar()
        {
            cliente = new SmtpClient();
            cliente.Credentials = new NetworkCredential(senderMail, password);
            cliente.Host = host;
            cliente.Port = port;
            cliente.EnableSsl = ssl;
        }

        public void sendMail (string subject, string body, List<string> to)
        {
           // var mailMessage = new MailMessage();
            try
            {

                var fromAddress = new MailAddress("matikonig13@gmail.com", "Matias");
                const string fromPassword = "Matifeli123";
                string smtpHost = "smtp.gmail.com";
                int smtpPort = 587;

                var smtp = new SmtpClient
                {
                    Host = smtpHost,
                    Port = smtpPort,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)

                };

                using (var message = new MailMessage())
                {
                    message.From = fromAddress;
                    foreach (var recipient in to)
                    {
                        message.To.Add(recipient);
                    }
                    message.Subject = subject;
                    message.Body = body;
                    smtp.Send(message);
                }

                /*
                mailMessage.From = new MailAddress(senderMail);
                foreach(string mail in to)
                {
                    mailMessage.To.Add(mail);
                }
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.Priority = MailPriority.Normal;
                cliente.Send(mailMessage);*/

            }
            catch (Exception ex)
            {

                throw ex;
            }
            /*finally
            {
                mailMessage.Dispose();
                cliente.Dispose();
            }*/
        }
    }
}
