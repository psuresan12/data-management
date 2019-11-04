using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataManagement.Models
{
    public class Customer
    {
        
        
            [Key]
            public int Customer_ID { get; set; }

            public string Customer_Name { get; set; }

            public string Email { get; set; }

            public List<CustomerPost> CustomerPosts { get; set; }
            

            
    }
}
