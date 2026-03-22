namespace mealPlanner;

using Spectre.Console;


public class ConsoleUI {
    DataManager dataManager;

    public ConsoleUI() {
        dataManager = new DataManager();
    }

    // show UI
    public void Show() {
    

        do {
            // main loop
            var mode = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                    .Title("Please select mode")
                                    .AddChoices(new[] {
                                        "fridge","recipe book","cook","request meal plan","end"
                                    }));

            if(mode=="fridge") {
                
                /*=========================================
                fridge mode start
                =========================================*/
                Console.WriteLine("you are in fridge mode:" + dataManager.myfridge.owner);

                var selectedMenu = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                    .Title("Select what to do:")
                                    .AddChoices(new[] {
                                        "add ingredient","remove ingredient", "list all ingredients"
                                    }));

                // to add ingredient
                if(selectedMenu=="add ingredient") {

                    string ingredientName = AnsiConsole.Prompt(new TextPrompt<string>("Enter what ingredient you want to add :"));

                    // just call dataManager
                    dataManager.addIngredient(new ingredientData(ingredientName));
                }else if(selectedMenu=="remove ingredient") {
                    // to remove ingredient
                    ingredientData selectedingredient = AnsiConsole.Prompt(
				            new SelectionPrompt<ingredientData>()
				                .Title("Select an ingredient")
				                .AddChoices(dataManager.myfridge.ingredientList));

                    // just call dataManager
                    dataManager.removeIngredient(selectedingredient);
                }else if(selectedMenu=="list all ingredients") {


                    Console.WriteLine("here is the ingredient list in your fridge:");
                    //Console.WriteLine("chicken");
                    //Console.WriteLine("beef");
                    //Console.WriteLine("rice");
                    //Console.WriteLine("bread");
                    
                    // output 
                    foreach(var ingredient in dataManager.myfridge.ingredientList) {
                        Console.WriteLine("--"+ingredient.Name);
                    }
                }
                /*=========================================
                fridge mode end
                =========================================*/
            } else if(mode=="recipe book") {

                /*=========================================
                recipe mode start
                =========================================*/
                Console.WriteLine("you are in recipe book mode:" + dataManager.myrecipeBook.owner);

                var selectedMenu = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                    .Title("recipe book ")
                                    .AddChoices(new[] {
                                        "add recipe","remove recipe", "list all recipes"
                                    }));

                if(selectedMenu=="add recipe") {
                    // add recipe
                    string recipeName = AnsiConsole.Prompt(new TextPrompt<string>("Enter what recipe you want to add :"));

                    // call dataManager
                    dataManager.addRecipe(new recipeData(recipeName));
                }else if(selectedMenu=="remove recipe") {
                    // remove recipe
                    recipeData selectedRecipe = AnsiConsole.Prompt(
				            new SelectionPrompt<recipeData>()
				                .Title("Select a recipe")
				                .AddChoices(dataManager.myrecipeBook.recipeList));

                    // call dataManager
                    dataManager.removeRecipe(selectedRecipe);
                }else if(selectedMenu=="list all recipes") {

                    // list myrecipeBook
                    Console.WriteLine("here is the recipe list:");

                    foreach(var each in dataManager.myrecipeBook.recipeList) {
                        Console.WriteLine("--"+each.recipe);
                    }

                    /*
                    Console.WriteLine("gongbao chicken=chicken+peanuts+chili pepper");
                    Console.WriteLine("stir fried beef=beef+vegetables");
                    Console.WriteLine("chiken curry=curry sauce+beef+rice");
                    Console.WriteLine("taco beef=ground beef+tomato sauce+tortillas");
                    Console.WriteLine("garlic shrimp pasta=garlic+shrimp+pasta");
                    */
                }
                /*=========================================
                recipe mode end
                =========================================*/
            }else if(mode=="cook") {
                /*=========================================
                cook mode start
                =========================================*/

                Console.WriteLine("please select from recipe list:");
                    recipeData selectedRecipe = AnsiConsole.Prompt(
				            new SelectionPrompt<recipeData>()
				                .Title("Select a recipe")
				                .AddChoices(dataManager.myrecipeBook.recipeList));

                // call dataManager
                dataManager.cook(selectedRecipe);

                /*
                Console.WriteLine("gongbao chicken=chicken+peanuts+chili pepper");
                Console.WriteLine("stir fried beef=beef+vegetables");
                Console.WriteLine("chiken curry=curry sauce+beef+rice");
                Console.WriteLine("taco beef=ground beef+tomato sauce+tortillas");
                Console.WriteLine("garlic shrimp pasta=garlic+shrimp+pasta");
                */
                /*=========================================
                cook mode end
                =========================================*/

            }else if(mode=="request meal plan") {
                /*=========================================
                meal plan mode start
                =========================================*/
                Console.WriteLine("here is the recipe you can cook for next week:");

                // call mealPlan and output
                Console.WriteLine(dataManager.mealPlan());

                
                /*
                Console.WriteLine("Monday:gongbao chicken=chicken+peanuts+chili pepper");
                Console.WriteLine("Tuesday:stir fried beef=beef+vegetables");
                Console.WriteLine("Wednesday:chiken curry=curry sauce+beef+rice");
                Console.WriteLine("Thursday:taco beef=ground beef+tomato sauce+tortillas");
                Console.WriteLine("Friday:garlic shrimp pasta=garlic+shrimp+pasta");
                */
                /*=========================================
                meal plan mode end
                =========================================*/
            }else if(mode=="end") {
                // end main loop
                break;
            };

        }while(true);
    }
}