using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro
{
    class VentasEmpleadosporMes
    {
        string codigoempleado;
        int cantidadvendida;
        Decimal totalvendido;

        public string Codigoempleado { get => codigoempleado; set => codigoempleado = value; }
        public int Cantidadvendida { get => cantidadvendida; set => cantidadvendida = value; }
        public decimal Totalvendido { get => totalvendido; set => totalvendido = value; }
    }
}
