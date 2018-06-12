using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace pro
{
    public partial class Factura : Form
    {
        List<Inventario1> invent = new List<Inventario1>();
        List<Clientes> clie = new List<Clientes>();
        List<Ventas> vent = new List<Ventas>();
        List<Empleado> mos = new List<Empleado>();

        public Factura()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fileName3 = @"C:\Users\Darwin Rodrigo\Desktop\pro\pro\bin\Debug\Ventas.txt";
            FileStream stream3 = new FileStream(fileName3, FileMode.Open, FileAccess.Read);
            StreamReader reader3 = new StreamReader(stream3);
            while (reader3.Peek() > -1)
            {
                Ventas vetemp = new Ventas();
                vetemp.Nitcliente = reader3.ReadLine();
                vetemp.Codigoempleado = reader3.ReadLine();
                vetemp.Producto = reader3.ReadLine();
                vetemp.Cantidad = Convert.ToInt16(reader3.ReadLine());
                vetemp.Precio = Convert.ToDecimal(reader3.ReadLine());
                vetemp.Fechaventa = Convert.ToDateTime(reader3.ReadLine());
                vent.Add(vetemp);
            }
            reader3.Close();
           

            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = vent;
            dataGridView1.Refresh();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("imprimiendo...");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 menu = new Form1();
            menu.Show();
            this.Hide();
        }
    }
}
