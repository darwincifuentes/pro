using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro
{
    class Ventas
    {
        string producto;
        int cantidad;
        string nitcliente;
        string codigoempleado;
        Decimal precio;
        DateTime fechaventa;

        public string Producto { get => producto; set => producto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public string Nitcliente { get => nitcliente; set => nitcliente = value; }
        public string Codigoempleado { get => codigoempleado; set => codigoempleado = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public DateTime Fechaventa { get => fechaventa; set => fechaventa = value; }
    }
}
