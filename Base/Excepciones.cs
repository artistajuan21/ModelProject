using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
       public static class Excepciones
    {
        public static string getException(Exception ex)
        {
            string mensaje = string.Empty;
            if (ConfigurationManager.AppSettings["modoApp"].ToString() == "debug")
                return ex.Message.ToString();
            else if (ConfigurationManager.AppSettings["modoApp"].ToString() == "release")
                return "error";
            else
                return "No se estableció un modo App";            
        }
    }
}

