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

    public partial class frmAccounts : Form
    {
        LibraryManagementEntities db = new LibraryManagementEntities();
        public frmAccounts()
        {
            InitializeComponent();
        }
        public void Display()
        {
            using (LibraryManagementEntities _entity = new LibraryManagementEntities())
            {
                List<User> _UserList = new List<User>();
                _UserList = _entity.tbUsers.Select(x => new User
                {
                    User_ID = x.User_ID,
                    UserName = x.UserName,
                    PassWord = x.PassWord,
                    Role = x.Role,
                    Phone = x.Phone,
                    Address = x.Address,
                    Email = x.Email,
                    Name = x.Name,
                    DateOfBirth = x.DateOfBirth,

                }).ToList();
                dvgListAccount.DataSource = _UserList;

            }
        }

        private void frmAccounts_Load(object sender, EventArgs e)
        {
            Display(); 
            cbxRole.Items.Add("Admin");
            cbxRole.Items.Add("Reader");
        }

        private bool IsUsernameExists(string username)
        {
            using (LibraryManagementEntities _entity = new LibraryManagementEntities())
            {
                return _entity.tbUsers.Any(u => u.UserName == username);
            }
        }
        public bool Saveuser(tbUser user)
        {
            bool result = false;
            using (LibraryManagementEntities _entity = new LibraryManagementEntities())
            {
                _entity.tbUsers.Add(user);
                _entity.SaveChanges();
                result = true;
            }
            return result;
        }
        private void ClearFields()
        {
            // Xóa nội dung của các TextBox
            txtTenDN.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtMK.Text = string.Empty;
            txtName.Text = string.Empty;
            cbxRole.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtGmail.Text = string.Empty;
            txtID.Text = string.Empty;

        }
      

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

       

        public bool UpdateUser(tbUser user)

        {
            bool result = false;
            using (LibraryManagementEntities _entity = new LibraryManagementEntities())
            {
                tbUser _user = _entity.tbUsers.Where(x => x.User_ID == user.User_ID).Select(x => x).FirstOrDefault();
                if (_user != null)
                {

                    _user.User_ID = user.User_ID;
                    _user.UserName = user.UserName;
                    _user.PassWord = user.PassWord;
                    _user.Role = user.Role;
                    _user.Phone = user.Phone;
                    _user.Address = user.Address;
                    _user.Email = user.Email;
                    _user.Name = user.Name;
                    _user.DateOfBirth = user.DateOfBirth;

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

    
      
        public bool DeleteUser(int user)
        {
            bool result = false;
            try
            {
                using (LibraryManagementEntities _entity = new LibraryManagementEntities())
                {
                    tbUser _user = _entity.tbUsers.Find(user);
                    if (_user != null)
                    {
                        _entity.tbUsers.Remove(_user);
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


        private void btnSua_Click_1(object sender, EventArgs e)
        {
            try
            {
                tbUser u = new tbUser();
                u.User_ID = Convert.ToInt32(txtID.Text);
                u.UserName = txtTenDN.Text;
                u.PassWord = txtMK.Text;
                u.Role = cbxRole.Text;
                u.Phone = txtPhone.Text;
                u.Address = txtAddress.Text;
                u.Email = txtGmail.Text;
                u.Name = txtName.Text;
                u.DateOfBirth = datepic.MaxDate;

                bool result = UpdateUser(u);
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
                MessageBox.Show("You need to select account !", "Again!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Display();
        }
       

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                tbUser _user = new tbUser();
                if (IsUsernameExists(txtTenDN.Text))
                {
                    MessageBox.Show("Username already exists. Please choose another username.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(txtTenDN.Text) || string.IsNullOrEmpty(txtMK.Text))
                {
                    MessageBox.Show("Please fill in all required fields.");
                    return;
                }

                else
                {
                    // Check if the ID is provided and valid
                    if (!string.IsNullOrEmpty(txtID.Text))
                    {
                        _user.User_ID = Convert.ToInt32(txtID.Text);
                    }
                    else
                    {
                        MessageBox.Show("Please provide a valid User ID.");
                        return;
                    }
                    _user.UserName = txtTenDN.Text;
                    _user.PassWord = txtMK.Text;
                    _user.Role = cbxRole.Text;
                    _user.Phone = txtPhone.Text;
                    _user.Address = txtAddress.Text;
                    _user.Email = txtGmail.Text;
                    _user.Name = txtName.Text;

                    if (DateTime.TryParse(datepic.Text, out DateTime dob))
                    {
                        _user.DateOfBirth = dob;
                    }
                    else
                    {
                        MessageBox.Show("Please provide a valid date of birth.");
                        return;
                    }

                    bool result = Saveuser(_user);
                    if (result == true)
                    {
                        MessageBox.Show("successful. ", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("failed. ", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ClearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions here, e.g., show an error message.
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Display();
        }

        private void btnDel_Click_1(object sender, EventArgs e)
        {
 
            using (LibraryManagementEntities _entity = new LibraryManagementEntities())
            {

                if (dvgListAccount.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select account to delete.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DataGridViewRow selectedRow = dvgListAccount.SelectedRows[0];
                int Userid = (int)selectedRow.Cells["User_ID"].Value;
                tbUser selectedus = _entity.tbUsers.SingleOrDefault(m => m.User_ID == Userid);
                if (selectedus != null)
                {
                    DialogResult result = MessageBox.Show("Do you want to delete this account?", "Are you sure to DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        // Xóa tài khoản khỏi nguồn dữ liệu.
                        _entity.tbUsers.Remove(selectedus);

                        // Lưu các thay đổi vào cơ sở dữ liệu.
                        _entity.SaveChanges();
                    }

                }
                ClearFields();
            }
            Display();
        }

        private void dvgListAccount_CellContentDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dvgListAccount_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dvgListAccount.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dvgListAccount.SelectedRows)
                {
                    txtID.Text = row.Cells[0].Value.ToString();
                    txtTenDN.Text = row.Cells[1].Value.ToString();
                    txtMK.Text = row.Cells[2].Value.ToString();
                    cbxRole.Text = row.Cells[3].Value.ToString();
                    txtName.Text = row.Cells[7].Value.ToString();
                    txtAddress.Text = row.Cells[5].Value.ToString();
                    txtGmail.Text = row.Cells[6].Value.ToString();
                    txtPhone.Text = row.Cells[4].Value.ToString();


                }

            }
        }

        private void txtPhone_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        private void txtID_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;

            }
        }
    }

    
}
