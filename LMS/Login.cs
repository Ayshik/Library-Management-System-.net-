using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        Boolean state = false;
        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "UserName") { textBox1.Clear(); }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.Clear();
                textBox2.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=AYSH-STAR;Integrated Security=SSPI;Initial Catalog=LMS");
            con.Open();

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Username or passward cannot be empty");
            }
            else
            {




                {
                    if (state == false)
                    {
                        string query = string.Format("Select * from librarian where username= '" + textBox1.Text + "' and password='" + textBox2.Text + "'");
                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlDataAdapter sa = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        sa.Fill(dt);
                        con.Close();


                        if (dt.Rows.Count == 1)
                        {
                            state = true;
                            Form1 c = new Form1(textBox1.Text);
                            this.Visible = false;
                            c.Visible = true;

                        }
                        else
                        {
                            state = false;
                        }
                    }

                }




                {
                    if (state == false)
                    {
                        string query = string.Format("Select * from Student where username= '" + textBox1.Text + "' and password='" + textBox2.Text + "'");
                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlDataAdapter sa = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        sa.Fill(dt);
                        con.Close();

                        if (dt.Rows.Count == 1)
                        {
                            state = true;
                            studentpanel c = new studentpanel(textBox1.Text);
                            this.Visible = false;
                            c.Visible = true;

                        }
                        else
                        {
                            state = false;
                        }
                    }

                }


              

                {



                    if (state == false)
                    {
                        MessageBox.Show("Your username Password not found");
                    }



                }

            }
        }
    }
}
