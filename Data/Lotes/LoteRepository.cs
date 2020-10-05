using Data.Base;
using Data.Context;
using Domain.Base;
using Domain.Lotes;
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

        public ICollection<Lote> Gets(ISpecification<Lote> especificacion)
        {
            return SpecificationEvaluator<Lote>.GetQuery(_context.Lotes.AsQueryable(), especificacion).ToList();
        }

        public Lote Get(ISpecification<Lote> especificacion) 
        {
            return SpecificationEvaluator<Lote>.GetQuery(_context.Lotes.AsQueryable(), especificacion).FirstOrDefault();
        }
    }
}
