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
    public partial class FYP_Form11 : Form
    {
        //COM8 is for the first scan and COM7 is for the second scan
        String serverinfo = "server = 127.0.0.1; username = root; password = HelloWorld!12345; database = rfid_library_system";
        int scan_confirmation1, scan_confirmation2, final_confirmation;
        int email_admin1;
        string user_name1, user_email1, book_name1;
        string []email_admin2;
        public FYP_Form11()
        {
            InitializeComponent();
        }

        private void BackToForm09Btn2(object sender, EventArgs e)//Back Button
        {
            SerialPort port3 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
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
            FYP_Form09 form09 = new FYP_Form09();
            form09.Show();
            this.Hide();
        }

        private void ReturnHistoryBTN1(object sender, EventArgs e)//View Return History
        {
            MySqlConnection connection1 = new MySqlConnection(serverinfo);
            try
            {
                Form11label1.Text = FYP_Form02.UsernameLogin;
                connection1.Open();
                MySqlDataAdapter adapter1 = new MySqlDataAdapter("select * from returned where ID_Of_User = " + Form11label1.Text, connection1);
                DataTable table1 = new DataTable();
                adapter1.Fill(table1);
                Form11dataGridView1.DataSource = table1;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex1)
            {
                MessageBox.Show(ex1.Message);
            }
            connection1.Close();
        }

        private void StartScanToReturnBookBtn(object sender, EventArgs e)//Start Scan Button
        {
            scan_confirmation1 = 0;
            scan_confirmation2 = 0;
            final_confirmation = 0;
            Form11label1.Text = FYP_Form02.UsernameLogin;
            string message = "10 seconds for Timeout. Click Yes to begin scan or Click No to cancel scan now";
            string title = "Scan To Return";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                SerialPort port3 = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
                try
                {
                    port3.Open();
                    port3.WriteLine("B");
                    port3.Close();
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
                port3.Close();
                SerialPort port1 = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);//This will be used for the first scan for the returning part
                try
                {
                    port1.ReadTimeout = 10000;
                    port1.Open();
                    Form11textBox1.Text = port1.ReadLine();
                    port1.Close();
                    MySqlConnection connection1 = new MySqlConnection(serverinfo);
                    try
                    {
                        connection1.Open();
                        MySqlCommand statement1 = new MySqlCommand();
                        statement1 = connection1.CreateCommand();
                        statement1.CommandText = "select * from borrow where ID_Of_User = " + Form11label1.Text + " and RFID_Code = trim('" + Form11textBox1.Text + "')";
                        MySqlDataReader Read1 = statement1.ExecuteReader();
                        if (Read1.Read())
                        {
                            connection1.Close();
                            scan_confirmation1 = 1;
                            SerialPort port03 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
                            try
                            {
                                port03.Open();
                                port03.WriteLine("R");//READYING FOR SECOND SCAN
                                port03.Close();
                            }
                            catch (Exception e4)
                            {
                                MessageBox.Show(e4.Message);
                            }
                            port03.Close();
                            SerialPort port2 = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);//This part is for the second scan for the returning book part for confirmation
                            try
                            {
                                port2.ReadTimeout = 10000;
                                port2.Open();
                                Form11textBox2.Text = port2.ReadLine();
                                port2.Close();
                                MySqlConnection connection10 = new MySqlConnection(serverinfo);
                                try
                                {
                                    connection10.Open();
                                    MySqlCommand statement10 = new MySqlCommand();
                                    statement10 = connection10.CreateCommand();
                                    statement10.CommandText = "select * from borrow where ID_Of_User = " + Form11label1.Text + " and RFID_Code = trim('" + Form11textBox2.Text + "')";
                                    MySqlDataReader Read10 = statement10.ExecuteReader();
                                    if (Read10.Read())
                                    {
                                        connection10.Close();
                                        scan_confirmation2 = 2;
                                        final_confirmation = scan_confirmation1 + scan_confirmation2;
                                        if (final_confirmation == 3 && Form11textBox1.Text == Form11textBox2.Text)
                                        {
                                            MySqlConnection connection2 = new MySqlConnection(serverinfo);
                                            try
                                            {
                                                connection2.Open();
                                                MySqlCommand statement2 = new MySqlCommand();
                                                statement2 = connection2.CreateCommand();
                                                statement2.CommandText = "insert into returned (ID_Of_User, Book_Name, ISBN, RFID_Code, Book_ID, Author, Publisher, Borrowed_Date, Returned_Date) select " + Form11label1.Text + ", Book_Name, ISBN, RFID_Code, Book_ID, Author, Publisher, Borrowed_Date, curdate() from borrow where RFID_Code = trim(@RFIDCHECK2)";
                                                statement2.Parameters.AddWithValue("@RFIDCHECK2", Form11textBox1.Text);
                                                statement2.ExecuteNonQuery();
                                                connection2.Close();
                                                MySqlConnection connection3 = new MySqlConnection(serverinfo);
                                                try
                                                {
                                                    connection3.Open();
                                                    MySqlCommand statement3 = new MySqlCommand();
                                                    statement3 = connection3.CreateCommand();
                                                    statement3.CommandText = "delete from borrow where ID_Of_User = " + Form11label1.Text + " and RFID_Code = trim(@RFIDCHECK3)";
                                                    statement3.Parameters.AddWithValue("@RFIDCHECK3", Form11textBox1.Text);
                                                    statement3.ExecuteNonQuery();
                                                    SerialPort port003 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
                                                    try
                                                    {
                                                        port003.Open();
                                                        port003.WriteLine("G");//SECOND SCAN SUCCESSFUL
                                                        port003.Close();
                                                    }
                                                    catch (Exception e7)
                                                    {
                                                        MessageBox.Show(e7.Message);
                                                    }
                                                    port003.Close();
                                                    MessageBox.Show("Book Successfully Returned! Thank you for using our system!");
                                                    connection3.Close();

                                                    //*****************************************TO EMAIL THE USER AND ADMIN********************************************************
                                                    MySqlConnection connection40 = new MySqlConnection(serverinfo);
                                                    try
                                                    {
                                                        connection40.Open();
                                                        MySqlCommand statement40 = new MySqlCommand();
                                                        statement40 = connection40.CreateCommand();
                                                        statement40.CommandText = "select Name from user where User_ID = " + Form11label1.Text;
                                                        MySqlDataReader Read40 = statement40.ExecuteReader();
                                                        Read40.Read();
                                                        user_name1 = Read40.GetValue(0).ToString();
                                                        connection40.Close();

                                                        MySqlConnection connection41 = new MySqlConnection(serverinfo);
                                                        try
                                                        {
                                                            connection41.Open();
                                                            MySqlCommand statement41 = new MySqlCommand();
                                                            statement41 = connection41.CreateCommand();
                                                            statement41.CommandText = "select Email from user where User_ID = " + Form11label1.Text;
                                                            MySqlDataReader Read41 = statement41.ExecuteReader();
                                                            Read41.Read();
                                                            user_email1 = Read41.GetValue(0).ToString();
                                                            connection41.Close();
                                                        }
                                                        catch(MySql.Data.MySqlClient.MySqlException ex41)
                                                        {
                                                            MessageBox.Show(ex41.Message);
                                                        }
                                                        connection41.Close();
                                                    }
                                                    catch(MySql.Data.MySqlClient.MySqlException ex40)
                                                    {
                                                        MessageBox.Show(ex40.Message);
                                                    }
                                                    connection40.Close();

                                                    MySqlConnection connection42 = new MySqlConnection(serverinfo);
                                                    try
                                                    {
                                                        connection42.Open();
                                                        MySqlCommand statement42 = new MySqlCommand();
                                                        statement42 = connection42.CreateCommand();
                                                        statement42.CommandText = "select count(*) Admin_Email from admin";
                                                        MySqlDataReader Read42 = statement42.ExecuteReader();
                                                        Read42.Read();
                                                        email_admin1 = Int32.Parse(Read42.GetValue(0).ToString());
                                                        email_admin2 = new string[email_admin1];
                                                        connection42.Close();

                                                        MySqlConnection connection43 = new MySqlConnection(serverinfo);
                                                        try
                                                        {
                                                            connection43.Open();
                                                            MySqlCommand statement43 = new MySqlCommand();
                                                            statement43 = connection43.CreateCommand();
                                                            statement43.CommandText = "select Admin_Email from admin";
                                                            MySqlDataReader Read43 = statement43.ExecuteReader();
                                                            for (int x5 = 0; x5 < email_admin1; x5++)
                                                            {
                                                                Read43.Read();
                                                                email_admin2[x5] = Read43.GetValue(0).ToString();
                                                            }
                                                            connection43.Close();
                                                        }
                                                        catch(MySql.Data.MySqlClient.MySqlException ex43)
                                                        {
                                                            MessageBox.Show(ex43.Message);
                                                        }
                                                        connection43.Close();
                                                    }
                                                    catch(MySql.Data.MySqlClient.MySqlException ex42)
                                                    {
                                                        MessageBox.Show(ex42.Message);
                                                    }
                                                    connection42.Close();

                                                    MySqlConnection connection44 = new MySqlConnection(serverinfo);
                                                    try
                                                    {
                                                        connection44.Open();
                                                        MySqlCommand statement44 = new MySqlCommand();
                                                        statement44 = connection44.CreateCommand();
                                                        statement44.CommandText = "select Book_Name from returned where RFID_Code = trim('" + Form11textBox2.Text + "')";
                                                        MySqlDataReader Read44 = statement44.ExecuteReader();
                                                        Read44.Read();
                                                        book_name1 = Read44.GetValue(0).ToString();
                                                        connection44.Close();
                                                    }
                                                    catch(MySql.Data.MySqlClient.MySqlException ex44)
                                                    {
                                                        MessageBox.Show(ex44.Message);
                                                    }
                                                    connection44.Close();

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
                                                        msg.Subject = "FYP Book Returned Successfully";
                                                        msg.Body = "Hello " + user_name1 + ".\nYou have successfully returned the book called " + book_name1 + ".\nThank You!";
                                                        client.Send(msg);
                                                        MessageBox.Show("Email Succesfully Sent to the User!");
                                                    }
                                                    catch (Exception ex1)
                                                    {
                                                        MessageBox.Show(ex1.Message);
                                                    }

                                                    for (int y4 = 0; y4 < email_admin1; y4++)
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
                                                            msg.To.Add("" + email_admin2[y4]);
                                                            msg.From = new MailAddress("fyprfidlibrarysystem1234@gmail.com");
                                                            msg.Subject = "FYP Book Borrowed Notification";
                                                            msg.Body = "Hello Admin.\nPlease take note that the user known as " + user_name1 + " has returned the book called " + book_name1;
                                                            client.Send(msg);
                                                            MessageBox.Show("Email Succesfully Sent to the Admin!");
                                                        }
                                                        catch (Exception ex1)
                                                        {
                                                            MessageBox.Show(ex1.Message);
                                                        }
                                                    }
                                                    //*****************************************TO EMAIL THE USER AND ADMIN********************************************************
                                                }
                                                catch (MySql.Data.MySqlClient.MySqlException ex3)
                                                {
                                                    MessageBox.Show(ex3.Message);
                                                }
                                                connection3.Close();//This will close the connection3
                                            }
                                            catch (MySql.Data.MySqlClient.MySqlException ex2)
                                            {
                                                MessageBox.Show(ex2.Message);
                                            }
                                            connection2.Close();
                                        }
                                        else
                                        {
                                            SerialPort port4 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
                                            try
                                            {
                                                port4.Open();
                                                port4.WriteLine("F");
                                                port4.Close();
                                            }
                                            catch (Exception e8)
                                            {
                                                MessageBox.Show(e8.Message);
                                            }
                                            port4.Close();
                                            MessageBox.Show("Error in the scannning processes!");
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
                                    else
                                    {
                                        SerialPort port05 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
                                        try
                                        {
                                            port05.Open();
                                            port05.WriteLine("F");
                                            port05.Close();
                                        }
                                        catch (Exception e11)
                                        {
                                            MessageBox.Show(e11.Message);
                                        }
                                        port05.Close();
                                        MessageBox.Show("RFID Code in 2nd scan does not match RFID Code in 1st scan!");
                                        SerialPort port7 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
                                        try
                                        {
                                            port7.Open();
                                            port7.WriteLine("W");
                                            port7.Close();
                                        }
                                        catch (Exception e14)
                                        {
                                            MessageBox.Show(e14.Message);
                                        }
                                        port7.Close();
                                    }
                                }
                                catch(MySql.Data.MySqlClient.MySqlException ex10)
                                {
                                    MessageBox.Show(ex10.Message);
                                }
                                connection10.Close();
                            }
                            catch(TimeoutException e2)//************************FOR SECOND SCAN TIMEOUT*******************************
                            {
                                SerialPort port22 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
                                try
                                {
                                    port22.Open();
                                    port22.WriteLine("F");
                                    port22.Close();
                                }
                                catch (Exception e44)
                                {
                                    MessageBox.Show(e44.Message);
                                }
                                port22.Close();
                                MessageBox.Show(e2.Message);
                                SerialPort port022 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
                                try
                                {
                                    port022.Open();
                                    port022.WriteLine("W");
                                    port022.Close();
                                }
                                catch (Exception e45)
                                {
                                    MessageBox.Show(e45.Message);
                                }
                                port022.Close();
                            }
                            port2.Close();
                        }
                        else
                        {
                            SerialPort port07 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
                            try
                            {
                                port07.Open();
                                port07.WriteLine("F");
                                port07.Close();
                            }
                            catch (Exception e15)
                            {
                                MessageBox.Show(e15.Message);
                            }
                            port07.Close();
                            MessageBox.Show("Details of this book was not found in your borrowed list!");
                            SerialPort port8 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
                            try
                            {
                                port8.Open();
                                port8.WriteLine("W");
                                port8.Close();
                            }
                            catch (Exception e16)
                            {
                                MessageBox.Show(e16.Message);
                            }
                            port8.Close();
                        }
                    }
                    catch(MySql.Data.MySqlClient.MySqlException ex1)
                    {
                        MessageBox.Show(ex1.Message);
                    }
                    connection1.Close();
                }
                catch (TimeoutException e1)//****************************FOR FIRST SCAN TIMEOUT****************************
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
                    SerialPort port21 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
                    try
                    {
                        port21.Open();
                        port21.WriteLine("W");
                        port21.Close();
                    }
                    catch (Exception e41)
                    {
                        MessageBox.Show(e41.Message);
                    }
                    port21.Close();
                }
                port1.Close();
            }
            else
            {
                MessageBox.Show("Book Return Process Cancelled");
            }
        }
    }
}
