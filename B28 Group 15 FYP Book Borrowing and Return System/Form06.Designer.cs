
namespace B28_Group_15_FYP_Book_Borrowing_and_Return_System
{
    partial class FYP_Form06
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
            this.Form06dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Form06radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.Form06label4 = new System.Windows.Forms.Label();
            this.Form06comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Form06button2 = new System.Windows.Forms.Button();
            this.Form06label5 = new System.Windows.Forms.Label();
            this.Form06label6 = new System.Windows.Forms.Label();
            this.Form06label7 = new System.Windows.Forms.Label();
            this.Form06comboBox2 = new System.Windows.Forms.ComboBox();
            this.Form06comboBox3 = new System.Windows.Forms.ComboBox();
            this.Form06textBox1 = new System.Windows.Forms.TextBox();
            this.Form06label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Form06dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Form06dataGridView1
            // 
            this.Form06dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form06dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Form06dataGridView1.Location = new System.Drawing.Point(77, 24);
            this.Form06dataGridView1.Name = "Form06dataGridView1";
            this.Form06dataGridView1.RowHeadersWidth = 51;
            this.Form06dataGridView1.RowTemplate.Height = 24;
            this.Form06dataGridView1.Size = new System.Drawing.Size(746, 168);
            this.Form06dataGridView1.TabIndex = 0;
            // 
            // Form06radioButton1
            // 
            this.Form06radioButton1.AutoSize = true;
            this.Form06radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Form06radioButton1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form06radioButton1.Location = new System.Drawing.Point(77, 221);
            this.Form06radioButton1.Name = "Form06radioButton1";
            this.Form06radioButton1.Size = new System.Drawing.Size(207, 33);
            this.Form06radioButton1.TabIndex = 1;
            this.Form06radioButton1.TabStop = true;
            this.Form06radioButton1.Text = "Add New Books";
            this.Form06radioButton1.UseVisualStyleBackColor = true;
            this.Form06radioButton1.CheckedChanged += new System.EventHandler(this.AddNewBooksRadio1);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.radioButton2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.radioButton2.Location = new System.Drawing.Point(306, 221);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(247, 33);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Delete Book Details";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.DeleteBookDetailsRadio2);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.radioButton3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.radioButton3.Location = new System.Drawing.Point(571, 221);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(252, 33);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Search Book Details";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.SearchBookDetailsRadio3);
            // 
            // Form06label4
            // 
            this.Form06label4.AutoSize = true;
            this.Form06label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Form06label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form06label4.Location = new System.Drawing.Point(186, 288);
            this.Form06label4.Name = "Form06label4";
            this.Form06label4.Size = new System.Drawing.Size(75, 25);
            this.Form06label4.TabIndex = 4;
            this.Form06label4.Text = "Search";
            this.Form06label4.Visible = false;
            // 
            // Form06comboBox1
            // 
            this.Form06comboBox1.FormattingEnabled = true;
            this.Form06comboBox1.Location = new System.Drawing.Point(419, 288);
            this.Form06comboBox1.Name = "Form06comboBox1";
            this.Form06comboBox1.Size = new System.Drawing.Size(186, 24);
            this.Form06comboBox1.TabIndex = 7;
            this.Form06comboBox1.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(77, 449);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 73);
            this.button1.TabIndex = 10;
            this.button1.Text = "Execute";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.ExecuteCommandBtn1);
            // 
            // Form06button2
            // 
            this.Form06button2.BackColor = System.Drawing.Color.RoyalBlue;
            this.Form06button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Form06button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form06button2.Location = new System.Drawing.Point(690, 449);
            this.Form06button2.Name = "Form06button2";
            this.Form06button2.Size = new System.Drawing.Size(133, 73);
            this.Form06button2.TabIndex = 11;
            this.Form06button2.Text = "Back";
            this.Form06button2.UseVisualStyleBackColor = false;
            this.Form06button2.Click += new System.EventHandler(this.BackToForm05Btn1);
            // 
            // Form06label5
            // 
            this.Form06label5.AutoSize = true;
            this.Form06label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Form06label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form06label5.Location = new System.Drawing.Point(281, 288);
            this.Form06label5.Name = "Form06label5";
            this.Form06label5.Size = new System.Drawing.Size(114, 25);
            this.Form06label5.TabIndex = 12;
            this.Form06label5.Text = "Book Name";
            this.Form06label5.Visible = false;
            // 
            // Form06label6
            // 
            this.Form06label6.AutoSize = true;
            this.Form06label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Form06label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form06label6.Location = new System.Drawing.Point(337, 339);
            this.Form06label6.Name = "Form06label6";
            this.Form06label6.Size = new System.Drawing.Size(58, 25);
            this.Form06label6.TabIndex = 13;
            this.Form06label6.Text = "ISBN";
            this.Form06label6.Visible = false;
            // 
            // Form06label7
            // 
            this.Form06label7.AutoSize = true;
            this.Form06label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Form06label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form06label7.Location = new System.Drawing.Point(314, 388);
            this.Form06label7.Name = "Form06label7";
            this.Form06label7.Size = new System.Drawing.Size(81, 25);
            this.Form06label7.TabIndex = 14;
            this.Form06label7.Text = "Book ID";
            this.Form06label7.Visible = false;
            // 
            // Form06comboBox2
            // 
            this.Form06comboBox2.FormattingEnabled = true;
            this.Form06comboBox2.Location = new System.Drawing.Point(419, 339);
            this.Form06comboBox2.Name = "Form06comboBox2";
            this.Form06comboBox2.Size = new System.Drawing.Size(186, 24);
            this.Form06comboBox2.TabIndex = 15;
            this.Form06comboBox2.Visible = false;
            // 
            // Form06comboBox3
            // 
            this.Form06comboBox3.FormattingEnabled = true;
            this.Form06comboBox3.Location = new System.Drawing.Point(419, 389);
            this.Form06comboBox3.Name = "Form06comboBox3";
            this.Form06comboBox3.Size = new System.Drawing.Size(186, 24);
            this.Form06comboBox3.TabIndex = 16;
            this.Form06comboBox3.Visible = false;
            // 
            // Form06textBox1
            // 
            this.Form06textBox1.Location = new System.Drawing.Point(419, 442);
            this.Form06textBox1.Name = "Form06textBox1";
            this.Form06textBox1.ReadOnly = true;
            this.Form06textBox1.Size = new System.Drawing.Size(186, 22);
            this.Form06textBox1.TabIndex = 17;
            // 
            // Form06label8
            // 
            this.Form06label8.AutoSize = true;
            this.Form06label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Form06label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form06label8.Location = new System.Drawing.Point(286, 439);
            this.Form06label8.Name = "Form06label8";
            this.Form06label8.Size = new System.Drawing.Size(109, 25);
            this.Form06label8.TabIndex = 18;
            this.Form06label8.Text = "RFID Code";
            // 
            // FYP_Form06
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(923, 555);
            this.Controls.Add(this.Form06label8);
            this.Controls.Add(this.Form06textBox1);
            this.Controls.Add(this.Form06comboBox3);
            this.Controls.Add(this.Form06comboBox2);
            this.Controls.Add(this.Form06label7);
            this.Controls.Add(this.Form06label6);
            this.Controls.Add(this.Form06label5);
            this.Controls.Add(this.Form06button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Form06comboBox1);
            this.Controls.Add(this.Form06label4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.Form06radioButton1);
            this.Controls.Add(this.Form06dataGridView1);
            this.Name = "FYP_Form06";
            this.Text = "Book Details Page";
            this.Load += new System.EventHandler(this.FYP_Form06_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Form06dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Form06dataGridView1;
        private System.Windows.Forms.RadioButton Form06radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Label Form06label4;
        private System.Windows.Forms.ComboBox Form06comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Form06button2;
        private System.Windows.Forms.Label Form06label5;
        private System.Windows.Forms.Label Form06label6;
        private System.Windows.Forms.Label Form06label7;
        private System.Windows.Forms.ComboBox Form06comboBox2;
        private System.Windows.Forms.ComboBox Form06comboBox3;
        private System.Windows.Forms.TextBox Form06textBox1;
        private System.Windows.Forms.Label Form06label8;
    }
}