using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;//biblioteka za rabora s SQL server

namespace zadanie1
{
    public partial class qryTotalOrders : Form
    {
        public qryTotalOrders()
        {
            InitializeComponent();
        }

        Form1 mainForm = new Form1();
        SqlConnection myConnection;
        SqlCommand myCommand;
        SqlDataAdapter dataAdapter;

        private void qryTotalOrders_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy HH:mm:ss";
        }

        private void SetPropertiesOfDataGridView_Button1()
        {
            dataGridView1.Columns[0].HeaderText = "Рег.номер";
            dataGridView1.Columns[1].HeaderText = "Марка такси";
        }

        private void SetPropertiesOfDataGridView_Button2()
        {
            dataGridView1.Columns[0].HeaderText = "Такси №";
            dataGridView1.Columns[1].HeaderText = "Обща сума поръчки(.лв)";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myConnection = new SqlConnection(mainForm.cs);
            myConnection.Open();
            DataTable dt = new DataTable();
            dataAdapter = new SqlDataAdapter("Select c.RegNomer,c.Mark From Orders o Join Cars c ON o.KodTaxi = c.KodTaxi Where o.OrdTime < '"+dateTimePicker1.Text+"';", myConnection);
            dataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
            myConnection.Close();
            SetPropertiesOfDataGridView_Button1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myConnection = new SqlConnection(mainForm.cs);
            myConnection.Open();
            DataTable dt = new DataTable();
            dataAdapter = new SqlDataAdapter("SELECT o.KodTaxi,SUM(o.Fare) AS total_score FROM Orders o Join Cars c ON o.KodTaxi = c.KodTaxi Where o.OrdTime < '"+dateTimePicker1.Text+"' GROUP BY o.KodTaxi ORDER BY SUM(o.Fare) DESC;", myConnection);
            dataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
            myConnection.Close();
            SetPropertiesOfDataGridView_Button2();
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Form1 = new Form1();
            Form1.Show();
        }

        private void qryTotalOrders_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
