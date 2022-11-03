using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//biblioteka za rabora s SQL server

namespace zadanie1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\USERS\YORDA\DESKTOP\СИТ\ПЕТИ СЕМЕСТЪР\ТСП C#\PROJECT\ZADANIE1\ZADANIE1\DATABASE1.MDF;Integrated Security=True";//put do nashata baza danni
        public SqlConnection myConnection = default(SqlConnection);
        public SqlCommand myCommand = default(SqlCommand);

        private void въвежданеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void изходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void колиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frmCars = new frmCars();
            frmCars.Show();
        }

        private void поръчкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Orders_subform = new Orders_subform();
            Orders_subform.Show();
        }

        private void qryTotalOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form qryTotalOrders = new qryTotalOrders();
            qryTotalOrders.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
