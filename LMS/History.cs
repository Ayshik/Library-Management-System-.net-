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
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
            this.Da = new DataConnection();

            this.PopulateGridView();
        }
        Boolean state = false;
        internal DataConnection Da { get; set; }

        internal DataSet Ds { get; set; }

        internal string Sql { get; set; }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void PopulateGridView(string sql = "select * from History where returndate='null';")
        {
            this.Ds = this.Da.ExecuteQuery(sql);

            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.DataSource = this.Ds.Tables[0];
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PopulateGridView2(string sql = "select * from History where NOT returndate = 'null';")
        {
            this.Ds = this.Da.ExecuteQuery(sql);

            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.DataSource = this.Ds.Tables[0];
        }
        private void button7_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        private void History_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.Sql = @"select * from History where name like '" + this.textBox2.Text + "%';";
            this.PopulateGridView(this.Sql);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.PopulateGridView2();
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
