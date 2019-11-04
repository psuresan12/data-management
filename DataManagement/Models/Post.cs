using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataManagement.Models
{
    public class Post
    {
        [Key]
        public int Post_ID { get; set; }
        public DateTime Post_Created_Time { get; set; }
        public string Post_Status { get; set; }
        public DateTime? Post_Delivered_Time{get;set;}
        
       

    }
}
