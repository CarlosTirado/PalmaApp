using System;
using System.Security.Cryptography;
using NETCore.Encrypt;
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

        [Test]
        public void Test2()
        {
            var a = 3;
            var b = 4;
            var c = a + b;
            Assert.AreEqual(7, c);
        }


        [Test]
        public void TestRSA()
        {
            var rsaKey = EncryptProvider.CreateRsaKey();

            var publicKey = rsaKey.PublicKey;
            var privateKey = rsaKey.PrivateKey;

            var plaintext = "CARLOS ORLEY TIRADO PABON";

            var encrypted = EncryptProvider.RSAEncrypt(publicKey, plaintext, RSAEncryptionPadding.Pkcs1);

            var decrypted = EncryptProvider.RSADecrypt(privateKey, encrypted, RSAEncryptionPadding.Pkcs1);

            Assert.AreEqual(plaintext, decrypted);
        }
    }
}