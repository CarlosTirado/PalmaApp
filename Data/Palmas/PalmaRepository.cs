using Data.Context;
using Domain.Palmas;
using Domain.DatosBasicos;
using Domain.DatosBasicos.EstadosGenerales;
using Domain.Lotes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Palmas
{
    public class PalmaRepository : IPalmaRepository
    {
        private readonly PalmAppContext _context;

        public PalmaRepository(PalmAppContext context)
        {
            _context = context;
        }

        public ICollection<Palma> Gets(long loteId)
        {
            var Palmas = _context.Palmas.Where(t => 
                t.Estado == EstadoGeneralEnumeration.Activo.Id &&
                t.LoteId == loteId
                ).ToList();
            return Palmas;
        }

        public Palma Get(long id)
        {
            var Palma = _context.Palmas
                .FirstOrDefault(t =>
                    t.Estado == EstadoGeneralEnumeration.Activo.Id &&
                    t.Id == id);
            return Palma;
        }

        public void Add(Palma Palma)
        {
            _context.Palmas.Add(Palma);
        }
    }
}
