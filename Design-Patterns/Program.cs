using System;
using DesignPatterns.Creational;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Info("== Creational Patterns ==");
            AbstractFactory.Run();
            FactoryMethod.Run();
            Singleton.Run();
            Builder.Run();

            Log.Info("== Structural Patterns ==");


            Log.Info("== Behavioral Patterns ==");
        }
    }
}
