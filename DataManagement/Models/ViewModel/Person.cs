using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataManagement.Models.ViewModel
{
    public class Person
    {
        public int Id { get;  set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }
        public bool IsSenior { get; set; }
             
    }
}
