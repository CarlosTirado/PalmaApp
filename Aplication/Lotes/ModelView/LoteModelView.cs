using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Lotes.ModelView
{
    public class LoteModelView
    {
        public long Id { get; set; }
        public long CultivoId { get; set; }
        public string Nombre { get; set; }
        public decimal NumeroHectareas { get; set; }
        public string Estado { get; set; }
    }
}
