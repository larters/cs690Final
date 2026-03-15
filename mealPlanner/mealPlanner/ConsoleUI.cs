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

                var selectedMenu = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                    .Title("Select what to do")
                                    .AddChoices(new[] {
                                        "add ingredient","remove ingredient", "list all ingredients"
                                    }));
                Console.WriteLine("you are in fridge mode:" + dataManager.myfridge.owner);



                if(mode=="add ingredient") {

                    string ingredieantName = AnsiConsole.Prompt(new TextPrompt<string>("Enter what ingredieant you want to add :"));

                    ingredientData data = new ingredientData(ingredieantName);
                }else if(mode=="remove ingredient") {

                    string ingredieantName = AnsiConsole.Prompt(new TextPrompt<string>("Enter what ingredieant you want to remove :"));

                    ingredientData data = new ingredientData(ingredieantName);
                }else if(mode=="list all ingredients") {

                    string ingredieantName = AnsiConsole.Prompt(new TextPrompt<string>("here is the ingredieant list:"));

                }

            } else if(mode=="recipe book") {

                var selectedMenu = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                    .Title("recipe book ")
                                    .AddChoices(new[] {
                                        "add recipe","remove recipe", "list all recipes"
                                    }));
                Console.WriteLine("you are in recipe mode:" + dataManager.myrecipeBook.owner);

                if(selectedMenu=="add recipe") {

                    string ingredieantName = AnsiConsole.Prompt(new TextPrompt<string>("Enter what recipe you want to add :"));

                    ingredientData data = new ingredientData(ingredieantName);
                }else if(selectedMenu=="remove recipe") {

                    string ingredieantName = AnsiConsole.Prompt(new TextPrompt<string>("Enter what recipe you want to remove :"));

                    ingredientData data = new ingredientData(ingredieantName);
                }else if(selectedMenu=="list all recipes") {

                    string ingredieantName = AnsiConsole.Prompt(new TextPrompt<string>("here is the recipe list:"));
                }


            }else if(mode=="cook") {

                string ingredieantName = AnsiConsole.Prompt(new TextPrompt<string>("please select from recipe list:"));


            }else if(mode=="request meal plan") {
                string ingredieantName = AnsiConsole.Prompt(new TextPrompt<string>("here is the recipe you can cook for next week:"));

            }else if(mode=="end") {
                break;
            };

        }while(true);
    }

    public static string AskForInput(string message) {
        Console.Write(message);
        return Console.ReadLine();
    }
}