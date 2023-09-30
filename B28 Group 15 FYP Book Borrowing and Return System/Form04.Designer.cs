
namespace B28_Group_15_FYP_Book_Borrowing_and_Return_System
{
    partial class FYP_Form04
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
            this.Form04label1 = new System.Windows.Forms.Label();
            this.Form04label2 = new System.Windows.Forms.Label();
            this.Form04label3 = new System.Windows.Forms.Label();
            this.Form04label4 = new System.Windows.Forms.Label();
            this.Form04textBox1 = new System.Windows.Forms.TextBox();
            this.Form04textBox2 = new System.Windows.Forms.TextBox();
            this.Form04textBox3 = new System.Windows.Forms.TextBox();
            this.Form04label5 = new System.Windows.Forms.Label();
            this.Form04button1 = new System.Windows.Forms.Button();
            this.Form04button2 = new System.Windows.Forms.Button();
            this.Form04label6 = new System.Windows.Forms.Label();
            this.Form04label7 = new System.Windows.Forms.Label();
            this.Form04textBox4 = new System.Windows.Forms.TextBox();
            this.Form04textBox5 = new System.Windows.Forms.TextBox();
            this.Form04label8 = new System.Windows.Forms.Label();
            this.Form04dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Form04checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Form04dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Form04label1
            // 
            this.Form04label1.AutoSize = true;
            this.Form04label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.Form04label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form04label1.Location = new System.Drawing.Point(256, 33);
            this.Form04label1.Name = "Form04label1";
            this.Form04label1.Size = new System.Drawing.Size(321, 29);
            this.Form04label1.TabIndex = 0;
            this.Form04label1.Text = "Please Enter User\'s Details";
            this.Form04label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form04label2
            // 
            this.Form04label2.AutoSize = true;
            this.Form04label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Form04label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form04label2.Location = new System.Drawing.Point(256, 103);
            this.Form04label2.Name = "Form04label2";
            this.Form04label2.Size = new System.Drawing.Size(78, 29);
            this.Form04label2.TabIndex = 1;
            this.Form04label2.Text = "Name";
            // 
            // Form04label3
            // 
            this.Form04label3.AutoSize = true;
            this.Form04label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Form04label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form04label3.Location = new System.Drawing.Point(214, 259);
            this.Form04label3.Name = "Form04label3";
            this.Form04label3.Size = new System.Drawing.Size(120, 29);
            this.Form04label3.TabIndex = 2;
            this.Form04label3.Text = "Password";
            // 
            // Form04label4
            // 
            this.Form04label4.AutoSize = true;
            this.Form04label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.Form04label4.Location = new System.Drawing.Point(114, 315);
            this.Form04label4.Name = "Form04label4";
            this.Form04label4.Size = new System.Drawing.Size(220, 29);
            this.Form04label4.TabIndex = 3;
            this.Form04label4.Text = "Confirm Password";
            // 
            // Form04textBox1
            // 
            this.Form04textBox1.Location = new System.Drawing.Point(369, 110);
            this.Form04textBox1.Name = "Form04textBox1";
            this.Form04textBox1.Size = new System.Drawing.Size(208, 22);
            this.Form04textBox1.TabIndex = 4;
            // 
            // Form04textBox2
            // 
            this.Form04textBox2.Location = new System.Drawing.Point(369, 266);
            this.Form04textBox2.Name = "Form04textBox2";
            this.Form04textBox2.PasswordChar = '*';
            this.Form04textBox2.Size = new System.Drawing.Size(208, 22);
            this.Form04textBox2.TabIndex = 5;
            // 
            // Form04textBox3
            // 
            this.Form04textBox3.Location = new System.Drawing.Point(369, 323);
            this.Form04textBox3.Name = "Form04textBox3";
            this.Form04textBox3.PasswordChar = '*';
            this.Form04textBox3.Size = new System.Drawing.Size(208, 22);
            this.Form04textBox3.TabIndex = 6;
            // 
            // Form04label5
            // 
            this.Form04label5.AutoSize = true;
            this.Form04label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Form04label5.ForeColor = System.Drawing.Color.SandyBrown;
            this.Form04label5.Location = new System.Drawing.Point(164, 465);
            this.Form04label5.Name = "Form04label5";
            this.Form04label5.Size = new System.Drawing.Size(450, 20);
            this.Form04label5.TabIndex = 7;
            this.Form04label5.Text = "User ID will be auto-generated after successful registration";
            // 
            // Form04button1
            // 
            this.Form04button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.Form04button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Form04button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Form04button1.Location = new System.Drawing.Point(439, 488);
            this.Form04button1.Name = "Form04button1";
            this.Form04button1.Size = new System.Drawing.Size(138, 83);
            this.Form04button1.TabIndex = 8;
            this.Form04button1.Text = "Complete Registration";
            this.Form04button1.UseVisualStyleBackColor = false;
            this.Form04button1.Click += new System.EventHandler(this.CompleteRegistrationBtn1);
            // 
            // Form04button2
            // 
            this.Form04button2.BackColor = System.Drawing.Color.RoyalBlue;
            this.Form04button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Form04button2.Location = new System.Drawing.Point(219, 488);
            this.Form04button2.Name = "Form04button2";
            this.Form04button2.Size = new System.Drawing.Size(150, 83);
            this.Form04button2.TabIndex = 9;
            this.Form04button2.Text = "Back";
            this.Form04button2.UseVisualStyleBackColor = false;
            this.Form04button2.Click += new System.EventHandler(this.BackToUserLogin);
            // 
            // Form04label6
            // 
            this.Form04label6.AutoSize = true;
            this.Form04label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Form04label6.Location = new System.Drawing.Point(260, 154);
            this.Form04label6.Name = "Form04label6";
            this.Form04label6.Size = new System.Drawing.Size(74, 29);
            this.Form04label6.TabIndex = 10;
            this.Form04label6.Text = "Email";
            // 
            // Form04label7
            // 
            this.Form04label7.AutoSize = true;
            this.Form04label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Form04label7.Location = new System.Drawing.Point(207, 206);
            this.Form04label7.Name = "Form04label7";
            this.Form04label7.Size = new System.Drawing.Size(127, 29);
            this.Form04label7.TabIndex = 11;
            this.Form04label7.Text = "Phone No.";
            // 
            // Form04textBox4
            // 
            this.Form04textBox4.Location = new System.Drawing.Point(369, 161);
            this.Form04textBox4.Name = "Form04textBox4";
            this.Form04textBox4.Size = new System.Drawing.Size(208, 22);
            this.Form04textBox4.TabIndex = 12;
            // 
            // Form04textBox5
            // 
            this.Form04textBox5.Location = new System.Drawing.Point(369, 213);
            this.Form04textBox5.Name = "Form04textBox5";
            this.Form04textBox5.Size = new System.Drawing.Size(208, 22);
            this.Form04textBox5.TabIndex = 13;
            // 
            // Form04label8
            // 
            this.Form04label8.AutoSize = true;
            this.Form04label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.Form04label8.ForeColor = System.Drawing.Color.SandyBrown;
            this.Form04label8.Location = new System.Drawing.Point(237, 394);
            this.Form04label8.Name = "Form04label8";
            this.Form04label8.Size = new System.Drawing.Size(97, 29);
            this.Form04label8.TabIndex = 14;
            this.Form04label8.Text = "User ID";
            // 
            // Form04dataGridView1
            // 
            this.Form04dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Form04dataGridView1.Location = new System.Drawing.Point(369, 363);
            this.Form04dataGridView1.Name = "Form04dataGridView1";
            this.Form04dataGridView1.RowHeadersWidth = 51;
            this.Form04dataGridView1.RowTemplate.Height = 24;
            this.Form04dataGridView1.Size = new System.Drawing.Size(208, 88);
            this.Form04dataGridView1.TabIndex = 15;
            // 
            // Form04checkBox1
            // 
            this.Form04checkBox1.AutoSize = true;
            this.Form04checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Form04checkBox1.Location = new System.Drawing.Point(597, 427);
            this.Form04checkBox1.Name = "Form04checkBox1";
            this.Form04checkBox1.Size = new System.Drawing.Size(151, 24);
            this.Form04checkBox1.TabIndex = 16;
            this.Form04checkBox1.Text = "Show Password";
            this.Form04checkBox1.UseVisualStyleBackColor = true;
            this.Form04checkBox1.CheckedChanged += new System.EventHandler(this.ShowPasswordBoxCheck1);
            // 
            // FYP_Form04
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(837, 583);
            this.Controls.Add(this.Form04checkBox1);
            this.Controls.Add(this.Form04dataGridView1);
            this.Controls.Add(this.Form04label8);
            this.Controls.Add(this.Form04textBox5);
            this.Controls.Add(this.Form04textBox4);
            this.Controls.Add(this.Form04label7);
            this.Controls.Add(this.Form04label6);
            this.Controls.Add(this.Form04button2);
            this.Controls.Add(this.Form04button1);
            this.Controls.Add(this.Form04label5);
            this.Controls.Add(this.Form04textBox3);
            this.Controls.Add(this.Form04textBox2);
            this.Controls.Add(this.Form04textBox1);
            this.Controls.Add(this.Form04label4);
            this.Controls.Add(this.Form04label3);
            this.Controls.Add(this.Form04label2);
            this.Controls.Add(this.Form04label1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "FYP_Form04";
            this.Text = "New User Registration";
            ((System.ComponentModel.ISupportInitialize)(this.Form04dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Form04label1;
        private System.Windows.Forms.Label Form04label2;
        private System.Windows.Forms.Label Form04label3;
        private System.Windows.Forms.Label Form04label4;
        private System.Windows.Forms.TextBox Form04textBox1;
        private System.Windows.Forms.TextBox Form04textBox2;
        private System.Windows.Forms.TextBox Form04textBox3;
        private System.Windows.Forms.Label Form04label5;
        private System.Windows.Forms.Button Form04button1;
        private System.Windows.Forms.Button Form04button2;
        private System.Windows.Forms.Label Form04label6;
        private System.Windows.Forms.Label Form04label7;
        private System.Windows.Forms.TextBox Form04textBox4;
        private System.Windows.Forms.TextBox Form04textBox5;
        private System.Windows.Forms.Label Form04label8;
        private System.Windows.Forms.DataGridView Form04dataGridView1;
        private System.Windows.Forms.CheckBox Form04checkBox1;
    }
}