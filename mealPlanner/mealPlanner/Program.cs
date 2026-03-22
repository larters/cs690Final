namespace mealPlanner;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello, World!");
        ConsoleUI theUI = new ConsoleUI();

        // just show the UI, until user select end
        theUI.Show();
    }
}
