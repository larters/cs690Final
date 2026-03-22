namespace mealPlanner;

public class DataManager {

    FileSaver fileSaver;
    public fridge myfridge;
    public recipeBook myrecipeBook;


    public DataManager() {

        /*====================================================
        init DataManager
        ====================================================*/
        // open ingredients file
        fileSaver = new FileSaver("ingredients.txt");

        // new myfridge
        myfridge = new fridge("Zoe's fridge");

        // new myrecipeBook
        myrecipeBook = new recipeBook("Zoe's recipeBook");

        // readout ingredients
        var ingredients = File.ReadAllLines("ingredients.txt");

        // add to myfridge
        foreach(var ingredient in ingredients) {
            //Console.WriteLine("alredy in your fridge: "+ingredient);
            myfridge.add(new ingredientData(ingredient));
        }
        
        // read recipeBook
        var book = File.ReadAllLines("recipeBook.txt");

        // add to myrecipeBook
        foreach(var recipe in book) {
            myrecipeBook.add(new recipeData(recipe));
        }
        
    }


    public void SynchronizeRecipe() {
        // delete and sync recipeBook
        File.Delete("recipeBook.txt");
        foreach(var recipe in myrecipeBook.recipeList) {
            File.AppendAllText("recipeBook.txt",recipe+Environment.NewLine);
        }
    }


    public void SynchronizeIngredients() {
        // delete and sync ingredient
        File.Delete("ingredients.txt");
        foreach(var ingredient in myfridge.ingredientList) {
            //Console.WriteLine("SynchronizeIngredients append: "+ingredient.Name);
            File.AppendAllText("ingredients.txt",ingredient+Environment.NewLine);
        }
    }


    public void removeIngredient(ingredientData ingredient) {

        //Console.WriteLine("ingredientList remove: "+ingredient.Name);
        // remove obj from myfridge
        myfridge.remove(ingredient);

        SynchronizeIngredients();
    }

    public void addIngredient(ingredientData ingredient) {
        // add and sync
        myfridge.ingredientList.Add(ingredient);
        SynchronizeIngredients();
    }

    public void removeRecipe(recipeData recipe) {
        // remove and sync
        myrecipeBook.remove(recipe);
        SynchronizeRecipe();
    }

    public void addRecipe(recipeData recipe) {
        // add and sync
        myrecipeBook.add(recipe);
        SynchronizeRecipe();
    }

    public void cook(recipeData recipe) {
        // get recipe
        string ingrediets = recipe.ToString().Split('=')[1];

        Console.WriteLine("you are cooking:" + recipe.Name);

        // split into ingredientList
        List<string> ingredientList = ingrediets.Split('+').ToList();

        // loop the ingredientList and remove from myfridge
        foreach(var ingredient in ingredientList) {
            Console.WriteLine("you are consuming:"+ingredient.ToString());

            // remove from fridge
            myfridge.consume(ingredient);

            // sync
            SynchronizeIngredients();
        }
    }


    public string mealPlan() {

        // list of weekdays
        List<string> weekdays = new List<string>();

        string mealPlan = "";

        // init weekdays, for one week work days
        weekdays.Add("Monday");
        weekdays.Add("Tuesday");
        weekdays.Add("Wednesday");
        weekdays.Add("Thursday");
        weekdays.Add("Friday");

        int i = 0;
        // loop for recipeList from myrecipeBook
        foreach(var eachRecipe in myrecipeBook.recipeList) 
        {
            //Console.WriteLine("plan for : "+eachRecipe.ToString());        
            // check if this recipe has all ingredient
            if(findIngredients(eachRecipe))
            {
                // add to mealPlan list
                mealPlan = mealPlan + weekdays[i] + " : " + eachRecipe.ToString() + Environment.NewLine;
                i++;

                // max 5 needed
                if(i > 4)
                {
                    // stop at 5 days
                    break;
                }
            }else{
                // did not find needed ingredient, do nothing, go for next recipe
            }

        }

        return mealPlan;
    }



    public bool findIngredients(recipeData recipe) {

        // split and get ingrediets
        string ingrediets = recipe.ToString().Split('=')[1];

        //Console.WriteLine("searching recipe:" + recipe.Name);

        // split into ingredientList
        List<string> ingredientList = ingrediets.Split('+').ToList();

        int i = 0;
        bool ingredietAllFound = true;

        // loop through ingredientList
        foreach(var ingrediet in ingredientList) 
        {
            // if not founded
            if(!myfridge.hasIngrediet(ingrediet))
            {
                // can not make this recipe
                ingredietAllFound = false;
                break;
            }
        }

        return ingredietAllFound;
    }    
}