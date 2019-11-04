using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataManagement.Builder
{
    public class StaticQuery
    {
        public static string GetQuery(QueryBank queryBank)
        {
            switch (queryBank)
            {
                case QueryBank.AllActiveCustomers:
                    return "SelectAllCustomers";

                case QueryBank.CustomerById:
                    return "GetCustomerById";

                case QueryBank.SenderDetailsByPostStatus:
                    return "GetCustomersByPostStatusProcedure";

                case QueryBank.PostDetailsBySenderId:
                    return "GetPostsByCustomerWhoCreatedItProcedure";

                case QueryBank.SenderAndReceiverWithPostNotDelivered:
                    return "GetFullDetailsWithPostNotDeliveredProcedure";

                case QueryBank.GetCustomer:
                    return "GetCustomer";

                default:
                    return "SelectAllCustomers";

            }
        }
    }
}
