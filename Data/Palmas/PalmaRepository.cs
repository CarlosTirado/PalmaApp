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
using Domain.Base;
using Data.Base;

namespace Data.Palmas
{
    public class PalmaRepository : IPalmaRepository
    {
        private readonly PalmAppContext _context;

        public PalmaRepository(PalmAppContext context)
        {
            _context = context;
        }

        public ICollection<Palma> Gets(ISpecification<Palma> especificacion)
        {
            return SpecificationEvaluator<Palma>.GetQuery(_context.Palmas.AsQueryable(), especificacion).ToList();
        }

        public Palma Get(ISpecification<Palma> especificacion)
        {
            return SpecificationEvaluator<Palma>.GetQuery(_context.Palmas.AsQueryable(), especificacion).FirstOrDefault();
        }

        public void Add(Palma Palma)
        {
            _context.Palmas.Add(Palma);
        }
    }
}
