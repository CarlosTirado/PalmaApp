using Data.Context;
using Data.Cultivos;
using Data.DatosBasicos.Terceros;
using Data.Lotes;
using Data.Palmas;
using Data.Tareas;
using Domain.Base;
using Domain.Cultivos;
using Domain.DatosBasicos;
using Domain.Lotes;
using Domain.Palmas;
using Domain.Tareas;

namespace Data.Base
{
    public class RepositoryAbstractFactory: IRepositoryAbstractFactory
    {
        protected PalmAppContext _context;
        private ITerceroRepository _terceroRepository;
        private ICultivoRepository _cultivoRepository;
        private ILoteRepository _loteRepository;
        private ITareaRepository _tareaRepository;
        private IPalmaRepository _palmaRepository;

        
        public RepositoryAbstractFactory(PalmAppContext context)
        {
            _context = context;
        }

        public ITerceroRepository CreateTerceroRepository()
        {
            return _terceroRepository ??= new TerceroRepository(_context);
        }

        public ICultivoRepository CreateCultivoRepository()
        {
            return _cultivoRepository ??= new CultivoRepository(_context);
        }

        public ILoteRepository CreateLoteRepository()
        {
            return _loteRepository ??= new LoteRepository(_context);
        }

        public ITareaRepository CreateTareaRepository()
        {
            return _tareaRepository ??= new TareaRepository(_context);
        }

        public IPalmaRepository CreatePalmaRepository()
        {
            return _palmaRepository ??= new PalmaRepository(_context);
        }
    }
}