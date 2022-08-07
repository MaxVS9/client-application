using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

           
        }

        private void buttonTovar_Click(object sender, EventArgs e)
        {
            TovarForm tovarForm = new TovarForm();
            tovarForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProdatTovarForm prodat = new ProdatTovarForm();
            prodat.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UchetDeneg uchet = new UchetDeneg();
            uchet.Show();
        }

        private void buttonOtchet_Click(object sender, EventArgs e)
        {
            OtchetForm otchet = new OtchetForm();
            otchet.Show();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm regWin = new RegisterForm();
            regWin.Show();
        }

    }
}
