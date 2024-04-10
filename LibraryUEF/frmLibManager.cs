using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryUEF
{
    public partial class frmLibManager : Form
    {
        public frmLibManager()
        {
            InitializeComponent();
        }

        private void picManageBooks_Click(object sender, EventArgs e)
        {
            frmManageBooks frmManageBooks = new frmManageBooks();   
            frmManageBooks.ShowDialog();

        }

        private void picBorrowBooks_Click(object sender, EventArgs e)
        {
            frmBorrowedBooks frmBorrowedBook = new frmBorrowedBooks();
            frmBorrowedBook.ShowDialog();
        }

        private void picAccounts_Click(object sender, EventArgs e)
        {
            frmAccounts _frmAccounts = new frmAccounts();
            _frmAccounts.ShowDialog();
        }
    }
}
