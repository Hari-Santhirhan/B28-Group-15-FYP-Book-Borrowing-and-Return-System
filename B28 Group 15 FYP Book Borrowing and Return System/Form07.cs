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
    public partial class FYP_Form07 : Form
    {
        String serverinfo = "server = 127.0.0.1; username = root; password = HelloWorld!12345; database = rfid_library_system";
        string email_of_user1;
        string name_of_user1;
        public FYP_Form07()
        {
            InitializeComponent();
        }

        private void BackToForm05Btn2(object sender, EventArgs e)//Back Btn
        {
            FYP_Form05 form05 = new FYP_Form05();
            form05.Show();
            this.Hide();
        }

        private void RegisterNewUserBtn1(object sender, EventArgs e)
        {
            
        }

        private void FYP_Form07_Load(object sender, EventArgs e)//Load Items into ComboBoxes
        {
            string A = "select User_ID from user";
            MySqlConnection connection1 = new MySqlConnection(serverinfo);
            try
            {
                connection1.Open();
                MySqlCommand statement1 = new MySqlCommand(A, connection1);
                MySqlDataReader Read1 = statement1.ExecuteReader();
                while (Read1.Read())
                {
                    Form07comboBox1.Items.Add(Read1[0]);
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex1)
            {
                MessageBox.Show(ex1.Message);
            }
            connection1.Close();
        }

        private void SearchUserDetailsBtn1(object sender, EventArgs e)//Search Btn
        {
            if (Form07comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose from the Combo Box first before Searching");
            }
            else
            {
                string s1 = "select Name, Email, Phone_Number, User_ID, user_status from user where User_ID = " + Form07comboBox1.Text;
                MySqlConnection connection1 = new MySqlConnection(serverinfo);
                try
                {
                    connection1.Open();
                    MySqlDataAdapter adapter1 = new MySqlDataAdapter(s1, connection1);
                    DataTable table1 = new DataTable();
                    adapter1.Fill(table1);
                    Form07dataGridView1.DataSource = table1;
                }
                catch (MySql.Data.MySqlClient.MySqlException ex1)
                {
                    MessageBox.Show(ex1.Message);
                }
                connection1.Close();
            }
        }

        private void BanUserBTN1(object sender, EventArgs e)//Ban User Btn
        {
            string D = "select Name, Email, Phone_Number, User_ID, user_status from user where User_ID = " + Form07comboBox1.Text;
            MySqlConnection connection2 = new MySqlConnection(serverinfo);
            try
            {
                connection2.Open();
                MySqlCommand statement2 = new MySqlCommand();
                statement2 = connection2.CreateCommand();
                statement2.CommandText = "update user set user_status = 'Banned' where User_ID = @UID2";
                statement2.Parameters.AddWithValue("@UID2", Form07comboBox1.Text);
                statement2.ExecuteNonQuery();
                MessageBox.Show("This User is now banned. An email will now be sent to this User to notify them.");
                MySqlDataAdapter adpt1 = new MySqlDataAdapter(D, connection2);
                DataTable table2 = new DataTable();
                adpt1.Fill(table2);
                Form07dataGridView1.DataSource = table2;
                connection2.Close();

                MySqlConnection connection3 = new MySqlConnection(serverinfo);
                try
                {
                    connection3.Open();
                    MySqlCommand statement3 = new MySqlCommand();
                    statement3 = connection3.CreateCommand();
                    statement3.CommandText = "select Name from user where User_ID = " + Form07comboBox1.Text;
                    MySqlDataReader Read3 = statement3.ExecuteReader();
                    Read3.Read();
                    string user_name1 = Read3.GetValue(0).ToString();
                    connection3.Close();

                    int admin_email1;
                    string[] admin_email2;
                    MySqlConnection connection4 = new MySqlConnection(serverinfo);
                    try
                    {
                        connection4.Open();
                        MySqlCommand statement4 = new MySqlCommand();
                        statement4 = connection4.CreateCommand();
                        statement4.CommandText = "select Email from user where User_ID = " + Form07comboBox1.Text;
                        MySqlDataReader Read4 = statement4.ExecuteReader();
                        Read4.Read();
                        string user_email1 = Read4.GetValue(0).ToString();
                        connection4.Close();

                        MySqlConnection connection5 = new MySqlConnection(serverinfo);
                        try
                        {
                            connection5.Open();
                            MySqlCommand statement5 = new MySqlCommand();
                            statement5 = connection5.CreateCommand();
                            statement5.CommandText = "select count(*) Admin_Email from admin";
                            MySqlDataReader Read5 = statement5.ExecuteReader();
                            Read5.Read();
                            admin_email1 = Int32.Parse(Read5.GetValue(0).ToString());
                            connection5.Close();

                            admin_email2 = new string[admin_email1];
                            MySqlConnection connection7 = new MySqlConnection(serverinfo);
                            try
                            {
                                connection7.Open();
                                MySqlCommand statement7 = new MySqlCommand();
                                statement7 = connection7.CreateCommand();
                                statement7.CommandText = "select Admin_Email from admin";
                                MySqlDataReader Read7 = statement7.ExecuteReader();
                                for (int x1 = 0; x1 < admin_email1; x1++)
                                {
                                    Read7.Read();
                                    admin_email2[x1] = Read7.GetValue(0).ToString();
                                }
                                connection7.Close();

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
                                    msg.Subject = "User Banned Notification";
                                    msg.Body = "Hello " + user_name1 + ". We regret to inform you that you have been banned from our system. Please contact the administration for further details\nAdmin Email(s):\n";
                                    for (int y = 0; y < admin_email1; y++)
                                    {
                                        msg.Body = msg.Body + "\n\n" + admin_email2[y];
                                    }
                                    client.Send(msg);
                                    MessageBox.Show("Email Succesfully Sent to the User!");
                                }
                                catch (Exception ex1)
                                {
                                    MessageBox.Show(ex1.Message);
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
                    catch (MySql.Data.MySqlClient.MySqlException ex3)
                    {
                        MessageBox.Show(ex3.Message);
                    }
                    connection4.Close();
                }
                catch(MySql.Data.MySqlClient.MySqlException ex3)
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

        private void UnbanUserBTN2(object sender, EventArgs e)//Unban User Btn
        {
            string D = "select Name, Email, Phone_Number, User_ID, user_status from user where User_ID = " + Form07comboBox1.Text;
            MySqlConnection connection2 = new MySqlConnection(serverinfo);
            try
            {
                connection2.Open();
                MySqlCommand statement2 = new MySqlCommand();
                statement2 = connection2.CreateCommand();
                statement2.CommandText = "update user set user_status = 'Normal' where User_ID = @UID2";
                statement2.Parameters.AddWithValue("@UID2", Form07comboBox1.Text);
                statement2.ExecuteNonQuery();
                MessageBox.Show("This User has been unbanned. An Email will now be sent to notify the User");
                MySqlDataAdapter adpt1 = new MySqlDataAdapter(D, connection2);
                DataTable table2 = new DataTable();
                adpt1.Fill(table2);
                Form07dataGridView1.DataSource = table2;

                MySqlConnection connection5 = new MySqlConnection(serverinfo);
                try
                {
                    connection5.Open();
                    MySqlCommand statement5 = new MySqlCommand();
                    statement5 = connection5.CreateCommand();
                    statement5.CommandText = "select Name from user where User_ID = " + Form07comboBox1.Text;
                    MySqlDataReader Read5 = statement5.ExecuteReader();
                    Read5.Read();
                    name_of_user1 = Read5.GetValue(0).ToString();
                    connection5.Close();
                }
                catch(MySql.Data.MySqlClient.MySqlException ex5)
                {
                    MessageBox.Show(ex5.Message);
                }
                connection5.Close();

                MySqlConnection connection4 = new MySqlConnection(serverinfo);
                try
                {
                    connection4.Open();
                    MySqlCommand statement4 = new MySqlCommand();
                    statement4 = connection4.CreateCommand();
                    statement4.CommandText = "select Email from user where User_ID = " + Form07comboBox1.Text;
                    MySqlDataReader Read4 = statement4.ExecuteReader();
                    Read4.Read();
                    email_of_user1 = Read4.GetValue(0).ToString();
                    connection4.Close();

                    try
                    {
                        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                        client.EnableSsl = true;
                        client.Timeout = 10000;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential("fyprfidlibrarysystem1234@gmail.com", "Ultimate1234MenOfIronMonger1234567*");
                        MailMessage msg = new MailMessage();
                        msg.To.Add("" + email_of_user1);
                        msg.From = new MailAddress("fyprfidlibrarysystem1234@gmail.com");
                        msg.Subject = "User Un-Banned Notification";
                        msg.Body = "Welcome " + name_of_user1 + "! We are grateful to inform you that you are now unbanned from our system.";
                        client.Send(msg);
                        MessageBox.Show("Email Succesfully Sent to the User!");
                    }
                    catch (Exception ex1)
                    {
                        MessageBox.Show(ex1.Message);
                    }
                }
                catch(MySql.Data.MySqlClient.MySqlException ex4)
                {
                    MessageBox.Show(ex4.Message);
                }
                connection4.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex2)
            {
                MessageBox.Show(ex2.Message);
            }
            connection2.Close();
        }
    }
}
