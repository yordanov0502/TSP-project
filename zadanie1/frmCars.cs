using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;//biblioteka za rabora s SQL server
using System.Linq;

namespace zadanie1
{
    public partial class frmCars : Form
    {
        //public static frmCars instance;
        public static String chosenTaxi;
        public frmCars()
        {
            InitializeComponent();
            //instance = this;
            chosenTaxi = "none";
        }


        Form1 mainForm = new Form1();
        SqlConnection myConnection;
        SqlCommand myCommand;
        SqlDataAdapter dataAdapter;

        private Boolean checkForExistingRegNomer() {

            myConnection = new SqlConnection(mainForm.cs);
            myConnection.Open();
            myCommand = new SqlCommand("SELECT COUNT (*) FROM Cars WHERE RegNomer='" + textBox2.Text + "'", myConnection);
            object obj = myCommand.ExecuteScalar();
            myConnection.Close();
            if (Convert.ToInt32(obj) > 0)
            {
                MessageBox.Show("Регистрационен номер:\""+textBox2.Text+"\" вече съществува в базата данни!","Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean validate_attributes() 
        {
            if (textBox1.Text.ToString() == "" || textBox2.Text.ToString() == "" || textBox3.Text.ToString() == "" || textBox4.Text.ToString() == "" || textBox5.Text.ToString() == "" || textBox6.Text.ToString() == "") { MessageBox.Show("Моля въведете данни във всички полета!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);return false; }

            else
            {
                if (!checkForExistingRegNomer())
                {
                    if (textBox2.Text.Length < 9) { MessageBox.Show("Регистрационния номер на автомобила не може да бъде по-малък от 9 символа.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
                    if (textBox2.Text.Length == 9 && (textBox2.Text[1].ToString() != " " || textBox2.Text[6].ToString() != " " || char.IsLower(textBox2.Text[0]) || char.IsLower(textBox2.Text[7]) || char.IsLower(textBox2.Text[8]))) { MessageBox.Show("Грешно въведен регистрационен номер!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
                    if (textBox2.Text.Length == 10 && (textBox2.Text[2].ToString() != " " || textBox2.Text[7].ToString() != " " || char.IsLower(textBox2.Text[0]) || char.IsLower(textBox2.Text[1]) || char.IsLower(textBox2.Text[8]) || char.IsLower(textBox2.Text[9]))) { MessageBox.Show("Грешно въведен регистрационен номер!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
                    if (Convert.ToInt32(textBox4.Text) < 3 || Convert.ToInt32(textBox4.Text) > 10) { MessageBox.Show("Свободните места в такси могат да са между 3 и 10.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
                    if (!(textBox5.Text.ToString() == "Да" || textBox5.Text.ToString() == "Не")) { MessageBox.Show("В поле \"Място за голям багаж\" трябва да въведете \"Да\" или \"Не\"!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }

                }
                else { return false; }
            }
            return true;
        }

        private void SetPropertiesOfDataGridView() 
        {
            dataGridView1.Columns[0].HeaderText = "Такси №";
            dataGridView1.Columns[1].HeaderText = "Рег.номер";
            dataGridView1.Columns[2].HeaderText = "Марка";
            dataGridView1.Columns[3].HeaderText = "Бр.места";
            dataGridView1.Columns[4].HeaderText = "Място за голям багаж";
            dataGridView1.Columns[5].HeaderText = "Шофьор";
        }

        private void DisplayData() 
        {
            myConnection = new SqlConnection(mainForm.cs);
            myConnection.Open(); 
            DataTable dt = new DataTable(); 
            dataAdapter = new SqlDataAdapter("select * from Cars", myConnection); 
            dataAdapter.Fill(dt);
            dataGridView1.DataSource = dt; 
            myConnection.Close();
            SetPropertiesOfDataGridView();
        }
        
        

        private void button1_Click(object sender, EventArgs e)
        {
           try
            {
                if (validate_attributes())
                {
                    myConnection = new SqlConnection(mainForm.cs);
                    //myCommand = new SqlCommand("Insert into Cars values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')", myConnection);
                    myCommand = new SqlCommand("INSERT INTO Cars (KodTaxi,RegNomer,Mark,Seats,Luggage,Driver) VALUES (@KodTaxi,@RegNomer,@Mark,@Seats,@Luggage,@Driver)", myConnection);
                    myConnection.Open();
                    myCommand.Parameters.AddWithValue("@KodTaxi", textBox1.Text);
                    myCommand.Parameters.AddWithValue("@RegNomer", textBox2.Text); //myCommand.Parameters.Add("@RegNomer", SqlDbType.NVarChar).Value = textBox2.Text;
                    myCommand.Parameters.AddWithValue("@Mark", textBox3.Text);
                    myCommand.Parameters.AddWithValue("@Seats", textBox4.Text);
                    myCommand.Parameters.AddWithValue("@Luggage", textBox5.Text);
                    myCommand.Parameters.AddWithValue("@Driver", textBox6.Text);
                    myCommand.ExecuteNonQuery(); 
                    myConnection.Close();
                    MessageBox.Show("Успешно въведени данни на такси!");
                    if (myConnection.State == ConnectionState.Open) { myConnection.Dispose(); }
                    DisplayData();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Грешка при въвеждането на данни!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void frmCars_Load(object sender, EventArgs e)
        {
            //this.ControlBox = false;
            DisplayData();
        }

        

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {


            // myConnection = new SqlConnection(mainForm.cs);
            //myConnection.Open();
            //DataTable dt = new DataTable();
            // dataAdapter = new SqlDataAdapter("select * from Orders where KodTaxi='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() +"'", myConnection);
            // dataAdapter.Fill(dt);
            // frmCars_subform.instance.dataGridViewOf_frmCars_subform.DataSource = dt;
            //myConnection.Close();

            //frmCars_subform.instance.Show();

            if (Application.OpenForms.OfType<frmCars_subform>().Count() == 1)
            {
                Application.OpenForms.OfType<frmCars_subform>().First().Close();
            }
           
                chosenTaxi = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                Form frmCars_subform = new frmCars_subform();
                frmCars_subform.Show();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Form1 = new Form1();
            Form1.Show();
        }

        private void frmCars_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
