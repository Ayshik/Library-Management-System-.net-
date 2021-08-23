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
    public partial class Addbook : Form
    {
        public Addbook()
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

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || dateTimePicker1.Text == "" || textBox6.Text == "" || numericUpDown1.Text == "" || numericUpDown2.Text == "")
            {
                MessageBox.Show("Please fill all the value");
            }
            else
            {




                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=AYSH-STAR;Integrated Security=SSPI;Initial Catalog=LMS");
                    con.Open();

                    int i = 0;



                    this.Sql = @"INSERT INTO Books(name,authorname,publication,purchasedate,sellerno,quantity,price) VALUES ('" + textBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + dateTimePicker1.Text + "','" + textBox6.Text + "','" + numericUpDown1.Text + "','" + numericUpDown2.Text + "')";

                    SqlCommand cmd = new SqlCommand(Sql, con);

                    i = cmd.ExecuteNonQuery();



                    if (i > 0)
                    {
                        MessageBox.Show("Succesfully Added");

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
            Application.Exit();
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
