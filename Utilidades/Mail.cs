using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public class Mail
    {
        private static Mail _instancia;
        public static Mail Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new Mail();
                return _instancia;
            }
        }
        protected Mail() { }

        public bool send(string strbody, List<string> emailList, string ruta, string asunto, string displayName,string email,string clave)
        {
            ///////////
            MailMessage msg = new MailMessage();
            int i = 0;
            foreach (var item in emailList)
            {
                msg.To.Add(new MailAddress(emailList.ElementAt(i).ToString(), displayName, UTF8Encoding.UTF8));
                i++;
            }
            msg.From = new MailAddress(email,displayName);
            msg.Subject = asunto;
            msg.Body = strbody.ToString();
            msg.IsBodyHtml = true;
            msg.Attachments.Add(new Attachment(ruta.ToString()));
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(email, clave);
            client.Port = 587; // You can use Port 25 if 587 is blocked (mine is!)
            client.Host = "smtp.office365.com";
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Send(msg);
            //-----------------------
            return true;
        }
    }
}
