using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Utilidades;

namespace Base
{
       public static class Excepciones
    {
        public static string getException(Exception ex)
        {
            string mensaje = string.Empty;
            if (ConfigurationManager.AppSettings["modoApp"].ToString() == "debug"){
                SaveLogs(ex);                
                return ex.Message.ToString();
            }
                
            else if (ConfigurationManager.AppSettings["modoApp"].ToString() == "release"){
                SaveLogs(ex); 
                return "error";
            }
                
            else
                return "No se estableció un modo App";            
        }


        private static void SaveLogs(Exception ex) {
            
            string folderName = System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory)+"/Logs/";
            string nombreArchivo = "LOGS_"+System.DateTime.Now.ToString("yyyy_MMMM_dd") + ".txt";

            string contenido = "Fecha: " + System.DateTime.Now.ToString("yyyy_MMMM_dd__H:mm:ss") + "\r\n";
            contenido += "Error: " + ex.Message + "\r\n";

            string pathString = System.IO.Path.Combine(folderName);
            System.IO.Directory.CreateDirectory(pathString);

            System.IO.File.AppendAllText(pathString + nombreArchivo, contenido, UTF8Encoding.UTF8);

            List<string> listaCorreos=new List<string>();

            listaCorreos.Add("juanbenitezlavado@hotmail.com");
            listaCorreos.Add("julioc_18@hotmail.com");

            Mail.Instancia.send(GenerarCustomErrorMessage(ex), listaCorreos, null, "Excepcion en la Aplicación", "App_Log");

        }

        private static string GenerarCustomErrorMessage(Exception ex){

            string completeMessage="";            
            completeMessage += "<table>";
            completeMessage += "<tr><td>";
            completeMessage +="Origen: "+ex.Source+"";
            completeMessage += "</td></tr>";
            completeMessage += "<tr><td>";
            completeMessage +="Exception Message: "+ex.Message+"";
            completeMessage += "</td></tr>";
            completeMessage += "<tr><td>";
            completeMessage +="StackTrace: "+ex.StackTrace;
            completeMessage += "</td></tr>";
            completeMessage += "</table>";

            return completeMessage;
        }
    }
}

