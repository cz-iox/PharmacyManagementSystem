using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyWinForms
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {

            InitializeComponent();
        }

        private void btnColes_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Minimize_btn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            userProfileControl1.Visible = false;
            lblTime.Text = DateTime.Now.ToString("M/d/yyyy");
            lbldate.Text = DateTime.Now.ToString("hh:mm tt");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("M/d/yyyy");

            lbldate.Text = DateTime.Now.ToString("hh:mm tt");


        }

        private void userIcon_Click(object sender, EventArgs e)
        {
            userProfileControl1.Visible = true;
        }
    }

}
