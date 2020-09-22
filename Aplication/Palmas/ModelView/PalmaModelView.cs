using Aplication.Lotes.ModelView;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Palmas.ModelView
{
    public class PalmaModelView
    {
        public long Id { get;  set; }
        public string Consecutivo { get;  set; }
        public int Altura { get;  set; }
        public string Descripcion { get;  set; }
        public DateTime FechaSiembra { get;  set; }
        public string Estado { get; set; }
        public long LoteId { get;  set; }
    }
}
