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
    public partial class frmManageBooks : Form
    {
        LibraryManagementEntities db = new LibraryManagementEntities();
        public frmManageBooks()
        {
            InitializeComponent();
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
                    Fee = x.Fee,
                    Type = x.Type,
                    AmountOfBook = x.AmountOfBook,
                    Status = x.Status,

                }).ToList();
                dvgListBooks.DataSource = _BookList;

            }
        }

        private void frmManageBooks_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void ClearFields()
        {
            // Xóa nội dung của các TextBox
            txtBooID.Text = string.Empty;
            txtTitle.Text = string.Empty;
            txtAuthor.Text = string.Empty;
            txtFee.Text = string.Empty;
            txtStatus.Text = string.Empty;
            txtStatus.Text = string.Empty;
            txtAuthor.Text = string.Empty;
            txtAmount.Text = string.Empty;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            tbBook book = new tbBook();
            try
            {
                if (txtBooID.Text == string.Empty && txtTitle.Text == string.Empty && txtAuthor.Text == string.Empty && txtFee.Text == string.Empty && txtStatus.Text == string.Empty && txtType.Text == string.Empty && txtAmount.Text == string.Empty)
                {
                    MessageBox.Show("Check bookInfo Again!");
                    return;
                }
                else
                {
                    double money = double.Parse((txtFee.Text));
                    if (money <= 0)
                    {
                        MessageBox.Show("Input Fee ");
                        return;
                    }
                
                        book.Book_ID = Convert.ToInt32(txtBooID.Text);
                        book.Title = txtTitle.Text;
                        book.Author = txtAuthor.Text;
                        book.Fee = Convert.ToInt32(txtFee.Text);
                        book.Status = txtStatus.Text;
                        book.Type = txtType.Text;
                        book.AmountOfBook = Convert.ToInt32(txtAmount.Text);
                }
               

                bool result = SaveBooks(book);
                if (result == true)
                {
                    MessageBox.Show("Add book sucessful ", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Add book fail ", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearFields();
                }
            } catch (Exception ex)
                {
                    MessageBox.Show("Something wrong !", "Again!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            Display();
        }
        public bool SaveBooks(tbBook book)
        {
            bool result = false;
            using (LibraryManagementEntities _entity = new LibraryManagementEntities())
            {
                _entity.tbBooks.Add(book);
                _entity.SaveChanges();
                result = true;
            }
            return result;
        }

        private void dvgListBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dvgListBooks.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dvgListBooks.SelectedRows)
                {
                    txtBooID.Text = row.Cells[0].Value.ToString();
                    txtTitle.Text = row.Cells[1].Value.ToString();
                    txtAuthor.Text = row.Cells[2].Value.ToString();
                    txtFee.Text = row.Cells[4].Value.ToString();
                    txtStatus.Text = row.Cells[7].Value.ToString();
                    txtType.Text = row.Cells[5].Value.ToString();
                    txtAmount.Text = row.Cells[6].Value.ToString();

                }

            }
        }

        

        public bool UpdateBook(tbBook b)

        {
            bool result = false;
            using (LibraryManagementEntities _entity = new LibraryManagementEntities())
            {
                tbBook _b = _entity.tbBooks.Where(x => x.Book_ID == b.Book_ID).Select(x => x).FirstOrDefault();
                if (_b != null)
                {
                    _b.Book_ID = b.Book_ID;
                    _b.Title = b.Title;
                    _b.Author = b.Author;
                    _b.Fee = b.Fee;
                    _b.Status = b.Status;
                    _b.Type = b.Type;
                    _b.AmountOfBook = b.AmountOfBook;

                    _entity.SaveChanges();
                    result = true;
                }
                else
                {
                    MessageBox.Show("Don't have book to update!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                
                   
                
            }
            return result;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                tbBook b = new tbBook();
                b.Book_ID = Convert.ToInt32(txtBooID.Text);
                b.Title = txtTitle.Text;
                b.Author = txtAuthor.Text;  
                b.Fee = Convert.ToDouble(txtFee.Text);
                b.Status= txtStatus.Text;
                b.Type = txtType.Text;
                b.AmountOfBook=Convert.ToInt32(txtAmount.Text);

                bool result = UpdateBook(b);
                if (result == true)
                {
                    MessageBox.Show("Update Successfully!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Update error !", "please Again!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("You need to select book !", "Again!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Display();
        }


        public bool DeleteBook(int b)
        {
            bool result = false;
            try
            {
                using (LibraryManagementEntities _entity = new LibraryManagementEntities())
                {
                    tbBook _book = _entity.tbBooks.Find(b);
                    if (_book != null)
                    {
                        _entity.tbBooks.Remove(_book);
                        _entity.SaveChanges();
                        result = true;

                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            using (LibraryManagementEntities _entity = new LibraryManagementEntities())
            {

                if (dvgListBooks.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select book to delete.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DataGridViewRow selectedRow = dvgListBooks.SelectedRows[0];
                int BooKid = (int)selectedRow.Cells["BooK_ID"].Value;
                tbBook selecteddv = _entity.tbBooks.SingleOrDefault(m => m.Book_ID == BooKid);
                if (selecteddv != null)
                {
                    DialogResult result = MessageBox.Show("Do you want to delete this book?", "Are you sure to DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        // Xóa tài khoản khỏi nguồn dữ liệu.
                        _entity.tbBooks.Remove(selecteddv);

                        // Lưu các thay đổi vào cơ sở dữ liệu.
                        _entity.SaveChanges();
                    }

                }
                ClearFields();
                
            }
            Display();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            using (LibraryManagementEntities _entity = new LibraryManagementEntities())
            {
                string sb = txtTitle.Text;
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
    }
}
