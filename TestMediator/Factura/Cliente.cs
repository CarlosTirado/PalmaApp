using System;
using System.Collections.Generic;
using System.Text;

namespace TestMediator.Factura
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }

    public class ClienteAgenteRetenedor: Cliente
    {
        public decimal PorcentajeDeRetencion { get; set; }
    }

    public class ClienteResponsableDeIva : Cliente
    {
    }
}
