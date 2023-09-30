
namespace B28_Group_15_FYP_Book_Borrowing_and_Return_System
{
    partial class FYP_Form07
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
            this.Form07dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Form07button1 = new System.Windows.Forms.Button();
            this.Form07button2 = new System.Windows.Forms.Button();
            this.Form07button3 = new System.Windows.Forms.Button();
            this.Form07button4 = new System.Windows.Forms.Button();
            this.Form07label1 = new System.Windows.Forms.Label();
            this.Form07comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.Form07dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Form07dataGridView1
            // 
            this.Form07dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form07dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Form07dataGridView1.Location = new System.Drawing.Point(79, 30);
            this.Form07dataGridView1.Name = "Form07dataGridView1";
            this.Form07dataGridView1.RowHeadersWidth = 51;
            this.Form07dataGridView1.RowTemplate.Height = 24;
            this.Form07dataGridView1.Size = new System.Drawing.Size(792, 285);
            this.Form07dataGridView1.TabIndex = 0;
            // 
            // Form07button1
            // 
            this.Form07button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.Form07button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Form07button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Form07button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form07button1.Location = new System.Drawing.Point(79, 444);
            this.Form07button1.Name = "Form07button1";
            this.Form07button1.Size = new System.Drawing.Size(131, 85);
            this.Form07button1.TabIndex = 1;
            this.Form07button1.Text = "Search";
            this.Form07button1.UseVisualStyleBackColor = false;
            this.Form07button1.Click += new System.EventHandler(this.SearchUserDetailsBtn1);
            // 
            // Form07button2
            // 
            this.Form07button2.BackColor = System.Drawing.Color.RoyalBlue;
            this.Form07button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Form07button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Form07button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form07button2.Location = new System.Drawing.Point(323, 444);
            this.Form07button2.Name = "Form07button2";
            this.Form07button2.Size = new System.Drawing.Size(131, 85);
            this.Form07button2.TabIndex = 2;
            this.Form07button2.Text = "Ban User";
            this.Form07button2.UseVisualStyleBackColor = false;
            this.Form07button2.Click += new System.EventHandler(this.BanUserBTN1);
            // 
            // Form07button3
            // 
            this.Form07button3.BackColor = System.Drawing.Color.RoyalBlue;
            this.Form07button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Form07button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Form07button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form07button3.Location = new System.Drawing.Point(563, 444);
            this.Form07button3.Name = "Form07button3";
            this.Form07button3.Size = new System.Drawing.Size(131, 85);
            this.Form07button3.TabIndex = 3;
            this.Form07button3.Text = "Unban User";
            this.Form07button3.UseVisualStyleBackColor = false;
            this.Form07button3.Click += new System.EventHandler(this.UnbanUserBTN2);
            // 
            // Form07button4
            // 
            this.Form07button4.BackColor = System.Drawing.Color.RoyalBlue;
            this.Form07button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Form07button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Form07button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form07button4.Location = new System.Drawing.Point(798, 444);
            this.Form07button4.Name = "Form07button4";
            this.Form07button4.Size = new System.Drawing.Size(131, 85);
            this.Form07button4.TabIndex = 4;
            this.Form07button4.Text = "Back";
            this.Form07button4.UseVisualStyleBackColor = false;
            this.Form07button4.Click += new System.EventHandler(this.BackToForm05Btn2);
            // 
            // Form07label1
            // 
            this.Form07label1.AutoSize = true;
            this.Form07label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Form07label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form07label1.Location = new System.Drawing.Point(318, 355);
            this.Form07label1.Name = "Form07label1";
            this.Form07label1.Size = new System.Drawing.Size(93, 29);
            this.Form07label1.TabIndex = 5;
            this.Form07label1.Text = "User ID";
            // 
            // Form07comboBox1
            // 
            this.Form07comboBox1.FormattingEnabled = true;
            this.Form07comboBox1.Location = new System.Drawing.Point(451, 359);
            this.Form07comboBox1.Name = "Form07comboBox1";
            this.Form07comboBox1.Size = new System.Drawing.Size(164, 24);
            this.Form07comboBox1.TabIndex = 6;
            // 
            // FYP_Form07
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(974, 577);
            this.Controls.Add(this.Form07comboBox1);
            this.Controls.Add(this.Form07label1);
            this.Controls.Add(this.Form07button4);
            this.Controls.Add(this.Form07button3);
            this.Controls.Add(this.Form07button2);
            this.Controls.Add(this.Form07button1);
            this.Controls.Add(this.Form07dataGridView1);
            this.Name = "FYP_Form07";
            this.Text = "Registered User Details";
            this.Load += new System.EventHandler(this.FYP_Form07_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Form07dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Form07dataGridView1;
        private System.Windows.Forms.Button Form07button1;
        private System.Windows.Forms.Button Form07button2;
        private System.Windows.Forms.Button Form07button3;
        private System.Windows.Forms.Button Form07button4;
        private System.Windows.Forms.Label Form07label1;
        private System.Windows.Forms.ComboBox Form07comboBox1;
    }
}