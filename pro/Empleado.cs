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
    public partial class Empleado : Form
    {
        List<Inventario1> invent = new List<Inventario1>();
        List<Clientes> clie = new List<Clientes>();
        List<Ventas> vent = new List<Ventas>();

        public Empleado()
        {
            InitializeComponent();
        }

        decimal sumacobrar = 0;

        private void button4_Click(object sender, EventArgs e)
        {

            string fileName3 = @"C:\Users\Darwin Rodrigo\Desktop\pro\pro\bin\Debug\Inventario.txt";
            FileStream stream3 = new FileStream(fileName3, FileMode.Open, FileAccess.Read);
            StreamReader reader3 = new StreamReader(stream3);
            while (reader3.Peek() > -1)
            {
                Inventario1 invetemp = new Inventario1();
                invetemp.Producto = reader3.ReadLine();
                invetemp.Cantidad = Convert.ToInt16(reader3.ReadLine());
                invetemp.Precio = Convert.ToDecimal(reader3.ReadLine());
                invent.Add(invetemp);
            }
            reader3.Close();

            string fileName = @"C:\Users\Darwin Rodrigo\Desktop\pro\pro\bin\Debug\Clientes.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Clientes clietemp = new Clientes();
                clietemp.Nit = reader.ReadLine();
                clietemp.Nombre = reader.ReadLine();
                clietemp.Apellido = reader.ReadLine();
                clietemp.Direccion = reader.ReadLine();
                clie.Add(clietemp);
            }
            reader.Close();

            for (int i = 0; i < clie.Count; i++)
            {
                if (textBox1.Text == clie[i].Nit)
                {
                    int pos = 0;
                    for (int j = 0; j < clie.Count; j++)
                    {
                        if (textBox1.Text == clie[j].Nit)
                        {
                            pos = j;
                        }
                    }

                    List<Clientes> cli = new List<Clientes>();
                    Clientes ct = new Clientes();

                    ct.Nit = clie[pos].Nit;
                    ct.Nombre = clie[pos].Nombre;
                    ct.Apellido = clie[pos].Apellido;
                    ct.Direccion = clie[pos].Direccion;
                    cli.Add(ct);


                    dataGridView2.DataSource = null;
                    dataGridView2.Refresh();
                    dataGridView2.DataSource = cli;
                    dataGridView2.Refresh();


                    label7.Text = "Nit encontrado";
                    break;
                }
                else
                {
                    dataGridView2.DataSource = null;
                    dataGridView2.Refresh();
                    label7.Text = "No encontrado";
                }

            }
            for (int i = 0; i < invent.Count; i++)
            {
                comboBox1.Items.Add(invent[i].Producto);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NuevoCliente clientenuevo = new NuevoCliente();
            clientenuevo.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // escribe los datos de la venta en un texto
            string fileName = @"C:\Users\Darwin Rodrigo\Desktop\pro\pro\bin\Debug\Ventas.txt";
            FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);


            for (int i = 0; i < vent.Count; i++)
            {
                writer.WriteLine(vent[i].Nitcliente);
                writer.WriteLine(vent[i].Codigoempleado);
                writer.WriteLine(vent[i].Producto);
                writer.WriteLine(vent[i].Cantidad);
                writer.WriteLine(vent[i].Precio);
                writer.WriteLine(vent[i].Fechaventa);
            }
            writer.Close();

            //escribe de nuevo el inventario con el producto vendido restado del inventario
            string fileName5 = @"C:\Users\Darwin Rodrigo\Desktop\pro\pro\bin\Debug\Inventario.txt";
            FileStream stream5 = new FileStream(fileName5, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer5 = new StreamWriter(stream5);

            for (int i = 0; i < invent.Count; i++)
            {
                writer5.WriteLine(invent[i].Producto);
                writer5.WriteLine(invent[i].Cantidad);
                writer5.WriteLine(invent[i].Precio);
            }
            writer5.Close();


            for (int i = 0; i < vent.Count; i++)
            {
                sumacobrar = sumacobrar + vent[i].Precio;
            }
            label8.Text = Convert.ToString(sumacobrar);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            decimal vuelto;
            vuelto = Convert.ToDecimal(textBox3.Text) - sumacobrar;
            label10.Text = vuelto.ToString();
            textBox4.Text = vuelto.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Ventas vetemp = new Ventas();
            vetemp.Nitcliente = textBox1.Text;
            vetemp.Fechaventa = DateTime.Now;
            vetemp.Producto = comboBox1.Text;
            vetemp.Cantidad = Convert.ToInt16(textBox2.Text);
            vetemp.Codigoempleado = textBox5.Text;
            for (int i = 0; i < invent.Count; i++)
            {
                if (invent[i].Producto == comboBox1.Text)
                {
                    invent[i].Cantidad = invent[i].Cantidad - Convert.ToInt16(textBox2.Text);
                    vetemp.Precio = invent[i].Precio * Convert.ToDecimal(textBox2.Text);
                    break;
                }
            }
            vent.Add(vetemp);

            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = vent;
            dataGridView1.Refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 menu = new Form1();
            menu.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Factura menu = new Factura();
            menu.Show();
            this.Hide();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
