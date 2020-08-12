using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CakeMaker
{
    public class Cake
    {
        public string CakeShape { get; set; }
        public List<string> Flavors { get; set; }
        public List<string> Decorations { get; set; }
        public TimeSpan TimeToMake { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public double Price { get; set; }
        public Cake(string shape, List<string> flavors, List<string> decorations, double price)
        {
            CakeShape = shape;
            Flavors = flavors;
            Decorations = decorations;
            TimeToMake = CalculateTimeToMake();
            Ingredients = CreateIngredientList();
            Price = price;
        }
        private TimeSpan CalculateTimeToMake()
        {
            TimeSpan ts = new TimeSpan(0, 0, 0);
            switch (CakeShape)
            {
                case "8\" Round":
                    ts = ts.Add(new TimeSpan(1, 0, 0));
                    break;
                case "10\" Round":
                    ts = ts.Add(new TimeSpan(1, 0, 0));
                    break;
                case "12\" x 12\" Square":
                    ts = ts.Add(new TimeSpan(1, 15, 0));
                    break;
                case "12\" x 24\" Rectangle":
                    ts = ts.Add(new TimeSpan(2, 0, 0));
                    break;
                default:
                    break;
            }

            if (Decorations.Any(d => d.StartsWith("Writing")))
            {
                ts = ts.Add(new TimeSpan(0, Decorations.First(d => d.StartsWith("Writing")).Split(':')[1].Length * 2, 0));
            }

            if (Decorations.Any(d => d.StartsWith("Drawing")))
                ts = ts.Add(new TimeSpan(0, 15, 0));

            if (Decorations.Any(d => d.StartsWith("Photo")))
                ts = ts.Add(new TimeSpan(0, 20, 0));

            return ts;
        }
        private List<Ingredient> CreateIngredientList()
        {
            List<Ingredient> l = new List<Ingredient>();

            switch (CakeShape)
            {
                case "8\" Round":
                    l.Add(new Ingredient("Flour", 2, "Cups"));
                    l.Add(new Ingredient("Sugar", 2, "Cups"));
                    l.Add(new Ingredient("Eggs", 2, "Each"));
                    l.Add(new Ingredient("Butter", 2, "Tablespoons"));
                    l.Add(new Ingredient("Baking Soda", 1, "Teaspoons"));
                    break;
                case "10\" Round":
                    l.Add(new Ingredient("Flour", 2.5, "Cups"));
                    l.Add(new Ingredient("Sugar", 2, "Cups"));
                    l.Add(new Ingredient("Eggs", 2, "Each"));
                    l.Add(new Ingredient("Butter", 2, "Tablespoons"));
                    l.Add(new Ingredient("Baking Soda", 1.5, "Teaspoons"));
                    break;
                case "12\" x 12\" Square":
                    l.Add(new Ingredient("Flour", 3, "Cups"));
                    l.Add(new Ingredient("Sugar", 3, "Cups"));
                    l.Add(new Ingredient("Eggs", 3, "Each"));
                    l.Add(new Ingredient("Butter", 3, "Tablespoons"));
                    l.Add(new Ingredient("Baking Soda", 2, "Teaspoons"));
                    break;
                case "12\" x 24\" Rectangle":
                    l.Add(new Ingredient("Flour", 6, "Cups"));
                    l.Add(new Ingredient("Sugar", 5, "Cups"));
                    l.Add(new Ingredient("Eggs", 6, "Each"));
                    l.Add(new Ingredient("Butter", 6, "Tablespoons"));
                    l.Add(new Ingredient("Baking Soda", 4, "Teaspoons"));
                    break;
                default:
                    break;
            }

            foreach (string flavor in Flavors)
            {
                if (flavor == "Chocolate Filling")
                {
                    if (CakeShape.StartsWith("8") || CakeShape.StartsWith("10"))
                    {
                        l.Add(new Ingredient("Chocolate Filling", 1, "Tub"));
                    }
                    else
                    {
                        l.Add(new Ingredient("Chocolate Filling", 2, "Tubs"));
                    }
                }
                if (flavor == "Vanilla Filling")
                {
                    if (CakeShape.StartsWith("8") || CakeShape.StartsWith("10"))
                    {
                        l.Add(new Ingredient("Vanilla Filling", 1, "Tub"));
                    }
                    else
                    {
                        l.Add(new Ingredient("Vanilla Filling", 2, "Tubs"));
                    }
                }
                if (flavor == "Pistachio Filling")
                {
                    if (CakeShape.StartsWith("8") || CakeShape.StartsWith("10"))
                    {
                        l.Add(new Ingredient("Chocolate Filling", 1, "Tub"));
                    }
                    else
                    {
                        l.Add(new Ingredient("Chocolate Filling", 2, "Tubs"));
                    }
                }
                if (flavor == "Chocolate Frosting")
                {
                    if (CakeShape.StartsWith("8") || CakeShape.StartsWith("10"))
                    {
                        l.Add(new Ingredient("Chocolate Frosting", 1, "Tub"));
                    }
                    else
                    {
                        l.Add(new Ingredient("Chocolate Filling", 2, "Tubs"));
                    }
                }
                if (flavor == "Caramel Frosting")
                {
                    if (CakeShape.StartsWith("8") || CakeShape.StartsWith("10"))
                    {
                        l.Add(new Ingredient("Caramel Frosting", 1, "Tub"));
                    }
                    else
                    {
                        l.Add(new Ingredient("Caramel Frosting", 2, "Tubs"));
                    }
                }
                if (flavor == "Bacon-Flavored Frosting")
                {
                    if (CakeShape.StartsWith("8") || CakeShape.StartsWith("10"))
                    {
                        l.Add(new Ingredient("Bacon-Flavored Frosting", 1, "Tub"));
                    }
                    else
                    {
                        l.Add(new Ingredient("Bacon-Flavored Frosting", 2, "Tubs"));
                    }
                }
            }

            if (Decorations.Any(d => d.StartsWith("Writing")) ||
                Decorations.Any(d => d.StartsWith("Drawing")))
                l.Add(new Ingredient("Edible Gel",
                                     1,
                                     "Pouch"));

            if (Decorations.Any(d => d.StartsWith("Candles")))
                l.Add(new Ingredient("Candles",
                                     double.Parse(Decorations.First(d => d.StartsWith("Candles")).Split(':')[1]),
                                     "Each"));

            return l;
        }
        public void CreateReport()
        {
            ReportWindow rw = new ReportWindow(this);
            rw.Show();
        }
    }
}
