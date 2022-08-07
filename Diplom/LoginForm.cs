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
    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();

            button1.Visible = false;

            this.PassField.AutoSize = false;
            this.PassField.Size = new Size(this.PassField.Size.Width, 34);

            LoginField.Text = "Введите логин";
            LoginField.ForeColor = Color.Silver;

            PassField.UseSystemPasswordChar = false;

            PassField.Text = "Введите пароль";
            PassField.ForeColor = Color.Silver;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {

            if(LoginField.Text == "Введите логин") {
                MessageBox.Show("Введите логин");
                    }
            else if (PassField.Text == "Введите пароль") {
                MessageBox.Show("Введите пароль");
                    }
            else {
                String loginUser = LoginField.Text;
                String passUser = PassField.Text;

                DB db = new DB();

                DataTable table = new DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                db.OpenConnection();

                MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL AND `pass` = @uP", db.getConnection());
                MySqlCommand command2 = new MySqlCommand("SELECT rol FROM `users` WHERE id = @idrol", db.getConnection());

                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
                command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

                adapter.SelectCommand = command;
                adapter.Fill(table);

                if(table.Rows.Count > 0) { 
                string iduser = command.ExecuteScalar().ToString();
                command2.Parameters.Add("@idrol", MySqlDbType.VarChar).Value = iduser;

                string role = command2.ExecuteScalar().ToString();

                db.CloseConnection();

                    if (role == "root")
                    {
                        this.Hide();
                        MainForm mMenu = new MainForm();
                        mMenu.Show();
                        Sroki sroki = new Sroki();
                        sroki.Show();

                    }
                    else if (role == "user")
                    {

                        this.Hide();
                        MainForm mMenu = new MainForm();
                        mMenu.Show();
                        mMenu.buttonOtchet.Visible = false;
                        mMenu.button2.Visible = false;
                        mMenu.button3.Visible = false;

                        Sroki sroki = new Sroki();
                        sroki.Show();
                    }

                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль");
                }
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void LoginField_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginField_Enter(object sender, EventArgs e)
        {
            if (LoginField.Text == "Введите логин")
            {
                LoginField.Text = "";
                LoginField.ForeColor = Color.Black;
            }
        }

        private void PassField_Enter(object sender, EventArgs e)
        {
            if (PassField.Text == "Введите пароль")
            {
                PassField.Text = "";
                PassField.ForeColor = Color.Black;
                PassField.UseSystemPasswordChar = true;
            }
        }

        private void LoginField_Leave(object sender, EventArgs e)
        {
            if (LoginField.Text == "")
            {
                LoginField.Text = "Введите логин";
                LoginField.ForeColor = Color.Silver;
            }
        }

        private void PassField_Leave(object sender, EventArgs e)
        {
            if (PassField.Text == "")
            {
                PassField.Text = "Введите пароль";
                PassField.ForeColor = Color.Silver;
                PassField.UseSystemPasswordChar = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm regWin = new RegisterForm(); 
            regWin.Show();
        }
    }
}
