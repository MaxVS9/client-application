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
    public partial class UchetDeneg : Form
    {
        public UchetDeneg()
        {
            InitializeComponent();

            LoadDataIntoDataGridView1();

            DB db = new DB();

            MySqlCommand command2 = new MySqlCommand("SELECT SUM(price) FROM money", db.getConnection());

            db.OpenConnection();

            string result = command2.ExecuteScalar().ToString();
            BudjetBox.Text = result;

            db.CloseConnection();

            this.DateBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.NameBox.Text = "";
            //this.comboBox1.Text = "";
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            PriceBox.Text = "";

        }

        private void LoadDataIntoDataGridView1()
        {
            DB db = new DB();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM money", db.getConnection());

            db.OpenConnection();

            MySqlDataReader sdr = command.ExecuteReader();

            DataTable dtRecords = new DataTable();

            dtRecords.Load(sdr);

            this.dataGridView1.DataSource = dtRecords;

            db.CloseConnection();
        }

        private void UchetDeneg_Load(object sender, EventArgs e)
        {

        }

        private void buttonDobavit_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView1();

            if (this.NameBox.Text == "") { 
                this.NameBox.Text = "NoName";}
            if (this.PriceBox.Text == "") {
                this.PriceBox.Text = "0";
                MessageBox.Show("Введите сумму");}
            else { 

            // if (this.comboBox1.Text == "")
            //   MessageBox.Show("Выберите тип статьи");

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("INSERT INTO `money` (`nazvanie`, `price`, `date`) VALUES (@nazvanie, @price, @date);", db.getConnection());
            
            db.OpenConnection();

            if(comboBox1.Text == "Расход")
            {
                string a = PriceBox.Text;
                int b = Convert.ToInt32(a);
                int c = b - (b * 2);
                PriceBox.Text = c.ToString();
            }

            command.Parameters.Add("@nazvanie", MySqlDbType.VarChar).Value = NameBox.Text;
            command.Parameters.Add("@price", MySqlDbType.VarChar).Value = PriceBox.Text;
            command.Parameters.Add("@date", MySqlDbType.VarChar).Value = DateBox.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            LoadDataIntoDataGridView1();

            db.CloseConnection();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlCommand command2 = new MySqlCommand("SELECT SUM(price) FROM money", db.getConnection());

            db.OpenConnection();

            string result = command2.ExecuteScalar().ToString();
            BudjetBox.Text = result;

            db.CloseConnection();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            this.NameBox.Text = "";
            this.PriceBox.Text = "";

            LoadDataIntoDataGridView1();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("DELETE FROM `money` WHERE `money`.`id` = @id", db.getConnection());

            db.OpenConnection();

            string a = dataGridView1.CurrentCell.Value.ToString();
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = a;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            db.CloseConnection();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlCommand command2 = new MySqlCommand("SELECT SUM(price) FROM money", db.getConnection());

            db.OpenConnection();

            string result = command2.ExecuteScalar().ToString();
            BudjetBox.Text = result;

            db.CloseConnection();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            LoadDataIntoDataGridView1();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
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
            else
            {
                DB db = new DB();

            // MySqlCommand command = new MySqlCommand("UPDATE `product` (`name`, `price`, `volume`, `date`, `sroki`) VALUES (@name, @price, @volume, @date, @sroki);", db.getConnection());

            MySqlCommand command = new MySqlCommand("UPDATE `money` SET `nazvanie` = @nazvanie, `price` = @price, `date` = @date WHERE `money`.`id` = @ID", db.getConnection());
                                                     
            if (comboBox1.Text == "Расход")
            {
                string a = PriceBox.Text;
                int b = Convert.ToInt32(a);
                int c = b - (b * 2);
                PriceBox.Text = c.ToString();
            }

            String g = dataGridView1.CurrentCell.Value.ToString();
            command.Parameters.Add("@ID", MySqlDbType.VarChar).Value = g;

            command.Parameters.Add("@nazvanie", MySqlDbType.VarChar).Value = NameBox.Text;
            command.Parameters.Add("@price", MySqlDbType.VarChar).Value = PriceBox.Text;
            command.Parameters.Add("@date", MySqlDbType.VarChar).Value = DateBox.Text;

            db.OpenConnection();

            if (command.ExecuteNonQuery() == 1)
                LoadDataIntoDataGridView1();
            else
                MessageBox.Show("Ошибка");

            db.CloseConnection();

            this.NameBox.Text = "";
            this.PriceBox.Text = "";
            //this.comboBox1.Text = "";
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            NameBox.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            PriceBox.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            DateBox.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void PriceBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (char.IsLetter(c))
            {
                e.Handled = true;
            }
        }
    }
}
