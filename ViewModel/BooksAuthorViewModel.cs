using BookStore2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore2.ViewModel
{
    public class BooksAuthorViewModel
    {
        public Books book { get; set; }
        public IList<Authors> authors { get; set; }

    }
}
