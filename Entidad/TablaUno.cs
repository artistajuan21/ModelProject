//------------------------------------------------------------------------------
// Author: Julio Becerra Urbina 
// Fecha: 2015_diciembre_02 - 11_08_12 
//-------------------------  TablaUno  ----------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class TablaUno : BaseEntidadDataTable
    {
        public Int64 id { get; set; }
        
        public string nombre { get; set; }
        public string unico { get; set; }
        public System.DateTime fechaCreacion { get; set; }
        public System.DateTime fecha { get; set; }
        public Int16 condicion { get; set; }
        public TimeSpan hora { get; set; }
        public Int32 numero { get; set; }
        public Int32 idTablaDos { get; set; }
        public TablaDos TablaDos { get; set; }
        public bool esActivo { get; set; }
    }
}
