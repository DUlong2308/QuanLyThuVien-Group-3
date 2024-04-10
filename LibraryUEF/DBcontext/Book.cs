using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryUEF.DBcontext
{
    public class Book
    {
        public int Book_ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string BookName { get; set; }
        public double? Fee { get; set; }
        public string Type { get; set; }
        public int? AmountOfBook { get; set; }
        public string Status { get; set; }

      
    }
}
