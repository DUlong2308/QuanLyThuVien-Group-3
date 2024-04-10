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
    public partial class frmRegister : Form
    {
        LibraryManagementEntities db = new LibraryManagementEntities();
        public frmRegister()
        {
            InitializeComponent();
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
            txtConfirm.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtGmail.Text = string.Empty;


        }

      

     

       
      

    

       

       

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            try
            {
                tbUser _user = new tbUser();
                if (string.IsNullOrEmpty(txtTenDN.Text) || string.IsNullOrEmpty(txtMK.Text))
                {
                    MessageBox.Show("Please fill in all required fields.");
                    return;
                }
                if (txtMK.Text != txtConfirm.Text)
                {
                    MessageBox.Show("Password and confirmation password do not match. Please enter again.");
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
                    _user.PassWord = txtConfirm.Text;
                    _user.Role = "Reader";
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
                        MessageBox.Show("User registration successful. ", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("User registration failed. ", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ClearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions here, e.g., show an error message.
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void chkShowPass_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkShowPass.Checked)
            {

                txtMK.UseSystemPasswordChar = false;
            }
            else
            {
                txtMK.UseSystemPasswordChar = true;

            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;

            }
        }
    }
}
