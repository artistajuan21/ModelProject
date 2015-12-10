using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Base
{
       public static class Excepciones
    {
        public static string getException(Exception ex)
        {
            string mensaje = string.Empty;
            if (ConfigurationManager.AppSettings["modoApp"].ToString() == "debug"){
                Excepciones.SaveLogs(ex);                
                return ex.Message.ToString();
            }
                
            else if (ConfigurationManager.AppSettings["modoApp"].ToString() == "release"){
                Excepciones.SaveLogs(ex);
                return "error";
            }
                
            else
                return "No se estableció un modo App";            
        }


        private static void SaveLogs(Exception ex) {
            
            string folderName = System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory)+"/Logs/"; 
            string nombreArchivo = "LOGS.txt";

            string contenido = "Fecha: " + System.DateTime.Now.ToString("yyyy_MMMM_dd__H:mm:ss") + "\r\n";
            contenido += "Error: " + ex.Message + "\r\n";

            string pathString = System.IO.Path.Combine(folderName);
            System.IO.Directory.CreateDirectory(pathString);

            System.IO.File.WriteAllText(pathString + nombreArchivo, contenido, UTF8Encoding.UTF8);
        }
    }
}

