using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public abstract class BaseEntidadDataTable
    {
        public long recordsTotal { get; set; }
        public long recordsFiltered { get; set; }
    }
}
