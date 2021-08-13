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
        private readonly IRepositoryAbstractFactory _repositoryAbstractFactory;

        public PalmAppInFileUnitOfWork(
            IRepositoryAbstractFactory repositoryAbstractFactory)
        {
            _repositoryAbstractFactory = repositoryAbstractFactory;

            var currentDirectory = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var rutaArchivo = $"{currentDirectory}/DataInFile/PalmAppData.txt";
            _fileData = new StreamReader(rutaArchivo);
        }


        public ITerceroRepository TerceroRepository => _repositoryAbstractFactory.CreateTerceroRepository();
        public ICultivoRepository CultivoRepository => _repositoryAbstractFactory.CreateCultivoRepository();
        public ILoteRepository LoteRepository => _repositoryAbstractFactory.CreateLoteRepository();
        public ITareaRepository TareaRepository => _repositoryAbstractFactory.CreateTareaRepository();
        public IPalmaRepository PalmaRepository => _repositoryAbstractFactory.CreatePalmaRepository();


        public void Commit()
        {
            _fileData.Close();
        }
    }
}