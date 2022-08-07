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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            rolBox.Text = "user";
            rolBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm main = new MainForm();
            main.Show();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {

            if (LoginField.Text == "")
            { 
                MessageBox.Show("Введите логин");
                return;
            }
            else if (PassField.Text == "")
            {
                MessageBox.Show("Введите пароль");
                return;
            }

            if (checkUsername())
                return;

            DB db = new DB();

            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `pass`, `rol`) VALUES (@log, @pass, @rol);", db.getConnection());

            command.Parameters.Add("@log", MySqlDbType.VarChar).Value = LoginField.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = PassField.Text;
            command.Parameters.Add("@rol", MySqlDbType.VarChar).Value = rolBox.Text;

            db.OpenConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Успешно");
            else
                MessageBox.Show("Ошибка");

            db.CloseConnection();

        }

        public Boolean checkUsername()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = LoginField.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Такой логин уже используется");
                return true;
            }
            else
                return false;
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
