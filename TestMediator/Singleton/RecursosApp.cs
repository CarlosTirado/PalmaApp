using System;
using System.Collections.Generic;
using System.Text;

namespace TestMediator.Singleton
{
    public class RecursosApp
    {
        public string LogoEntidad { get; private set; }
        public string NombreEntidad { get; private set; }

        private static RecursosApp instance;

        private RecursosApp()
        {
            ConsultarRecursosApp();
        }

        public static RecursosApp GetInstance()
        {
            if(instance == null)
            {
                instance = new RecursosApp();
            }

            return instance;
        }


        private void ConsultarRecursosApp()
        {
            //Consulta a BD
            LogoEntidad = "Base64 con logo de la entidad";
            NombreEntidad = "Nombre de la entidad";
        }
    }
}
