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
    public partial class frmCars_subform : Form
    {
        //public static frmCars_subform instance;
        //public DataGridView dataGridViewOf_frmCars_subform;
        public frmCars_subform()
        {
            InitializeComponent();
            //instance = this;
            //dataGridViewOf_frmCars_subform = dataGridView1;
        }

        Form1 mainForm = new Form1();
        SqlConnection myConnection;
        SqlCommand myCommand;
        SqlDataAdapter dataAdapter;

        private void SetPropertiesOfDataGridView()
        {
            dataGridView1.Columns[0].HeaderText = "Поръчка №";
            dataGridView1.Columns[1].HeaderText = "Адрес";
            dataGridView1.Columns[2].HeaderText = "Време на поръчка";
            dataGridView1.Columns[3].HeaderText = "Разстояние";
            dataGridView1.Columns[4].HeaderText = "Такса(лв)";
        }

        private void frmCars_subform_Load(object sender, EventArgs e)
        {
            label1.Text = label1.Text + " " + frmCars.chosenTaxi;

             myConnection = new SqlConnection(mainForm.cs);
             myConnection.Open();
             DataTable dt = new DataTable();
             dataAdapter = new SqlDataAdapter("select NumOrd,Addres,OrdTime,Distance,Fare from Orders where KodTaxi='" + frmCars./*static.*/chosenTaxi +"'", myConnection);
             dataAdapter.Fill(dt);
             dataGridView1.DataSource = dt;
             myConnection.Close();
            SetPropertiesOfDataGridView();
        }

       // private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        //{
            //this.Hide();
           // Form Form1 = new Form1();
            //Form1.Show();
       // }

        private void frmCars_subform_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Close();
        }
    }
}
