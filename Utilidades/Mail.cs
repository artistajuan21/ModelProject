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

        public bool send(string strbody, List<string> emailList, string ruta, string asunto, string displayName)
        {
            SmtpClient client = new SmtpClient();
            string from = client.Credentials.GetCredential(client.Host.ToString(), client.Port, client.DeliveryMethod.ToString()).UserName.ToString();

            MailMessage msg = new MailMessage();
            int i = 0;
            foreach (var item in emailList)
            {
                msg.To.Add(new MailAddress(emailList.ElementAt(i).ToString(), displayName, UTF8Encoding.UTF8));
                i++;
            }
            msg.From = new MailAddress(from,displayName);
            msg.Subject = asunto;
            msg.Body = strbody.ToString();
            msg.IsBodyHtml = true;
            if(ruta!=null)
                msg.Attachments.Add(new Attachment(ruta.ToString()));
            
            client.Send(msg);
            //-----------------------
            return true;
        }
    }
}
