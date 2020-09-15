using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational
{
    public class Utilities
    {
        public static readonly Random rnd = new Random();

        public static T GetRandomEnum<T>()
        {
            var enumValues = Enum.GetValues(typeof(T));
            return (T)enumValues.GetValue(rnd.Next(enumValues.Length));
        }
    }
}