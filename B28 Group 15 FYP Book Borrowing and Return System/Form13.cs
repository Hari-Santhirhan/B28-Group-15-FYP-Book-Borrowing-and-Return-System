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
    public partial class FYP_Form13 : Form
    {
        String serverinfo = "server = 127.0.0.1; username = root; password = HelloWorld!12345; database = rfid_library_system";
        public FYP_Form13()
        {
            InitializeComponent();
        }

        private void BackToForm09Btn4(object sender, EventArgs e)//Back Button
        {
            FYP_Form09 form09 = new FYP_Form09();
            form09.Show();
            this.Hide();
        }

        private void FYP_Form13_Load(object sender, EventArgs e)//Load Items into ComboBoxes
        {
            string A = "select Book_Name from book_details";
            string B = "select ISBN from book_details";
            MySqlConnection connection1 = new MySqlConnection(serverinfo);
            try
            {
                connection1.Open();
                MySqlCommand statement1 = new MySqlCommand(A, connection1);
                MySqlDataReader Read1 = statement1.ExecuteReader();
                while (Read1.Read())
                {
                    Form13comboBox1.Items.Add(Read1[0]);
                }
            }
            catch(MySql.Data.MySqlClient.MySqlException ex1)
            {
                MessageBox.Show(ex1.Message);
            }
            connection1.Close();


            MySqlConnection connection2 = new MySqlConnection(serverinfo);
            try
            {
                connection2.Open();
                MySqlCommand statement2 = new MySqlCommand(B, connection2);
                MySqlDataReader Read2 = statement2.ExecuteReader();
                while (Read2.Read())
                {
                    Form13comboBox2.Items.Add(Read2[0]);
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex2)
            {
                MessageBox.Show(ex2.Message);
            }
            connection2.Close();
        }

        private void SearchInfoBtn001(object sender, EventArgs e)//Search Button
        {
            if (Form13comboBox1.SelectedIndex == -1 && Form13comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose from one of the Combo Boxes first");
            }
            else if (Form13comboBox1.SelectedIndex != -1 && Form13comboBox2.SelectedIndex == -1)
            {
                string C = "select * from book_details where Book_Name = '" + Form13comboBox1.Text + "'";
                MySqlConnection connection3 = new MySqlConnection(serverinfo);
                {
                    connection3.Open();
                    try
                    {
                        MySqlDataAdapter adpt1 = new MySqlDataAdapter(C, connection3);
                        DataTable table1 = new DataTable();
                        adpt1.Fill(table1);
                        dataGridView1.DataSource = table1;
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex3)
                    {
                        MessageBox.Show(ex3.Message);
                    }
                    connection3.Close();
                }
            }
            else if (Form13comboBox1.SelectedIndex == -1 && Form13comboBox2.SelectedIndex != -1)
            {
                string C = "select * from book_details where ISBN = " + Form13comboBox2.Text;
                MySqlConnection connection3 = new MySqlConnection(serverinfo);
                {
                    connection3.Open();
                    try
                    {
                        MySqlDataAdapter adpt1 = new MySqlDataAdapter(C, connection3);
                        DataTable table1 = new DataTable();
                        adpt1.Fill(table1);
                        dataGridView1.DataSource = table1;
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex3)
                    {
                        MessageBox.Show(ex3.Message);
                    }
                    connection3.Close();
                }
            }
            else if (Form13comboBox1.SelectedIndex != -1 && Form13comboBox2.SelectedIndex != -1)
            {
                string C = "select * from book_details where Book_Name = '" + Form13comboBox1.Text + "' and ISBN = " + Form13comboBox2.Text;
                MySqlConnection connection3 = new MySqlConnection(serverinfo);
                {
                    connection3.Open();
                    try
                    {
                        MySqlDataAdapter adpt1 = new MySqlDataAdapter(C, connection3);
                        DataTable table1 = new DataTable();
                        adpt1.Fill(table1);
                        dataGridView1.DataSource = table1;
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex3)
                    {
                        MessageBox.Show(ex3.Message);
                    }
                    connection3.Close();
                }
            }
        }
    }
}
