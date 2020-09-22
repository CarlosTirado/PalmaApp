using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Lotes.ModelView
{
    public class TareaModelView
    { 
        public long Id { get; set; }
        public long CultivoId { get; set; }
        public string Nombre { get; set; }
        public int NumeroHectareas { get; set; }
        public string Estado { get; set; }

    }
}
