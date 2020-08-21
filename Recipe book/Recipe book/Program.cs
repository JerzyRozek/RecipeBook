using System;

namespace Recipe_book
{
    class Program
    {
        //  public static MenuActionService menuActionService = new MenuActionService();
        static void Main(string[] args)
        {
            Console.WriteLine("Recipe book");
            MenuActionService menuActionService = new MenuActionService(); // obiekt menu głównego
            RecipeService recipeService = new RecipeService(); // obiekt menu rozdziału

            menuActionService = Initialize(menuActionService);

            recipeService.CreateDatabase();

            bool running = true;

            while (running)
            {
                Console.WriteLine("\r\nWhat do you want to do?");
                var mainMenu = menuActionService.GetMenuActionsByMenuName("Main");  // wyświetlenie menu główne
                foreach (var menuAction in mainMenu)
                {
                    Console.WriteLine($"{menuAction.Id}. {menuAction.ActionName}");
                }
                Console.Write("Enter the number: ");
                var operation = Console.ReadKey();
                Console.WriteLine("");

                switch (operation.KeyChar)
                {
                    case '0':
                        running = false;
                        break;
                    case '1':
                        var chapterId = recipeService.ListOfRecipesView(menuActionService);// wyświetlenie menu i zwraca wybraną opcję
                        recipeService.ListOfRecipes(chapterId.KeyChar);
                        break;
                    case '2':
                       var findName = recipeService.FindReceipeView();
                        recipeService.FindReceipe(findName);
                        break;
                    case '3':
                        var typeId = recipeService.DisplayReceipeView();
                        recipeService.DisplayReceipe(typeId);
                        break;

                    default:
                        Console.WriteLine("Action doesn't exist.");
                        break;
                }

            }
        }

        private static MenuActionService Initialize(MenuActionService menuActionService)
        {
            menuActionService.AddNewAction(0, "Exit", "Main");
            menuActionService.AddNewAction(1, "List Recipes", "Main");
            menuActionService.AddNewAction(2, "Find Recipe", "Main");
            menuActionService.AddNewAction(3, "Display Recipe", "Main");


            menuActionService.AddNewAction(0, "Main Menu", "CategoryMenu");
            menuActionService.AddNewAction(1, "1 Soup", "CategoryMenu");
            menuActionService.AddNewAction(2, "2 Bread", "CategoryMenu");
            menuActionService.AddNewAction(3, "3 Sauce", "CategoryMenu");

            return menuActionService;
        }

    }
}
