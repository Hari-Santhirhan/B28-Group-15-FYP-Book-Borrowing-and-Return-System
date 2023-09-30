
namespace B28_Group_15_FYP_Book_Borrowing_and_Return_System
{
    partial class FYP_Form08
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
            this.Form08dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Form08radioButton1 = new System.Windows.Forms.RadioButton();
            this.Form08radioButton2 = new System.Windows.Forms.RadioButton();
            this.Form08button1 = new System.Windows.Forms.Button();
            this.Form08button2 = new System.Windows.Forms.Button();
            this.Form08radioButton3 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.Form08dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Form08dataGridView1
            // 
            this.Form08dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form08dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Form08dataGridView1.Location = new System.Drawing.Point(70, 33);
            this.Form08dataGridView1.Name = "Form08dataGridView1";
            this.Form08dataGridView1.RowHeadersWidth = 51;
            this.Form08dataGridView1.RowTemplate.Height = 24;
            this.Form08dataGridView1.Size = new System.Drawing.Size(874, 243);
            this.Form08dataGridView1.TabIndex = 0;
            // 
            // Form08radioButton1
            // 
            this.Form08radioButton1.AutoSize = true;
            this.Form08radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Form08radioButton1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form08radioButton1.Location = new System.Drawing.Point(104, 315);
            this.Form08radioButton1.Name = "Form08radioButton1";
            this.Form08radioButton1.Size = new System.Drawing.Size(214, 33);
            this.Form08radioButton1.TabIndex = 1;
            this.Form08radioButton1.TabStop = true;
            this.Form08radioButton1.Text = "Borrowed Books";
            this.Form08radioButton1.UseVisualStyleBackColor = true;
            // 
            // Form08radioButton2
            // 
            this.Form08radioButton2.AutoSize = true;
            this.Form08radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Form08radioButton2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form08radioButton2.Location = new System.Drawing.Point(399, 315);
            this.Form08radioButton2.Name = "Form08radioButton2";
            this.Form08radioButton2.Size = new System.Drawing.Size(207, 33);
            this.Form08radioButton2.TabIndex = 2;
            this.Form08radioButton2.TabStop = true;
            this.Form08radioButton2.Text = "Returned Books";
            this.Form08radioButton2.UseVisualStyleBackColor = true;
            // 
            // Form08button1
            // 
            this.Form08button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.Form08button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Form08button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form08button1.Location = new System.Drawing.Point(329, 409);
            this.Form08button1.Name = "Form08button1";
            this.Form08button1.Size = new System.Drawing.Size(145, 80);
            this.Form08button1.TabIndex = 3;
            this.Form08button1.Text = "View";
            this.Form08button1.UseVisualStyleBackColor = false;
            this.Form08button1.Click += new System.EventHandler(this.ViewBtn01);
            // 
            // Form08button2
            // 
            this.Form08button2.BackColor = System.Drawing.Color.RoyalBlue;
            this.Form08button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Form08button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form08button2.Location = new System.Drawing.Point(540, 409);
            this.Form08button2.Name = "Form08button2";
            this.Form08button2.Size = new System.Drawing.Size(145, 80);
            this.Form08button2.TabIndex = 4;
            this.Form08button2.Text = "Back";
            this.Form08button2.UseVisualStyleBackColor = false;
            this.Form08button2.Click += new System.EventHandler(this.BackToForm05Btn3);
            // 
            // Form08radioButton3
            // 
            this.Form08radioButton3.AutoSize = true;
            this.Form08radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Form08radioButton3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Form08radioButton3.Location = new System.Drawing.Point(686, 315);
            this.Form08radioButton3.Name = "Form08radioButton3";
            this.Form08radioButton3.Size = new System.Drawing.Size(215, 33);
            this.Form08radioButton3.TabIndex = 5;
            this.Form08radioButton3.TabStop = true;
            this.Form08radioButton3.Text = "Overdued Books";
            this.Form08radioButton3.UseVisualStyleBackColor = true;
            // 
            // FYP_Form08
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(1010, 520);
            this.Controls.Add(this.Form08radioButton3);
            this.Controls.Add(this.Form08button2);
            this.Controls.Add(this.Form08button1);
            this.Controls.Add(this.Form08radioButton2);
            this.Controls.Add(this.Form08radioButton1);
            this.Controls.Add(this.Form08dataGridView1);
            this.Name = "FYP_Form08";
            this.Text = "Borrowed/Returned Details";
            ((System.ComponentModel.ISupportInitialize)(this.Form08dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Form08dataGridView1;
        private System.Windows.Forms.RadioButton Form08radioButton1;
        private System.Windows.Forms.RadioButton Form08radioButton2;
        private System.Windows.Forms.Button Form08button1;
        private System.Windows.Forms.Button Form08button2;
        private System.Windows.Forms.RadioButton Form08radioButton3;
    }
}