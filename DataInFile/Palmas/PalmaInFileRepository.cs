using Domain.Base;
using Domain.Palmas;
using System;
using System.Collections.Generic;
using System.IO;

namespace DataInFile.Palmas
{
    public class PalmaInFileRepository : IPalmaRepository
    {
        private readonly StreamReader _fileData;

        public PalmaInFileRepository(StreamReader fileData)
        {
            _fileData = fileData;
        }
        public ICollection<Palma> Gets(ISpecification<Palma> especificacion)
        {
            /// Logica de consultar una lista de Palmas en archivo plano
            /// ...
            /// ...
            /// ...
            ///  

            var palma1 = new Palma(altura: 4, descripcion: "Palma_Fake 1", new DateTime(2020, 01, 01));
            palma1.AsignarConsecutivo("01");

            var palma2 = new Palma(altura: 4, descripcion: "Palma_Fake 2", new DateTime(2020, 01, 01));
            palma2.AsignarConsecutivo("02");


            var palma3 = new Palma(altura: 4, descripcion: "Palma_Fake 3", new DateTime(2020, 01, 01));
            palma3.AsignarConsecutivo("03");

            return new List<Palma>()
            {
                palma1, palma2, palma3
            };
        }
        public Palma Get(ISpecification<Palma> especificacion)
        {
            /// Logica de consultar una Palma en archivo plano
            /// ...
            /// ...
            /// ...
            /// 

            return new Palma(altura: 4, descripcion: "Palma_Fake 1", new DateTime(2020, 01, 01));
        }
        public void Add(Palma Palma)
        {
            //Logica de guardar Palma en archivo plano
        }
    }
}
