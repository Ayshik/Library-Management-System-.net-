using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS
{
    public partial class studentinfo : Form
    {
        public studentinfo()
        {
            InitializeComponent();
            this.Da = new DataConnection();

            this.PopulateGridView();
            panel4.Visible = false;
        }
        internal DataConnection Da { get; set; }

        internal DataSet Ds { get; set; }

        internal string Sql { get; set; }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void PopulateGridView(string sql = "select * from Student;")
        {
            this.Ds = this.Da.ExecuteQuery(sql);

            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.DataSource = this.Ds.Tables[0];
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnAnalytics_Click1(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.Sql = @"select * from student where name like '" + this.textBox1.Text + "%';";
            this.PopulateGridView(this.Sql);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            panel4.Visible = true;
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            label4.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "" || textBox4.Text == "" || textBox7.Text == "" || textBox6.Text == "" || comboBox1.Text == "" || textBox2.Text == ""|| label4.Text == "sl")
            {
                MessageBox.Show("Null Not Acteped");
            }

            else
            {

                try
                {


                   

                    this.Sql = @"UPDATE Student SET name='" + textBox2.Text + "',department='" + comboBox1.Text + "',semester='" + textBox6.Text + "',phone='" + textBox4.Text + "',email='" + textBox7.Text + "',password='" + textBox5.Text + "' WHERE sl='" + label4.Text + "'";
                    int count = this.Da.ExecuteUpdateQuery(this.Sql);


                    if (count == 1)
                    {
                        MessageBox.Show("Student info Updated!!!");

                    }



                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error: " + exc.Message);
                }
            }
        }

        private void btnAnalytics_Click_1(object sender, EventArgs e)
        {
            Addstudent c = new Addstudent();
            this.Visible = false;
            c.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res.Equals(DialogResult.Yes))
            {
                if (label4.Text == "sl"|| textBox2.Text == "")
                {
                    MessageBox.Show("Please select a Student to Delete");
                }

                else
                {
                   

                    this.Sql = "DELETE FROM Student WHERE sl ='" + label4.Text + "'";
                    int count = this.Da.ExecuteUpdateQuery(this.Sql);

                    if (count == 1)
                    {
                        MessageBox.Show("Student  has been deleted");
                        studentinfo sn = new studentinfo();
                        sn.Visible = true;
                        this.Visible = false;
                    }
                    else
                        MessageBox.Show("Error while deleting data");

                }
            }
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
