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
using System;

namespace Data.Base
{
    public class PalmAppUnitOfWork : IPalmAppUnitOfWork
    {
        private readonly PalmAppContext _context;
        private readonly IRepositoryAbstractFactory _repositoryAbstractFactory;

        public PalmAppUnitOfWork(
            PalmAppContext context, 
            IRepositoryAbstractFactory repositoryAbstractFactory)
        {
            _context = context;
            _repositoryAbstractFactory = repositoryAbstractFactory;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public ITerceroRepository TerceroRepository => _repositoryAbstractFactory.CreateTerceroRepository();
        public ICultivoRepository CultivoRepository => _repositoryAbstractFactory.CreateCultivoRepository();
        public ILoteRepository LoteRepository => _repositoryAbstractFactory.CreateLoteRepository();
        public ITareaRepository TareaRepository => _repositoryAbstractFactory.CreateTareaRepository();
        public IPalmaRepository PalmaRepository => _repositoryAbstractFactory.CreatePalmaRepository();
    }
}
