using Data.Context;
using Domain.Lotes;
using Domain.DatosBasicos;
using Domain.DatosBasicos.EstadosGenerales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Lotes
{
    public class LoteRepository : ILoteRepository
    {
        private readonly PalmAppContext _context;

        public LoteRepository(PalmAppContext context)
        {
            _context = context;
        }

        public ICollection<Lote> Gets()
        {
            var Lotes = _context.Lotes.Where(t => t.Estado == EstadoGeneralEnumeration.Activo.Id).ToList();
            return Lotes;
        }

        public Lote Get(long id)
        {
            var Lote = _context.Lotes.FirstOrDefault(t => 
                t.Estado == EstadoGeneralEnumeration.Activo.Id &&
                t.Id == id);
            return Lote;
        }

        public void Add(Lote lote)
        {
            _context.Lotes.Add(lote);
        }
    }
}
