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
    public partial class FYP_Form14 : Form
    {
        int admin_email1;
        string[] admin_email2;
        String serverinfo = "server = 127.0.0.1; username = root; password = HelloWorld!12345; database = rfid_library_system";
        string admin_name1;
        int button_number;
        public FYP_Form14()
        {
            InitializeComponent();
        }

        private void ViewAdminRadioBTN1(object sender, EventArgs e)//View Radio Button
        {
            if (Form14radioButton4.Checked == false)
            {
                Form14textBox1.Visible = false;
                Form14textBox2.Visible = false;
                Form14textBox3.Visible = false;
                Form14textBox4.Visible = false;
                Form14textBox5.Visible = false;
                Form14textBox6.Visible = false;
                button_number = 0;
            }
            else if (Form14radioButton4.Checked == true)
            {
                Form14textBox1.Visible = false;
                Form14textBox2.Visible = false;
                Form14textBox3.Visible = false;
                Form14textBox4.Visible = false;
                Form14textBox5.Visible = false;
                Form14textBox6.Visible = false;
                button_number = 4;
            }
        }

        private void AddNewAdminRadioBTN2(object sender, EventArgs e)//Add Radio Button
        {
            if (Form14radioButton1.Checked == false)
            {
                Form14textBox1.Visible = false;
                Form14textBox2.Visible = false;
                Form14textBox3.Visible = false;
                Form14textBox4.Visible = false;
                Form14textBox5.Visible = false;
                Form14textBox6.Visible = false;
                button_number = 0;
            }
            else if (Form14radioButton1.Checked == true)
            {
                Form14textBox1.Visible = true;
                Form14textBox2.Visible = true;
                Form14textBox3.Visible = true;
                Form14textBox4.Visible = true;
                Form14textBox5.Visible = false;
                Form14textBox6.Visible = true;
                button_number = 1;
            }
        }

        private void ChangeAdminDetailsRadioBTN3(object sender, EventArgs e)//Change Radio Button
        {
            if (Form14radioButton2.Checked == false)
            {
                Form14textBox1.Visible = false;
                Form14textBox2.Visible = false;
                Form14textBox3.Visible = false;
                Form14textBox4.Visible = false;
                Form14textBox5.Visible = false;
                Form14textBox6.Visible = false;
                button_number = 0;
            }
            else if (Form14radioButton2.Checked == true)
            {
                Form14textBox1.Visible = true;
                Form14textBox2.Visible = true;
                Form14textBox3.Visible = true;
                Form14textBox4.Visible = true;
                Form14textBox5.Visible = true;
                Form14textBox6.Visible = true;
                button_number = 2;
            }
        }

        private void DeleteAdminDetailsRadioBTN4(object sender, EventArgs e)//Delete Radio Button
        {
            if (Form14radioButton3.Checked == false)
            {
                Form14textBox1.Visible = false;
                Form14textBox2.Visible = false;
                Form14textBox3.Visible = false;
                Form14textBox4.Visible = false;
                Form14textBox5.Visible = false;
                Form14textBox6.Visible = false;
                button_number = 0;
            }
            else if (Form14radioButton3.Checked == true)
            {
                Form14textBox1.Visible = false;
                Form14textBox2.Visible = true;
                Form14textBox3.Visible = false;
                Form14textBox4.Visible = false;
                Form14textBox5.Visible = true;
                Form14textBox6.Visible = false;
                button_number = 3;
            }
        }

        private void ExecuteCommandBTN0001(object sender, EventArgs e)//Execute Button
        {
            if (button_number == 0)
            {
                MessageBox.Show("Please select from one of the Radio Buttons first");
            }
            else if (button_number == 1)
            {
                string A = "" + Form14textBox3.Text;
                string B = "" + Form14textBox4.Text;
                string message = "Confirm Admin Registration?";
                string title = "Admin Registration Confirmation";

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    if (A == B)
                    {
                        MySqlConnection connection5 = new MySqlConnection(serverinfo);
                        try
                        {
                            connection5.Open();
                            MySqlCommand statement5 = new MySqlCommand();
                            statement5 = connection5.CreateCommand();
                            statement5.CommandText = "select * from admin where Admin_Email = @AdminEmail";
                            statement5.Parameters.AddWithValue("@AdminEmail", Form14textBox6.Text);
                            MySqlDataReader Read5 = statement5.ExecuteReader();
                            if (Read5.Read())
                            {
                                MessageBox.Show("This email address already exists!");
                            }
                            else
                            {
                                

                                string s1 = "" + Form14textBox2.Text;
                                string s2 = s1.Substring(0, 5);
                                string s3 = s1.Substring(5);
                                if (s1.Contains("Admin") == true && s1.Length == 9 && s2.Length == 5 && s3.Length == 4)
                                {
                                    int numcheck = Int32.Parse(s3);
                                    if (numcheck <= 9999 || numcheck >= 0001)
                                    {
                                        MySqlConnection connection15 = new MySqlConnection(serverinfo);
                                        try
                                        {
                                            connection15.Open();
                                            MySqlCommand statement15 = new MySqlCommand();
                                            statement15 = connection15.CreateCommand();
                                            statement15.CommandText = "select * from admin where Admin_ID = '" + Form14textBox2.Text + "'";
                                            MySqlDataReader Read15 = statement15.ExecuteReader();
                                            if (Read15.Read())
                                            {
                                                MessageBox.Show("This Admin ID already exists!");
                                            }
                                            else
                                            {
                                                MySqlConnection connection1 = new MySqlConnection(serverinfo);
                                                try
                                                {
                                                    connection1.Open();
                                                    MySqlCommand statement1 = new MySqlCommand();
                                                    statement1 = connection1.CreateCommand();
                                                    statement1.CommandText = "insert into admin (Name, Admin_Email, Admin_ID, Password) values (@Name, @EmailAdmin, @AdminID, md5(@Password))";
                                                    statement1.Parameters.AddWithValue("@Name", Form14textBox1.Text);
                                                    statement1.Parameters.AddWithValue("@EmailAdmin", Form14textBox6.Text);
                                                    statement1.Parameters.AddWithValue("@AdminID", Form14textBox2.Text);
                                                    statement1.Parameters.AddWithValue("@Password", Form14textBox3.Text);
                                                    statement1.ExecuteNonQuery();
                                                    MessageBox.Show("Admin Registration Successful!");
                                                    connection1.Close();

                                                    MySqlConnection connection20 = new MySqlConnection(serverinfo);
                                                    try
                                                    {
                                                        connection20.Open();
                                                        MySqlCommand statement20 = new MySqlCommand();
                                                        statement20 = connection20.CreateCommand();
                                                        statement20.CommandText = "select count(*) Admin_Email from admin";
                                                        MySqlDataReader Read20 = statement20.ExecuteReader();
                                                        Read20.Read();
                                                        admin_email1 = Int32.Parse(Read20.GetValue(0).ToString());
                                                        admin_email2 = new string[admin_email1];
                                                        connection20.Close();

                                                        MySqlConnection connection22 = new MySqlConnection(serverinfo);
                                                        try
                                                        {
                                                            connection22.Open();
                                                            MySqlCommand statement22 = new MySqlCommand();
                                                            statement22 = connection22.CreateCommand();
                                                            statement22.CommandText = "select Admin_Email from admin";
                                                            MySqlDataReader Read22 = statement22.ExecuteReader();
                                                            for (int x7 = 0; x7 < admin_email1; x7++)
                                                            {
                                                                Read22.Read();
                                                                admin_email2[x7] = Read22.GetValue(0).ToString();
                                                            }
                                                            connection22.Close();

                                                            MySqlConnection connection24 = new MySqlConnection(serverinfo);
                                                            try
                                                            {
                                                                connection24.Open();
                                                                MySqlCommand statement24 = new MySqlCommand();
                                                                statement24 = connection24.CreateCommand();
                                                                statement24.CommandText = "select Name from Admin where Admin_ID = '" + Form14textBox2.Text + "'";
                                                                MySqlDataReader Read24 = statement24.ExecuteReader();
                                                                Read24.Read();
                                                                admin_name1 = Read24.GetValue(0).ToString();
                                                                connection24.Close();
                                                            }
                                                            catch (MySql.Data.MySqlClient.MySqlException ex24)
                                                            {
                                                                MessageBox.Show(ex24.Message);
                                                            }
                                                            connection24.Close();
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

                                                    for (int x = 0; x < admin_email1; x++)
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
                                                            msg.To.Add("" + admin_email2[x]);
                                                            msg.From = new MailAddress("fyprfidlibrarysystem1234@gmail.com");
                                                            msg.Subject = "FYP Admin Registration into our System Succesful (For Admin)";
                                                            msg.Body = "Hello Admin!\nPlease Take note that a new Admin called " + admin_name1 + " has registered into the system";
                                                            client.Send(msg);
                                                            MessageBox.Show("Email Succesfully Sent to the Admin!");
                                                        }
                                                        catch (Exception ex1)
                                                        {
                                                            MessageBox.Show(ex1.Message);
                                                        }
                                                    }
                                                }
                                                catch (MySql.Data.MySqlClient.MySqlException ex1)
                                                {
                                                    MessageBox.Show(ex1.Message);
                                                }
                                                connection1.Close();
                                            }
                                            connection15.Close();
                                        }
                                        catch (MySql.Data.MySqlClient.MySqlException ex15)
                                        {
                                            MessageBox.Show(ex15.Message);
                                        }
                                        connection15.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("The Incorrect Format is used. The format must be 'Admin + 4 digit number'");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("The Incorrect Format is used. The format must be 'Admin + 4 digit number'");
                                }
                            }
                        }
                        catch(MySql.Data.MySqlClient.MySqlException ex5)
                        {
                            MessageBox.Show(ex5.Message);
                        }
                        connection5.Close();
                    }
                    else if (A != B)
                    {
                        MessageBox.Show("The Passwords do no match!");
                    }
                }
                else
                {
                    MessageBox.Show("Admin Registration has been cancelled");
                }
            }
            else if (button_number == 2)
            {
                string A = "" + Form14textBox3.Text;
                string B = "" + Form14textBox4.Text;
                string message = "Are you sure you want to change these details?";
                string title = "Admin Details Change Confirmation";

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    if (A == B)
                    {
                        MySqlConnection connection1 = new MySqlConnection(serverinfo);
                        try
                        {
                            connection1.Open();
                            MySqlCommand statement1 = new MySqlCommand();
                            statement1 = connection1.CreateCommand();
                            statement1.CommandText = "select Name from admin where Admin_ID = @AdminID and Password = md5(@Password) and Admin_Email = @Email";
                            statement1.Parameters.AddWithValue("@AdminID", Form14textBox2.Text);
                            statement1.Parameters.AddWithValue("@Password", Form14textBox5.Text);
                            statement1.Parameters.AddWithValue("@Email", Form14textBox6.Text);
                            MySqlDataReader Read1 = statement1.ExecuteReader();
                            if (Read1.Read())
                            {
                                connection1.Close();
                                if (Form14textBox3.Text == Form14textBox4.Text)
                                {
                                    MySqlConnection connection2 = new MySqlConnection(serverinfo);
                                    try
                                    {
                                        connection2.Open();
                                        MySqlCommand statement2 = new MySqlCommand();
                                        statement2 = connection2.CreateCommand();
                                        statement2.CommandText = "update admin set Password = md5('" + Form14textBox3.Text + "') where Name = '" + Form14textBox1.Text + "' and Admin_ID = '" + Form14textBox2.Text + "' and Admin_Email = '" + Form14textBox6.Text + "' and Password = md5('" + Form14textBox5.Text + "')";
                                        statement2.ExecuteNonQuery();
                                        MessageBox.Show("Admin's Details have been successfully updated!");
                                        connection2.Close();

                                        try
                                        {
                                            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                                            client.EnableSsl = true;
                                            client.Timeout = 10000;
                                            client.DeliveryMethod = SmtpDeliveryMethod.Network;
                                            client.UseDefaultCredentials = false;
                                            client.Credentials = new NetworkCredential("fyprfidlibrarysystem1234@gmail.com", "Ultimate1234MenOfIronMonger1234567*");
                                            MailMessage msg = new MailMessage();
                                            msg.To.Add("" + Form14textBox6.Text);
                                            msg.From = new MailAddress("fyprfidlibrarysystem1234@gmail.com");
                                            msg.Subject = "FYP Admin Password Change Successful";
                                            msg.Body = "Hello Admin " + Form14textBox1.Text + ".\nYour password has been succesfully changed";
                                            client.Send(msg);
                                            MessageBox.Show("Email Succesfully Sent to the Admin!");
                                        }
                                        catch (Exception ex1)
                                        {
                                            MessageBox.Show(ex1.Message);
                                        }
                                    }
                                    catch (MySql.Data.MySqlClient.MySqlException ex2)
                                    {
                                        MessageBox.Show(ex2.Message);
                                    }
                                    connection2.Close();
                                }
                                else
                                {
                                    MessageBox.Show("The Passwords do not match");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid Admin ID or Current Password or Email");
                            }
                        }
                        catch (MySql.Data.MySqlClient.MySqlException ex1)
                        {
                            MessageBox.Show(ex1.Message);
                        }
                        connection1.Close();
                    }
                    else if (A != B)
                    {
                        MessageBox.Show("The Passwords do not match!");
                    }
                }
                else
                {
                    MessageBox.Show("Admin's Detail Changes have been cancelled");
                }
            }
            else if (button_number == 3)
            {
                string message = "Are you sure you want to delete this Admin's Details? If YES, it CAN'T be undone later";
                string title = "Delete Admin Details Confirmation";

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
                        statement1.CommandText = "select Name from admin where Admin_ID = @AdminID and Password = md5(@Password)";
                        statement1.Parameters.AddWithValue("@AdminID", Form14textBox2.Text);
                        statement1.Parameters.AddWithValue("@Password", Form14textBox5.Text);
                        MySqlDataReader Read1 = statement1.ExecuteReader();
                        if (Read1.Read())
                        {
                            admin_name1 = Read1.GetValue(0).ToString();
                            connection1.Close();
                            MySqlConnection connection2 = new MySqlConnection(serverinfo);
                            try
                            {
                                connection2.Open();
                                MySqlCommand statement2 = new MySqlCommand();
                                statement2 = connection2.CreateCommand();
                                statement2.CommandText = "delete from admin where Admin_ID = @AdminID and Password = md5(@Password)";
                                statement2.Parameters.AddWithValue("@AdminID", Form14textBox2.Text);
                                statement2.Parameters.AddWithValue("@Password", Form14textBox5.Text);
                                statement2.ExecuteNonQuery();
                                MessageBox.Show("This Admin's Details have been successfully deleted");

                                MySqlConnection connection20 = new MySqlConnection(serverinfo);
                                try
                                {
                                    connection20.Open();
                                    MySqlCommand statement20 = new MySqlCommand();
                                    statement20 = connection20.CreateCommand();
                                    statement20.CommandText = "select count(*) Admin_Email from admin";
                                    MySqlDataReader Read20 = statement20.ExecuteReader();
                                    Read20.Read();
                                    admin_email1 = Int32.Parse(Read20.GetValue(0).ToString());
                                    admin_email2 = new string[admin_email1];
                                    connection20.Close();

                                    MySqlConnection connection22 = new MySqlConnection(serverinfo);
                                    try
                                    {
                                        connection22.Open();
                                        MySqlCommand statement22 = new MySqlCommand();
                                        statement22 = connection22.CreateCommand();
                                        statement22.CommandText = "select Admin_Email from admin";
                                        MySqlDataReader Read22 = statement22.ExecuteReader();
                                        for (int x7 = 0; x7 < admin_email1; x7++)
                                        {
                                            Read22.Read();
                                            admin_email2[x7] = Read22.GetValue(0).ToString();
                                        }
                                        connection22.Close();
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

                                for (int x = 0; x < admin_email1; x++)
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
                                        msg.To.Add("" + admin_email2[x]);
                                        msg.From = new MailAddress("fyprfidlibrarysystem1234@gmail.com");
                                        msg.Subject = "FYP Admin Un-Registration from our System Succesful (For Admin)";
                                        msg.Body = "Hello Admin!\nPlease Take note that the Admin called " + admin_name1 + " has unregistered from the system";
                                        client.Send(msg);
                                        MessageBox.Show("Email Succesfully Sent to the Admin!");
                                    }
                                    catch (Exception ex1)
                                    {
                                        MessageBox.Show(ex1.Message);
                                    }
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
                            MessageBox.Show("Invalid Admin ID or Password");
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
                    MessageBox.Show("Admin's Details Deletion has been cancelled");
                }
            }
            else if (button_number == 4)
            {
                MySqlConnection connection1 = new MySqlConnection(serverinfo);
                try
                {
                    connection1.Open();
                    MySqlDataAdapter adpt1 = new MySqlDataAdapter("select Name, Admin_Email, Admin_ID from admin", connection1);
                    DataTable table1 = new DataTable();
                    adpt1.Fill(table1);
                    Form14dataGridView1.DataSource = table1;
                }
                catch(MySql.Data.MySqlClient.MySqlException ex1)
                {
                    MessageBox.Show(ex1.Message);
                }
                connection1.Close();
            }
        }

        private void ShowPasswordBoxCheck4(object sender, EventArgs e)
        {
            if (Form14checkBox1.Checked == false)
            {
                Form14textBox3.PasswordChar = '*';
                Form14textBox4.PasswordChar = '*';
                Form14textBox5.PasswordChar = '*';
            }
            else if (Form14checkBox1.Checked == true)
            {
                Form14textBox3.PasswordChar = '\0';
                Form14textBox4.PasswordChar = '\0';
                Form14textBox5.PasswordChar = '\0';
            }
        }

        private void Test0001(object sender, EventArgs e)
        {
            
        }

        private void BackToMainLoginPage02(object sender, EventArgs e)//Back Button
        {
            FYP_Form02 form02 = new FYP_Form02();
            form02.Show();
            this.Hide();
        }

        private void FYP_Form14_Load(object sender, EventArgs e)//Show & Hide Password
        {
            if (Form14checkBox1.Checked == false)
            {
                Form14textBox3.PasswordChar = '*';
                Form14textBox4.PasswordChar = '*';
                Form14textBox5.PasswordChar = '*';
            }
            else if (Form14checkBox1.Checked == true)
            {
                Form14textBox3.PasswordChar = '\0';
                Form14textBox4.PasswordChar = '\0';
                Form14textBox5.PasswordChar = '\0';
            }
        }
    }
}
