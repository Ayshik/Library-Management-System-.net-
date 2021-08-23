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
    public partial class bookinfo : Form
    {
        public bookinfo()
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
        private void PopulateGridView(string sql = "select * from Books;")
        {
            this.Ds = this.Da.ExecuteQuery(sql);

            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.DataSource = this.Ds.Tables[0];
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
       

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.Sql = @"select * from Books where name like '" + this.textBox1.Text + "%';";
            this.PopulateGridView(this.Sql);
        }

        private void button1_Click(object sender, EventArgs e)
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
           
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            numericUpDown1.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            numericUpDown2.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            label4.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" ||  textBox6.Text == "" || numericUpDown1.Text == "" || numericUpDown2.Text == "")
            {
                MessageBox.Show("Null not acteped");
            }

            else
            {

                try
                {




                    this.Sql = @"UPDATE Books SET name='" + textBox2.Text + "',authorname='" + textBox3.Text + "',publication='" + textBox4.Text + "',sellerno='" + textBox6.Text + "',quantity='" + numericUpDown1.Text + "',price='" + numericUpDown2.Text + "' WHERE sl='" + label4.Text + "'";
                    int count = this.Da.ExecuteUpdateQuery(this.Sql);


                    if (count == 1)
                    {
                        MessageBox.Show("Book info Updated!!!");

                    }



                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error: " + exc.Message);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res.Equals(DialogResult.Yes))
            {
                if (label4.Text == "sl" || textBox2.Text == "")
                {
                    MessageBox.Show("Please select a Book to Delete");
                }

                else
                {


                    this.Sql = "DELETE FROM Books WHERE sl ='" + label4.Text + "'";
                    int count = this.Da.ExecuteUpdateQuery(this.Sql);

                    if (count == 1)
                    {
                        MessageBox.Show("Book Deleted");
                        bookinfo sn = new bookinfo();
                        sn.Visible = true;
                        this.Visible = false;
                    }
                    else
                        MessageBox.Show("Error while deleting data");

                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

            Login c = new Login();
            this.Visible = false;
            c.Visible = true;
        }
    }
}
