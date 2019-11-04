using DataManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataManagement.ViewModel
{
    public class CustomerPostViewModel
    {
        public Sender Sender { get; set; }
        public Post Post { get; set; }
        public Receiver Receiver { get; set; }
    }


    public class Sender
    {
        public int Sender_ID { get; set; }

        public string Sender_Name { get; set; }

        public string Sender_Email { get; set; }
    }


    public class Receiver
    {
        public int Receiver_ID { get; set; }

        public string Receiver_Name { get; set; }

        public string Receiver_Email { get; set; }
    }
}
