using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static WindowsFormsApp2.Program;

namespace WindowsFormsApp2
{
    public partial class Сustomers : Form
    {
        private int _lastId;
        private List<string> data;

        public Сustomers()
        {
            InitializeComponent();
        }

        private void Сustomers_Load(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void AddButton(string text)
        {
            AssociateButton btn = new AssociateButton();
            btn.Recid = _lastId++;
            btn.BackColor = Color.LightPink;
            btn.Text = text;
            btn.Click += btnClick;
            btn.Height = 30;
            btn.Width = 100;
            btn.Dock = DockStyle.Top;
            btn.FlatAppearance.BorderSize = 4;
            groupBox2.Controls.Add(btn);

        }
        private void PutData(int id)
        {
            textBox3.Text = data[id];
        }

        private void btnClick(object sender, EventArgs e)
        {
            foreach (object btn in groupBox2.Controls)
            {
                ((AssociateButton)btn).Enabled = true;
            }
            ((AssociateButton)sender).Enabled = false;
            PutData(((AssociateButton)sender).Recid);
        }

        public void UpdateData()
        {

            data = new List<string>();
            _lastId = 0;

            groupBox2.Controls.Clear();
            
            NpgsqlCommand cl = new NpgsqlCommand("SELECT * FROM clients;");
            var reader = Program.DB.ExecuteReader(cl);

            while (reader.Read())
            {
                string text = $" Имя: {reader[1]}\r\n " +
                    $"Номер телефона: {reader[2]}\r\n " +
                    $"Адрес электронной почты: " +
                    $"{reader[3]}\r\n " +
                    $"Адрес: {reader[4]}\r\n ";
                 
                data.Add(text);
                AddButton(reader[1].ToString());
            }
            reader.Close();
        }

      
    }
}
