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
    public partial class FYP_Form10 : Form
    {
        //COM8 to 5 = First Scan; COM9 to 3 = Second Scan; COM3 to 4 = LED, LCD, Buzzer;

        //select row_number() over() as num_row, ID_Of_User, Book_Name, ISBN, RFID_Code, Book_ID, Author, Publisher, Overdue_Status from testing where Overdue_Status = 'Overdue!';

        //insert into testing (ID_Of_User, Book_Name, ISBN, RFID_Code, Book_ID, Author, Publisher, Borrowed_Date, To_Return_Date) select 0001, Book_Name, ISBN, RFID_Code, Book_ID, Author, Publisher, curdate(), date_add(curdate(), interval 2 week);

        //insert into borrow(ID_Of_User, Book_Name, ISBN, RFID_Code, Book_ID, Author, Publisher, Borrowed_Date, To_Return_Date) values(0001, 'BOOK1', 1000, 'CODE001', 'E1M1', 'AUTHOR1', 'PUBLISHER1', curdate(), date_add(curdate(), interval 2 week));

        //insert into testing (Book_Name, ISBN, RFID_Code, Book_ID, Author, Publisher, Number_Of_Copies) select Book_Name, ISBN, RFID_Code, Book_ID, Author, Publisher, 5 from book_details where RFID_Code = 'RFIDCODE02'; 
        String serverinfo = "server = 127.0.0.1; username = root; password = HelloWorld!12345; database = rfid_library_system";
        int admin_email1;
        string user_name1, user_email1, book_name1, dates_in_email;
        string[] admin_email2;
        public FYP_Form10()
        {
            InitializeComponent();
        }

        private void BackToForm09Btn1(object sender, EventArgs e)//Back Button
        {
            SerialPort port3 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
            try
            {
                port3.Open();
                port3.WriteLine("N");//NULL WHEN LEAVING PAGE
                port3.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            port3.Close();
            FYP_Form09 form09 = new FYP_Form09();
            form09.Show();
            this.Hide();
        }

        private void BorrowHistoryBtn2(object sender, EventArgs e)//View Borrow History
        {
            MySqlConnection connection1 = new MySqlConnection(serverinfo);
            try
            {
                Form10label1.Text = FYP_Form02.UsernameLogin;
                connection1.Open();
                MySqlDataAdapter adapter1 = new MySqlDataAdapter("select * from borrow where ID_Of_User = " + Form10label1.Text, connection1);
                DataTable table1 = new DataTable();
                adapter1.Fill(table1);
                Form10dataGridView1.DataSource = table1;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex1)
            {
                MessageBox.Show(ex1.Message);
            }
            connection1.Close();
        }

        private void StartScanBtnForm10(object sender, EventArgs e)//Start Scan Button
        {
            Form10label1.Text = FYP_Form02.UsernameLogin;
            string message = "10 seconds for Timeout. Click Yes to begin scan or Click No to cancel scan now";
            string title = "Scan To Borrow";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                SerialPort port3 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
                try
                {
                    port3.Open();
                    port3.WriteLine("B");//BEGIN SCAN
                    port3.Close();
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
                port3.Close();
                SerialPort port1 = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
                try
                {
                    Form10textBox1.Text = "";
                    port1.ReadTimeout = 10000;
                    port1.Open();
                    Form10textBox1.Text = port1.ReadLine();
                    port1.Close();
                    MySqlConnection connection4 = new MySqlConnection(serverinfo);
                    try
                    {
                        connection4.Open();
                        MySqlCommand statement4 = new MySqlCommand();
                        statement4 = connection4.CreateCommand();
                        statement4.CommandText = "select * from borrow where RFID_Code = trim(@RFIDCHECK)";
                        statement4.Parameters.AddWithValue("@RFIDCHECK", Form10textBox1.Text);
                        MySqlDataReader Read4 = statement4.ExecuteReader();
                        if (Read4.Read())
                        {
                            SerialPort port4 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
                            try
                            {
                                port4.Open();
                                port4.WriteLine("F");//SCAN FAILED
                                port4.Close();
                            }
                            catch (Exception e4)
                            {
                                MessageBox.Show(e4.Message);
                            }
                            port4.Close();
                            MessageBox.Show("This book has already been borrowed! Please wait for this book to be returned to borrow it");
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
                        }
                        else
                        {
                            connection4.Close();
                            MySqlConnection connection1 = new MySqlConnection(serverinfo);
                            try
                            {
                                connection1.Open();
                                MySqlCommand statement1 = new MySqlCommand();
                                statement1 = connection1.CreateCommand();
                                statement1.CommandText = "select * from book_details where RFID_Code = trim('" + Form10textBox1.Text + "')";
                                MySqlDataReader Read1 = statement1.ExecuteReader();
                                if (Read1.Read())
                                {
                                    connection1.Close();
                                    string message2 = "Are you sure you want to borrow this book?";
                                    string title2 = "Borrow Confirmation";
                                    MessageBoxButtons buttons2 = MessageBoxButtons.YesNo;
                                    DialogResult result2 = MessageBox.Show(message2, title2, buttons2);
                                    if (result2 == DialogResult.Yes)
                                    {
                                        MySqlConnection connection2 = new MySqlConnection(serverinfo);
                                        try
                                        {
                                            connection2.Open();
                                            MySqlCommand statement2 = new MySqlCommand();
                                            statement2 = connection2.CreateCommand();
                                            statement2.CommandText = "insert into borrow (ID_Of_User, Book_Name, ISBN, RFID_Code, Book_ID, Author, Publisher, Borrowed_Date, To_Return_Date, Overdue_Status, Email_Status) select " + Form10label1.Text + ", Book_Name, ISBN, RFID_Code, Book_ID, Author, Publisher, curdate(), date_add(curdate(), interval 2 week), 'Not Overdued', 'No Need Send' from book_details where RFID_Code = trim('" + Form10textBox1.Text + "')";
                                            statement2.ExecuteNonQuery();
                                            SerialPort port04 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
                                            try
                                            {
                                                port04.Open();
                                                port04.WriteLine("S");//FIRST SCAN COMPLETE
                                                port04.Close();
                                            }
                                            catch (Exception e5)
                                            {
                                                MessageBox.Show(e5.Message);
                                            }
                                            port04.Close();
                                            MessageBox.Show("Book Successfully Borrowed! Please Return within 2 weeks from now! Thank You!");
                                            connection2.Close();
                                            SerialPort port0004 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
                                            try
                                            {
                                                port0004.Open();
                                                port0004.WriteLine("W");//WAITING FOR INPUT
                                                port0004.Close();
                                            }
                                            catch (Exception e7)
                                            {
                                                MessageBox.Show(e7.Message);
                                            }
                                            port0004.Close();

                                            MySqlConnection connection200 = new MySqlConnection(serverinfo);
                                            try
                                            {
                                                connection200.Open();
                                                MySqlCommand statement200 = new MySqlCommand();
                                                statement200 = connection200.CreateCommand();
                                                statement200.CommandText = "select date_add(curdate(), interval 2 week)";
                                                MySqlDataReader Read200 = statement200.ExecuteReader();
                                                Read200.Read();
                                                dates_in_email = Read200.GetValue(0).ToString();
                                                connection200.Close();
                                            }
                                            catch(MySql.Data.MySqlClient.MySqlException ex200)
                                            {
                                                MessageBox.Show(ex200.Message);
                                            }
                                            connection200.Close();

                                            //=========THE PROCESS OF GATHERING INFO TO SEND BY EMAIL STARTS HERE==================================
                                            MySqlConnection connection20 = new MySqlConnection(serverinfo);
                                            try
                                            {
                                                connection20.Open();
                                                MySqlCommand statement20 = new MySqlCommand();
                                                statement20 = connection20.CreateCommand();
                                                statement20.CommandText = "select Name from user where User_ID = " + Form10label1.Text;
                                                MySqlDataReader Read20 = statement20.ExecuteReader();
                                                Read20.Read();
                                                user_name1 = Read20.GetValue(0).ToString();
                                                connection20.Close();

                                                MySqlConnection connection21 = new MySqlConnection(serverinfo);
                                                try
                                                {
                                                    connection21.Open();
                                                    MySqlCommand statement21 = new MySqlCommand();
                                                    statement21 = connection21.CreateCommand();
                                                    statement21.CommandText = "select Email from user where User_ID = " + Form10label1.Text;
                                                    MySqlDataReader Read21 = statement21.ExecuteReader();
                                                    Read21.Read();
                                                    user_email1 = Read21.GetValue(0).ToString();
                                                    connection21.Close();
                                                }
                                                catch(MySql.Data.MySqlClient.MySqlException ex21)
                                                {
                                                    MessageBox.Show(ex21.Message);
                                                }
                                                connection21.Close();

                                                MySqlConnection connection30 = new MySqlConnection(serverinfo);
                                                try
                                                {
                                                    connection30.Open();
                                                    MySqlCommand statement30 = new MySqlCommand();
                                                    statement30 = connection30.CreateCommand();
                                                    statement30.CommandText = "select Book_Name from book_details where RFID_Code = trim('" + Form10textBox1.Text + "')";
                                                    MySqlDataReader Read30 = statement30.ExecuteReader();
                                                    Read30.Read();
                                                    book_name1 = Read30.GetValue(0).ToString();
                                                    connection30.Close();
                                                }
                                                catch(MySql.Data.MySqlClient.MySqlException ex30)
                                                {
                                                    MessageBox.Show(ex30.Message);
                                                }
                                                connection30.Close();
                                            }
                                            catch(MySql.Data.MySqlClient.MySqlException ex20)
                                            {
                                                MessageBox.Show(ex20.Message);
                                            }
                                            connection20.Close();

                                            MySqlConnection connection22 = new MySqlConnection(serverinfo);
                                            try
                                            {
                                                connection22.Open();
                                                MySqlCommand statement22 = new MySqlCommand();
                                                statement22 = connection22.CreateCommand();
                                                statement22.CommandText = "select count(*) Admin_Email from admin";
                                                MySqlDataReader Read22 = statement22.ExecuteReader();
                                                Read22.Read();
                                                admin_email1 = Int32.Parse(Read22.GetValue(0).ToString());
                                                connection22.Close();

                                                admin_email2 = new string[admin_email1];
                                                MySqlConnection connection23 = new MySqlConnection(serverinfo);
                                                try
                                                {
                                                    connection23.Open();
                                                    MySqlCommand statement23 = new MySqlCommand();
                                                    statement23 = connection23.CreateCommand();
                                                    statement23.CommandText = "select Admin_Email from admin";
                                                    MySqlDataReader Read23 = statement23.ExecuteReader();
                                                    for (int x4 = 0; x4 < admin_email1; x4++)
                                                    {
                                                        Read23.Read();
                                                        admin_email2[x4] = Read23.GetValue(0).ToString();
                                                    }
                                                    connection23.Close();
                                                }
                                                catch(MySql.Data.MySqlClient.MySqlException ex23)
                                                {
                                                    MessageBox.Show(ex23.Message);
                                                }
                                                connection23.Close();
                                            }
                                            catch(MySql.Data.MySqlClient.MySqlException ex22)
                                            {
                                                MessageBox.Show(ex22.Message);
                                            }
                                            connection22.Close();

                                            try
                                            {
                                                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                                                client.EnableSsl = true;
                                                client.Timeout = 10000;
                                                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                                                client.UseDefaultCredentials = false;
                                                client.Credentials = new NetworkCredential("fyprfidlibrarysystem1234@gmail.com", "Ultimate1234MenOfIronMonger1234567*");
                                                MailMessage msg = new MailMessage();
                                                msg.To.Add("" + user_email1);
                                                msg.From = new MailAddress("fyprfidlibrarysystem1234@gmail.com");
                                                msg.Subject = "FYP Book Borrowed Successfully";
                                                msg.Body = "Hello " + user_name1 + ".\nYou have successfully borrowed the book called " + book_name1 + ".\nPlease return this book within 2 weeks by " + dates_in_email + ".\nThank You!";
                                                client.Send(msg);
                                                MessageBox.Show("Email Succesfully Sent to the User!");
                                            }
                                            catch (Exception ex1)
                                            {
                                                MessageBox.Show(ex1.Message);
                                            }

                                            for (int y4 = 0; y4 < admin_email1; y4++)
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
                                                    msg.To.Add("" + admin_email2[y4]);
                                                    msg.From = new MailAddress("fyprfidlibrarysystem1234@gmail.com");
                                                    msg.Subject = "FYP Book Return Notification";
                                                    msg.Body = "Hello Admin.\nPlease take note that the user known as " + user_name1 + " has borrowed the book called " + book_name1 + "\nPlease make sure that this book is returned by " + dates_in_email;
                                                    client.Send(msg);
                                                    MessageBox.Show("Email Succesfully Sent to the Admin!");
                                                }
                                                catch (Exception ex1)
                                                {
                                                    MessageBox.Show(ex1.Message);
                                                }
                                            }
                                            //=========THE PROCESS OF GATHERING INFO TO SEND BY EMAIL ENDS HERE==================================
                                        }
                                        catch (MySql.Data.MySqlClient.MySqlException ex4)
                                        {
                                            MessageBox.Show(ex4.Message);
                                        }
                                        connection2.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Book Borrowing Cancelled");
                                    }
                                }
                                else
                                {
                                    SerialPort port004 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
                                    try
                                    {
                                        port004.Open();
                                        port004.WriteLine("F");
                                        port004.Close();
                                    }
                                    catch (Exception e6)
                                    {
                                        MessageBox.Show(e6.Message);
                                    }
                                    port004.Close();
                                    MessageBox.Show("RFID Code in this Book not recognized!");
                                    SerialPort port05 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
                                    try
                                    {
                                        port05.Open();
                                        port05.WriteLine("W");
                                        port05.Close();
                                    }
                                    catch (Exception e9)
                                    {
                                        MessageBox.Show(e9.Message);
                                    }
                                    port05.Close();
                                }
                            }
                            catch (MySql.Data.MySqlClient.MySqlException ex1)
                            {
                                MessageBox.Show(ex1.Message);
                            }
                            connection1.Close();
                        }
                        Form10textBox1.Text = "";
                    }
                    catch(MySql.Data.MySqlClient.MySqlException ex4)
                    {
                        MessageBox.Show(ex4.Message);
                    }
                    connection4.Close();
                }
                catch(TimeoutException e1)//*****************************FOR TIMEOUT FOR FIRST SCAN*********************************
                {
                    SerialPort port03 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
                    try
                    {
                        port03.Open();
                        port03.WriteLine("F");
                        port03.Close();
                    }
                    catch (Exception e2)
                    {
                        MessageBox.Show(e2.Message);
                    }
                    port03.Close();
                    MessageBox.Show(e1.Message);
                    SerialPort port003 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
                    try
                    {
                        port003.Open();
                        port003.WriteLine("W");
                        port003.Close();
                    }
                    catch (Exception e3)
                    {
                        MessageBox.Show(e3.Message);
                    }
                    port003.Close();
                }
                port1.Close();
            }
            else
            {
                MessageBox.Show("Scan has been cancelled");
            }
        }

        private void FYP_Form10_Load(object sender, EventArgs e)
        {
            
        }
    }
}
