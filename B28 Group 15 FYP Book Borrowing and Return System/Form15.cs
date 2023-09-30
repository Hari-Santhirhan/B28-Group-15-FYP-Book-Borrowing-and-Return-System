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
    public partial class FYP_Form15 : Form
    {
        String serverinfo = "server = 127.0.0.1; username = root; password = HelloWorld!12345; database = rfid_library_system";
        int email_admin1;
        string[] email_admin2;
        public FYP_Form15()
        {
            InitializeComponent();
        }

        private void ScanToAddNewBookRFID(object sender, EventArgs e)//Start Scan for Add Btn
        {
            SerialPort port3 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
            try
            {
                port3.Open();
                port3.WriteLine("B");
                port3.Close();
            }
            catch (Exception e6)
            {
                MessageBox.Show(e6.Message);
            }
            port3.Close();
            SerialPort port1 = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
            try
            {
                port1.ReadTimeout = 10000;
                port1.Open();
                Form15textBox3.Text = port1.ReadLine();
                port1.Close();
                MySqlConnection connection1 = new MySqlConnection(serverinfo);
                try
                {
                    connection1.Open();
                    MySqlCommand statement1 = new MySqlCommand();
                    statement1 = connection1.CreateCommand();
                    statement1.CommandText = "select * from book_details where RFID_Code = trim(@RFIDCode)";
                    statement1.Parameters.AddWithValue("@RFIDCode", Form15textBox3.Text);
                    MySqlDataReader Read1 = statement1.ExecuteReader();
                    if (Read1.Read())
                    {
                        SerialPort port03 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
                        try
                        {
                            port03.Open();
                            port03.WriteLine("F");
                            port03.Close();
                        }
                        catch (Exception e7)
                        {
                            MessageBox.Show(e7.Message);
                        }
                        port03.Close();
                        MessageBox.Show("A Book with this RFID Code already exists in this database");
                        SerialPort port4 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
                        try
                        {
                            port4.Open();
                            port4.WriteLine("W");
                            port4.Close();
                        }
                        catch (Exception e8)
                        {
                            MessageBox.Show(e8.Message);
                        }
                        port4.Close();
                    }
                    else
                    {
                        SerialPort port04 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
                        try
                        {
                            port04.Open();
                            port04.WriteLine("S");
                            port04.Close();
                        }
                        catch (Exception e9)
                        {
                            MessageBox.Show(e9.Message);
                        }
                        port04.Close();
                        MessageBox.Show("A new RFID Code has been detected. To add this into the database, please this book's details and click confirm");
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
                    }
                }
                catch(MySql.Data.MySqlClient.MySqlException ex1)
                {
                    MessageBox.Show(ex1.Message);
                }
                connection1.Close();
            }
            catch(TimeoutException e1)//***********************TIMEOUT WHEN SCANNING FOR ADMIN ADD BOOKS************************
            {
                SerialPort port20 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
                try
                {
                    port20.Open();
                    port20.WriteLine("F");
                    port20.Close();
                }
                catch (Exception e40)
                {
                    MessageBox.Show(e40.Message);
                }
                port20.Close();
                MessageBox.Show(e1.Message);
                SerialPort port020 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
                try
                {
                    port020.Open();
                    port020.WriteLine("W");
                    port020.Close();
                }
                catch (Exception e41)
                {
                    MessageBox.Show(e41.Message);
                }
                port020.Close();
            }
            port1.Close();
        }

        private void ConfirmDetailsForAddNewBooks(object sender, EventArgs e)//Confirm Btn
        {
            string message = "Are you sure you want to add in this new book?";
            string title = "Book Adding Confirmation";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                MySqlConnection connection2 = new MySqlConnection(serverinfo);
                try
                {
                    connection2.Open();
                    MySqlCommand statement2 = new MySqlCommand();
                    statement2 = connection2.CreateCommand();
                    statement2.CommandText = "select * from book_details where RFID_Code = trim(@Code)";
                    statement2.Parameters.AddWithValue("@Code", Form15textBox3.Text);
                    MySqlDataReader Read2 = statement2.ExecuteReader();
                    if (Read2.Read())
                    {
                        connection2.Close();
                        MessageBox.Show("This RFID Code corresponds with a book that has already been added into the database");
                    }
                    else
                    {
                        connection2.Close();
                        MySqlConnection connection1 = new MySqlConnection(serverinfo);
                        try
                        {
                            connection1.Open();
                            MySqlCommand statement1 = new MySqlCommand();
                            statement1 = connection1.CreateCommand();
                            statement1.CommandText = "insert into book_details (Book_Name, ISBN, RFID_Code, Book_ID, Author, Publisher) values (@BookName, @ISBN, trim(@RFID), @BookID, @Author, @Publisher)";
                            statement1.Parameters.AddWithValue("@BookName", Form15textBox1.Text);
                            statement1.Parameters.AddWithValue("@ISBN", Form15textBox2.Text);
                            statement1.Parameters.AddWithValue("@RFID", Form15textBox3.Text);
                            statement1.Parameters.AddWithValue("@BookID", Form15textBox4.Text);
                            statement1.Parameters.AddWithValue("@Author", Form15textBox5.Text);
                            statement1.Parameters.AddWithValue("@Publisher", Form15textBox6.Text);
                            statement1.ExecuteNonQuery();
                            MessageBox.Show("New Book was successfully added!");
                        }
                        catch (MySql.Data.MySqlClient.MySqlException ex1)
                        {
                            MessageBox.Show(ex1.Message);
                        }
                        connection1.Close();

                        MySqlConnection connection100 = new MySqlConnection(serverinfo);
                        try
                        {
                            connection100.Open();
                            MySqlCommand statement100 = new MySqlCommand();
                            statement100 = connection100.CreateCommand();
                            statement100.CommandText = "select count(*) Admin_Email from admin";
                            MySqlDataReader Read100 = statement100.ExecuteReader();
                            Read100.Read();
                            email_admin1 = Int32.Parse(Read100.GetValue(0).ToString());
                            email_admin2 = new string[email_admin1];
                            connection100.Close();

                            MySqlConnection connection101 = new MySqlConnection(serverinfo);
                            try
                            {
                                connection101.Open();
                                MySqlCommand statement101 = new MySqlCommand();
                                statement101 = connection101.CreateCommand();
                                statement101.CommandText = "select Admin_Email from admin";
                                MySqlDataReader Read101 = statement101.ExecuteReader();
                                for (int z = 0; z < email_admin1; z++)
                                {
                                    Read101.Read();
                                    email_admin2[z] = Read101.GetValue(0).ToString();
                                }
                                connection101.Close();
                            }
                            catch(MySql.Data.MySqlClient.MySqlException ex101)
                            {
                                MessageBox.Show(ex101.Message);
                            }
                            connection101.Close();

                            for (int x1 = 0; x1 < email_admin1; x1++)
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
                                    msg.To.Add("" + email_admin2[x1]);
                                    msg.From = new MailAddress("fyprfidlibrarysystem1234@gmail.com");
                                    msg.Subject = "FYP New Book Added into System";
                                    msg.Body = "Hello Admin! A new Book called " + Form15textBox1.Text + " has been added into the system!";
                                    client.Send(msg);
                                    MessageBox.Show("Email Succesfully Sent to the Admin!");
                                }
                                catch (Exception ex1)
                                {
                                    MessageBox.Show(ex1.Message);
                                }
                            }
                        }
                        catch(MySql.Data.MySqlClient.MySqlException ex100)
                        {
                            MessageBox.Show(ex100.Message);
                        }
                        connection100.Close();
                    }
                }
                catch(MySql.Data.MySqlClient.MySqlException ex2)
                {
                    MessageBox.Show(ex2.Message);
                }
                connection2.Close();
            }
            else
            {
                MessageBox.Show("Book Adding Process was cancelled");
            }
        }

        private void BackToAdminfromForm15(object sender, EventArgs e)//Back Button
        {
            SerialPort port3 = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
            try
            {
                port3.Open();
                port3.WriteLine("N");
                port3.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            port3.Close();
            FYP_Form06 form06 = new FYP_Form06();
            form06.Show();
            this.Hide();
        }
    }
}
