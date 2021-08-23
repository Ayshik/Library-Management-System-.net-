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
    public partial class studentpanel : Form
    {
        public studentpanel(string uname)
        {
            InitializeComponent();
            label1.Text = uname;
        }

        private void studentpanel_Load(object sender, EventArgs e)
        {

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

            Login c = new Login();
            this.Visible = false;
            c.Visible = true;
        }
    }
}
