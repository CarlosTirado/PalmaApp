using Domain.Base;
using Domain.Cultivos;
using Domain.Lotes;
using System;
using System.Collections.Generic;
using System.IO;

namespace DataInfile.Cultivos
{
    public class CultivoInFileRepository : ICultivoRepository
    {
        private readonly StreamReader _fileData;

        public CultivoInFileRepository(StreamReader fileData)
        {
            _fileData = fileData;
        }


        public void Add(Cultivo cultivo)
        {
            // Logica de guardar un cultivo en archivo plano
        }


        public ICollection<Cultivo> Gets(ISpecification<Cultivo> especificacion)
        {
            /// Logica de consultar una lista de Cultivo en archivo plano
            /// ...
            /// ...
            /// ...
            /// 

            return new List<Cultivo>()
            {
                new Cultivo("Cultivo_Fake 1",DateTime.Now),
                new Cultivo("Cultivo_Fake 2",DateTime.Now),
                new Cultivo("Cultivo_Fake 3",DateTime.Now)
            };
        }

        public Cultivo Get(ISpecification<Cultivo> especificacion)
        {
            /// Logica de consultar un Cultivo en archivo plano
            /// ...
            /// ...
            /// ...
            /// 

            return new Cultivo("Cultivo_Fake 1", DateTime.Now);
        }

        public ICollection<Cultivo> Gets()
        {
            /// Logica de consultar una lista de Cultivo en archivo plano
            /// ...
            /// ...
            /// ...
            /// 

            return new List<Cultivo>()
            {
                new Cultivo("Cultivo_Fake 1",DateTime.Now),
                new Cultivo("Cultivo_Fake 2",DateTime.Now),
                new Cultivo("Cultivo_Fake 3",DateTime.Now)
            };
        }
    }
}
