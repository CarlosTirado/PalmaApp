using System;
using System.Collections.Generic;
using System.Text;

namespace TestMediator.Factura
{
    public class Factura
    {
        public int Id { get; set; }
        public int TipoFacturaId { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public decimal ValorTotal { get; set; }
        public List<DetalleFactura> DetallesDeFactura { get; set; }
    }

    public class DetalleFactura
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
    }
}