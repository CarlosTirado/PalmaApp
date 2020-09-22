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
        protected PalmAppContext _context;

        public PalmAppUnitOfWork(PalmAppContext context)
        {
            _context = context;
        }

        public DateTime DateNow => DateTime.Now;

        public int Commit()
        {
            int numeroFilas = _context.SaveChanges();
            return numeroFilas;
        }


        private ITerceroRepository _terceroRepository;
        public ITerceroRepository TerceroRepository { get { return _terceroRepository ?? (_terceroRepository = new TerceroRepository(_context)); } }

        private ICultivoRepository _cultivoRepository;
        public ICultivoRepository CultivoRepository { get { return _cultivoRepository ?? (_cultivoRepository = new CultivoRepository(_context)); } }

        private ITareaRepository _tareaRepository;
        public ITareaRepository TareaRepository { get { return _tareaRepository ?? (_tareaRepository = new TareaRepository(_context)); } }

        private IPalmaRepository _palmaRepository;
        public IPalmaRepository PalmaRepository { get { return _palmaRepository ?? (_palmaRepository = new PalmaRepository(_context)); } }
    }
}
