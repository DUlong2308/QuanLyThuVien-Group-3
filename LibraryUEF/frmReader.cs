using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryUEF.DBcontext;



namespace LibraryUEF
{
    public partial class frmReader : Form
        
    {
        int User_ID;
        LibraryManagementEntities db = new LibraryManagementEntities();
        public frmReader(int User_Id)
        {
            InitializeComponent();
            User_ID = User_Id;
        }


        public void Display()
        {
            using (LibraryManagementEntities _entity = new LibraryManagementEntities())
            {
                List<Book> _BookList = new List<Book>();
                _BookList = _entity.tbBooks.Select(x => new Book
                {
                    Book_ID = x.Book_ID,
                    Title = x.Title,    
                    Author = x.Author,
                    BookName = x.BookName,
                    Fee=x.Fee,
                    Type = x.Type,
                    AmountOfBook=x.AmountOfBook,
                    Status=x.Status,

                }).ToList();
                dvgListBooks.DataSource = _BookList;

            }
        }

        public void LoadBookList()
        {

            dvgListBooks.DataSource = (from tbBook in db.tbBooks select new { Book_ID = tbBook.Book_ID,Title = tbBook.Title, Author = tbBook.Author, Fee = tbBook.Fee, Type = tbBook.Type, AmountOfBook = tbBook.AmountOfBook,Status=tbBook.Status }).ToArray();
        }
        private void frmReader_Load(object sender, EventArgs e)
        {
            Display();
            
        }

       

      
        public void DisplayBorrowed()
        {
            using (LibraryManagementEntities _entity = new LibraryManagementEntities())
            {
                var borrowedBook = from BorrowedBook in _entity.tbBorrowedBooks
                                   join Book in _entity.tbBooks on BorrowedBook.Book_ID equals Book.Book_ID
                                   where BorrowedBook.User_ID == User_ID
                                   select new
                                   {
                                       BookTitle = Book.Title,
                                       BorrowDate = BorrowedBook.Borrow_date,
                                       ReturnDate = BorrowedBook.Return_date
                                   };
                dvgListBooks.DataSource = borrowedBook.ToList();
            }
        }
       

        //Hàm cập nhật thống kê sách khi mượn sách
        private void UpdateBookStatsOnBorrow(int bookID)
        {
            using (LibraryManagementEntities _entity = new LibraryManagementEntities())
            {
                var bookStats = _entity.BookStats.FirstOrDefault(b => b.Book_ID == bookID);
                if (bookStats != null)
                {
                    bookStats.BorrowedCount++;
                    _entity.SaveChanges();
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DisplayBorrowed();
        }

        private void btnBorrow_Click_1(object sender, EventArgs e)
        {
            using (LibraryManagementEntities _entity = new LibraryManagementEntities())
            {
                try
                {
                    if (dvgListBooks.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Please select a book from the list.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Kiểm tra xem người dùng đã mượn sách trước đó chưa
                    int borrowedBooksCount = _entity.tbBorrowedBooks.Count(b => b.User_ID == User_ID);
                    if (borrowedBooksCount >= 10)
                    {
                        MessageBox.Show("You can borrow only one book at a time.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int index = dvgListBooks.SelectedRows[0].Index;
                    string bookTitle = dvgListBooks.Rows[index].Cells["Title"].Value.ToString();
                    tbBook selectedBook = _entity.tbBooks.SingleOrDefault(c => c.Title == bookTitle);

                    if (selectedBook.Status == "Allow")
                    {
                        tbBorrowedBook br = new tbBorrowedBook();
                        br.User_ID = User_ID;
                        br.Book_ID = selectedBook.Book_ID;
                        br.Borrow_date = DateTime.Today;
                        br.Return_date = null;

                        selectedBook.AmountOfBook--;

                        _entity.tbBorrowedBooks.Add(br);
                        _entity.SaveChanges();

                        MessageBox.Show("Book borrowed successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("You can't borrow this book.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Display();
            }
        }

        private void bnttimkiem_Click_1(object sender, EventArgs e)
        {
            using (LibraryManagementEntities _entity = new LibraryManagementEntities())
            {
                string sb = txtSearchBook.Text;
                tbBook _book = db.tbBooks.Where(s => s.Title == sb).FirstOrDefault();
                if (_book != null)
                {

                    Display();
                }
                else
                {
                    MessageBox.Show("Not found!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Display();
        }

        private void btnReturn_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem người dùng đã chọn sách để trả chưa
                if (dvgListBooks.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a book to return.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Lấy thông tin sách được chọn
                DataGridViewRow selectedRow = dvgListBooks.SelectedRows[0];
                string bookTitle = selectedRow.Cells["BookTitle"].Value.ToString();
                DateTime borrowDate = (DateTime)selectedRow.Cells["BorrowDate"].Value;

                // Tìm thông tin sách từ tiêu đề sách
                tbBook book = db.tbBooks.FirstOrDefault(b => b.Title == bookTitle);
                if (book == null)
                {
                    MessageBox.Show("Book not found.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tìm bản ghi trong bảng BorrowedBook tương ứng với sách đã chọn và ngày mượn
                tbBorrowedBook borrowedBook = db.tbBorrowedBooks.FirstOrDefault(b => b.Book_ID == book.Book_ID && b.Borrow_date == borrowDate && b.User_ID == User_ID);
                if (borrowedBook == null)
                {
                    MessageBox.Show("Borrowed record not found.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra xem sách đã được trả hay chưa
                if (borrowedBook.Return_date != null)
                {
                    MessageBox.Show("This book has already been returned.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thiết lập ngày trả là ngày hiện tại
                borrowedBook.Return_date = DateTime.Today;
                // Giảm số lượng sách đã mượn
                book.AmountOfBook--;

                // Lưu thay đổi vào cơ sở dữ liệu
                db.SaveChanges();

                MessageBox.Show("Book returned successfully.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại danh sách sách đã mượn
                DisplayBorrowed();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    }


