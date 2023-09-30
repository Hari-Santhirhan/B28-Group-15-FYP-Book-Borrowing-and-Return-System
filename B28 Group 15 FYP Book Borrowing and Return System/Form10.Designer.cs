
namespace B28_Group_15_FYP_Book_Borrowing_and_Return_System
{
    partial class FYP_Form10
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
            this.Form10dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Form10button1 = new System.Windows.Forms.Button();
            this.Form10button2 = new System.Windows.Forms.Button();
            this.Form10button3 = new System.Windows.Forms.Button();
            this.Form10dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Form10textBox1 = new System.Windows.Forms.TextBox();
            this.Form10label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Form10dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Form10dataGridView1
            // 
            this.Form10dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form10dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Form10dataGridView1.Location = new System.Drawing.Point(41, 22);
            this.Form10dataGridView1.Name = "Form10dataGridView1";
            this.Form10dataGridView1.RowHeadersWidth = 51;
            this.Form10dataGridView1.RowTemplate.Height = 24;
            this.Form10dataGridView1.Size = new System.Drawing.Size(837, 248);
            this.Form10dataGridView1.TabIndex = 0;
            // 
            // Form10button1
            // 
            this.Form10button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.Form10button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Form10button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Form10button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form10button1.Location = new System.Drawing.Point(136, 331);
            this.Form10button1.Name = "Form10button1";
            this.Form10button1.Size = new System.Drawing.Size(149, 97);
            this.Form10button1.TabIndex = 1;
            this.Form10button1.Text = "Start Scan";
            this.Form10button1.UseVisualStyleBackColor = false;
            this.Form10button1.Click += new System.EventHandler(this.StartScanBtnForm10);
            // 
            // Form10button2
            // 
            this.Form10button2.BackColor = System.Drawing.Color.RoyalBlue;
            this.Form10button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Form10button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Form10button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form10button2.Location = new System.Drawing.Point(375, 331);
            this.Form10button2.Name = "Form10button2";
            this.Form10button2.Size = new System.Drawing.Size(160, 97);
            this.Form10button2.TabIndex = 2;
            this.Form10button2.Text = "Borrow History";
            this.Form10button2.UseVisualStyleBackColor = false;
            this.Form10button2.Click += new System.EventHandler(this.BorrowHistoryBtn2);
            // 
            // Form10button3
            // 
            this.Form10button3.BackColor = System.Drawing.Color.RoyalBlue;
            this.Form10button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Form10button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Form10button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form10button3.Location = new System.Drawing.Point(633, 331);
            this.Form10button3.Name = "Form10button3";
            this.Form10button3.Size = new System.Drawing.Size(149, 97);
            this.Form10button3.TabIndex = 3;
            this.Form10button3.Text = "Back";
            this.Form10button3.UseVisualStyleBackColor = false;
            this.Form10button3.Click += new System.EventHandler(this.BackToForm09Btn1);
            // 
            // Form10dateTimePicker1
            // 
            this.Form10dateTimePicker1.Location = new System.Drawing.Point(633, 497);
            this.Form10dateTimePicker1.Name = "Form10dateTimePicker1";
            this.Form10dateTimePicker1.Size = new System.Drawing.Size(273, 22);
            this.Form10dateTimePicker1.TabIndex = 4;
            // 
            // Form10textBox1
            // 
            this.Form10textBox1.Location = new System.Drawing.Point(633, 452);
            this.Form10textBox1.Name = "Form10textBox1";
            this.Form10textBox1.ReadOnly = true;
            this.Form10textBox1.Size = new System.Drawing.Size(273, 22);
            this.Form10textBox1.TabIndex = 5;
            // 
            // Form10label1
            // 
            this.Form10label1.AutoSize = true;
            this.Form10label1.Location = new System.Drawing.Point(429, 497);
            this.Form10label1.Name = "Form10label1";
            this.Form10label1.Size = new System.Drawing.Size(46, 17);
            this.Form10label1.TabIndex = 6;
            this.Form10label1.Text = "label1";
            this.Form10label1.Visible = false;
            // 
            // FYP_Form10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(923, 549);
            this.Controls.Add(this.Form10label1);
            this.Controls.Add(this.Form10textBox1);
            this.Controls.Add(this.Form10dateTimePicker1);
            this.Controls.Add(this.Form10button3);
            this.Controls.Add(this.Form10button2);
            this.Controls.Add(this.Form10button1);
            this.Controls.Add(this.Form10dataGridView1);
            this.Name = "FYP_Form10";
            this.Text = "Borrow Books Page";
            this.Load += new System.EventHandler(this.FYP_Form10_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Form10dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Form10dataGridView1;
        private System.Windows.Forms.Button Form10button1;
        private System.Windows.Forms.Button Form10button2;
        private System.Windows.Forms.Button Form10button3;
        private System.Windows.Forms.DateTimePicker Form10dateTimePicker1;
        private System.Windows.Forms.TextBox Form10textBox1;
        private System.Windows.Forms.Label Form10label1;
    }
}