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
    public partial class FYP_Form12 : Form
    {
        String serverinfo = "server = 127.0.0.1; username = root; password = HelloWorld!12345; database = rfid_library_system";
        string user_name1, user_email1;
        public FYP_Form12()
        {
            InitializeComponent();
        }

        private void BackToForm09Btn3(object sender, EventArgs e)//Back Button
        {
            FYP_Form09 form09 = new FYP_Form09();
            form09.Show();
            this.Hide();
        }

        private void ConfirmPasswordBTN1(object sender, EventArgs e)//Confirm Password Button
        {
            string message = "Confirm Password Change?";
            string title = "Password Change Confirmation";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                if (Form12textBox2.Text == Form12textBox3.Text)
                {
                    MySqlConnection connection1 = new MySqlConnection(serverinfo);
                    try
                    {
                        connection1.Open();
                        MySqlCommand statement1 = new MySqlCommand();
                        statement1 = connection1.CreateCommand();
                        statement1.CommandText = "select Name from user where User_ID = @UID and Password = md5(@Password)";
                        statement1.Parameters.AddWithValue("@UID", Form12textBox4.Text);
                        statement1.Parameters.AddWithValue("@Password", Form12textBox1.Text);
                        MySqlDataReader Read1 = statement1.ExecuteReader();
                        if (Read1.Read())
                        {
                            connection1.Close();
                            MySqlConnection connection2 = new MySqlConnection(serverinfo);
                            try
                            {
                                connection2.Open();
                                MySqlCommand statement2 = new MySqlCommand();
                                statement2 = connection2.CreateCommand();
                                statement2.CommandText = "update user set Password = md5(@Password2) where User_ID = @UID2";
                                statement2.Parameters.AddWithValue("@Password2", Form12textBox2.Text);
                                statement2.Parameters.AddWithValue("@UID2", Form12textBox4.Text);
                                statement2.ExecuteNonQuery();
                                MessageBox.Show("Password has been succesfully changed");
                            }
                            catch(MySql.Data.MySqlClient.MySqlException ex2)
                            {
                                MessageBox.Show(ex2.Message);
                            }
                            connection2.Close();

                            MySqlConnection connection20 = new MySqlConnection(serverinfo);
                            try
                            {
                                connection20.Open();
                                MySqlCommand statement20 = new MySqlCommand();
                                statement20 = connection20.CreateCommand();
                                statement20.CommandText = "select Name from user where User_ID = " + Form12textBox4.Text;
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
                                    statement21.CommandText = "select Email from user where User_ID = " + Form12textBox4.Text;
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
                            }
                            catch(MySql.Data.MySqlClient.MySqlException ex20)
                            {
                                MessageBox.Show(ex20.Message);
                            }
                            connection20.Close();

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
                                msg.Subject = "FYP User Password Change Successful";
                                msg.Body = "Hello " + user_name1 + ".\nYour Password has been successfully changed!";
                                client.Send(msg);
                                MessageBox.Show("Email Succesfully Sent to the User!");
                            }
                            catch (Exception ex1)
                            {
                                MessageBox.Show(ex1.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid Details Entered!");
                        }
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex1)
                    {
                        MessageBox.Show(ex1.Message);
                    }
                    connection1.Close();
                }
                else
                {
                    MessageBox.Show("The Passwords do not Match!");
                }
            }
            else
            {
                MessageBox.Show("Password Change has been cancelled");
            }
        }

        private void ShowPasswordBoxCheck3(object sender, EventArgs e)//Show & Hide Password
        {
            if (Form12checkBox1.Checked == false)
            {
                Form12textBox1.PasswordChar = '*';
                Form12textBox2.PasswordChar = '*';
                Form12textBox3.PasswordChar = '*';
            }
            else if (Form12checkBox1.Checked == true)
            {
                Form12textBox1.PasswordChar = '\0';
                Form12textBox2.PasswordChar = '\0';
                Form12textBox3.PasswordChar = '\0';
            }
        }
    }
}
