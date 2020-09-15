using System;

namespace DesignPatterns.Creational
{
    /// <summary>
    /// Abstract factory 'IFoodShopFactory' and abstract products 'IFood' and 'IDrink' are created with concrete implementations.
    /// </summary>
    public class AbstractFactory
    {
        public static void Run()
        {
            Log.Info("Abstract Factory Pattern");
            var rnd = new Random();
            FoodShopType option = Utilities.GetRandomEnum<FoodShopType>();

            IFoodShopFactory factory;
            switch (option)
            {
                case FoodShopType.CoffeeShop:
                    factory = new CoffeeShopFactory();
                    break;
                case FoodShopType.BubbleTeaShop:
                    factory = new BubbleTeaFactory();
                    break;
                default:
                    Log.Error("Invalid option.");
                    return;
            }

            IDrink drink;
            if (factory.CreateDrink(out drink))
                drink.Print();

            IFood food;
            if (factory.CreateFood(out food))
                food.Print();
        }
    }

    public enum FoodShopType
    {
        CoffeeShop,
        BubbleTeaShop
    }

    public interface IFoodShopFactory
    {
        public bool CreateDrink(out IDrink drink);
        public bool CreateFood(out IFood food);
    }

    #region Concrete Factories
    public class CoffeeShopFactory : IFoodShopFactory
    {
        public bool CreateDrink(out IDrink drink)
        {
            drink = new Coffee();
            return drink != null;
        }

        // What if a coffee shop has more than 1 type of food?
        // Or what if there are changes to the type of food offered?
        public bool CreateFood(out IFood food)
        {
            food = new Cake();
            return food != null;
        }
    }

    public class BubbleTeaFactory : IFoodShopFactory
    {
        public bool CreateDrink(out IDrink drink)
        {
            drink = new BubbleTea();
            return drink != null;
        }

        // What if a coffee shop has more than 1 type of food?
        // Or what if there are changes to the type of food offered?
        public bool CreateFood(out IFood food)
        {
            food = new Snack();
            return food != null;
        }
    }
    #endregion

    public interface IDrink
    {
        public void Print();
    }

    public interface IFood
    {
        public void Print();
    }

    #region Concrete Products
    public class Coffee : IDrink
    {
        public void Print() => Console.WriteLine("Coffee");
    }

    public class Cake : IFood
    {
        public void Print() => Console.WriteLine("Cake");
    }

    public class BubbleTea : IDrink
    {
        public void Print() => Console.WriteLine("Bubble Tea");
    }

    public class Snack : IFood
    {
        public void Print() => Console.WriteLine("Snack");
    }
    #endregion
}
