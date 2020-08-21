using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe_book
{
    public class RecipeService
    {
        public List<Recipe> Recipes { get; set; }


        public RecipeService()
        {
            Recipes = new List<Recipe>();
        }

        public ConsoleKeyInfo ListOfRecipesView(MenuActionService menuActionService) // wyświetlenie menu
        {
            var categoryMenu = menuActionService.GetMenuActionsByMenuName("CategoryMenu");
            Console.WriteLine("\r\n\r\nPlease select:");
            foreach (var menuAction in categoryMenu)
            {
                Console.WriteLine($"{menuAction.Id}. {menuAction.ActionName}");
            }
            Console.Write("Enter the number: ");
            var option = Console.ReadKey();
            return option;
        }

        public void ListOfRecipes(char productCategory)
        {
            int productCategoryId;
            Int32.TryParse(productCategory.ToString(), out productCategoryId);
            Console.WriteLine();
            Console.WriteLine("\r\nList Recipes");
            foreach (var item in Recipes)
            {
                if ((int)item.Category == productCategoryId)
                {
                    Console.WriteLine(item.Id + " " + item.Name);
                }
            }
        }

         public string FindReceipeView()
        {
            Console.WriteLine("\r\nFind Receipe");
            Console.Write("Enter the Receipe Name: ");
            string nameInput = Console.ReadLine().ToLower();
            return nameInput;
        }

        public void FindReceipe(string nameInput)
        {
            foreach (var item in Recipes)
            {
                if (item.Name.ToLower().Contains(nameInput))
                {
                    Console.WriteLine(item.Id + " " + item.Name);
                }
            }
        }

        public int DisplayReceipeView()
        {
            Console.WriteLine("\r\nDisplay Receipe");
            Console.Write("Enter the Receipe Id: ");
            string idInput = Console.ReadLine();
            int productId;
            Int32.TryParse(idInput, out productId);
            return productId;
        }

        public void DisplayReceipe(int productId)
        {

            Recipe displayRecipe = new Recipe();
            foreach (var item in Recipes)
            {
                if (item.Id == productId)
                {
                    displayRecipe = item;
                }
            }
            if (displayRecipe.Name != null)
            {
                Console.WriteLine(displayRecipe.Id + " " + displayRecipe.Name);
                foreach (var item in displayRecipe.Ingridients)
                {
                    Console.Write(item.Component + " " + item.Unit + " " + item.Quantity + "\n");

                }
                Console.WriteLine(displayRecipe.Description);
            }
            else
            {
                Console.WriteLine($"Recipe w with Id: {productId} not found");
            }

        }

        public void CreateDatabase()
        {
            List<Ingridient> ingrid = new List<Ingridient>();
            ingrid.Add(new Ingridient() { Component = "Buraki", Unit = Units.g, Quantity = 800.0f });
            ingrid.Add(new Ingridient() { Component = "Wywar z warzyw", Unit = Units.l, Quantity = 2.0f });
            ingrid.Add(new Ingridient() { Component = "Kwas z kapusty", Unit = Units.l, Quantity = 0.25f });
            Recipes.Add(new Recipe()
            {
                Id = 1,
                Category = Categories.Soup,
                Name = "Barszcz na kwasie z kapusty",
                Ingridients = ingrid,
                Description = "Umyte i obrane buraki pokroić w plasterki, zalać wywarem oraz kwasem z kapusty. Dodać sól i cukier do smaku. Gotować 30 min."
            }); ;

            ingrid = new List<Ingridient>();
            ingrid.Add(new Ingridient() { Component = "Kwaśne mleko", Unit = Units.l, Quantity = 0.5f });
            ingrid.Add(new Ingridient() { Component = "Woda", Unit = Units.l, Quantity = 0.25f });
            ingrid.Add(new Ingridient() { Component = "Mąka", Unit = Units.g, Quantity = 200.0f });
            ingrid.Add(new Ingridient() { Component = "Śmietana", Unit = Units.l, Quantity = 0.20f });
            Recipes.Add(new Recipe()
            {
                Id = 2,
                Category = Categories.Soup,
                Name = "Chłodnik",
                Ingridients = ingrid,
                Description = "Mleko zagotować z wodą. dodać śmietanę rozmąconą z  mąką i zagotować razem."
            });

            ingrid = new List<Ingridient>();
            ingrid.Add(new Ingridient() { Component = "Buraki", Unit = Units.kg, Quantity = 1.0f });
            ingrid.Add(new Ingridient() { Component = "Włoszczyzna", Unit = Units.g, Quantity = 150.0f });
            ingrid.Add(new Ingridient() { Component = "Wędzonka", Unit = Units.g, Quantity = 100.0f });
            Recipes.Add(new Recipe()
            {
                Id = 3,
                Category = Categories.Soup,
                Name = "Barszcz czerwony",
                Ingridients = ingrid,
                Description = "Buraki posiekać, posolić i skropić winnym octem. Zalać wodą. Gotować 45 min."
            });

            ingrid = new List<Ingridient>();
            ingrid.Add(new Ingridient() { Component = "Mąka", Unit = Units.kg, Quantity = 4.0f });
            ingrid.Add(new Ingridient() { Component = "Woda", Unit = Units.l, Quantity = 2.0f });
            ingrid.Add(new Ingridient() { Component = "Drożdże", Unit = Units.g, Quantity = 15.0f });
            ingrid.Add(new Ingridient() { Component = "Zsiadłe mleko", Unit = Units.l, Quantity = 0.25f });
            Recipes.Add(new Recipe()
            {
                Id = 4,
                Category = Categories.Bread,
                Name = "Chleb wiejski",
                Ingridients = ingrid,
                Description = "Przygotować rozczyn, Piec 2 h."
            });

            ingrid = new List<Ingridient>();
            ingrid.Add(new Ingridient() { Component = "Masło", Unit = Units.g, Quantity = 125.0f });
            ingrid.Add(new Ingridient() { Component = "Mąka", Unit = Units.g, Quantity = 20.0f });
            ingrid.Add(new Ingridient() { Component = "Śmietanka", Unit = Units.l, Quantity = 0.25f });
            ingrid.Add(new Ingridient() { Component = "Żółtka", Unit = Units.piece, Quantity = 4.0f });
            Recipes.Add(new Recipe()
            {
                Id = 5,
                Category = Categories.Sauce,
                Name = "Beszamel",
                Ingridients = ingrid,
                Description = "Masło przesmażyć z mąką. Dolewać śmietanki. Gotować do gęstości"
            });
        }

    }
}
