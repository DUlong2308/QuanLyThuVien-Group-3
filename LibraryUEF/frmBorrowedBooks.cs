using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryUEF.DBcontext;


namespace LibraryUEF
{
    public partial class frmBorrowedBooks : Form
    {
        public frmBorrowedBooks()
        {
            InitializeComponent();
        }
        LibraryManagementEntities db = new LibraryManagementEntities();



        
            

        public void DisplayBorrowed()
        {


            using (LibraryManagementEntities _entity = new LibraryManagementEntities())
            {
                var borrowedBook = from BorrowedBook in _entity.tbBorrowedBooks
                                   join Book in _entity.tbBooks on BorrowedBook.Book_ID equals Book.Book_ID
                                   join User in _entity.tbUsers on BorrowedBook.User_ID equals User.User_ID
                                   where BorrowedBook.Book_ID == Book.Book_ID
                                   select new
                                   {
                                       User = User.Name,
                                       BookTitle = Book.Title,
                                       BorrowDate = BorrowedBook.Borrow_date,
                                       ReturnDate = BorrowedBook.Return_date
                                   };
                dvgBorrowedList.DataSource = borrowedBook.ToList();
            }



        }

       

       

      

        private void ExportToText(DataGridView dataGridView)
        {
            try
            {
                // Prompt user to select a location to save the text file
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    saveFileDialog.RestoreDirectory = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Open a stream writer to write to the text file
                        using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                        {
                            // Write column headers
                            for (int i = 0; i < dataGridView.Columns.Count; i++)
                            {
                                writer.Write(dataGridView.Columns[i].HeaderText + "\t\t");
                            }
                            writer.WriteLine();

                            // Write data rows
                            for (int i = 0; i < dataGridView.Rows.Count; i++)
                            {
                                for (int j = 0; j < dataGridView.Columns.Count; j++)
                                {
                                    writer.Write(dataGridView.Rows[i].Cells[j].Value?.ToString() + "\t\t");
                                }
                                writer.WriteLine();
                            }

                            MessageBox.Show("Data exported successfully to " + saveFileDialog.FileName, "Export to Text", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Export to Text", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReport_Click_1(object sender, EventArgs e)
        {
            ExportToText(dvgBorrowedList);
        }

        private void dvgBorrowedList_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dvgBorrowedList.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dvgBorrowedList.SelectedRows)
                {
                    txtName.Text = row.Cells[0].Value.ToString();
                    txtBook.Text = row.Cells[1].Value.ToString();
                }

            }
        }

        private void frmBorrowedBooks_Load_1(object sender, EventArgs e)
        {
            DisplayBorrowed();
        }
    }
}

