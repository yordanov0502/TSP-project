using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;//biblioteka za rabora s SQL server
using System.Globalization;

namespace zadanie1
{
    public partial class Orders_subform : Form
    {
        public Orders_subform()
        {
            InitializeComponent();
        }

        Form1 mainForm = new Form1(); 
        SqlConnection myConnection; 
        SqlCommand myCommand;

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void showCurrentId() 
        {
            //izvejdam tekusht nomer na poruchka ako bude napravena takava
            myConnection = new SqlConnection(mainForm.cs);
            myCommand = new SqlCommand("select count(NumOrd) from [dbo].[Orders]", myConnection);
            myConnection.Open();
            object idCounter = myCommand.ExecuteScalar();
            myConnection.Close();
            if (idCounter != null) { label1.Text = "Поръчка №: " + (Convert.ToInt32(idCounter) + 1).ToString(); }
        }

        private void Orders_subform_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy HH:mm:ss";

            showCurrentId();

            //zarejdam v comboBox1 vsichki unikalni nomera na taksita(KodTaxi) ot tablica Cars
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            myCommand = new SqlCommand("select KodTaxi from [dbo].[Cars]", myConnection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = myCommand;
            DataTable tempTable = new DataTable();
            dataAdapter.Fill(tempTable);
            DataRow itemRow = tempTable.NewRow();
            itemRow[0] = "Изберете номер на такси";
            tempTable.Rows.InsertAt(itemRow, 0);
            comboBox1.DataSource = tempTable;
            comboBox1.ValueMember = "KodTaxi";

            //dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //dateTimePicker1.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
        }

        private Boolean validate_attributes()
        {
            CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            ci.NumberFormat.CurrencyDecimalSeparator = ".";

            if (comboBox1.SelectedIndex == 0 || textBox3.Text.ToString() == "" || textBox5.Text.ToString() == "" || textBox6.Text.ToString() == "") { MessageBox.Show("Моля въведете данни във всички полета!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }

            else if (float.Parse(textBox5.Text, NumberStyles.Any, ci) <= 0) {MessageBox.Show("Изминатото разстояние трябва да бъде положително число!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);return false;}
            else if (float.Parse(textBox6.Text, NumberStyles.Any, ci) <= 0) { MessageBox.Show("Таксата трябва да бъде положително число!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            else { return true; }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (validate_attributes())
                {
                    myConnection = new SqlConnection(mainForm.cs);
                    //myCommand = new SqlCommand("Insert into Orders values('" + comboBox1.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')", myConnection);
                    myCommand = new SqlCommand("INSERT INTO Orders (KodTaxi,Addres,OrdTime,Distance,Fare) VALUES (@KodTaxi,@Addres,@OrdTime,@Distance,@Fare)", myConnection);
                    myConnection.Open();
                    //nomer na poru4ka e napraven na auto increment zatova ne my se zadava stojnost ot textBox
                    myCommand.Parameters.AddWithValue("@KodTaxi", comboBox1.Text);
                    myCommand.Parameters.AddWithValue("@Addres", textBox3.Text);
                    myCommand.Parameters.AddWithValue("@OrdTime", dateTimePicker1.Text);
                    myCommand.Parameters.AddWithValue("@Distance", textBox5.Text);
                    myCommand.Parameters.AddWithValue("@Fare", textBox6.Text);
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                    MessageBox.Show("Успешно въведени данни за поръчка на такси!");
                    if (myConnection.State == ConnectionState.Open) { myConnection.Dispose(); }
                }
                // Convert.ToDateTime(dateTimePicker1.Value.ToLongDateString())

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Грешка при въвеждането на данни!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            showCurrentId();
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Form1 = new Form1();
            Form1.Show();
        }

        private void Orders_subform_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
