using DataManagement.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataManagement.Request
{
    /// <summary>
    /// Accepts Any query and returns IDictionary<string,string>
    /// </summary>
    public class GetResultForQueryOrStoreProc
    {
        //To accept complete query
        public QueryType QueryType { get; set; }
        public string QueryString { get; set; } 


    }
}
