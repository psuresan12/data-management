using Ganss.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBLibrary
{
   public class ExcelExecutor
    {
        public IEnumerable<T> Execute<T>(string file,string sheetName) where T : new()
        {
           var results = new ExcelMapper(file).Fetch<T>(sheetName);
           return results;
        }

       
    }
}
