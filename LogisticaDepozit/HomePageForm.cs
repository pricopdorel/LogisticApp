using LogisticaDepozit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxWMPLib;
using WMPLib;
using System.Data.SqlClient;

namespace LogisticaDepozit
{
    public partial class HomePageForm : Form
    {
        //DE MODIFICAT STRING-UL DOAR AICI
        internal static string connString =ConnectionStrings.Dorel;
        internal SqlConnection myCon = new SqlConnection(connectionString: connString);

        internal Timer timer;
        public HomePageForm()
        {
            InitializeComponent();

            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);
            this.MaximumSize = new Size(this.Size.Width, this.Size.Height);

            this.btn_SignUpOpen.Enabled = false;
            this.btn_LogInOpen.Enabled = false;

            timer = new Timer();
            timer.Interval = 6000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            this.Controls.Remove(pictureBox2);

            this.btn_SignUpOpen.Enabled = true;
            this.btn_LogInOpen.Enabled = true;
        }

        private void btn_LogInOpen_Click(object sender, EventArgs e)
        {

            LoginForm logIn = new LoginForm();
            this.Hide();
            logIn.Show();

        }

        private void btn_SignUpOpen_Click(object sender, EventArgs e)
        {
            SignUpForm logIn = new SignUpForm();
            this.Hide();
            logIn.Show();
        }

        private void HomePageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void HomePageForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
