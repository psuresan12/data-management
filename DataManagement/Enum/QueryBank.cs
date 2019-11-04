using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataManagement.Builder
{
    public enum QueryBank
    {

        CustomerById,
        SenderDetailsByPostStatus,
        PostDetailsBySenderId,
        SenderAndReceiverWithPostNotDelivered,
        AllActiveCustomers,
        GetCustomer



    }
}
