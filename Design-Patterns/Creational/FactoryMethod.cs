using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational
{
    public class FactoryMethod
    {
        public static void Run()
        {
            Log.Info("Factory Method Pattern");

            TechDepartment techDepartment = new TechDepartment();
            techDepartment.HireEmployee("Dan");
            techDepartment.HireEmployee("Delia");

            BusinessDepartment businessDepartment = new BusinessDepartment();
            businessDepartment.HireEmployee("Bob");
            businessDepartment.HireEmployee("Benee");

            techDepartment.PrintEmployees();
            businessDepartment.SendEmployeesToWork();
        }
    }

    public abstract class Department
    {
        protected List<IEmployee> _employees = new List<IEmployee>();

        public void HireEmployee(string name)
        {
            IEmployee employee = CreateEmployee(name);
            _employees.Add(employee);
        }

        public void PrintEmployees()
        {
            _employees.ForEach(e => Console.WriteLine(e));
        }

        public void SendEmployeesToWork()
        {
            _employees.ForEach(e => e.DoWork());
        }

        /// <summary>
        /// This is the factory method.
        /// </summary>
        /// <param name="name">The employee's name.</param>
        public abstract IEmployee CreateEmployee(string name);
    }

    #region Concrete Factories
    public class BusinessDepartment : Department
    {
        public override IEmployee CreateEmployee(string name)
        {
            return new Businessman(name);
        }
    }

    public class TechDepartment : Department
    {
        public override IEmployee CreateEmployee(string name)
        {
            return new Developer(name);
        }
    }
    #endregion

    public interface IEmployee
    {
        public void DoWork();
    }

    #region Concrete Products
    public class Businessman : IEmployee
    {
        private string _name;

        public Businessman(string name)
        {
            _name = name;
        }

        public void DoWork()
        {
            Console.WriteLine("Sending Businessman {0} to work...", _name);
        }

        public override string ToString()
        {
            return "Businessman " + _name;
        }
    }

    public class Developer : IEmployee
    {
        private string _name;

        public Developer(string name)
        {
            _name = name;
        }

        public void DoWork()
        {
            Console.WriteLine("Sending Developer {0} to work...", _name);
        }

        public override string ToString()
        {
            return "Developer " + _name;
        }
    }
    #endregion
}
