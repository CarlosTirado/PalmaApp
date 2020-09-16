using Data.Context;
using Data.Cultivos;
using Data.DatosBasicos.Terceros;
using Domain.Base;
using Domain.Cultivos;
using Domain.DatosBasicos;
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
    }
}
