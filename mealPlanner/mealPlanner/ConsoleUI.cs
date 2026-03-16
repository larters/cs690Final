namespace mealPlanner;

using Spectre.Console;


public class ConsoleUI {
    DataManager dataManager;

    public ConsoleUI() {
        dataManager = new DataManager();
    }

    public void Show() {
    

        do {

            var mode = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                    .Title("Please select mode")
                                    .AddChoices(new[] {
                                        "frige","recipe book","cook","request meal plan","end"
                                    }));

            if(mode=="frige") {
                Console.WriteLine("you are in fridge mode:" + dataManager.myfridge.owner);


                var selectedMenu = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                    .Title("Select what to do:")
                                    .AddChoices(new[] {
                                        "add ingredient","remove ingredient", "list all ingredients"
                                    }));


                if(selectedMenu=="add ingredient") {

                    string ingredieantName = AnsiConsole.Prompt(new TextPrompt<string>("Enter what ingredieant you want to add :"));

                    dataManager.addIngredient(new ingredientData(ingredieantName));
                }else if(selectedMenu=="remove ingredient") {


                    ingredientData selectedIngredieant = AnsiConsole.Prompt(
				            new SelectionPrompt<ingredientData>()
				                .Title("Select an Ingredieant")
				                .AddChoices(dataManager.myfridge.ingredientList));


                    dataManager.removeIngredient(selectedIngredieant);
                }else if(selectedMenu=="list all ingredients") {


                    Console.WriteLine("here is the ingredient list in your fridge:");
                    //Console.WriteLine("chicken");
                    //Console.WriteLine("beef");
                    //Console.WriteLine("rice");
                    //Console.WriteLine("bread");
                    
                    foreach(var ingredieant in dataManager.myfridge.ingredientList) {
                        Console.WriteLine("--"+ingredieant.Name);
                    }
                }

            } else if(mode=="recipe book") {
                Console.WriteLine("you are in recipe book mode:" + dataManager.myrecipeBook.owner);

                var selectedMenu = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                    .Title("recipe book ")
                                    .AddChoices(new[] {
                                        "add recipe","remove recipe", "list all recipes"
                                    }));

                if(selectedMenu=="add recipe") {

                    string ingredieantName = AnsiConsole.Prompt(new TextPrompt<string>("Enter what recipe you want to add :"));

                    ingredientData data = new ingredientData(ingredieantName);
                }else if(selectedMenu=="remove recipe") {

                    string ingredieantName = AnsiConsole.Prompt(new TextPrompt<string>("Enter what recipe you want to remove :"));

                    ingredientData data = new ingredientData(ingredieantName);
                }else if(selectedMenu=="list all recipes") {


                    Console.WriteLine("here is the recipe list:");

                    Console.WriteLine("gongbao chicken=chicken+peanuts+chili pepper");
                    Console.WriteLine("stir fried beef=beef+vegetables");
                    Console.WriteLine("chiken curry=curry sauce+beef+rice");
                    Console.WriteLine("taco beef=ground beef+tomato sauce+tortillas");
                    Console.WriteLine("garlic shrimp pasta=garlic+shrimp+pasta");
                }

            }else if(mode=="cook") {

                    Console.WriteLine("please select from recipe list:");
                    Console.WriteLine("gongbao chicken=chicken+peanuts+chili pepper");
                    Console.WriteLine("stir fried beef=beef+vegetables");
                    Console.WriteLine("chiken curry=curry sauce+beef+rice");
                    Console.WriteLine("taco beef=ground beef+tomato sauce+tortillas");
                    Console.WriteLine("garlic shrimp pasta=garlic+shrimp+pasta");

            }else if(mode=="request meal plan") {
                
                    Console.WriteLine("here is the recipe you can cook for next week:");
                    Console.WriteLine("Monday:gongbao chicken=chicken+peanuts+chili pepper");
                    Console.WriteLine("Tuesday:stir fried beef=beef+vegetables");
                    Console.WriteLine("Wednesday:chiken curry=curry sauce+beef+rice");
                    Console.WriteLine("Thursday:taco beef=ground beef+tomato sauce+tortillas");
                    Console.WriteLine("Friday:garlic shrimp pasta=garlic+shrimp+pasta");
            }else if(mode=="end") {
                break;
            };

        }while(false);
    }

    public static string AskForInput(string message) {
        Console.Write(message);
        return Console.ReadLine();
    }
}