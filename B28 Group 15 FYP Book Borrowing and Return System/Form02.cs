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
    public partial class FYP_Form02 : Form
    {
       //==============================================================LIST OF FORMS CREATED======================================================================
       /*Form List

        Form02 = Main Login Page for [Admin/User]
        Form04 = Register (Create) New User [ADMIN]
        Form05 = Admin Main Page [ADMIN]
        Form06 = Book Details Page to Add, Delete, and Search Book Details [ADMIN]
        Form07 = Registered User Details to Register New User (Goes to Form04), Search, Ban, and Unban User [ADMIN]
        Form08 = Borrowed/Returned Details to View Borrowed/Returned Details; Extend Borrow Date (Goes to Form16), and to Send Email for Overdue [ADMIN]
        Form09 = User Main Page [USER]
        Form10 = Borrow Books Page to Scan (for borrowing) and to View Borrow History [USER]
        Form11 = Return Books Page to Scan (for returning) and to View Return History [USER]
        Form12 = Change Password Page for User to change their current password [USER]
        Form13 = Search Books Page for the User to search for Books by Book Name and ISBN [USER]
        Form14 = Register (Create) New Admin [ADMIN by Secret Admin Password]
        Form15 = Redirected to this form by clicking the Add button from Form07 for Adding New Book Details via Scan + Typing
        Form16 = Redirected to this form by clicking the Extend Date button from Form08 to Extend the To Return Date (Needs Book Scan for Confirmation)*/
       //=========================================================================================================================================================

        public static string UsernameLogin = "";
        public static string PasswordLogin = "";
        public static string name_user_login = "";
        int email1;
        string[] books1;
        string user_name1;
        String serverinfo = "server = 127.0.0.1; username = root; password = HelloWorld!12345; database = rfid_library_system";
        public FYP_Form02()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void BackToLoginOptions(object sender, EventArgs e)
        {

        }

        private void LoginAsAdminBtn1(object sender, EventArgs e)//THIS IS FOR THE LOGIN BUTTON
        {
            string username_checking = "";
            string password_checking = "";
            string A = "" + Form02comboBox1.Text;
            string B = "" + Form02textBox1.Text;
            string C = "" + Form02textBox2.Text;

            MySqlConnection connection9 = new MySqlConnection(serverinfo);
            try
            {
                //============================================TO CHECK IF ANY BOOKS ARE OVERDUED============================================
                connection9.Open();
                MySqlCommand statement9 = new MySqlCommand();
                statement9 = connection9.CreateCommand();
                statement9.CommandText = "select * from borrow where (curdate() > To_Return_Date) and Overdue_Status = 'Not Overdued'";
                MySqlDataReader Read9 = statement9.ExecuteReader();
                if (Read9.Read())//IF THERE ARE ANY OVERDUED BOOKS
                {
                    connection9.Close();
                    MySqlConnection connection10 = new MySqlConnection(serverinfo);
                    try
                    {
                        //===============================================CHANGE STATUS TO OVERDUE!===================================
                        connection10.Open();
                        MySqlCommand statement10 = new MySqlCommand();
                        statement10 = connection10.CreateCommand();
                        statement10.CommandText = "update borrow set Overdue_Status = 'Overdue!' where (curdate() > To_Return_Date) and Overdue_Status = 'Not Overdued' and ID_Of_User = " + Form02textBox1.Text;
                        statement10.ExecuteNonQuery();
                        connection10.Close();

                        MySqlConnection connection100 = new MySqlConnection(serverinfo);
                        try
                        {
                            connection100.Open();
                            MySqlCommand statement100 = new MySqlCommand();
                            statement100 = connection100.CreateCommand();
                            statement100.CommandText = "update borrow set Email_Status = 'Must Send' where Overdue_Status = 'Overdue!' and Email_Status = 'No Need Send'";
                            statement100.ExecuteNonQuery();
                            connection100.Close();
                        }
                        catch (MySql.Data.MySqlClient.MySqlException ex100)
                        {
                            MessageBox.Show(ex100.Message);
                        }
                        connection100.Close();
                        //=========================================TO CHANGE TO MUST SEND FOR THE EMAIL==============================
                        MySqlConnection connection101 = new MySqlConnection(serverinfo);
                        try
                        {
                            connection101.Open();
                            MySqlCommand statement101 = new MySqlCommand();
                            statement101 = connection101.CreateCommand();
                            statement101.CommandText = "select count(*) from borrow where Email_Status = 'Must Send' and ID_Of_User = " + Form02textBox1.Text;
                            MySqlDataReader Read101 = statement101.ExecuteReader();
                            Read101.Read();
                            email1 = int.Parse(Read101.GetValue(0).ToString());
                            connection101.Close();
                        }
                        catch(MySql.Data.MySqlClient.MySqlException ex101)
                        {
                            MessageBox.Show(ex101.Message);
                        }
                        MySqlConnection connection102 = new MySqlConnection(serverinfo);
                        try
                        {
                            books1 = new string[email1];
                            connection102.Open();
                            MySqlCommand statement102 = new MySqlCommand();
                            statement102 = connection102.CreateCommand();
                            statement102.CommandText = "select Book_Name from borrow where Email_Status = 'Must Send'";
                            MySqlDataReader Read102 = statement102.ExecuteReader();
                            for (int x = 0; x < email1; x++)
                            {
                                Read102.Read();
                                books1[x] = Read102.GetValue(0).ToString();//STORES THE NAME OF THE BOOKS INTO THIS ARRAY
                            }
                        }
                        catch(MySql.Data.MySqlClient.MySqlException ex102)
                        {
                            MessageBox.Show(ex102.Message);
                        }
                        connection102.Close();

                        MySqlConnection connection103 = new MySqlConnection(serverinfo);
                        try
                        {
                            connection103.Open();
                            MySqlCommand statement103 = new MySqlCommand();
                            statement103 = connection103.CreateCommand();
                            statement103.CommandText = "select Email from user where User_ID = " + Form02textBox1.Text + " and Password = md5('" + Form02textBox2.Text + "')";
                            MySqlDataReader Read103 = statement103.ExecuteReader();
                            Read103.Read();
                            string email_user1 = Read103.GetValue(0).ToString();//STORES THE EMAIL OF THE USER INTO THIS ARRAY
                            connection103.Close();

                            MySqlConnection connection104 = new MySqlConnection(serverinfo);
                            try
                            {
                                connection104.Open();
                                MySqlCommand statement104 = new MySqlCommand();
                                statement104 = connection104.CreateCommand();
                                statement104.CommandText = "select Name from user where User_ID = " + Form02textBox1.Text + " and Password = md5('" + Form02textBox2.Text + "')";
                                MySqlDataReader Read104 = statement104.ExecuteReader();
                                Read104.Read();
                                user_name1 = Read104.GetValue(0).ToString();
                                name_user_login = user_name1;
                                connection104.Close();

                                //CODE FOR SENDING TO GMAIL==========================================================
                                try
                                {
                                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                                    client.EnableSsl = true;
                                    client.Timeout = 10000;
                                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                                    client.UseDefaultCredentials = false;
                                    client.Credentials = new NetworkCredential("fyprfidlibrarysystem1234@gmail.com", "Ultimate1234MenOfIronMonger1234567*");
                                    MailMessage msg = new MailMessage();
                                    msg.To.Add("" + email_user1);
                                    msg.From = new MailAddress("fyprfidlibrarysystem1234@gmail.com");
                                    msg.Subject = "FYP Overdue Books";
                                    msg.Body = "Hello user " + user_name1 + "! Please return your overdued books:";
                                    for (int y = 0; y < email1; y++)
                                    {
                                        msg.Body = msg.Body + "\n\n" + books1[y];
                                    }
                                    client.Send(msg);
                                    MessageBox.Show("Email Succesfully Sent to the User!");
                                }
                                catch (Exception ex1)
                                {
                                    MessageBox.Show(ex1.Message);
                                }
                                //====================================================================================
                            }
                            catch (MySql.Data.MySqlClient.MySqlException ex104)
                            {
                                MessageBox.Show(ex104.Message);
                            }
                            connection104.Close();
                        }
                        catch (MySql.Data.MySqlClient.MySqlException ex103)
                        {
                            MessageBox.Show(ex103.Message);
                        }
                        connection103.Close();

                        MySqlConnection connection110 = new MySqlConnection(serverinfo);
                        try
                        {
                            connection110.Open();
                            MySqlCommand statement110 = new MySqlCommand();
                            statement110 = connection110.CreateCommand();
                            statement110.CommandText = "select count(*) Admin_Email from admin";
                            MySqlDataReader Read110 = statement110.ExecuteReader();
                            Read110.Read();
                            int admin_email2 = Int32.Parse(Read110.GetValue(0).ToString());
                            connection110.Close();

                            string[] admin_email_details = new string[admin_email2];
                            MySqlConnection connection111 = new MySqlConnection(serverinfo);
                            try
                            {
                                connection111.Open();
                                MySqlCommand statement111 = new MySqlCommand();
                                statement111 = connection111.CreateCommand();
                                statement111.CommandText = "select Admin_Email from admin";
                                MySqlDataReader Read111 = statement111.ExecuteReader();
                                for (int x2 = 0; x2 < admin_email2; x2++)
                                {
                                    Read111.Read();
                                    admin_email_details[x2] = Read111.GetValue(0).ToString();
                                }
                            }
                            catch(MySql.Data.MySqlClient.MySqlException ex111)
                            {
                                MessageBox.Show(ex111.Message);
                            }
                            connection111.Close();

                            for (int x3 = 0; x3 < admin_email2; x3++)
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
                                    msg.To.Add("" + admin_email_details[x3]);
                                    msg.From = new MailAddress("fyprfidlibrarysystem1234@gmail.com");
                                    msg.Subject = "FYP Admin Notification for User's Overdue Books";
                                    msg.Body = "Hello Admin. Please take note that the user known as " + user_name1 + " has these books overdued:\n";
                                    for (int y = 0; y < email1; y++)
                                    {
                                        msg.Body = msg.Body + "\n\n" + books1[y];
                                    }
                                    client.Send(msg);
                                    MessageBox.Show("Email Succesfully Sent to the Admin!");
                                }
                                catch (Exception ex1)
                                {
                                    MessageBox.Show(ex1.Message);
                                }
                            }
                        }
                        catch (MySql.Data.MySqlClient.MySqlException ex110)
                        {
                            MessageBox.Show(ex110.Message);
                        }
                        connection110.Close();
                        //===========================================================================================================
                    }
                    catch(MySql.Data.MySqlClient.MySqlException ex10)
                    {
                        MessageBox.Show(ex10.Message);
                    }
                    connection10.Close();
                }
                else//DONT DO ANYTHING AND GO TO NEXT PART IF ANY BOOKS ARENT OVERDUED
                {

                }
            }
            catch(MySql.Data.MySqlClient.MySqlException ex8)
            {
                MessageBox.Show(ex8.Message);
            }
            connection9.Close();

            
            if (A == "Admin" && B != "IDNewAdmin" && C != "PasswordNewAdmin")
            {
                MySqlConnection connection1 = new MySqlConnection(serverinfo);
                try
                {
                    //=================================THIS IS FOR REDIRECTING TO THE ADMIN FORM==========================================
                    connection1.Open();
                    MySqlCommand statement1 = new MySqlCommand();
                    statement1 = connection1.CreateCommand();
                    statement1.CommandText = "select Name from admin where Admin_ID = @ID and Password = md5(@Password)";
                    statement1.Parameters.AddWithValue("@ID", Form02textBox1.Text);
                    statement1.Parameters.AddWithValue("@Password", Form02textBox2.Text);
                    MySqlDataReader Read1 = statement1.ExecuteReader();
                    if (Read1.Read())
                    {
                        connection1.Close();
                        FYP_Form05 form05 = new FYP_Form05();
                        form05.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Login!");
                    }
                }
                catch (MySql.Data.MySqlClient.MySqlException ex1)
                {
                    MessageBox.Show(ex1.Message);
                }
                connection1.Close();
            }
            else if (A == "Admin" && B == "IDNewAdmin" && C == "PasswordNewAdmin")
            {
                //==============================================THIS IS FOR REDIRECTING TO THE REGISTER ADMIN PAGE===============================
                FYP_Form14 form14 = new FYP_Form14();
                form14.Show();
                this.Hide();
            }
            else if (A == "User")
            {
                MySqlConnection connection1 = new MySqlConnection(serverinfo);
                try
                {
                    //==================================================THIS REDIRECTS THE USER TO THE USER MAIN FORM PAGE=====================
                    connection1.Open();
                    MySqlCommand statement1 = new MySqlCommand();
                    statement1 = connection1.CreateCommand();
                    statement1.CommandText = "select Name from user where User_ID = @ID and Password = md5(@Password)";
                    statement1.Parameters.AddWithValue("@ID", Form02textBox1.Text);
                    statement1.Parameters.AddWithValue("@Password", Form02textBox2.Text);
                    MySqlDataReader Read1 = statement1.ExecuteReader();
                    if (Read1.Read())
                    {
                        //==========IT SAVES THE USER'S LOGIN DETAILS TEMPORARILY FOR KNOWING WHO IS BORROWING AND RETURNING AT THE MOMENT===============
                        connection1.Close();
                        username_checking = "" + Form02textBox1.Text;
                        password_checking = "" + Form02textBox2.Text;
                        MySqlConnection connection2 = new MySqlConnection(serverinfo);
                        try
                        {
                            connection2.Open();
                            MySqlCommand statement2 = new MySqlCommand();
                            statement2 = connection2.CreateCommand();
                            statement2.CommandText = "select * from user where User_ID = " + username_checking + " and Password = md5('" + password_checking + "') and user_status = 'Normal'";
                            MySqlDataReader Read2 = statement2.ExecuteReader();
                            if (Read2.Read())//IF THE CREDENTIALS ARE CORRECT AND THE USER IS NOT BANNED
                            {
                                connection2.Close();
                                UsernameLogin = "" + Form02textBox1.Text;
                                PasswordLogin = "" + Form02textBox2.Text;
                                FYP_Form09 form09 = new FYP_Form09();
                                form09.Show();
                                this.Hide();
                            }
                            else//IF THE USER HAS BEEN BANNED BY THE ADMIN
                            {
                                MessageBox.Show("This User is Banned! Contact Admin for further details!");
                            }
                        }
                        catch(MySql.Data.MySqlClient.MySqlException ex10)
                        {
                            MessageBox.Show(ex10.Message);
                        }
                        connection2.Close();
                    }
                    else//IF THE USER CREDENTIALS ARE WRONG
                    {
                        MessageBox.Show("Invalid Login!");
                    }
                }
                catch (MySql.Data.MySqlClient.MySqlException ex1)
                {
                    MessageBox.Show(ex1.Message);
                }
                connection1.Close();
            }
            else if (A != "Admin" && A != "User")//IF THE USER DOES NOT STATE IF THEY ARE USER OR ADMIN
            {
                //===========================IF NOT STATED WHETHER ADMIN OR USER=========================================
                MessageBox.Show("Please State whether you are an Admin or a User");
            }
        }

        private void ShowPasswordBoxCheck2(object sender, EventArgs e)//SHOW OR HIDE PASSWORD
        {
            //=====================================THIS IS FOR SHOWING OR HIDING THE PASSWORD====================================
            if (Form02checkBox1.Checked == false)
            {
                Form02textBox2.PasswordChar = '*';
            }
            else if (Form02checkBox1.Checked == true)
            {
                Form02textBox2.PasswordChar = '\0';
            }
            //===================================================================================================================
        }

        private void ToTestFormForLCDBTN1(object sender, EventArgs e)
        {
            
        }

        private void GoToTestEmailForm(object sender, EventArgs e)
        {
            
        }

        private void Form02button2_Click(object sender, EventArgs e)//THIS IS FOR THE REGISTER BUTTON
        {
            FYP_Form04 form4 = new FYP_Form04();
            form4.Show();
            this.Hide();
        }

        private void Form02button3_Click(object sender, EventArgs e)
        {
            
        }

        private void Form02button20_Click(object sender, EventArgs e)
        {
            
        }

        private void Form02button30_Click(object sender, EventArgs e)
        {
            
        }
    }
}
