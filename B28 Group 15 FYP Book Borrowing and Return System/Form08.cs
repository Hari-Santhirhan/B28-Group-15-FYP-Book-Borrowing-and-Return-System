using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace B28_Group_15_FYP_Book_Borrowing_and_Return_System
{
    public partial class FYP_Form08 : Form
    {
        String serverinfo = "server = 127.0.0.1; username = root; password = HelloWorld!12345; database = rfid_library_system";
        int choice;

        private void ToExtendDateBtn01(object sender, EventArgs e)
        {
            
        }

        public FYP_Form08()
        {
            InitializeComponent();
        }

        private void BackToForm05Btn3(object sender, EventArgs e)//Back Btn
        {
            FYP_Form05 form05 = new FYP_Form05();
            form05.Show();
            this.Hide();
        }

        private void ViewBtn01(object sender, EventArgs e)//View Button
        {
            if (Form08radioButton1.Checked == true)
            {
                choice = 1;
            }
            else if (Form08radioButton2.Checked == true)
            {
                choice = 2;
            }
            else if (Form08radioButton3.Checked == true)
            {
                choice = 3;
            }
            if (choice == 1)
            {
                MySqlConnection connection1 = new MySqlConnection(serverinfo);
                try
                {
                    connection1.Open();
                    MySqlDataAdapter adapter1 = new MySqlDataAdapter("select * from borrow", connection1);
                    DataTable table1 = new DataTable();
                    adapter1.Fill(table1);
                    Form08dataGridView1.DataSource = table1;
                }
                catch (MySql.Data.MySqlClient.MySqlException ex1)
                {
                    MessageBox.Show(ex1.Message);
                }
                connection1.Close();
            }
            else if (choice == 2)
            {
                MySqlConnection connection1 = new MySqlConnection(serverinfo);
                try
                {
                    connection1.Open();
                    MySqlDataAdapter adapter1 = new MySqlDataAdapter("select * from returned", connection1);
                    DataTable table1 = new DataTable();
                    adapter1.Fill(table1);
                    Form08dataGridView1.DataSource = table1;
                }
                catch (MySql.Data.MySqlClient.MySqlException ex1)
                {
                    MessageBox.Show(ex1.Message);
                }
                connection1.Close();
            }
            else if (choice == 3)
            {
                MySqlConnection connection1 = new MySqlConnection(serverinfo);
                try
                {
                    connection1.Open();
                    MySqlDataAdapter adpt1 = new MySqlDataAdapter("select * from borrow where Overdue_Status = 'Overdue!'", connection1);
                    DataTable table1 = new DataTable();
                    adpt1.Fill(table1);
                    Form08dataGridView1.DataSource = table1;
                }
                catch(MySql.Data.MySqlClient.MySqlException ex1)
                {
                    MessageBox.Show(ex1.Message);
                }
                connection1.Close();
            }
            else
            {
                MessageBox.Show("Please Choose from one of the following Radio Buttons");
            }
        }

        private void SendingEmailForOverdueBooksBTN01(object sender, EventArgs e)
        {
            
        }
    }
}
