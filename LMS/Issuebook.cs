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
    public partial class Issuebook : Form
    {
        public Issuebook()
        {
            InitializeComponent();
        }
        internal DataConnection Da { get; set; }

        internal DataSet Ds { get; set; }

        internal string Sql { get; set; }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnAnalytics_Click(object sender, EventArgs e)
        {
            Addstudent c = new Addstudent();
            this.Visible = false;
            c.Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCalender_Click(object sender, EventArgs e)
        {
            studentinfo c = new studentinfo();
            this.Visible = false;
            c.Visible = true;
        }

        private void btnContactUs_Click(object sender, EventArgs e)
        {
            Addbook c = new Addbook();
            this.Visible = false;
            c.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bookinfo c = new bookinfo();
            this.Visible = false;
            c.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Issuebook c = new Issuebook();
            this.Visible = false;
            c.Visible = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Returnbook c = new Returnbook();
            this.Visible = false;
            c.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            History c = new History();
            this.Visible = false;
            c.Visible = true;
        }

        private void btnsettings_Click(object sender, EventArgs e)
        {
            Form1 c = new Form1(label1.Text);
            this.Visible = false;
            c.Visible = true;
        }

        private void lbltitle_Click(object sender, EventArgs e)
        {

        }

        private void Issuebook_Load(object sender, EventArgs e)
        {
           
            
                SqlConnection con = new SqlConnection(@"Data Source=AYSH-STAR;Integrated Security=SSPI;Initial Catalog=LMS");
                con.Open();

                string query = string.Format("Select * from Books");
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sa.Fill(dt);
               
            
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboBox2.Items.Add(dt.Rows[i]["name"]);


                }

                
              
            }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")

            { MessageBox.Show("Please write Account NO"); }

            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=AYSH-STAR;Integrated Security=SSPI;Initial Catalog=LMS");
                con.Open();

               





                string query = string.Format("Select * from Student where username='" + textBox2.Text + "'");
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sa.Fill(dt);
                con.Close();

                if (dt.Rows.Count == 1)
                {
                    textBox5.Text = dt.Rows[0][1].ToString();
                   
                   
                    textBox3.Text = dt.Rows[0][2].ToString();
                    textBox1.Text = dt.Rows[0][3].ToString();
                    textBox6.Text = dt.Rows[0][4].ToString();
                    textBox4.Text = dt.Rows[0][5].ToString();
                   textBox7.Text = dt.Rows[0][6].ToString();
                    label10.Text = dt.Rows[0][0].ToString();


                    string query2 = string.Format("Select COUNT(sl) from History where sl='" + label10.Text + "' and returndate='null'");
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    SqlDataAdapter sa2 = new SqlDataAdapter(cmd2);
                    DataTable dt2 = new DataTable();
                    sa2.Fill(dt2);

                    int count =int.Parse(dt2.Rows[0][0].ToString());
                    label11.Text = count.ToString();
                    if (count >= 3)
                    { label8.Text = "Limit Reached";
                        button8.Visible = false;
                    }
                    else { label8.Text = "You are good to go!!!!!";
                        button8.Visible = true;
                    }
                    

                }
                else
                {
                    MessageBox.Show("INVALID UserName");
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox7.Text == "" || textBox6.Text == "" || textBox2.Text == ""||comboBox2.Text=="")
            {
                MessageBox.Show("select a bookname");
            }
            else
            {




                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=AYSH-STAR;Integrated Security=SSPI;Initial Catalog=LMS");
                    con.Open();

                    int i = 0;



                    this.Sql = @"INSERT INTO History(sl,name,username,department,semester,phone,email,bookname,issuedate,returndate) VALUES ('" + label10.Text + "','" + textBox5.Text + "','" + textBox3.Text + "','" + textBox1.Text + "','" + textBox6.Text + "','" + textBox4.Text + "','" + textBox7.Text + "','" + comboBox2.Text + "','" + dateTimePicker1.Text + "','null')";

                    SqlCommand cmd = new SqlCommand(Sql, con);

                    i = cmd.ExecuteNonQuery();



                    if (i > 0)
                    {
                        MessageBox.Show("Succesfully issued");
                        Issuebook ib = new Issuebook();
                        ib.Visible = true;
                        this.Visible = false;

                    }
                    else
                    { MessageBox.Show("Server Busy"); }


                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error: " + exc.Message);
                }







            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Issuebook ib = new Issuebook();
            ib.Visible = true;
            this.Visible = false;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCalender_Click_1(object sender, EventArgs e)
        {
            studentinfo c = new studentinfo();
            this.Visible = false;
            c.Visible = true;


        }

        private void btnContactUs_Click_1(object sender, EventArgs e)
        {

            Addbook c = new Addbook();
            this.Visible = false;
            c.Visible = true;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            bookinfo c = new bookinfo();
            this.Visible = false;
            c.Visible = true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Issuebook c = new Issuebook();
            this.Visible = false;
            c.Visible = true;

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            Returnbook c = new Returnbook();
            this.Visible = false;
            c.Visible = true;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {

            History c = new History();
            this.Visible = false;
            c.Visible = true;
        }

        private void btnsettings_Click_1(object sender, EventArgs e)
        {

            Login c = new Login();
            this.Visible = false;
            c.Visible = true;
        }
    }
}
