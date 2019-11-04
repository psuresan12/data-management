using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataManagement.Request
{
    public class ExcelReaderRequest
    {
        public string fileName { get; set; }
        public string sheetName { get; set; }
    }
}
