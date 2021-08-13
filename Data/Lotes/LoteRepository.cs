using Data.Base;
using Data.Context;
using Domain.Base;
using Domain.Lotes;
using Microsoft.EntityFrameworkCore;
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

        public ICollection<Lote> Gets()
        {
            return _context.Lotes.ToList();
        }

        public Lote Get(ISpecification<Lote> especificacion) 
        {
            return SpecificationEvaluator<Lote>.GetQuery(_context.Lotes.AsQueryable(), especificacion).FirstOrDefault();
        }

        public Lote Get(int id)
        {
            var lote = _context.Lotes
                .Include(t => t.Palmas)
                .FirstOrDefault(t => t.Id == id);

            return lote;
        }
    }
}
