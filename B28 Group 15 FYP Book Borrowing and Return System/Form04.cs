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
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace B28_Group_15_FYP_Book_Borrowing_and_Return_System
{
    public partial class FYP_Form04 : Form
    {
        String serverinfo = "server = 127.0.0.1; username = root; password = HelloWorld!12345; database = rfid_library_system";
        string user_email_details;
        int email_admin1 = 0, user_identification;
        string[] email_admin2;
        public FYP_Form04()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ShowPasswordBoxCheck1(object sender, EventArgs e)//SHOWS OR HIDES PASSWORD
        {
            //========================================SHOWS OR HIDES PASSWORD WHEN ENTERING===========================================
            if (Form04checkBox1.Checked == false)
            {
                Form04textBox2.PasswordChar = '*';
                Form04textBox3.PasswordChar = '*';
            }
            else if (Form04checkBox1.Checked == true)
            {
                Form04textBox2.PasswordChar = '\0';
                Form04textBox3.PasswordChar = '\0';
            }
            //========================================================================================================================
        }

        private void BackToUserLogin(object sender, EventArgs e)//BACK BUTTON
        {
            //=================================BACK TO MAIN LOGIN PAGE=================================
            FYP_Form02 form02 = new FYP_Form02();
            form02.Show();
            this.Hide();
            //=========================================================================================
        }

        private void CompleteRegistrationBtn1(object sender, EventArgs e)//COMPLETE REGISTRATION BUTTON
        {
            //===================================================TO CONFIRM AND COMPLETE USER REGISTRATION===============================
            string message = "Confirm User Registration?";
            string title = "User Registration Confirmation";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                //===================================IF YES IS SELECTED FOR THE DIALOG BOX================================
                if (Form04textBox2.Text == Form04textBox3.Text)
                {
                    MySqlConnection connection11 = new MySqlConnection(serverinfo);
                    try
                    {
                        //======================================TO CHECK IF THIS EMAIL ALREADY EXISTS IN THE SYSTEM=============================
                        connection11.Open();
                        MySqlCommand statement11 = new MySqlCommand();
                        statement11 = connection11.CreateCommand();
                        statement11.CommandText = "select * from user where Email = @EmailCheck";
                        statement11.Parameters.AddWithValue("@EmailCheck", Form04textBox4.Text);
                        MySqlDataReader Read11 = statement11.ExecuteReader();
                        if (Read11.Read())//IF THE EMAIL EXISTS
                        {
                            MessageBox.Show("Email already exists!");
                        }
                        else
                        {
                            connection11.Close();
                            MySqlConnection connection45 = new MySqlConnection(serverinfo);
                            try
                            {
                                connection45.Open();
                                MySqlCommand statement45 = new MySqlCommand();
                                statement45 = connection45.CreateCommand();
                                statement45.CommandText = "select * from admin where Admin_Email = '" + Form04textBox4.Text + "'";
                                MySqlDataReader Read45 = statement45.ExecuteReader();
                                if (Read45.Read())
                                {
                                    MessageBox.Show("This Email already exists");
                                }
                                else
                                {
                                    connection45.Close();
                                    MySqlConnection connection100 = new MySqlConnection(serverinfo);
                                    try
                                    {
                                        connection100.Open();
                                        MySqlCommand statement100 = new MySqlCommand();
                                        statement100 = connection100.CreateCommand();
                                        statement100.CommandText = "select * from user where Phone_Number = " + Form04textBox5.Text;
                                        MySqlDataReader Read100 = statement100.ExecuteReader();
                                        if (Read100.Read())
                                        {
                                            MessageBox.Show("This Phone number is registered with this system by another user");
                                        }
                                        else
                                        {
                                            connection100.Close();
                                            //===============================IF THE EMAIL IS A NEW EMAIL==========================
                                            connection11.Close();
                                            MySqlConnection connection1 = new MySqlConnection(serverinfo);
                                            try
                                            {
                                                //============================THIS IS FOR ADDING IN THE NEW USER'S DETAILS AND AUTO-INCREMENTING THE USER ID=================
                                                connection1.Open();
                                                MySqlCommand statement1 = new MySqlCommand();
                                                statement1 = connection1.CreateCommand();
                                                statement1.CommandText = "insert into user (Name, Email, Phone_Number, Password, user_status) values (@Name, '" + Form04textBox4.Text +"', @Phone, md5(@Password), 'Normal')";
                                                statement1.Parameters.AddWithValue("@Name", Form04textBox1.Text);
                                                statement1.Parameters.AddWithValue("@Phone", Form04textBox5.Text);
                                                statement1.Parameters.AddWithValue("@Password", Form04textBox2.Text);
                                                statement1.ExecuteNonQuery();
                                                //===========================TO DISPLAY TO USER ID TO INFORM TO THE USER============================================================================
                                                string s1 = "select User_ID from user where Name = '" + Form04textBox1.Text + "' and Email = '" + Form04textBox4.Text + "' and Phone_Number = " + Form04textBox5.Text + " and Password = md5('" + Form04textBox2.Text + "')";
                                                MessageBox.Show("Account Succesfully Registered! Your User ID has been generated!");
                                                MySqlDataAdapter adapter1 = new MySqlDataAdapter(s1, connection1);
                                                DataTable table1 = new DataTable();
                                                adapter1.Fill(table1);
                                                Form04dataGridView1.DataSource = table1;
                                                connection1.Close();
                                                MySqlConnection connection20 = new MySqlConnection(serverinfo);
                                                try
                                                {//TO FIND THE EMAIL OF THE NEW USER TO INFORM THEM OF THEIR REGISTRATION
                                                    connection20.Open();
                                                    MySqlCommand statement20 = new MySqlCommand();
                                                    statement20 = connection20.CreateCommand();
                                                    statement20.CommandText = "select Email from user where Email = '" + Form04textBox4.Text + "'";
                                                    MySqlDataReader Read20 = statement20.ExecuteReader();
                                                    Read20.Read();
                                                    user_email_details = Read20.GetValue(0).ToString();
                                                    connection20.Close();

                                                    MySqlConnection connection22 = new MySqlConnection(serverinfo);
                                                    try
                                                    {//THIS IS TO FIND THE USER ID OF THE NEWLY REGISTERED USER
                                                        connection22.Open();
                                                        MySqlCommand statement22 = new MySqlCommand();
                                                        statement22 = connection22.CreateCommand();
                                                        statement22.CommandText = "select User_ID from user where Name = '" + Form04textBox1.Text + "' and Email = '" + Form04textBox4.Text + "' and Phone_Number = " + Form04textBox5.Text + " and Password = md5('" + Form04textBox2.Text + "')";
                                                        MySqlDataReader Read22 = statement22.ExecuteReader();
                                                        Read22.Read();
                                                        user_identification = Int32.Parse(Read22.GetValue(0).ToString());
                                                        connection22.Close();

                                                        //======================================EMAIL CODING==============================================================
                                                        try
                                                        {
                                                            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                                                            client.EnableSsl = true;
                                                            client.Timeout = 10000;
                                                            client.DeliveryMethod = SmtpDeliveryMethod.Network;
                                                            client.UseDefaultCredentials = false;
                                                            client.Credentials = new NetworkCredential("fyprfidlibrarysystem1234@gmail.com", "Ultimate1234MenOfIronMonger1234567*");
                                                            MailMessage msg = new MailMessage();
                                                            msg.To.Add("" + user_email_details);
                                                            msg.From = new MailAddress("fyprfidlibrarysystem1234@gmail.com");
                                                            msg.Subject = "FYP User Registration into our System Succesful (For User)";
                                                            msg.Body = "Welcome, " + Form04textBox1.Text + "! Thank you for registering into our system\nYour User ID is " + user_identification;
                                                            client.Send(msg);
                                                            MessageBox.Show("Email Succesfully Sent to the User!");
                                                        }
                                                        catch (Exception ex1)
                                                        {
                                                            MessageBox.Show(ex1.Message);
                                                        }
                                                        //================================================================================================================

                                                        MySqlConnection connection110 = new MySqlConnection(serverinfo);
                                                        try
                                                        {
                                                            connection110.Open();
                                                            MySqlCommand statement110 = new MySqlCommand();
                                                            statement110 = connection110.CreateCommand();
                                                            statement110.CommandText = "select count(*) Admin_Email from admin";
                                                            MySqlDataReader Read110 = statement110.ExecuteReader();
                                                            Read110.Read();
                                                            email_admin1 = Int32.Parse(Read110.GetValue(0).ToString());
                                                            connection110.Close();
                                                        }
                                                        catch (MySql.Data.MySqlClient.MySqlException ex110)
                                                        {
                                                            MessageBox.Show(ex110.Message);
                                                        }
                                                        connection110.Close();

                                                        email_admin2 = new string[email_admin1];
                                                        MySqlConnection connection111 = new MySqlConnection(serverinfo);
                                                        try
                                                        {
                                                            connection111.Open();
                                                            MySqlCommand statement111 = new MySqlCommand();
                                                            statement111 = connection111.CreateCommand();
                                                            statement111.CommandText = "select Admin_Email from admin";
                                                            MySqlDataReader Read111 = statement111.ExecuteReader();
                                                            for (int z = 0; z < email_admin1; z++)
                                                            {
                                                                Read111.Read();
                                                                email_admin2[z] = Read111.GetValue(0).ToString();
                                                            }
                                                            connection111.Close();
                                                        }
                                                        catch (MySql.Data.MySqlClient.MySqlException ex111)
                                                        {
                                                            MessageBox.Show(ex111.Message);
                                                        }
                                                        connection111.Close();

                                                        //======================TO EMAIL THE ADMIN TO INFORM THEM THAT A NEW USER HAS BEEN REGISTERED=========================
                                                        for (int x = 0; x < email_admin1; x++)
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
                                                                msg.To.Add("" + email_admin2[x]);
                                                                msg.From = new MailAddress("fyprfidlibrarysystem1234@gmail.com");
                                                                msg.Subject = "FYP User Registration into our System Succesful (For Admin)";
                                                                msg.Body = "Hello Admin!\nPlease take note that a new user called " + Form04textBox1.Text + " has registered into our system";
                                                                client.Send(msg);
                                                                MessageBox.Show("Email Succesfully Sent to the Admin!");
                                                            }
                                                            catch (Exception ex1)
                                                            {
                                                                MessageBox.Show(ex1.Message);
                                                            }
                                                        }
                                                        //====================================================================================================================
                                                    }
                                                    catch (MySql.Data.MySqlClient.MySqlException ex22)
                                                    {
                                                        MessageBox.Show(ex22.Message);
                                                    }
                                                    connection22.Close();
                                                }
                                                catch (MySql.Data.MySqlClient.MySqlException ex20)
                                                {
                                                    MessageBox.Show(ex20.Message);
                                                }
                                                connection20.Close();
                                            }
                                            catch (MySql.Data.MySqlClient.MySqlException ex1)
                                            {
                                                MessageBox.Show(ex1.Message);
                                            }
                                            connection1.Close();
                                        }
                                    }
                                    catch(MySql.Data.MySqlClient.MySqlException ex100)
                                    {
                                        MessageBox.Show(ex100.Message);
                                    }
                                }
                            }
                            catch(MySql.Data.MySqlClient.MySqlException ex45)
                            {
                                MessageBox.Show(ex45.Message);
                            }
                            connection45.Close();
                        }
                    }
                    catch(MySql.Data.MySqlClient.MySqlException ex11)
                    {
                        MessageBox.Show(ex11.Message);
                    }
                    connection11.Close();
                }
                else
                {
                    MessageBox.Show("The Passwords do not Match");
                }
            }
            else
            {
                MessageBox.Show("Registration has been cancelled");
            }
        }
    }
}
