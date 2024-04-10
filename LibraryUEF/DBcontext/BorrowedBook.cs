using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryUEF.DBcontext
{
    public class BorrowedBook
    {
        public int Borrow_ID { get; set; }
        public int User_ID { get; set; }
        public int Book_ID { get; set; }
        public Nullable<System.DateTime> Borrow_date { get; set; }
        public Nullable<System.DateTime> Return_date { get; set; }

        public virtual tbBook tbBook { get; set; }
        public virtual tbUser tbUser { get; set; }
    }
}
