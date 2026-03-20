namespace mealPlanner;

public class DataManager {

    FileSaver fileSaver;
    public fridge myfridge;
    public recipeBook myrecipeBook;




    public DataManager() {

        fileSaver = new FileSaver("ingredients.txt");

        myfridge = new fridge("Zoe's fridge");

        myfridge.menu = new List<string>();
        myfridge.menu.Add("add");
        myfridge.menu.Add("remove");

        myrecipeBook = new recipeBook("Zoe's recipeBook");

        var ingredients = File.ReadAllLines("ingredients.txt");

        foreach(var ingredient in ingredients) {
            //Console.WriteLine("alredy in your fridge: "+ingredient);
            myfridge.add(new ingredientData(ingredient));
        }
        

        var book = File.ReadAllLines("recipeBook.txt");

        foreach(var recipe in book) {
            myrecipeBook.add(new recipeData(recipe));
        }
        
        
    }


    public void SynchronizeRecipe() {
        File.Delete("recipeBook.txt");
        foreach(var recipe in myrecipeBook.recipeList) {
            File.AppendAllText("recipeBook.txt",recipe+Environment.NewLine);
        }
    }


    public void SynchronizeIngredients() {
        File.Delete("ingredients.txt");
        foreach(var ingredient in myfridge.ingredientList) {
            //Console.WriteLine("SynchronizeIngredients append: "+ingredient.Name);
            File.AppendAllText("ingredients.txt",ingredient+Environment.NewLine);
        }
    }


    public void removeIngredient(ingredientData ingredient) {

        //Console.WriteLine("ingredientList remove: "+ingredient.Name);

        myfridge.remove(ingredient);
        /*
        foreach(var each in myfridge.ingredientList) {
            Console.WriteLine("each remove: "+each.Name);
            Console.WriteLine("to remove: "+ingredient.Name);
            if(each.Name == ingredient.Name){
                Console.WriteLine("found remove: "+each.Name);
                myfridge.ingredientList.Remove(each);
            }
        }
        */

        /*
        foreach(var each in myfridge.ingredientList) {
            Console.WriteLine("removeIngredient after: "+each.Name);
        }
        */

        SynchronizeIngredients();
    }

    public void addIngredient(ingredientData ingredient) {
        myfridge.ingredientList.Add(ingredient);
        SynchronizeIngredients();
    }

    public void removeRecipe(recipeData recipe) {
        myrecipeBook.recipeList.Remove(recipe);
        SynchronizeRecipe();
    }
}