using Domain.DatosBasicos;
using System;
using System.Collections.Generic;
using System.IO;

namespace DataInFile.DatosBasicos.Terceros
{
    public class TerceroInFileRepository : ITerceroRepository
    {
        private readonly StreamReader _fileData;

        public TerceroInFileRepository(StreamReader fileData)
        {
            _fileData = fileData;
        }

        public ICollection<Tercero> Gets() 
        {
            /// Logica de consultar una lista de Terceros en archivo plano
            /// ...
            /// ...
            /// ...
            ///  

            return new List<Tercero>()
            {
                new Tercero(
                identificacion: "1111111",
                nombres: "Carlos InFile",
                apellidos: "Tirado InFile",
                telefono: "3504628322",
                direccion: "Calle 44 23 22",
                email: "orley333@gmail.com",
                fechaNacimiento: new DateTime(1990,01,01))
            };
        }

        public Tercero Get(string identificacion)
        {
            /// Logica de consultar un tercero por correo en archivo plano
            /// ...
            /// ...
            /// ...
            /// 

            return new Tercero(
                identificacion: "1111111",
                nombres: "Carlos InFile",
                apellidos: "Tirado InFile",
                telefono: "3504628322",
                direccion: "Calle 44 23 22",
                email: "orley333@gmail.com",
                fechaNacimiento: new DateTime(1990,01,01));
        }

        public Tercero GetPorCorreo(string correo)
        {
            /// Logica de consultar un tercero por correo en archivo plano
            /// ...
            /// ...
            /// ...
            /// 

            return new Tercero(
                identificacion: "1111111",
                nombres: "Carlos InFile",
                apellidos: "Tirado InFile",
                telefono: "3504628322",
                direccion: "Calle 44 23 22",
                email: "orley333@gmail.com",
                fechaNacimiento: new DateTime(1990, 01, 01));
        }
    }
}
