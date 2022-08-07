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
    public partial class ProdatTovarForm : Form
    {
        public ProdatTovarForm()
        {
            InitializeComponent();

            LoadDataIntoDataGridView1();

            this.VolumeBox.Visible = false;
            this.VolumeBox.Text = "Введите количество";
            this.VolumeBox.ForeColor = Color.Silver;
            this.OkButton.Visible = false;
            CheckTextBox.Text = "";

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void OkButton_Click(object sender, EventArgs e)
        {

            this.VolumeBox.Visible = false;
            this.OkButton.Visible = false;

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT name FROM `product` WHERE `product`.`id` = @id", db.getConnection());

            db.OpenConnection();

            string a = dataGridView1.CurrentCell.Value.ToString();
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = a;

            string result = command.ExecuteScalar().ToString();

            db.CloseConnection();

            string VolumeText = VolumeBox.Text;

            if (VolumeBox.Text == "")
            {
                MessageBox.Show("Введите количество");
                return;
            }
            else if (VolumeBox.Text == "Введите количество")
            {
                MessageBox.Show("Введите количество");
                return;
            }

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlCommand command2 = new MySqlCommand("SELECT price FROM `product` WHERE `product`.`id` = @price", db.getConnection());

            db.OpenConnection();

            string b = dataGridView1.CurrentCell.Value.ToString();
            command2.Parameters.Add("@price", MySqlDbType.VarChar).Value = b;

            string price1 = command2.ExecuteScalar().ToString();
            int p1 = Convert.ToInt32(price1);
            int ktovarov = Convert.ToInt32(VolumeText);
            int itogPrice = p1 * ktovarov;

            if (this.PriceBox.Text == "")
                this.PriceBox.Text = 0.ToString();

            string price2 = this.PriceBox.Text;
            int p2 = Convert.ToInt32(price2);
            int p3 = p2 + itogPrice;

            db.CloseConnection();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlCommand command3 = new MySqlCommand("SELECT volume FROM `product` WHERE `product`.`id` = @volume", db.getConnection());
               
            db.OpenConnection();

            string c = dataGridView1.CurrentCell.Value.ToString();                  // GET ID
            command3.Parameters.Add("@volume", MySqlDbType.VarChar).Value = c;

            string GetVolumeID = command3.ExecuteScalar().ToString();               // GET REZULTAT

            db.CloseConnection();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            int t1 = Convert.ToInt32(GetVolumeID);
            int t2 = Convert.ToInt32(VolumeText);

            if (t2 > t1)
            {
                MessageBox.Show("Количество превышает товар в наличии!");
                return;
            }

            this.CheckTextBox.Text += result + " " + "x" + VolumeText + "\r\n";
            this.PriceBox.Text = p3.ToString();

            MySqlCommand command4 = new MySqlCommand("UPDATE product SET volume = @Vol - @skolkoMinus WHERE product.id = @idVolume", db.getConnection());

            db.OpenConnection();

            command4.Parameters.Add("@Vol", MySqlDbType.VarChar).Value = GetVolumeID;               // GET REZULTAT

            command4.Parameters.Add("@skolkoMinus", MySqlDbType.VarChar).Value = VolumeText;        // GET MINUS
            
            string d = dataGridView1.CurrentCell.Value.ToString();                                  // GET ID
            command4.Parameters.Add("@idVolume", MySqlDbType.VarChar).Value = d;

            adapter.SelectCommand = command4;
            adapter.Fill(table);

            LoadDataIntoDataGridView1();

            db.CloseConnection();
        }

        private void buttonDobavit_Click(object sender, EventArgs e)
        {

            this.VolumeBox.Visible = true;
            this.OkButton.Visible = true;
            VolumeBox.Text = "Введите количество";
            VolumeBox.ForeColor = Color.Silver;

        }

        private void VolumeBox_Enter(object sender, EventArgs e)
        {
            if (VolumeBox.Text == "Введите количество")
            {
                VolumeBox.Text = "";
                VolumeBox.ForeColor = Color.Black;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

            string proverka = this.PriceBox.Text;              //Беру значение Текущей цены
            if (proverka == "0")
            {
               MessageBox.Show("Операция невозможна");
                return;
            }
            else if(proverka == ""){
                MessageBox.Show("Операция невозможна");
                return;
            }
            
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command2 = new MySqlCommand("SELECT price FROM `product` WHERE `product`.`id` = @volume", db.getConnection());

            db.OpenConnection();

            string idPrice = dataGridView1.CurrentCell.Value.ToString();                                  // GET ID
            command2.Parameters.Add("@Volume", MySqlDbType.VarChar).Value = idPrice;                       //Передаю ид в запрос

            string priceProd = command2.ExecuteScalar().ToString();                                            //Беру результат запроса
            int skolkoVernut = Convert.ToInt32(priceProd);                                                    //Перевожу в инт

            db.CloseConnection();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlCommand command = new MySqlCommand("UPDATE product SET volume = volume + @Vernut WHERE product.id = @idVolume", db.getConnection());

            db.OpenConnection();
            string id = dataGridView1.CurrentCell.Value.ToString();                                  // GET ID
            command.Parameters.Add("@idVolume", MySqlDbType.VarChar).Value = id;

            string Vernut = this.VolumeBox.Text;               //Беру значение сколько вернуть
            int VernutX = Convert.ToInt32(Vernut);

            command.Parameters.Add("@Vernut", MySqlDbType.VarChar).Value = Vernut;

            string price = this.PriceBox.Text;              //Беру значение Текущей цены
            int tekushayaCena = Convert.ToInt32(price);             //Перевожу в инт

            int kk3 = tekushayaCena - (skolkoVernut * VernutX);

            this.PriceBox.Text = kk3.ToString();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            this.CheckTextBox.Text += "отмена предыдущего действия" + "\r\n";

            LoadDataIntoDataGridView1();

            db.CloseConnection();
            
        }

        private void VolumeBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonOplata_Click(object sender, EventArgs e)
        {

            if(CheckTextBox.Text == "")
            {
                MessageBox.Show("Выберите товар");
            }
            else
            {

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("INSERT INTO `money` (`nazvanie`, `price`, `date`) VALUES (@nazvanie, @price, @date);", db.getConnection());

            db.OpenConnection();

            command.Parameters.Add("@price", MySqlDbType.VarChar).Value = PriceBox.Text;
            command.Parameters.Add("@date", MySqlDbType.VarChar).Value = DateTime.Now.ToString("yyyy-MM-dd");
            command.Parameters.Add("@nazvanie", MySqlDbType.VarChar).Value = "Продажа товаров";

            db.CloseConnection();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
      
            MySqlCommand zapicat = new MySqlCommand("INSERT INTO `tovaranasklade` (`Kolichestvo`, `date`) VALUES (@skolkoZapicat, @date);", db.getConnection());
            MySqlCommand poscitat = new MySqlCommand("SELECT SUM(volume) FROM product", db.getConnection());
            
            db.OpenConnection();

            string a = poscitat.ExecuteScalar().ToString();                                           
            int b = Convert.ToInt32(a);
            string date = DateTime.Now.ToString("yyyy-MM-dd");

            zapicat.Parameters.Add("@skolkoZapicat", MySqlDbType.VarChar).Value = b;
            zapicat.Parameters.Add("@date", MySqlDbType.VarChar).Value = date;

            adapter.SelectCommand = poscitat;
            adapter.SelectCommand = zapicat;
            adapter.Fill(table);

            db.CloseConnection();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlCommand zapicat1 = new MySqlCommand("INSERT INTO `budjet` (`dengi`, `date`) VALUES (@skolkoZapicat1, @date1);", db.getConnection());
            MySqlCommand poscitat1 = new MySqlCommand("SELECT SUM(price) FROM money", db.getConnection());

            db.OpenConnection();

            string a1 = poscitat1.ExecuteScalar().ToString();
            int b1 = Convert.ToInt32(a1);
            string date1 = DateTime.Now.ToString("yyyy-MM-dd");

            zapicat1.Parameters.Add("@skolkoZapicat1", MySqlDbType.VarChar).Value = b1;
            zapicat1.Parameters.Add("@date1", MySqlDbType.VarChar).Value = date1;

            adapter.SelectCommand = poscitat1;
            adapter.SelectCommand = zapicat1;
            adapter.Fill(table);

            db.CloseConnection();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            this.CheckTextBox.Text = "";
            this.PriceBox.Text = "0";
            MessageBox.Show("Товар оплачен");
        }

    }

        private void ProdatTovarForm_Load(object sender, EventArgs e)
        {
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}