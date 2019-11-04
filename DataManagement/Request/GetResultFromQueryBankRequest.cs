using DataManagement.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataManagement.Request
{
    public class GetResultFromQueryBankRequest
    {
        public QueryBank QueryBank { get; set; }
        public Dictionary<string,string> Parameters { get; set; }

        
    }
}
