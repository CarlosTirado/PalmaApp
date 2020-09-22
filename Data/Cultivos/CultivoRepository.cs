using Data.Context;
using Domain.Cultivos;
using Domain.DatosBasicos;
using Domain.DatosBasicos.EstadosGenerales;
using Domain.Lotes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public Cultivo Get(long id)
        {
            var Cultivo = _context.Cultivos
                .Include(t => t.Lotes).ThenInclude(t=> t.Palmas)
                .FirstOrDefault(t =>
                    t.Estado == EstadoGeneralEnumeration.Activo.Id &&
                    t.Id == id);
            return Cultivo;
        }

        public void Add(Cultivo cultivo)
        {
            _context.Cultivos.Add(cultivo);
        }

        public Lote GetLotePorId(long loteId)
        {
            var lote = _context.Lotes
                .FirstOrDefault(t =>
                    t.Estado == EstadoGeneralEnumeration.Activo.Id &&
                    t.Id == loteId);
            return lote;
        }

        public ICollection<Lote> GetLotes(long cultivoId)
        {
            var lotes = _context.Lotes
                .Where(t =>
                    t.Estado == EstadoGeneralEnumeration.Activo.Id &&
                    t.CultivoId == cultivoId)
                .ToList();
            return lotes;
        }
    }
}
