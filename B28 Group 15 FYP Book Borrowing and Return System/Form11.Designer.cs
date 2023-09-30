
namespace B28_Group_15_FYP_Book_Borrowing_and_Return_System
{
    partial class FYP_Form11
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
            this.Form11dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Form11button1 = new System.Windows.Forms.Button();
            this.Form11button2 = new System.Windows.Forms.Button();
            this.Form11button3 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Form11label1 = new System.Windows.Forms.Label();
            this.Form11textBox1 = new System.Windows.Forms.TextBox();
            this.Form11textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Form11dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Form11dataGridView1
            // 
            this.Form11dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form11dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Form11dataGridView1.Location = new System.Drawing.Point(39, 24);
            this.Form11dataGridView1.Name = "Form11dataGridView1";
            this.Form11dataGridView1.RowHeadersWidth = 51;
            this.Form11dataGridView1.RowTemplate.Height = 24;
            this.Form11dataGridView1.Size = new System.Drawing.Size(818, 225);
            this.Form11dataGridView1.TabIndex = 0;
            // 
            // Form11button1
            // 
            this.Form11button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.Form11button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Form11button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form11button1.Location = new System.Drawing.Point(137, 302);
            this.Form11button1.Name = "Form11button1";
            this.Form11button1.Size = new System.Drawing.Size(151, 101);
            this.Form11button1.TabIndex = 1;
            this.Form11button1.Text = "Start Scan";
            this.Form11button1.UseVisualStyleBackColor = false;
            this.Form11button1.Click += new System.EventHandler(this.StartScanToReturnBookBtn);
            // 
            // Form11button2
            // 
            this.Form11button2.BackColor = System.Drawing.Color.RoyalBlue;
            this.Form11button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Form11button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form11button2.Location = new System.Drawing.Point(362, 302);
            this.Form11button2.Name = "Form11button2";
            this.Form11button2.Size = new System.Drawing.Size(162, 101);
            this.Form11button2.TabIndex = 2;
            this.Form11button2.Text = "Return History";
            this.Form11button2.UseVisualStyleBackColor = false;
            this.Form11button2.Click += new System.EventHandler(this.ReturnHistoryBTN1);
            // 
            // Form11button3
            // 
            this.Form11button3.BackColor = System.Drawing.Color.RoyalBlue;
            this.Form11button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Form11button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form11button3.Location = new System.Drawing.Point(600, 302);
            this.Form11button3.Name = "Form11button3";
            this.Form11button3.Size = new System.Drawing.Size(151, 101);
            this.Form11button3.TabIndex = 3;
            this.Form11button3.Text = "Back";
            this.Form11button3.UseVisualStyleBackColor = false;
            this.Form11button3.Click += new System.EventHandler(this.BackToForm09Btn2);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(600, 515);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(272, 22);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // Form11label1
            // 
            this.Form11label1.AutoSize = true;
            this.Form11label1.Location = new System.Drawing.Point(374, 521);
            this.Form11label1.Name = "Form11label1";
            this.Form11label1.Size = new System.Drawing.Size(46, 17);
            this.Form11label1.TabIndex = 5;
            this.Form11label1.Text = "label1";
            this.Form11label1.Visible = false;
            // 
            // Form11textBox1
            // 
            this.Form11textBox1.Location = new System.Drawing.Point(600, 431);
            this.Form11textBox1.Name = "Form11textBox1";
            this.Form11textBox1.ReadOnly = true;
            this.Form11textBox1.Size = new System.Drawing.Size(272, 22);
            this.Form11textBox1.TabIndex = 6;
            // 
            // Form11textBox2
            // 
            this.Form11textBox2.Location = new System.Drawing.Point(600, 472);
            this.Form11textBox2.Name = "Form11textBox2";
            this.Form11textBox2.ReadOnly = true;
            this.Form11textBox2.Size = new System.Drawing.Size(272, 22);
            this.Form11textBox2.TabIndex = 7;
            // 
            // FYP_Form11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(907, 567);
            this.Controls.Add(this.Form11textBox2);
            this.Controls.Add(this.Form11textBox1);
            this.Controls.Add(this.Form11label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.Form11button3);
            this.Controls.Add(this.Form11button2);
            this.Controls.Add(this.Form11button1);
            this.Controls.Add(this.Form11dataGridView1);
            this.Name = "FYP_Form11";
            this.Text = "Return Books Page";
            ((System.ComponentModel.ISupportInitialize)(this.Form11dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Form11dataGridView1;
        private System.Windows.Forms.Button Form11button1;
        private System.Windows.Forms.Button Form11button2;
        private System.Windows.Forms.Button Form11button3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label Form11label1;
        private System.Windows.Forms.TextBox Form11textBox1;
        private System.Windows.Forms.TextBox Form11textBox2;
    }
}