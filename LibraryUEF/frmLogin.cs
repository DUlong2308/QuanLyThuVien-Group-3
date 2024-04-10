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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace LibraryUEF
{
    public partial class frmLogin : Form
    { 
        LibraryManagementEntities db = new LibraryManagementEntities();
        int User_ID;    
        public frmLogin()
        {
           
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string UserName1 = txtUserName.Text;
            string PassWord1 = txtPassWord.Text;
            tbUser _user = db.tbUsers.Where(s=>s.UserName== UserName1&&s.PassWord==PassWord1).FirstOrDefault();
            if (_user != null)
            {
                User_ID = _user.User_ID;
                if(_user.Role== "Admin")
                {
                    frmLibManager mainForm = new frmLibManager();
                    this.Visible = false;
                    mainForm.ShowDialog();
                    this.Visible = true;
                }
                else if(_user.Role=="Reader")
                {
                    frmReader reader = new frmReader(User_ID);
                    this.Visible = false;
                    reader.ShowDialog();
                    this.Visible = true;    

                }
                   
            }
            else
            {
                MessageBox.Show("Pleace check your Information!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return;
            }





        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegister Register = new frmRegister();
            this.Visible = false;
            Register.ShowDialog();
            this.Visible = true;
        }

    
        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPass.Checked)
            {

                txtPassWord.UseSystemPasswordChar = false;
            }
            else
            {

                txtPassWord.UseSystemPasswordChar = true;
            }
        }
    }
}
