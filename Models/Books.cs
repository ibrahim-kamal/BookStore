using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore2.Models
{
    public class Books
    {
        public int id { get; set; }
        public String title { get; set; }
        public String description{get; set;}
        public Authors author{ get; set; }

    }
}
