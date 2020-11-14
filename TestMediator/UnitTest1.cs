using System;
using NUnit.Framework;

namespace TestMediator
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            // Crear el objeto centralizador de la comunicación
            Mediator m = new Mediator();
            
            // Crear los objetos que participarán en la comunicación
            Colega cc1 = new ColegaConcreto1(m);
            Colega cc2 = new ColegaConcreto2(m);
            Colega cc3 = new ColegaConcreto3(m);
            
            // Provocar un cambio en un uno de los elementos
            cc1.comunicar("ColegaConcreto1 ha cambiado!");
            
            Console.WriteLine("\n");
            
            // Provocar un cambio en un uno de los elementos
            cc2.comunicar("ColegaConcreto2 ha cambiado!");
            
            Console.WriteLine("\n");
            
            // Provocar un cambio en un uno de los elementos
            cc3.comunicar("ColegaConcreto3 ha cambiado!");
        }
    }
}