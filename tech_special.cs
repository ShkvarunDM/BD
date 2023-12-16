using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp2.Program;

namespace WindowsFormsApp2
{
    public partial class tech_special : Form
    {
        private int _lastId;
        private List<string> data;
        public tech_special()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlCommand add3 = new NpgsqlCommand("INSERT INTO tech_special (id_tech, tName, tphone,skills ,salary) values (@idt,@tn,@tp,@sk,@sal);");

            add3.Parameters.Add("idt", NpgsqlDbType.Integer).Value = Convert.ToInt32(id_techBox.Text);
            add3.Parameters.Add("tn", NpgsqlDbType.Char).Value = NameBox.Text;
            add3.Parameters.Add("tp", NpgsqlDbType.Char).Value = NumberBox.Text;
            add3.Parameters.Add("sk", NpgsqlDbType.Char).Value = SkillBox.Text;
            add3.Parameters.Add("sal", NpgsqlDbType.Integer).Value = Convert.ToInt32(salaryBox.Text);

            Program.DB.ExecuteNonQuery(add3);
            Clear();
        }
        public void Clear()
        {
            NameBox.Text = "";
            NumberBox.Text = "";
            id_techBox.Text = "";
            SkillBox.Text = "";
            salaryBox.Text = "";
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

        private void btnClick(object sender, EventArgs e)
        {
            foreach (object btn in groupBox2.Controls)
            {
                ((AssociateButton)btn).Enabled = true;
            }
            ((AssociateButton)sender).Enabled = false;
            PutData(((AssociateButton)sender).Recid);
        }

        private void PutData(int id)
        {
            textBox1.Text = data[id];
        }

        public void UpdateData()
        {
            data = new List<string>();
            _lastId = 0;

            groupBox2.Controls.Clear();

            NpgsqlCommand tech = new NpgsqlCommand("SELECT * FROM tech_special;");
            var reader = Program.DB.ExecuteReader(tech);

            while (reader.Read())
            {
                string id3 = reader[1].ToString();
                string text = $" Номер технического специалиста: {reader[0]}\r\n " +
                    $"Имя: {reader[1]}\r\n " +
                    $"Номер телефона: " +
                    $"{reader[2]}\r\n " +
                    $"Навыки: {reader[3]}\r\n " +
                    $"Заработная плата: {reader[4]}\r\n";

                data.Add(text);
                AddButton(id3);
            }
            reader.Close();
        }

        private void tech_special_Load(object sender, EventArgs e)
        {
            UpdateData();
        }
    }



}
