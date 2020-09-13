using Data.Context;
using Domain.DatosBasicos;
using Domain.DatosBasicos.EstadosGenerales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.DatosBasicos.Terceros
{
    public class TerceroRepository : ITerceroRepository
    {
        private readonly PalmAppContext _context;

        public TerceroRepository(PalmAppContext context)
        {
            _context = context;
        }

        public ICollection<Tercero> Gets()
        {
            var terceros = _context.Terceros.Where(t => t.Estado == EstadoGeneralEnumeration.Activo.Id).ToList();
            return terceros;
        }
    }
}
