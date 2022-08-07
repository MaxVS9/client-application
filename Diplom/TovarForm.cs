using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Diplom
{
    public partial class TovarForm : Form
    {
        public TovarForm()
        {
            InitializeComponent();

            LoadDataIntoDataGridView1();

            this.DateBox.Text = DateTime.Now.ToString("yyyy.MM.dd");

            DateTime today = DateTime.Now; // Создаем текущую дату
            today = today.AddDays(30); // Добавляем к ней 7 дней
            SrokBox.Text = today.ToString("yyyy.MM.dd");

            NameBox.Text = "";
            PriceBox.Text = "";
            VolumeBox.Text = "";

        }

        private void LoadDataIntoDataGridView1()
        {
            DB db = new DB();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM product", db.getConnection());

            db.OpenConnection();

            MySqlDataReader sdr = command.ExecuteReader();

            DataTable dtRecords = new DataTable();

            dtRecords.Load(sdr);

            this.dataGridView1.DataSource = dtRecords;

            db.CloseConnection();
        }

        private void TovarForm_Load(object sender, EventArgs e)
        {
       
        }

        private void NameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonDobavit_Click(object sender, EventArgs e)
        {
            if (this.NameBox.Text == "")
            {
                this.NameBox.Text = "NoName";
            }
             if (this.PriceBox.Text == "")
            {
                this.PriceBox.Text = "0";
                MessageBox.Show("Введите сумму");
            }
             if (this.VolumeBox.Text == "")
            {
                this.VolumeBox.Text = "0";
                MessageBox.Show("Введите количество");
            }
            else { 
            DB db = new DB();

            MySqlCommand command = new MySqlCommand("INSERT INTO `product` (`name`, `price`, `volume`, `date`, `sroki`) VALUES (@name, @price, @volume, @date, @sroki);", db.getConnection());

            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = NameBox.Text;
            command.Parameters.Add("@price", MySqlDbType.VarChar).Value = PriceBox.Text;
            command.Parameters.Add("@volume", MySqlDbType.VarChar).Value = VolumeBox.Text;
            command.Parameters.Add("@date", MySqlDbType.VarChar).Value = DateBox.Text;
            command.Parameters.Add("@sroki", MySqlDbType.VarChar).Value = SrokBox.Text;

            db.OpenConnection();

            if (command.ExecuteNonQuery() == 1)
                LoadDataIntoDataGridView1();
            else
                MessageBox.Show("Ошибка");

            db.CloseConnection();

            this.NameBox.Text = "";
            this.PriceBox.Text = "";
            this.VolumeBox.Text = "";

            }
            //LoadDataIntoDataGridView1();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView1();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("DELETE FROM `product` WHERE `product`.`id` = @id", db.getConnection());

            string a = dataGridView1.CurrentCell.Value.ToString();
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = a;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            LoadDataIntoDataGridView1();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sroki2 srok = new Sroki2();
            srok.Show();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            //String a = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            NameBox.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            PriceBox.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            VolumeBox.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            DateBox.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            SrokBox.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void buttonIzm_Click(object sender, EventArgs e)
        {

            if (this.NameBox.Text == "")
            {
                this.NameBox.Text = "NoName";
            }
            if (this.PriceBox.Text == "")
            {
                this.PriceBox.Text = "0";
                MessageBox.Show("Введите сумму");
            }
            if (this.VolumeBox.Text == "")
            {
                this.VolumeBox.Text = "0";
                MessageBox.Show("Введите количество");
            }
            else { 
            DB db = new DB();

           // MySqlCommand command = new MySqlCommand("UPDATE `product` (`name`, `price`, `volume`, `date`, `sroki`) VALUES (@name, @price, @volume, @date, @sroki);", db.getConnection());

            MySqlCommand command = new MySqlCommand("UPDATE `product` SET `name` = @name, `price` = @price, `volume` = @volume, `date` = @date, `sroki` = @sroki WHERE product.id = @ID", db.getConnection());

            String a = dataGridView1.CurrentCell.Value.ToString();
            command.Parameters.Add("@ID", MySqlDbType.VarChar).Value = a;

            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = NameBox.Text;
            command.Parameters.Add("@price", MySqlDbType.VarChar).Value = PriceBox.Text;
            command.Parameters.Add("@volume", MySqlDbType.VarChar).Value = VolumeBox.Text;
            command.Parameters.Add("@date", MySqlDbType.VarChar).Value = DateBox.Text;
            command.Parameters.Add("@sroki", MySqlDbType.VarChar).Value = SrokBox.Text;

            db.OpenConnection();

            if (command.ExecuteNonQuery() == 1)
                LoadDataIntoDataGridView1();
            else
                MessageBox.Show("Ошибка");

            db.CloseConnection();

            this.NameBox.Text = "";
            this.PriceBox.Text = "";
            this.VolumeBox.Text = "";
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable dtRecords = new DataTable();

            db.OpenConnection();

            MySqlCommand command = new MySqlCommand("SELECT * FROM product WHERE name LIKE '%" + searchBox.Text + "%'", db.getConnection());

            MySqlDataReader sdr = command.ExecuteReader();

            dtRecords.Load(sdr);

            dataGridView1.DataSource = dtRecords;

            db.CloseConnection();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable dtRecords = new DataTable();

            db.OpenConnection();

            MySqlCommand command = new MySqlCommand("SELECT * FROM product WHERE name LIKE '%" + searchBox.Text + "%'", db.getConnection());

            MySqlDataReader sdr = command.ExecuteReader();

            dtRecords.Load(sdr);

            dataGridView1.DataSource = dtRecords;

            db.CloseConnection();
        }

        private void PriceBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (Char.IsDigit(e.KeyChar)) return;
            //else                                                      все кроме цифр!
            //    e.Handled = true;

            char c = e.KeyChar;
            if (char.IsLetter(c))
            {
                e.Handled = true;
            }

        }

        private void VolumeBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (char.IsLetter(c))
            {
                e.Handled = true;
            }
        }
    }
}
