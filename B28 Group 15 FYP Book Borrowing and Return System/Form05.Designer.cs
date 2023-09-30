
namespace B28_Group_15_FYP_Book_Borrowing_and_Return_System
{
    partial class FYP_Form05
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
            this.Form05label1 = new System.Windows.Forms.Label();
            this.Form05label2 = new System.Windows.Forms.Label();
            this.Form05button1 = new System.Windows.Forms.Button();
            this.Form05button2 = new System.Windows.Forms.Button();
            this.Form05button3 = new System.Windows.Forms.Button();
            this.Form05button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Form05label1
            // 
            this.Form05label1.AutoSize = true;
            this.Form05label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.Form05label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form05label1.Location = new System.Drawing.Point(260, 27);
            this.Form05label1.Name = "Form05label1";
            this.Form05label1.Size = new System.Drawing.Size(336, 29);
            this.Form05label1.TabIndex = 0;
            this.Form05label1.Text = "Welcome to the Admin Page";
            // 
            // Form05label2
            // 
            this.Form05label2.AutoSize = true;
            this.Form05label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.Form05label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form05label2.Location = new System.Drawing.Point(177, 71);
            this.Form05label2.Name = "Form05label2";
            this.Form05label2.Size = new System.Drawing.Size(485, 29);
            this.Form05label2.TabIndex = 1;
            this.Form05label2.Text = "Please Choose from the following Options";
            // 
            // Form05button1
            // 
            this.Form05button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.Form05button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Form05button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Form05button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form05button1.Location = new System.Drawing.Point(90, 198);
            this.Form05button1.Name = "Form05button1";
            this.Form05button1.Size = new System.Drawing.Size(179, 127);
            this.Form05button1.TabIndex = 2;
            this.Form05button1.Text = "Book Details";
            this.Form05button1.UseVisualStyleBackColor = false;
            this.Form05button1.Click += new System.EventHandler(this.BookDetailsBtn);
            // 
            // Form05button2
            // 
            this.Form05button2.BackColor = System.Drawing.Color.RoyalBlue;
            this.Form05button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Form05button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Form05button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form05button2.Location = new System.Drawing.Point(324, 198);
            this.Form05button2.Name = "Form05button2";
            this.Form05button2.Size = new System.Drawing.Size(185, 127);
            this.Form05button2.TabIndex = 3;
            this.Form05button2.Text = "User Details";
            this.Form05button2.UseVisualStyleBackColor = false;
            this.Form05button2.Click += new System.EventHandler(this.RegisteredUserDetailsBtn);
            // 
            // Form05button3
            // 
            this.Form05button3.BackColor = System.Drawing.Color.RoyalBlue;
            this.Form05button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Form05button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Form05button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form05button3.Location = new System.Drawing.Point(560, 198);
            this.Form05button3.Name = "Form05button3";
            this.Form05button3.Size = new System.Drawing.Size(217, 127);
            this.Form05button3.TabIndex = 4;
            this.Form05button3.Text = "Borrowed/Returned Details";
            this.Form05button3.UseVisualStyleBackColor = false;
            this.Form05button3.Click += new System.EventHandler(this.BorrowedReturnedDetailsBtn);
            // 
            // Form05button4
            // 
            this.Form05button4.BackColor = System.Drawing.Color.RoyalBlue;
            this.Form05button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Form05button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Form05button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form05button4.Location = new System.Drawing.Point(692, 402);
            this.Form05button4.Name = "Form05button4";
            this.Form05button4.Size = new System.Drawing.Size(117, 49);
            this.Form05button4.TabIndex = 5;
            this.Form05button4.Text = "Log-Out";
            this.Form05button4.UseVisualStyleBackColor = false;
            this.Form05button4.Click += new System.EventHandler(this.AdminLogOutBtn);
            // 
            // FYP_Form05
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(843, 482);
            this.Controls.Add(this.Form05button4);
            this.Controls.Add(this.Form05button3);
            this.Controls.Add(this.Form05button2);
            this.Controls.Add(this.Form05button1);
            this.Controls.Add(this.Form05label2);
            this.Controls.Add(this.Form05label1);
            this.Name = "FYP_Form05";
            this.Text = "Admin Main Page";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Form05label1;
        private System.Windows.Forms.Label Form05label2;
        private System.Windows.Forms.Button Form05button1;
        private System.Windows.Forms.Button Form05button2;
        private System.Windows.Forms.Button Form05button3;
        private System.Windows.Forms.Button Form05button4;
    }
}