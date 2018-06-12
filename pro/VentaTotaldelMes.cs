using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro
{
    class VentaTotaldelMes
    {
        string producto;
        int cantidad;
        Decimal totalvendido;

        public string Producto { get => producto; set => producto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public decimal Totalvendido { get => totalvendido; set => totalvendido = value; }
    }
}
