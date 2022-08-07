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
    public partial class Sroki2 : Form
    {
        public Sroki2()
        {
            InitializeComponent();

            LoadDataIntoDataGridView1();
        }

        private void LoadDataIntoDataGridView1()
        {
            DB db = new DB();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `product` WHERE @date = sroki - INTERVAL 7 DAY", db.getConnection());

            string data = DateTime.Now.ToString("yyyy-MM-dd");
            command.Parameters.Add("@date", MySqlDbType.VarChar).Value = data;

            db.OpenConnection();

            MySqlDataReader sdr = command.ExecuteReader();

            DataTable dtRecords = new DataTable();

            dtRecords.Load(sdr);

            this.dataGridView1.DataSource = dtRecords;

            db.CloseConnection();
        }

        private void Sroki2_Load(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {

            }
            else
            {
                MessageBox.Show("Продукты с истекающим сроком годности не найдены");
                this.Close();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
