namespace mealPlanner;

public class ingredientData {
    public string Name { get; }

    public ingredientData(string name) {
        this.Name = name;
    }

    public override string ToString() {
        return this.Name;
    }
}

public class recipeData {
    // left side of =
    public string Name { get; }

    // full recipe string
    public string recipe { get; }

    public recipeData(string name) {
        this.recipe = name;
        this.Name = name.Split('=')[0];
    }

    public override string ToString() {
        return this.recipe;
    }
}



public class fridge {
    public string owner;


    public fridge(string name) {
        this.owner = name;

        // init ingredientList
        this.ingredientList = new List<ingredientData>();
    }

    public override string ToString() {
        return this.owner;
    }

    public string add(ingredientData ingredient) {
        // add into ingredientList
        ingredientList.Add(ingredient);
        return ingredient.Name;
    }

    public string remove(ingredientData ingredient) {
        // remove from ingredientList
        ingredientList.Remove(ingredient);
        return ingredient.Name;
    }


    public string consume(string ingredient) {
        // loop ingredientList
        foreach(var each in this.ingredientList) {
            //Console.WriteLine("each name: "+each.Name);
            //Console.WriteLine("to remove: "+ingredient);
            // match
            if(each.Name == ingredient){
                //Console.WriteLine("found remove: "+each.Name);
                // remove from ingredientList
                this.ingredientList.Remove(each);
                break;
            }
        }

        return ingredient;
    }

    public bool hasIngrediet(string ingredient) {
        // loop ingredientList
        foreach(var each in this.ingredientList) {
            //Console.WriteLine("each name: "+each.Name);
            //Console.WriteLine("to find: "+ingredient);
            // find the same name 
            if(each.Name == ingredient){
                // found match
                //Console.WriteLine("found ingredient: "+each.Name);
                return true;
            }
        }

        return false;
    }

    public List<ingredientData> ingredientList;
}


public class recipeBook {
    public string owner;

    public recipeBook(string name) {
        this.owner = name;

        // init list
        this.recipeList = new List<recipeData>();
    }

    public override string ToString() {
        return this.owner;
    }

    public string add(recipeData recipe) {
        // add to recipeList
        recipeList.Add(recipe);
        return recipe.recipe;
    }

    public string remove(recipeData recipe) {
        // remove from recipeList
        recipeList.Remove(recipe);
        return recipe.Name;
    }

    public List<recipeData> recipeList { get; }
}


