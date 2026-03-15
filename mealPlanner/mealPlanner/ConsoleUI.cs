namespace mealPlanner;

using Spectre.Console;


public class ConsoleUI {
    DataManager dataManager;

    public ConsoleUI() {
        dataManager = new DataManager();
    }

    public void Show() {
        
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
				                    "add","remove"
				                }));
            Console.WriteLine("you are in fridge mode"+"Zoe");

            string ingredieantName = AnsiConsole.Prompt(new TextPrompt<string>("Enter what ingredieant you want to add :"));

            ingredientData data = new ingredientData(ingredieantName);


        } else if(mode=="recipe book") {

        }else if(mode=="cook") {

        }else if(mode=="request meal plan") {

        }else if(mode=="end") {

        }
    }

    public static string AskForInput(string message) {
        Console.Write(message);
        return Console.ReadLine();
    }
}