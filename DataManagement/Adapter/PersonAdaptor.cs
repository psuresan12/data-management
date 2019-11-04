using DataManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBLibrary;


namespace DataManagement.Adapter
{
    public class PersonAdaptor
    {

        private string _file,_sheetName;
        public PersonAdaptor(string file,string sheetName)
        {
            _file = file;
            _sheetName = sheetName;
        }

        public IEnumerable<Person> Execute()
        {
            
            var executor = new ExcelExecutor();
            var results = executor.Execute<Person>(_file, _sheetName);
            return results;

            
        }
    }
}
