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
    public partial class Inventario : Form
    {
        public Inventario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Inventario1> invent = new List<Inventario1>();


            string fileName = @"C:\Users\Darwin Rodrigo\Desktop\pro\pro\bin\Debug\Inventario.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Inventario1 invetemp = new Inventario1();
                invetemp.Producto = reader.ReadLine();
                invetemp.Cantidad = Convert.ToInt16(reader.ReadLine());
                invetemp.Precio = Convert.ToDecimal(reader.ReadLine());
                invent.Add(invetemp);
            }
            reader.Close();

            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = invent;
            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Inventario1> invent = new List<Inventario1>();


            string fileName2 = @"C:\Users\Darwin Rodrigo\Desktop\pro\pro\bin\Debug\Inventario.txt";
            FileStream stream2 = new FileStream(fileName2, FileMode.Open, FileAccess.Read);
            StreamReader reader2 = new StreamReader(stream2);
            while (reader2.Peek() > -1)
            {
                Inventario1 invetemp = new Inventario1();
                invetemp.Producto = reader2.ReadLine();
                invetemp.Cantidad = Convert.ToInt16(reader2.ReadLine());
                invetemp.Precio = Convert.ToDecimal(reader2.ReadLine());
                invent.Add(invetemp);
            }
            reader2.Close();


            string fileName = @"C:\Users\Darwin Rodrigo\Desktop\pro\pro\bin\Debug\Inventario.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Inventario1 invetemp = new Inventario1();
                invetemp.Producto = reader.ReadLine();
                invetemp.Cantidad = Convert.ToInt16(reader.ReadLine());
                invetemp.Precio = Convert.ToDecimal(reader.ReadLine());
                invent.Add(invetemp);
            }
            reader.Close();


            for (int i = 0; i < invent.Count; i++)
            {
                if (textBox1.Text == invent[i].Producto)
                {
                    textBox2.Text = invent[i].Cantidad.ToString();
                    textBox3.Text = invent[i].Precio.ToString();
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Inventario1> invent = new List<Inventario1>();


            string fileName2 = @"C:\Users\Darwin Rodrigo\Desktop\pro\pro\bin\Debug\Inventario.txt";
            FileStream stream2 = new FileStream(fileName2, FileMode.Open, FileAccess.Read);
            StreamReader reader2 = new StreamReader(stream2);
            while (reader2.Peek() > -1)
            {
                Inventario1 invetemp = new Inventario1();
                invetemp.Producto = reader2.ReadLine();
                invetemp.Cantidad = Convert.ToInt16(reader2.ReadLine());
                invetemp.Precio = Convert.ToDecimal(reader2.ReadLine());
                invent.Add(invetemp);
            }
            reader2.Close();
            string fileName = @"C:\Users\Darwin Rodrigo\Desktop\pro\pro\bin\Debug\Inventario.txt";
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            for (int i = 0; i < invent.Count; i++)
            {
                if (invent[i].Producto == textBox1.Text)
                {
                    invent[i].Producto = textBox1.Text;
                    invent[i].Cantidad = Convert.ToInt16(textBox2.Text);
                    invent[i].Precio = Convert.ToDecimal(textBox3.Text);
                }
            }

            for (int i = 0; i < invent.Count; i++)
            {
                writer.WriteLine(invent[i].Producto);
                writer.WriteLine(invent[i].Cantidad);
                writer.WriteLine(invent[i].Precio);
            }
            writer.Close();
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Administrador menu = new Administrador();
            menu.Show();
            this.Hide();
        }
    }
}
