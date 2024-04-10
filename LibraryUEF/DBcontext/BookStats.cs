using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryUEF.DBcontext
{
    internal class BookStats
    {
        public int Book_ID { get; set; }
        public Nullable<int> BorrowedCount { get; set; }
        public Nullable<int> ReturnedCount { get; set; }
    }
}
