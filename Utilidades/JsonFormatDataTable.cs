using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public class JsonFormatDataTable
    {
        public int draw { get; set; }
        public long recordsTotal { get; set; }
        public long recordsFiltered { get; set; }
        public List<string[]> data { get; set; }
        public JsonFormatDataTable() {
            this.data = new List<string[]>();
        }
    }
}
