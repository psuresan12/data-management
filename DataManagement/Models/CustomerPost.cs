using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataManagement.Models
{
    public class CustomerPost
    {
        [Key]
        public int Post_ID { get; set; }
        
        
        public int Sender_ID { get; set; }
        public Customer Sender { get; set; }

        
        public int Receiver_ID { get; set; }
        public Customer Receiver { get; set; }

    }
}
