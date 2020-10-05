using DataInfile.Cultivos;
using DataInFile.DatosBasicos.Terceros;
using DataInFile.Lotes;
using DataInFile.Palmas;
using DataInFile.Tareas;
using Domain.Base;
using Domain.Cultivos;
using Domain.DatosBasicos;
using Domain.Lotes;
using Domain.Palmas;
using Domain.Tareas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace DataInFile.Base
{
    public class PalmAppInFileUnitOfWork : IPalmAppUnitOfWork
    {
        private readonly StreamReader _fileData;

        public PalmAppInFileUnitOfWork()
        {
            var currentDirectory = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var rutaArchivo = $"{currentDirectory}/DataInFile/PalmAppData.txt";
            _fileData = new StreamReader(rutaArchivo);
        }


        private ITerceroRepository _terceroRepository;
        public ITerceroRepository TerceroRepository { get { return _terceroRepository ?? (_terceroRepository = new TerceroInFileRepository(_fileData)); } }

        private ICultivoRepository _cultivoRepository;
        public ICultivoRepository CultivoRepository { get { return _cultivoRepository ?? (_cultivoRepository = new CultivoInFileRepository(_fileData)); } }

        private ILoteRepository _loteRepository;
        public ILoteRepository LoteRepository { get { return _loteRepository ?? (_loteRepository = new LoteInFileRepository(_fileData)); } }

        private ITareaRepository _tareaRepository;
        public ITareaRepository TareaRepository { get { return _tareaRepository ?? (_tareaRepository = new TareaInFileRepository(_fileData)); } }

        private IPalmaRepository _palmaRepository;
        public IPalmaRepository PalmaRepository { get { return _palmaRepository ?? (_palmaRepository = new PalmaInFileRepository(_fileData)); } }


        public void Commit()
        {
            _fileData.Close();
        }
    }
}
