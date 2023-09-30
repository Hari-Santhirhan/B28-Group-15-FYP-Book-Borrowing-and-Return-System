using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace B28_Group_15_FYP_Book_Borrowing_and_Return_System
{
    public partial class FYP_Form09 : Form
    {
        public FYP_Form09()
        {
            InitializeComponent();
        }

        private void BorrowBooksBtn(object sender, EventArgs e)//Goto Borrow Page
        {
            SerialPort port5 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
            try
            {
                port5.Open();
                port5.WriteLine("W");
                port5.Close();
            }
            catch (Exception e8)
            {
                MessageBox.Show(e8.Message);
            }
            port5.Close();
            FYP_Form10 form10 = new FYP_Form10();
            form10.Show();
            this.Hide();
        }

        private void ReturnBooksBtn(object sender, EventArgs e)//Goto Return Page
        {
            SerialPort port5 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
            try
            {
                port5.Open();
                port5.WriteLine("W");
                port5.Close();
            }
            catch (Exception e8)
            {
                MessageBox.Show(e8.Message);
            }
            port5.Close();
            FYP_Form11 form11 = new FYP_Form11();
            form11.Show();
            this.Hide();
        }

        private void ChangePasswordBtn(object sender, EventArgs e)//Goto Change Password Page
        {
            FYP_Form12 form12 = new FYP_Form12();
            form12.Show();
            this.Hide();
        }

        private void SearchBooksBtn(object sender, EventArgs e)//Goto Search Books Page
        {
            FYP_Form13 form13 = new FYP_Form13();
            form13.Show();
            this.Hide();
        }

        private void BackToUserLoginBtn(object sender, EventArgs e)//Logout Button
        {
            FYP_Form02 form02 = new FYP_Form02();
            form02.Show();
            this.Hide();
        }

        private void FYP_Form09_Load(object sender, EventArgs e)
        {
            
        }

        private void Form09label1_Click(object sender, EventArgs e)
        {

        }

        private void Form09Button7_Click(object sender, EventArgs e)//Goto Extend Date Page
        {
            SerialPort port5 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
            try
            {
                port5.Open();
                port5.WriteLine("W");
                port5.Close();
            }
            catch (Exception e8)
            {
                MessageBox.Show(e8.Message);
            }
            port5.Close();
            FYP_Form16 form16 = new FYP_Form16();
            form16.Show();
            this.Hide();
        }
    }
}
