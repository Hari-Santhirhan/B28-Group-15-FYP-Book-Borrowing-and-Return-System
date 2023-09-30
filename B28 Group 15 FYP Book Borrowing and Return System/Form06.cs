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
using System.IO.Ports;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace B28_Group_15_FYP_Book_Borrowing_and_Return_System
{
    public partial class FYP_Form06 : Form
    {
        int number_choice;
        String serverinfo = "server = 127.0.0.1; username = root; password = HelloWorld!12345; database = rfid_library_system";
        public FYP_Form06()
        {
            InitializeComponent();
        }

        private void BackToForm05Btn1(object sender, EventArgs e)//Back Button
        {
            SerialPort port5 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
            try
            {
                port5.Open();
                port5.WriteLine("N");
                port5.Close();
            }
            catch (Exception e10)
            {
                MessageBox.Show(e10.Message);
            }
            port5.Close();
            FYP_Form05 form05 = new FYP_Form05();
            form05.Show();
            this.Hide();
        }

        private void ExecuteCommandBtn1(object sender, EventArgs e)//Execute Button
        {
            if (number_choice == 0)//IF NOT RADIO BUTTONS SELECTED
            {
                MessageBox.Show("Please Select from one of the Following Radio Buttons first");
            }
            else if (number_choice == 1)//BRINGS ADMIN TO ADD NEW BOOK FORM PAGE
            {
                SerialPort port3 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
                try
                {
                    port3.Open();
                    port3.WriteLine("W");
                    port3.Close();
                }
                catch(Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
                port3.Close();
                FYP_Form15 form15 = new FYP_Form15();
                form15.Show();
                this.Hide();
            }
            else if (number_choice == 2)//DELETES BOOK DETAILS FOR THE ADMIN
            {
                SerialPort port5 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
                try
                {
                    port5.Open();
                    port5.WriteLine("B");
                    port5.Close();
                }
                catch (Exception e10)
                {
                    MessageBox.Show(e10.Message);
                }
                port5.Close();
                SerialPort port1 = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
                try
                {
                    //SCANS USING COM8 ARDUINO FOR RFID
                    port1.ReadTimeout = 10000;
                    port1.Open();
                    Form06textBox1.Text = port1.ReadLine();
                    port1.Close();
                    string message = "Are you sure you want to delete this book's details?";
                    string title = "Deletion Confirmation";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.Yes)
                    {
                        MySqlConnection connection1 = new MySqlConnection(serverinfo);
                        try
                        {
                            connection1.Open();
                            MySqlCommand statement1 = new MySqlCommand();
                            statement1 = connection1.CreateCommand();
                            statement1.CommandText = "select * from book_details where RFID_Code = trim('" + Form06textBox1.Text + "')";
                            MySqlDataReader Read1 = statement1.ExecuteReader();
                            if (Read1.Read())
                            {
                                connection1.Close();
                                SerialPort port7 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
                                try
                                {
                                    port7.Open();
                                    port7.WriteLine("S");
                                    port7.Close();
                                }
                                catch (Exception e10)
                                {
                                    MessageBox.Show(e10.Message);
                                }
                                port7.Close();
                                MySqlConnection connection2 = new MySqlConnection(serverinfo);
                                try
                                {
                                    connection2.Open();
                                    MySqlCommand statement2 = new MySqlCommand();
                                    statement2 = connection2.CreateCommand();
                                    statement2.CommandText = "delete from book_details where RFID_Code = trim('" + Form06textBox1.Text + "')";
                                    statement2.ExecuteNonQuery();
                                    MessageBox.Show("This Book's Details have been removed from the database");
                                    connection2.Close();

                                    int email_admin1;
                                    string[] email_admin2;
                                    MySqlConnection connection5 = new MySqlConnection(serverinfo);
                                    try
                                    {
                                        connection5.Open();
                                        MySqlCommand statement5 = new MySqlCommand();
                                        statement5 = connection5.CreateCommand();
                                        statement5.CommandText = "select count(*) Admin_Email from admin";
                                        MySqlDataReader Read5 = statement5.ExecuteReader();
                                        Read5.Read();
                                        email_admin1 = Int32.Parse(Read5.GetValue(0).ToString());
                                        connection5.Close();

                                        email_admin2 = new string[email_admin1];
                                        MySqlConnection connection7 = new MySqlConnection(serverinfo);
                                        try
                                        {
                                            connection7.Open();
                                            MySqlCommand statement7 = new MySqlCommand();
                                            statement7 = connection7.CreateCommand();
                                            statement7.CommandText = "select Admin_Email from admin";
                                            MySqlDataReader Read7 = statement7.ExecuteReader();
                                            for (int x = 0; x < email_admin1; x++)
                                            {
                                                Read7.Read();
                                                email_admin2[x] = Read7.GetValue(0).ToString();
                                            }
                                            connection7.Close();

                                            for (int x2 = 0; x2 < email_admin1; x2++)
                                            {
                                                try
                                                {
                                                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                                                    client.EnableSsl = true;
                                                    client.Timeout = 10000;
                                                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                                                    client.UseDefaultCredentials = false;
                                                    client.Credentials = new NetworkCredential("fyprfidlibrarysystem1234@gmail.com", "Ultimate1234MenOfIronMonger1234567*");
                                                    MailMessage msg = new MailMessage();
                                                    msg.To.Add("" + email_admin2[x2]);
                                                    msg.From = new MailAddress("fyprfidlibrarysystem1234@gmail.com");
                                                    msg.Subject = "FYP Notification for Book Removal from System";
                                                    msg.Body = "Hello Admin. Please take note that a Book has been removed from the database";
                                                    client.Send(msg);
                                                    MessageBox.Show("Email Succesfully Sent to the Admin!");
                                                }
                                                catch (Exception ex1)
                                                {
                                                    MessageBox.Show(ex1.Message);
                                                }
                                            }
                                        }
                                        catch(MySql.Data.MySqlClient.MySqlException ex7)
                                        {
                                            MessageBox.Show(ex7.Message);
                                        }
                                        connection7.Close();
                                    }
                                    catch(MySql.Data.MySqlClient.MySqlException ex5)
                                    {
                                        MessageBox.Show(ex5.Message);
                                    }
                                    connection5.Close();
                                }
                                catch (MySql.Data.MySqlClient.MySqlException ex2)
                                {
                                    MessageBox.Show(ex2.Message);
                                }
                                connection2.Close();
                            }
                            else
                            {
                                SerialPort port8 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
                                try
                                {
                                    port8.Open();
                                    port8.WriteLine("F");
                                    port8.Close();
                                }
                                catch (Exception e10)
                                {
                                    MessageBox.Show(e10.Message);
                                }
                                port8.Close();
                                MessageBox.Show("This book is not found in the database");
                            }
                        }
                        catch(MySql.Data.MySqlClient.MySqlException ex1)
                        {
                            MessageBox.Show(ex1.Message);
                        }
                        connection1.Close();
                    }
                    else
                    {
                        MessageBox.Show("Book Deletion process cancelled");
                    }
                }
                catch (TimeoutException e1)
                {
                    MessageBox.Show(e1.Message);
                }
                port1.Close();
            }
            else if (number_choice == 3)
            {
                MySqlConnection connection1 = new MySqlConnection(serverinfo);
                if (Form06comboBox1.SelectedIndex == -1 && Form06comboBox2.SelectedIndex == -1 && Form06comboBox3.SelectedIndex == -1)//IF NONE
                {
                    MessageBox.Show("Please select an option from one of the Combo Boxes first before Searching");
                }

                else if (Form06comboBox1.SelectedIndex != -1 && Form06comboBox2.SelectedIndex == -1 && Form06comboBox3.SelectedIndex == -1)//IF ONLY BOOK NAME
                {
                    //string s1 = "select * from book_details where Book_Name = '" + Form06comboBox1.Text + "' and ISBN = " + Form06comboBox2.Text + " and Book_ID = '" + Form06comboBox3.Text + "'";
                    string s1 = "select * from book_details where Book_Name = '" + Form06comboBox1.Text + "'";
                    try
                    {
                        connection1.Open();
                        MySqlDataAdapter adapter1 = new MySqlDataAdapter(s1, connection1);
                        DataTable table1 = new DataTable();
                        adapter1.Fill(table1);
                        Form06dataGridView1.DataSource = table1;
                        connection1.Close();
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex1)
                    {
                        MessageBox.Show(ex1.Message);
                    }
                    connection1.Close();
                }

                else if (Form06comboBox1.SelectedIndex == -1 && Form06comboBox2.SelectedIndex != -1 && Form06comboBox3.SelectedIndex == -1)//FOR ISBN ONLY
                {
                    string s1 = "select * from book_details where ISBN = " + Form06comboBox2.Text;
                    try
                    {
                        connection1.Open();
                        MySqlDataAdapter adapter1 = new MySqlDataAdapter(s1, connection1);
                        DataTable table1 = new DataTable();
                        adapter1.Fill(table1);
                        Form06dataGridView1.DataSource = table1;
                        connection1.Close();
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex1)
                    {
                        MessageBox.Show(ex1.Message);
                    }
                    connection1.Close();
                }

                else if (Form06comboBox1.SelectedIndex == -1 && Form06comboBox2.SelectedIndex == -1 && Form06comboBox3.SelectedIndex != -1)//FOR BOOK ID ONLY
                {
                    string s1 = "select * from book_details where Book_ID = '" + Form06comboBox3.Text + "'";
                    try
                    {
                        connection1.Open();
                        MySqlDataAdapter adapter1 = new MySqlDataAdapter(s1, connection1);
                        DataTable table1 = new DataTable();
                        adapter1.Fill(table1);
                        Form06dataGridView1.DataSource = table1;
                        connection1.Close();
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex1)
                    {
                        MessageBox.Show(ex1.Message);
                    }
                    connection1.Close();
                }

                else if (Form06comboBox1.SelectedIndex != -1 && Form06comboBox2.SelectedIndex != -1 && Form06comboBox3.SelectedIndex == -1)//FOR BOOK NAME & ISBN ONLY
                {
                    string s1 = "select * from book_details where Book_Name = '" + Form06comboBox1.Text + "' and ISBN = " + Form06comboBox2.Text;
                    try
                    {
                        connection1.Open();
                        MySqlDataAdapter adapter1 = new MySqlDataAdapter(s1, connection1);
                        DataTable table1 = new DataTable();
                        adapter1.Fill(table1);
                        Form06dataGridView1.DataSource = table1;
                        connection1.Close();
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex1)
                    {
                        MessageBox.Show(ex1.Message);
                    }
                    connection1.Close();
                }

                else if (Form06comboBox1.SelectedIndex == -1 && Form06comboBox2.SelectedIndex != -1 && Form06comboBox3.SelectedIndex != -1)//FOR ISBN & BOOK ID ONLY
                {
                    string s1 = "select * from book_details where ISBN = " + Form06comboBox2.Text + " and Book_ID = '" + Form06comboBox3.Text + "'";
                    try
                    {
                        connection1.Open();
                        MySqlDataAdapter adapter1 = new MySqlDataAdapter(s1, connection1);
                        DataTable table1 = new DataTable();
                        adapter1.Fill(table1);
                        Form06dataGridView1.DataSource = table1;
                        connection1.Close();
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex1)
                    {
                        MessageBox.Show(ex1.Message);
                    }
                    connection1.Close();
                }

                else if (Form06comboBox1.SelectedIndex != -1 && Form06comboBox2.SelectedIndex == -1 && Form06comboBox3.SelectedIndex != -1)//FOR BOOK NAME & BOOK ID ONLY
                {
                    string s1 = "select * from book_details where Book_Name = '" + Form06comboBox1.Text + "' and Book_ID = '" + Form06comboBox3.Text + "'";
                    try
                    {
                        connection1.Open();
                        MySqlDataAdapter adapter1 = new MySqlDataAdapter(s1, connection1);
                        DataTable table1 = new DataTable();
                        adapter1.Fill(table1);
                        Form06dataGridView1.DataSource = table1;
                        connection1.Close();
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex1)
                    {
                        MessageBox.Show(ex1.Message);
                    }
                    connection1.Close();
                }

                else if (Form06comboBox1.SelectedIndex != -1 && Form06comboBox2.SelectedIndex != -1 && Form06comboBox3.SelectedIndex != -1)//FOR BOOK NAME, ISBN, & BOOK ID
                {
                    string s1 = "select * from book_details where Book_Name = '" + Form06comboBox1.Text + "' and ISBN = " + Form06comboBox2.Text + " and Book_ID = '" + Form06comboBox3.Text + "'";
                    try
                    {
                        connection1.Open();
                        MySqlDataAdapter adapter1 = new MySqlDataAdapter(s1, connection1);
                        DataTable table1 = new DataTable();
                        adapter1.Fill(table1);
                        Form06dataGridView1.DataSource = table1;
                        connection1.Close();
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex1)
                    {
                        MessageBox.Show(ex1.Message);
                    }
                    connection1.Close();
                }


            }
        }

        private void FYP_Form06_Load(object sender, EventArgs e)//Loads Items into ComboBoxes
        {
            string A = "select Book_Name from book_details";
            string B = "select ISBN from book_details";
            string C = "select Book_ID from book_details";
            MySqlConnection connection1 = new MySqlConnection(serverinfo);
            try
            {
                connection1.Open();
                MySqlCommand statement1 = new MySqlCommand(A, connection1);
                MySqlDataReader Read1 = statement1.ExecuteReader();
                while (Read1.Read())
                {
                    Form06comboBox1.Items.Add(Read1[0]);
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex1)
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
                    Form06comboBox2.Items.Add(Read2[0]);
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex2)
            {
                MessageBox.Show(ex2.Message);
            }
            connection2.Close();


            MySqlConnection connection3 = new MySqlConnection(serverinfo);
            try
            {
                connection3.Open();
                MySqlCommand statement3 = new MySqlCommand(C, connection3);
                MySqlDataReader Read3 = statement3.ExecuteReader();
                while (Read3.Read())
                {
                    Form06comboBox3.Items.Add(Read3[0]);
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex3)
            {
                MessageBox.Show(ex3.Message);
            }
            connection3.Close();
        }

        private void AddNewBooksRadio1(object sender, EventArgs e)//Add Radio Btn
        {
            if (Form06radioButton1.Checked == true)
            {
                Form06label4.Visible = false;
                Form06label5.Visible = false;
                Form06label6.Visible = false;
                Form06label7.Visible = false;
                Form06label8.Visible = false;
                Form06comboBox1.Visible = false;
                Form06comboBox2.Visible = false;
                Form06comboBox3.Visible = false;
                Form06textBox1.Visible = false;
                number_choice = 1;
            }
            else if (Form06radioButton1.Checked == false)
            {
                Form06label4.Visible = false;
                Form06label5.Visible = false;
                Form06label6.Visible = false;
                Form06label7.Visible = false;
                Form06label8.Visible = false;
                Form06comboBox1.Visible = false;
                Form06comboBox2.Visible = false;
                Form06comboBox3.Visible = false;
                Form06textBox1.Visible = false;
                number_choice = 0;
            }
        }

        private void DeleteBookDetailsRadio2(object sender, EventArgs e)//Delete Radio Btn
        {
            if (radioButton2.Checked == true)
            {
                Form06label4.Visible = false;
                Form06label5.Visible = false;
                Form06label6.Visible = false;
                Form06label7.Visible = false;
                Form06label8.Visible = true;
                Form06comboBox1.Visible = false;
                Form06comboBox2.Visible = false;
                Form06comboBox3.Visible = false;
                Form06textBox1.Visible = true;
                number_choice = 2;
            }
            else if (radioButton2.Checked == false)
            {
                Form06label4.Visible = false;
                Form06label5.Visible = false;
                Form06label6.Visible = false;
                Form06label7.Visible = false;
                Form06label8.Visible = false;
                Form06comboBox1.Visible = false;
                Form06comboBox2.Visible = false;
                Form06comboBox3.Visible = false;
                Form06textBox1.Visible = false;
                number_choice = 0;
            }
        }

        private void SearchBookDetailsRadio3(object sender, EventArgs e)//Search Radio Btn
        {
            if (radioButton3.Checked == true)
            {
                Form06label4.Visible = true;
                Form06label5.Visible = true;
                Form06label6.Visible = true;
                Form06label7.Visible = true;
                Form06label8.Visible = false;
                Form06comboBox1.Visible = true;
                Form06comboBox2.Visible = true;
                Form06comboBox3.Visible = true;
                Form06textBox1.Visible = false;
                number_choice = 3;
            }
            else if (radioButton3.Checked == false)
            {
                Form06label4.Visible = false;
                Form06label5.Visible = false;
                Form06label6.Visible = false;
                Form06label7.Visible = false;
                Form06label8.Visible = false;
                Form06comboBox1.Visible = false;
                Form06comboBox2.Visible = false;
                Form06comboBox3.Visible = false;
                Form06textBox1.Visible = false;
                number_choice = 0;
            }
        }
    }
}
