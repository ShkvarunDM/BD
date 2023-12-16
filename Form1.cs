using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void loginbutton1_Click(object sender, EventArgs e)
        {
            
            NpgsqlCommand login = new NpgsqlCommand("SELECT * FROM login1 WHERE login2 =  '"+ textBox1.Text + "'AND passw = '" + textBox2.Text + "'");
            var sdr = Program.DB.ExecuteReader(login);

            if (sdr.Read())
            {
                MessageBox.Show("пароль введен верно ");
                int lev = (int)sdr[2];
                ((Base_Form)Program.fc.forms[1]).Data_Access(lev);
                Program.fc.Show(1);
            }
            else
            {
                MessageBox.Show("неверно введен пароль");
            }

        }
    }
}
