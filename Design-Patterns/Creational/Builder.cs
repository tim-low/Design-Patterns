using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational
{
    /// <summary>
    /// Build a burger.
    /// </summary>
    public class Builder
    {
        public static void Run()
        {
            Log.Info("Builder Pattern");

            var menu = new BreadMenu();
            BurgerBuilder builder = new BurgerBuilder();
            menu.Builder = builder;
            menu.BuildStandardOption();
            menu.PrintIngredients();
            menu.BuildTreatYourselfOption();
            menu.PrintIngredients();
        }
    }

    public class BreadMenu
    {
        private IBreadBuilder _builder;

        public IBreadBuilder Builder
        {
            set { _builder = value; }
        }

        public void BuildStandardOption()
        {
            Console.WriteLine("Standard Option");
            _builder.BuildBread();
            _builder.BuildMeat();
            _builder.BuildSauce();
        }

        public void BuildVegetarianOption()
        {
            Console.WriteLine("Vegetarian Option");
            _builder.BuildBread();
            _builder.BuildVeggie();
            _builder.BuildSauce();
        }

        public void BuildTreatYourselfOption()
        {
            Console.WriteLine("Treat Yourself Option");
            _builder.BuildBread();
            _builder.BuildMeat();
            _builder.BuildMeat();
            _builder.BuildSauce();
            _builder.BuildCheese();
            _builder.BuildSauce();
        }

        public void PrintIngredients()
        {
            _builder.GetProduct().PrintIngredients();
        }
    }

    public interface IBreadBuilder
    {
        public void Reset();
        public IBread GetProduct();
        public void BuildBread();
        public void BuildMeat();
        public void BuildVeggie();
        public void BuildSauce();
        public void BuildCheese();
    }

    #region Concrete Builder
    public class BurgerBuilder : IBreadBuilder
    {
        private Burger _burger;

        public BurgerBuilder()
        {
            Reset();
        }

        public void Reset()
        {
            _burger = new Burger();
        }

        public IBread GetProduct()
        {
            Burger result = _burger;
            Reset();
            return result;
        }

        public void BuildBread()
        {
            _burger.Add("Bread");
        }

        public void BuildMeat()
        {
            _burger.Add("Chicken Patty");
        }

        public void BuildVeggie()
        {
            _burger.Add("Lettuce & Tomato");
        }

        public void BuildSauce()
        {
            _burger.Add("Mayonnaise");
        }

        public void BuildCheese()
        {
            _burger.Add("Cheddar Cheese");
        }
    }
    #endregion

    public interface IBread
    {
        public void Add(string ingredient);
        public void PrintIngredients();
    }

    public class Burger : IBread
    {
        private List<string> _ingredients;

        public Burger()
        {
            _ingredients = new List<string>();
        }

        public void Add(string ingredient)
        {
            _ingredients.Add(ingredient);
        }

        public void PrintIngredients()
        {
            _ingredients.ForEach(i => Console.WriteLine(i));
        }
    }
}
