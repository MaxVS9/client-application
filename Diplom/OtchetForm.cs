using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using MySql.Data.MySqlClient;

namespace Diplom
{
    public partial class OtchetForm : Form
    {

        string data1;
        string data2;

        public OtchetForm()
        {
            InitializeComponent();

            data1 = Date1Box.Text;
            data2 = Date2Box.Text;

            
            DateTime today = DateTime.Now; // Создаем текущую дату
            today = today.AddDays(-30); // Добавляем к ней 30 дней

            Date1Box.Text = today.ToString("yyyy.MM.dd");
            Date2Box.Text = DateTime.Now.ToString("yyyy.MM.dd");

        }

        private void OtchetForm_Load(object sender, EventArgs e)
        {
            DB db = new DB();
        }

        private void buttonPostroitGrafik_Click(object sender, EventArgs e)
        {

            data1 = Date1Box.Text;
            data2 = Date2Box.Text;

            DB db = new DB();
            DataSet dataset = new DataSet();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM money WHERE date >= @data1 AND date <= @data2", db.getConnection());

            adapter.SelectCommand.Parameters.Add("@data1", MySqlDbType.VarChar).Value = data1;
            adapter.SelectCommand.Parameters.Add("@data2", MySqlDbType.VarChar).Value = data2;

            db.OpenConnection();

            adapter.Fill(table);
            adapter.Fill(dataset, "money");
            table = dataset.Tables["money"];

            cartesianChart1.LegendLocation = LegendLocation.Bottom;

            db.CloseConnection();

            SeriesCollection series = new SeriesCollection();

            ChartValues<int> MoneyValues = new ChartValues<int>();

            List<string> dates = new List<string>();


            foreach (DataRow row in table.Rows)
            {
                MoneyValues.Add(Convert.ToInt32(row["price"]));
                dates.Add(Convert.ToDateTime(row["date"]).ToShortDateString());
            }

            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisX.Add(new Axis()
            {
                Title = "Даты",
                Labels = dates 
            });

            LineSeries line = new LineSeries();
            line.Title = "Доходы/Расходы";
            line.Values = MoneyValues;

            series.Add(line);

            cartesianChart1.Series = series;

        }

        private void buttonTovar_Click(object sender, EventArgs e)
        {

            data1 = Date1Box.Text;
            data2 = Date2Box.Text;

            DB db = new DB();

            DataSet dataset = new DataSet();

            DataTable table = new DataTable();

            db.OpenConnection();

            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM tovaranasklade WHERE date >= @data1 AND date <= @data2", db.getConnection());

            adapter.SelectCommand.Parameters.Add("@data1", MySqlDbType.VarChar).Value = data1;
            adapter.SelectCommand.Parameters.Add("@data2", MySqlDbType.VarChar).Value = data2;

            adapter.Fill(dataset, "tovaranasklade");
            table = dataset.Tables["tovaranasklade"];

            cartesianChart1.LegendLocation = LegendLocation.Bottom;

            db.CloseConnection();

            SeriesCollection series = new SeriesCollection();

            ChartValues<int> MoneyValues = new ChartValues<int>();

            List<string> dates = new List<string>();

            foreach (DataRow row in table.Rows)
            {
                MoneyValues.Add(Convert.ToInt32(row["Kolichestvo"]));
                dates.Add(Convert.ToDateTime(row["date"]).ToShortDateString());
            }

            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisX.Add(new Axis()
            {
                Title = "Даты",
                Labels = dates
            });

            LineSeries line = new LineSeries();
            line.Title = "Количество товаров на складе";
            line.Values = MoneyValues;

            series.Add(line);

            cartesianChart1.Series = series;
        }

        private void buttonBudjet_Click(object sender, EventArgs e)
        {

            data1 = Date1Box.Text;
            data2 = Date2Box.Text;

            DB db = new DB();
            DataSet dataset = new DataSet();
            DataTable table = new DataTable();

            db.OpenConnection();

            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM budjet WHERE date >= @data1 AND date <= @data2", db.getConnection());

            adapter.SelectCommand.Parameters.Add("@data1", MySqlDbType.VarChar).Value = data1;
            adapter.SelectCommand.Parameters.Add("@data2", MySqlDbType.VarChar).Value = data2;

            adapter.Fill(dataset, "budjet");
            table = dataset.Tables["budjet"];

            cartesianChart1.LegendLocation = LegendLocation.Bottom;

            SeriesCollection series = new SeriesCollection();
            ChartValues<int> MoneyValues = new ChartValues<int>();
            List<string> dates = new List<string>();

            foreach (DataRow row in table.Rows)
            {
                MoneyValues.Add(Convert.ToInt32(row["dengi"]));
                dates.Add(Convert.ToDateTime(row["date"]).ToShortDateString());
            }

            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisX.Add(new Axis()
            {
                Title = "Даты",
                Labels = dates,
            });
            
            LineSeries line = new LineSeries();
            line.Title = "Бюджет";
            line.Values = MoneyValues;
            series.Add(line);

            cartesianChart1.Series = series;

            db.CloseConnection();
        }

        private void buttonPeriod_Click(object sender, EventArgs e)
        {
            data1 = Date1Box.Text;
            data2 = Date2Box.Text;
            MessageBox.Show("Успешно! Теперь нажмите на кнопку нужного вам графика.");
        }

        private void Date1Box_TextChanged(object sender, EventArgs e)
        {

        }

        private void Date1Box_Enter(object sender, EventArgs e)
        {
            //Date1Box.Text = "";
            //Date1Box.ForeColor = Color.Black;

        }

        private void Date2Box_Enter(object sender, EventArgs e)
        {
            //Date2Box.Text = "";
           // Date2Box.ForeColor = Color.Black;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
