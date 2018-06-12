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
    public partial class Administrador : Form
    {
        List<Ventas> ven = new List<Ventas>();
        List<VentasEmpleadosporMes> vent2 = new List<VentasEmpleadosporMes>();
        List<Empleados> emple = new List<Empleados>();
        List<Mes> meusar = new List<Mes>();
        List<Inventario1> inven = new List<Inventario1>();
        List<VentaTotaldelMes> ventasmes = new List<VentaTotaldelMes>();

        public Administrador()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Producto pro = new Producto();
            pro.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Inventario mod = new Inventario();
            mod.Show();
        }

        int meelegido;
        private void button2_Click(object sender, EventArgs e)
        {
            string fileName = @"C:\Users\Darwin Rodrigo\Desktop\pro\pro\bin\Debug\Inventario.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Inventario1 invetemp = new Inventario1();
                invetemp.Producto = reader.ReadLine();
                invetemp.Cantidad = Convert.ToInt16(reader.ReadLine());
                invetemp.Precio = Convert.ToDecimal(reader.ReadLine());

                inven.Add(invetemp);
            }
            reader.Close();
            string fileName2 = @"C:\Users\Darwin Rodrigo\Desktop\pro\pro\bin\Debug\Ventas.txt";
            FileStream stream2 = new FileStream(fileName2, FileMode.Open, FileAccess.Read);
            StreamReader reader2 = new StreamReader(stream2);
            while (reader2.Peek() > -1)
            {
                Ventas vetemp = new Ventas();
                vetemp.Nitcliente = reader2.ReadLine();
                vetemp.Codigoempleado = reader2.ReadLine();
                vetemp.Producto = reader2.ReadLine();
                vetemp.Cantidad = Convert.ToInt16(reader2.ReadLine());
                vetemp.Precio = Convert.ToDecimal(reader2.ReadLine());
                vetemp.Fechaventa = Convert.ToDateTime(reader2.ReadLine());

                ven.Add(vetemp);
            }
            reader2.Close();

            string fileName4 = @"C:\Users\Darwin Rodrigo\Desktop\pro\pro\bin\Debug\Empleados.txt";
            FileStream stream4 = new FileStream(fileName4, FileMode.Open, FileAccess.Read);
            StreamReader reader4 = new StreamReader(stream4);
            while (reader4.Peek() > -1)
            {
                Empleados emtemp = new Empleados();
                emtemp.Codigo = reader4.ReadLine();
                emtemp.Nombre = reader4.ReadLine();
                emtemp.Apellido = reader4.ReadLine();
                emple.Add(emtemp);
            }
            reader4.Close();

            string fileName3 = @"C:\Users\Darwin Rodrigo\Desktop\pro\pro\bin\Debug\Mes.txt";
            FileStream stream3 = new FileStream(fileName3, FileMode.Open, FileAccess.Read);
            StreamReader reader3 = new StreamReader(stream3);
            while (reader3.Peek() > -1)
            {
                Mes mestemp = new Mes();
                mestemp.Mesano = reader3.ReadLine();
                meusar.Add(mestemp);
            }
            reader3.Close();

            for (int i = 0; i < inven.Count; i++)
            {
                VentaTotaldelMes ventmestemporal = new VentaTotaldelMes();
                ventmestemporal.Producto = inven[i].Producto;
                ventmestemporal.Cantidad = 0;
                ventmestemporal.Totalvendido = 0;
                ventasmes.Add(ventmestemporal);
            }

            for (int i = 0; i < emple.Count; i++)
            {
                VentasEmpleadosporMes empleadomes = new VentasEmpleadosporMes();
                empleadomes.Codigoempleado = emple[i].Codigo;
                empleadomes.Cantidadvendida = 0;
                empleadomes.Totalvendido = 0;
                vent2.Add(empleadomes);
            }

            for (int i = 0; i < 12; i++)
            {
                if (Convert.ToInt16(comboBox2.Text) == i)
                {
                    meelegido = i;
                    break;
                }
            }
            label3.Text = meelegido.ToString();
            //ventas totales del mes
            for (int i = 0; i < ven.Count; i++) // revisa todas las ventas hechas de cierto mes 
            {
                if (ven[i].Fechaventa.Month == meelegido)
                {
                    for (int j = 0; j < ventasmes.Count; j++)
                    {
                        if (ven[i].Producto == ventasmes[j].Producto)
                        {
                            ventasmes[j].Cantidad = ventasmes[j].Cantidad + ven[i].Cantidad;
                            ventasmes[j].Totalvendido = ventasmes[j].Cantidad + ven[i].Precio;
                        }
                    }
                }
            }

            //Ventas organizadas por empleados +vendedor
            for (int i = 0; i < ven.Count; i++) // revisa todas las ventas hechas de cierto mes 
            {
                if (ven[i].Fechaventa.Month == meelegido)
                {
                    for (int j = 0; j < vent2.Count; j++)
                    {
                        if (ven[i].Codigoempleado == vent2[j].Codigoempleado)
                        {
                            vent2[j].Cantidadvendida = vent2[j].Cantidadvendida + ven[i].Cantidad;
                            vent2[j].Totalvendido = vent2[j].Totalvendido + ven[i].Precio;
                        }
                    }
                }
            }



            dataGridView2.DataSource = null;
            dataGridView2.Refresh();
            dataGridView2.DataSource = ventasmes;
            dataGridView2.Refresh();

            dataGridView4.DataSource = null;
            dataGridView4.Refresh();
            dataGridView4.DataSource = vent2;
            dataGridView4.Refresh();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 12; i++)
            {
                comboBox1.Items.Add(i + 1);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 menu = new Form1();
            menu.Show();
            this.Hide();
        }
    }
}
