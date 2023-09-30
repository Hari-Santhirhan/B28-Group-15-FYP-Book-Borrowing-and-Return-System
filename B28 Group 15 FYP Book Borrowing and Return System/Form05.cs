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
    public partial class FYP_Form05 : Form
    {
        public FYP_Form05()
        {
            InitializeComponent();
        }

        private void BookDetailsBtn(object sender, EventArgs e)//Goto Book Details
        {
            //==========================================TO BOOK DETAILS======================
            SerialPort port5 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
            try
            {
                port5.Open();
                port5.WriteLine("W");
                port5.Close();
            }
            catch (Exception e10)
            {
                MessageBox.Show(e10.Message);
            }
            port5.Close();
            FYP_Form06 form06 = new FYP_Form06();
            form06.Show();
            this.Hide();
        }

        private void RegisteredUserDetailsBtn(object sender, EventArgs e)//Goto Registered User Details
        {
            //=========================================TO SEE REGISTERED USER DETAILS==========================
            FYP_Form07 form07 = new FYP_Form07();
            form07.Show();
            this.Hide();
        }

        private void BorrowedReturnedDetailsBtn(object sender, EventArgs e)//Goto Borrowed & Returned & Overdue Details 
        {
            //===========================================TO SEE BORROWED AND RETURNED BOOK DETAILS==========================
            FYP_Form08 form08 = new FYP_Form08();
            form08.Show();
            this.Hide();
        }

        private void AdminLogOutBtn(object sender, EventArgs e)//Logout for Admin
        {
            //===========================================TO LOG OUT FROM ADMIN LOGIN========================================
            FYP_Form02 form02 = new FYP_Form02();
            form02.Show();
            this.Hide();
        }

        private void TestViewinMySQLbtn(object sender, EventArgs e)
        {

        }

        private void GotoTestingBTN01(object sender, EventArgs e)
        {
           
        }
    }
}
