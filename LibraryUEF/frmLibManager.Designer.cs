namespace LibraryUEF
{
    partial class frmLibManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.picManageBooks = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.picAccounts = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.picBorrowBooks = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picManageBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBorrowBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(149, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage Books";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::LibraryUEF.Properties.Resources._316535330_575103304614810_5267373571795743056_n;
            this.pictureBox2.Location = new System.Drawing.Point(169, 157);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(422, 284);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // picManageBooks
            // 
            this.picManageBooks.BackColor = System.Drawing.Color.White;
            this.picManageBooks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picManageBooks.Image = global::LibraryUEF.Properties.Resources.book;
            this.picManageBooks.Location = new System.Drawing.Point(152, 69);
            this.picManageBooks.Name = "picManageBooks";
            this.picManageBooks.Size = new System.Drawing.Size(118, 106);
            this.picManageBooks.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picManageBooks.TabIndex = 0;
            this.picManageBooks.TabStop = false;
            this.picManageBooks.Click += new System.EventHandler(this.picManageBooks_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(513, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Accounts";
            // 
            // picAccounts
            // 
            this.picAccounts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.picAccounts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAccounts.Image = global::LibraryUEF.Properties.Resources.reading_book;
            this.picAccounts.Location = new System.Drawing.Point(495, 69);
            this.picAccounts.Name = "picAccounts";
            this.picAccounts.Size = new System.Drawing.Size(118, 106);
            this.picAccounts.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAccounts.TabIndex = 3;
            this.picAccounts.TabStop = false;
            this.picAccounts.Click += new System.EventHandler(this.picAccounts_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(319, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Borrow Books";
            // 
            // picBorrowBooks
            // 
            this.picBorrowBooks.BackColor = System.Drawing.Color.White;
            this.picBorrowBooks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBorrowBooks.Image = global::LibraryUEF.Properties.Resources.library__1_;
            this.picBorrowBooks.Location = new System.Drawing.Point(322, 69);
            this.picBorrowBooks.Name = "picBorrowBooks";
            this.picBorrowBooks.Size = new System.Drawing.Size(118, 106);
            this.picBorrowBooks.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBorrowBooks.TabIndex = 5;
            this.picBorrowBooks.TabStop = false;
            this.picBorrowBooks.Click += new System.EventHandler(this.picBorrowBooks_Click);
            // 
            // frmLibManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(761, 401);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picBorrowBooks);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picAccounts);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picManageBooks);
            this.Controls.Add(this.pictureBox2);
            this.Name = "frmLibManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library Manager";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picManageBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBorrowBooks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picManageBooks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picAccounts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picBorrowBooks;
    }
}