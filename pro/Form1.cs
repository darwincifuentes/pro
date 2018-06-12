using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                if (textBox1.Text == "555")
                {
                    Administrador adm = new Administrador();
                    adm.Show();
                }
            }
            else if (radioButton2.Checked == true)
            {
                if (textBox1.Text == "111")
                {
                    Empleado empl = new Empleado();
                    empl.Show();
                }
            }
        }
    }
}
