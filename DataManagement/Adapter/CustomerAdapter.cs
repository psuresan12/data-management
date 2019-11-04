using DataManagement.Controllers.Business;
using DataManagement.Converter;
using DataManagement.Models.ViewModel;
using DataManagement.QueryBuilder;
using DataManagement.ViewModel;
using DBLibrary;
using System;
using System.Collections.Generic;

namespace DataManagement.Adapter
{
    public class CustomerAdapter
    {
        private IBuilder builder;
        private QueryExecutor executor;

        public CustomerAdapter(string connectionString, bool isOracleDatabase)
        {
            builder = new CustomerBuilder(isOracleDatabase);
            executor = new QueryExecutor(connectionString, isOracleDatabase);
        }

        private List<CustomerViewModel> ParseResponse(List<Dictionary<string, string>> dataDictionary)
        {
            List<CustomerViewModel> customers = new List<CustomerViewModel>();

            foreach (var item in dataDictionary)
                customers.Add(
                    DictionaryConverter.DictionaryToObject<CustomerViewModel>(item));

            return customers;
        }

       
        public List<Dictionary<string, string>> GetDictionary<V>(V request)
        {
             var command = builder.CreateCommand(request);
             return  executor.Execute(command);

        }

        public List<CustomerViewModel> GetViewModel<V>(V request)
        {
            var dataDictionary = GetDictionary(request);
            return ParseResponse(dataDictionary);

        }
            

       

        

 



    }
}
