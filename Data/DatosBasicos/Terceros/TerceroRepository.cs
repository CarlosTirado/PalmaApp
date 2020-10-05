using Data.Base;
using Data.Context;
using Domain.Base;
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
            return _context.Terceros.ToList();
        }

        public ICollection<Tercero> Gets(ISpecification<Tercero> especificacion)
        {
            return SpecificationEvaluator<Tercero>.GetQuery(_context.Terceros.AsQueryable(), especificacion).ToList();
        }

        public Tercero Get(ISpecification<Tercero> especificacion)
        {
            return SpecificationEvaluator<Tercero>.GetQuery(_context.Terceros.AsQueryable(), especificacion).FirstOrDefault();
        }
    }
}
