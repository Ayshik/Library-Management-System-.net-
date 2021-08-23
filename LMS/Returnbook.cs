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
    public partial class Returnbook : Form
    {
        public Returnbook()
        {
            InitializeComponent();
            this.Da = new DataConnection();
        }
        internal DataConnection Da { get; set; }

        internal DataSet Ds { get; set; }

        internal string Sql { get; set; }
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
           



            if (textBox2.Text == "")

            { MessageBox.Show("Please write Account NO"); }

            else
            {







                SqlConnection con2 = new SqlConnection(@"Data Source=AYSH-STAR;Integrated Security=SSPI;Initial Catalog=LMS");
                con2.Open();
                string query2 = string.Format("Select * from Student where username='"+textBox2.Text+"'");
                SqlCommand cmd2 = new SqlCommand(query2, con2);
                SqlDataAdapter sa2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                sa2.Fill(dt2);
                con2.Close();

                if (dt2.Rows.Count == 1)
                {
                    textBox5.Text = dt2.Rows[0][1].ToString();


                    textBox3.Text = dt2.Rows[0][2].ToString();
                    textBox1.Text = dt2.Rows[0][3].ToString();
                    textBox6.Text = dt2.Rows[0][4].ToString();
                    textBox4.Text = dt2.Rows[0][5].ToString();
                    textBox7.Text = dt2.Rows[0][6].ToString();
                    label10.Text = dt2.Rows[0][0].ToString();


                    //combo box e bookname anar jonno
                    SqlConnection con = new SqlConnection(@"Data Source=AYSH-STAR;Integrated Security=SSPI;Initial Catalog=LMS");
                    con.Open();
                    string query = string.Format("Select * from History where username='" +textBox2.Text+ "'and returndate='null'");
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter sa = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sa.Fill(dt);
                    


                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        comboBox2.Items.Add(dt.Rows[i]["bookname"]);


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
            if (textBox5.Text == "" || textBox4.Text == "" || textBox7.Text == ""||comboBox2.Text == "" || textBox2.Text == "" || label4.Text == "sl")
            {
                MessageBox.Show("Select a book");
            }

            else
            {

                try
                {




                    this.Sql = @"UPDATE History SET returndate='" + dateTimePicker1.Text + "' WHERE sl='"+label10.Text+"'and bookname='"+comboBox2.Text +"' and returndate='null'";
                    int count = this.Da.ExecuteUpdateQuery(this.Sql);


                    if (count == 1)
                    {
                        MessageBox.Show("Book Returned");
                        Returnbook rb = new Returnbook();
                        rb.Visible = true;
                        this.Visible = false;


                    }



                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error: " + exc.Message);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Returnbook rb = new Returnbook();
            rb.Visible = true;
            this.Visible = false;
        }

        private void btnAnalytics_Click_1(object sender, EventArgs e)
        {
            Addstudent c = new Addstudent();
            this.Visible = false;
            c.Visible = true;
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
