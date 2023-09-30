
namespace B28_Group_15_FYP_Book_Borrowing_and_Return_System
{
    partial class FYP_Form13
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Form13label1 = new System.Windows.Forms.Label();
            this.Form13label2 = new System.Windows.Forms.Label();
            this.Form13comboBox1 = new System.Windows.Forms.ComboBox();
            this.Form13comboBox2 = new System.Windows.Forms.ComboBox();
            this.Form13button1 = new System.Windows.Forms.Button();
            this.Form13button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(39, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(823, 241);
            this.dataGridView1.TabIndex = 0;
            // 
            // Form13label1
            // 
            this.Form13label1.AutoSize = true;
            this.Form13label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Form13label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form13label1.Location = new System.Drawing.Point(289, 309);
            this.Form13label1.Name = "Form13label1";
            this.Form13label1.Size = new System.Drawing.Size(140, 29);
            this.Form13label1.TabIndex = 1;
            this.Form13label1.Text = "Book Name";
            // 
            // Form13label2
            // 
            this.Form13label2.AutoSize = true;
            this.Form13label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Form13label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form13label2.Location = new System.Drawing.Point(360, 367);
            this.Form13label2.Name = "Form13label2";
            this.Form13label2.Size = new System.Drawing.Size(69, 29);
            this.Form13label2.TabIndex = 2;
            this.Form13label2.Text = "ISBN";
            // 
            // Form13comboBox1
            // 
            this.Form13comboBox1.FormattingEnabled = true;
            this.Form13comboBox1.Location = new System.Drawing.Point(467, 314);
            this.Form13comboBox1.Name = "Form13comboBox1";
            this.Form13comboBox1.Size = new System.Drawing.Size(181, 24);
            this.Form13comboBox1.TabIndex = 3;
            // 
            // Form13comboBox2
            // 
            this.Form13comboBox2.FormattingEnabled = true;
            this.Form13comboBox2.Location = new System.Drawing.Point(467, 372);
            this.Form13comboBox2.Name = "Form13comboBox2";
            this.Form13comboBox2.Size = new System.Drawing.Size(181, 24);
            this.Form13comboBox2.TabIndex = 4;
            // 
            // Form13button1
            // 
            this.Form13button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.Form13button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Form13button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form13button1.Location = new System.Drawing.Point(294, 448);
            this.Form13button1.Name = "Form13button1";
            this.Form13button1.Size = new System.Drawing.Size(138, 88);
            this.Form13button1.TabIndex = 5;
            this.Form13button1.Text = "Search";
            this.Form13button1.UseVisualStyleBackColor = false;
            this.Form13button1.Click += new System.EventHandler(this.SearchInfoBtn001);
            // 
            // Form13button2
            // 
            this.Form13button2.BackColor = System.Drawing.Color.RoyalBlue;
            this.Form13button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Form13button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form13button2.Location = new System.Drawing.Point(510, 448);
            this.Form13button2.Name = "Form13button2";
            this.Form13button2.Size = new System.Drawing.Size(138, 88);
            this.Form13button2.TabIndex = 6;
            this.Form13button2.Text = "Back";
            this.Form13button2.UseVisualStyleBackColor = false;
            this.Form13button2.Click += new System.EventHandler(this.BackToForm09Btn4);
            // 
            // FYP_Form13
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(904, 568);
            this.Controls.Add(this.Form13button2);
            this.Controls.Add(this.Form13button1);
            this.Controls.Add(this.Form13comboBox2);
            this.Controls.Add(this.Form13comboBox1);
            this.Controls.Add(this.Form13label2);
            this.Controls.Add(this.Form13label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FYP_Form13";
            this.Text = "Search Books Page (User)";
            this.Load += new System.EventHandler(this.FYP_Form13_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label Form13label1;
        private System.Windows.Forms.Label Form13label2;
        private System.Windows.Forms.ComboBox Form13comboBox1;
        private System.Windows.Forms.ComboBox Form13comboBox2;
        private System.Windows.Forms.Button Form13button1;
        private System.Windows.Forms.Button Form13button2;
    }
}