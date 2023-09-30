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
    public partial class FYP_Form16 : Form
    {
        String serverinfo = "server = 127.0.0.1; username = root; password = HelloWorld!12345; database = rfid_library_system";
        string name_user_1, email_user_1, email_of_dates;
        int date_extend;
        public FYP_Form16()
        {
            InitializeComponent();
        }

        private void BackToAdminPageBTN10(object sender, EventArgs e)//Back Button
        {
            FYP_Form09 form0009 = new FYP_Form09();
            form0009.Show();
            this.Hide();
        }

        private void ExtendDateAccordinglyBtn01(object sender, EventArgs e)//Extend Date
        {
            if (Form16comboBox2.SelectedIndex == -1 || Form16comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Please select both options from the combo boxes first");
            }
            else
            {
                MessageBox.Show("Please scan the selected book for confirmation first. Scan will begin once Ok is selected.");
                SerialPort port1 = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
                try
                {
                    port1.ReadTimeout = 5000;
                    port1.Open();
                    Form16textBox1.Text = port1.ReadLine();
                    port1.Close();
                    MySqlConnection connection1 = new MySqlConnection(serverinfo);
                    try
                    {
                        connection1.Open();
                        MySqlCommand statement1 = new MySqlCommand();
                        statement1 = connection1.CreateCommand();
                        statement1.CommandText = "select * from borrow where ID_Of_User = " + FYP_Form02.UsernameLogin + " and Book_Name = '" + Form16comboBox2.Text + "' and ISBN = " + Form16comboBox3.Text + " and RFID_Code = trim('" + Form16textBox1.Text + "')";
                        MySqlDataReader Read1 = statement1.ExecuteReader();
                        if (Read1.Read())
                        {
                            connection1.Close();
                            MessageBox.Show("The Details provided match with a book in the database");
                            MessageBox.Show("To Confirm the Extension Date, Please Enter the Week Interval into the Text Box");
                        }
                        else
                        {
                            MessageBox.Show("The Details provided DO NOT match with anything found in the database");
                        }
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex1)
                    {
                        MessageBox.Show(ex1.Message);
                    }
                    connection1.Close();
                }
                catch (TimeoutException e1)
                {
                    MessageBox.Show(e1.Message);
                }
                port1.Close();
            }
        }

        private void FYP_Form16_Load(object sender, EventArgs e)//For Loading items into ComboBoxes
        {
            string B = "select Book_Name from borrow";
            string C = "select ISBN from borrow";

            MySqlConnection connection2 = new MySqlConnection(serverinfo);
            try
            {
                connection2.Open();
                MySqlCommand statement2 = new MySqlCommand(B, connection2);
                MySqlDataReader Read2 = statement2.ExecuteReader();
                while (Read2.Read())
                {
                    Form16comboBox2.Items.Add(Read2[0]);
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
                    Form16comboBox3.Items.Add(Read3[0]);
                }
            }
            catch(MySql.Data.MySqlClient.MySqlException ex3)
            {
                MessageBox.Show(ex3.Message);
            }
            connection3.Close();
        }

        private void ConfirmExtensionDateBtn01(object sender, EventArgs e)//Confirm Extend Date
        {
            MySqlConnection connection2 = new MySqlConnection(serverinfo);
            try
            {
                connection2.Open();
                MySqlCommand statement2 = new MySqlCommand();
                statement2 = connection2.CreateCommand();
                statement2.CommandText = "update borrow set To_Return_Date = curdate() where ID_Of_User = " + FYP_Form02.UsernameLogin + " and Book_Name = '" + Form16comboBox2.Text + "' and ISBN = " + Form16comboBox3.Text + " and RFID_Code = trim('" + Form16textBox1.Text + "')";
                statement2.ExecuteNonQuery();
                connection2.Close();
                MySqlConnection connection3 = new MySqlConnection(serverinfo);
                try
                {
                    connection3.Open();
                    MySqlCommand statement3 = new MySqlCommand();
                    statement3 = connection3.CreateCommand();
                    statement3.CommandText = "update borrow set To_Return_Date = date_add(curdate(), interval " + Form16textBox2.Text + " week) where ID_Of_User = " + FYP_Form02.UsernameLogin + " and Book_Name = '" + Form16comboBox2.Text + "' and ISBN = " + Form16comboBox3.Text + " and RFID_Code = trim('" + Form16textBox1.Text + "')";
                    statement3.ExecuteNonQuery();
                    connection3.Close();
                    MessageBox.Show("Due Date Successfully Extended!");

                    MySqlConnection connection10 = new MySqlConnection(serverinfo);
                    try
                    {
                        connection10.Open();
                        MySqlCommand statement10 = new MySqlCommand();
                        statement10 = connection10.CreateCommand();
                        statement10.CommandText = "select Name from user where User_ID = " + FYP_Form02.UsernameLogin;
                        MySqlDataReader Read10 = statement10.ExecuteReader();
                        Read10.Read();
                        name_user_1 = Read10.GetValue(0).ToString();
                        connection10.Close();

                        MySqlConnection connection11 = new MySqlConnection(serverinfo);
                        try
                        {
                            connection11.Open();
                            MySqlCommand statement11 = new MySqlCommand();
                            statement11 = connection11.CreateCommand();
                            statement11.CommandText = "select Email from user where User_ID = " + FYP_Form02.UsernameLogin;
                            MySqlDataReader Read11 = statement11.ExecuteReader();
                            Read11.Read();
                            email_user_1 = Read11.GetValue(0).ToString();
                            connection11.Close();
                        }
                        catch(MySql.Data.MySqlClient.MySqlException ex11)
                        {
                            MessageBox.Show(ex11.Message);
                        }
                        connection11.Close();

                        date_extend = Int32.Parse(Form16textBox2.Text);
                        MySqlConnection connection12 = new MySqlConnection(serverinfo);
                        try
                        {
                            connection12.Open();
                            MySqlCommand statement12 = new MySqlCommand();
                            statement12 = connection12.CreateCommand();
                            statement12.CommandText = "select date_add(curdate(), interval " + date_extend + " week)";
                            MySqlDataReader Read12 = statement12.ExecuteReader();
                            Read12.Read();
                            email_of_dates = Read12.GetValue(0).ToString();
                            connection12.Close();
                        }
                        catch(MySql.Data.MySqlClient.MySqlException ex12)
                        {
                            MessageBox.Show(ex12.Message);
                        }
                        connection12.Close();

                        try
                        {
                            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                            client.EnableSsl = true;
                            client.Timeout = 10000;
                            client.DeliveryMethod = SmtpDeliveryMethod.Network;
                            client.UseDefaultCredentials = false;
                            client.Credentials = new NetworkCredential("fyprfidlibrarysystem1234@gmail.com", "Ultimate1234MenOfIronMonger1234567*");
                            MailMessage msg = new MailMessage();
                            msg.To.Add("" + email_user_1);
                            msg.From = new MailAddress("fyprfidlibrarysystem1234@gmail.com");
                            msg.Subject = "FYP Book Due Date Extension Successful";
                            msg.Body = "Hello " + name_user_1 + "!\nYou have succesfully extended your book return date by " + date_extend + " weeks\nYour new due date is " + email_of_dates;
                            client.Send(msg);
                            MessageBox.Show("Email Succesfully Sent to the User!");
                        }
                        catch (Exception ex1)
                        {
                            MessageBox.Show(ex1.Message);
                        }
                    }
                    catch(MySql.Data.MySqlClient.MySqlException ex10)
                    {
                        MessageBox.Show(ex10.Message);
                    }
                    connection10.Close();
                }
                catch (MySql.Data.MySqlClient.MySqlException ex3)
                {
                    MessageBox.Show(ex3.Message);
                }
                connection3.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex2)
            {
                MessageBox.Show(ex2.Message);
            }
            connection2.Close();
        }
    }
}
