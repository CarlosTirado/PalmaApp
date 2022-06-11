using System;
using System.Collections.Generic;
using System.Text;

namespace TestMediator.Singleton
{
    public class TestSingleton
    {
        public void Main()
        {
            RecursosApp recursosApp = RecursosApp.GetInstance();
            RecursosApp recursosApp3 = RecursosApp.GetInstance();
            RecursosApp recursosApp4 = RecursosApp.GetInstance();
        }
    }
}
