using System;

namespace DesignPatterns.Creational
{
    /// <summary>
    /// Classes 'Me' and 'You' are implemented as singletons.
    /// While the program is running, there can only be one instance of each class.
    /// </summary>
    public class Singleton
    {
        public static void Run()
        {
            Log.Info("Singleton Pattern");
            Me.Instance.Print();
            You.GetInstance().Print();
        }
    }

    public class Me
    {
        public static readonly Me Instance = new Me();

        private Me() { }

        public void Print() => Console.WriteLine("There's can only be one of me!");
    } 

    public class You
    {
        private static You _instance;

        private You() { }

        public static You GetInstance()
        {
            if (_instance == null)
                _instance = new You();
            return _instance;
        }

        public void Print() => Console.WriteLine("There's can only be one of you!");
    }
}