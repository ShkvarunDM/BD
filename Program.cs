using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    internal static class Program
    {
        public static Controller fc = new Controller();
        public static Connect DB = new Connect();

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form log_form = new Form1();
            Form base_form = new Base_Form();
            Form customers_form = new Сustomers();
            Form appl_form = new Applications();
            Form appl_info_form = new appl_info();
            Form compl_work = new coml_work();
            Form  tech_special = new tech_special();

            fc.forms.Add(log_form);  //0
            fc.forms.Add(base_form);   //1
            fc.forms.Add(customers_form);  //2
            fc.forms.Add(appl_form);          //3
            fc.forms.Add(appl_info_form);      //4
            fc.forms.Add(compl_work);   //5
            fc.forms.Add(tech_special);   //6


            Application.Run(base_form);

        }
            public class AssociateButton : Button
            {
            public AssociateButton() : base() { AutoSize = false; }
            public int Recid;
            }


    

        
    }
}
