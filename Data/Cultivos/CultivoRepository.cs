using Data.Base;
using Data.Context;
using Domain.Base;
using Domain.Cultivos;
using Domain.DatosBasicos.EstadosGenerales;
using System.Collections.Generic;
using System.Linq;

namespace Data.Cultivos
{
    public class CultivoRepository : ICultivoRepository
    {
        private readonly PalmAppContext _context;

        public CultivoRepository(PalmAppContext context)
        {
            _context = context;
        }

        public ICollection<Cultivo> Gets()
        {
            var Cultivos = _context.Cultivos.Where(t => t.Estado == EstadoGeneralEnumeration.Activo.Id).ToList();
            return Cultivos;
        }

        public ICollection<Cultivo> Gets(ISpecification<Cultivo> especificacion)
        {
            return SpecificationEvaluator<Cultivo>.GetQuery(_context.Cultivos.AsQueryable(), especificacion).ToList();
        }

        public Cultivo Get(ISpecification<Cultivo> especificacion)
        {
            return SpecificationEvaluator<Cultivo>.GetQuery(_context.Cultivos.AsQueryable(), especificacion).FirstOrDefault();
        }

        public void Add(Cultivo cultivo)
        {
            _context.Cultivos.Add(cultivo);
        }
    }
}
