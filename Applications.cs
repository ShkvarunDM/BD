using Npgsql;
using NpgsqlTypes;
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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static WindowsFormsApp2.Program;

namespace WindowsFormsApp2
{
    public partial class Applications : Form
    {
       
        public Applications()
        {
            InitializeComponent();
        }

        private void Applications_Load(object sender, EventArgs e)
        {
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            NpgsqlCommand add2 = new NpgsqlCommand("INSERT INTO application (id_appl,problems, date_created,priority, id_worker,status) values (@id_a, @problems, @datec,@priority,@idw,@sts);");

            add2.Parameters.Add("id_a", NpgsqlDbType.Integer).Value = Convert.ToInt32(id_applBox.Text);
            add2.Parameters.Add("problems", NpgsqlDbType.Char).Value = problemBox.Text;
            add2.Parameters.Add("datec", NpgsqlDbType.Date).Value = DateTime.Now.Date;
            add2.Parameters.Add("priority", NpgsqlDbType.Char).Value = priorityBox.Text;
            add2.Parameters.Add("idw", NpgsqlDbType.Integer).Value = Convert.ToInt32(idWBox.Text);
            add2.Parameters.Add("sts", NpgsqlDbType.Char).Value = "В обработке";

            Program.DB.ExecuteNonQuery(add2);

            NpgsqlCommand add1 = new NpgsqlCommand("INSERT INTO clients (cName, cphone, email, adress, id_appl) values (@name,@phone,@email,@adress,@id_appl);");
           
            add1.Parameters.Add("name", NpgsqlDbType.Char).Value = NameBox.Text;
            add1.Parameters.Add("phone", NpgsqlDbType.Char).Value = numberBox.Text;
            add1.Parameters.Add("email", NpgsqlDbType.Char).Value = emailBox.Text;
            add1.Parameters.Add("adress", NpgsqlDbType.Char).Value = adressBox.Text;
            add1.Parameters.Add("id_appl", NpgsqlDbType.Integer).Value = Convert.ToInt32(id_applBox.Text);

            Program.DB.ExecuteNonQuery(add1);

            

            Clear();
        }

        public void Clear()
        {
            NameBox.Text = "";
            numberBox.Text = "";
            emailBox.Text = "";
            adressBox.Text = "";
            problemBox.Text = "";
            priorityBox.Text = "";
            idWBox.Text = "";
            id_applBox.Text = "";
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            e.Cancel = true;
            Program.fc.Show(1);
        }

        /*public void Applications_FormClosing(object sender, FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            e.Cancel = true;
            //Program.fc.Show(1);
        }*/
    }
}
