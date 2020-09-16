using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Cultivos.ModelView
{
    public class CultivoModelView
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaSiembra { get; set; }
        public string Estado { get; set; }
    }
}
