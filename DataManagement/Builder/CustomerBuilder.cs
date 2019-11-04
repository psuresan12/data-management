using DataManagement.Builder;
using DataManagement.Models.ViewModel;
using DataManagement.QueryBuilder;
using DataManagement.Request;
using DataManagement.ViewModel;
using DBLibrary;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DataManagement.Controllers.Business
{
    public class CustomerBuilder : AbstractBuilder
    {
        //List of Parameters:
        public const string Id = "Id";
        public const string CustomerId = "CustomerId";
        public const string CustomerName = "CustomerName";
        public const string CustomerEmail = "CustomerEmail";



        public CustomerBuilder(bool isOracleDatabase) : base(isOracleDatabase)
        {
        }


        public override DbCommand CreateCommand<T>(T request)
        {
            switch (request)
            {
               
                case GetResultForQueryOrStoreProc queryOrStoreProcRequest:
                    if (queryOrStoreProcRequest.QueryType.Equals(QueryType.SQLQuery))
                        BuildQuery(queryOrStoreProcRequest.QueryString);
                    else if (queryOrStoreProcRequest.QueryType.Equals(QueryType.StoredProcedure))
                            BuildStoredProc(queryOrStoreProcRequest.QueryString);
                    break;

                case CustomerViewModel customerViewModel:
                    BuildStoredProc(StaticQuery.GetQuery(QueryBank.GetCustomer));
                    BuildCustomerParameters(customerViewModel);
                    break;

                case GetResultFromQueryBankRequest queryBankRequest:
                    BuildFromQueryBank(queryBankRequest.QueryBank);
                    BuildParametersFromDictionary(queryBankRequest.Parameters);
                    break;
            }

            return builder.Build();
        }

       


        private void BuildFromQueryBank(QueryBank queryBank)
        {
            BuildStoredProc(StaticQuery.GetQuery(queryBank));
        }

        private void BuildParametersFromDictionary(Dictionary<string, string> parameters)
        {
            foreach (KeyValuePair<string, string> entry in parameters)
            {
                if (entry.Key.Contains(Id))
                    BuildParam(entry.Key, Convert.ToInt32(entry.Value));
                else
                    BuildParam(entry.Key, entry.Value);
            }

        }

        private void BuildCustomerParameters(CustomerViewModel customerViewModel)
        {
            BuildParam(CustomerId, customerViewModel.Customer_ID);
           
            if (customerViewModel.Customer_Name != null)
                BuildParam(CustomerName, customerViewModel.Customer_Name);   
            else
                BuildParam(CustomerName, String.Empty);

            if (customerViewModel.Email != null)
                BuildParam(CustomerEmail, customerViewModel.Email);
            else
                BuildParam(CustomerEmail, String.Empty);

        }

    }
}
