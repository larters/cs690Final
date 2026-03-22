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
    public string Name { get; }

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
    public List<string> menu { get;set; }

    public fridge(string name) {
        this.owner = name;

        this.ingredientList = new List<ingredientData>();
    }

    public override string ToString() {
        return this.owner;
    }

    public string add(ingredientData ingredient) {
        ingredientList.Add(ingredient);
        return ingredient.Name;
    }

    public string remove(ingredientData ingredient) {
        ingredientList.Remove(ingredient);
        return ingredient.Name;
    }


    public string consume(string ingredient) {
            foreach(var each in this.ingredientList) {
                //Console.WriteLine("each name: "+each.Name);
                //Console.WriteLine("to remove: "+ingredient);
                if(each.Name == ingredient){
                    //Console.WriteLine("found remove: "+each.Name);
                    this.ingredientList.Remove(each);
                    break;
                }
            }
        return ingredient;
    }

    public bool hasIngrediet(string ingredient) {
            foreach(var each in this.ingredientList) {
                //Console.WriteLine("each name: "+each.Name);
                //Console.WriteLine("to find: "+ingredient);
                if(each.Name == ingredient){
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

        this.recipeList = new List<recipeData>();
    }

    public override string ToString() {
        return this.owner;
    }

    public string add(recipeData recipe) {
        recipeList.Add(recipe);
        return recipe.recipe;
    }

    public string remove(recipeData recipe) {
        recipeList.Remove(recipe);
        return recipe.Name;
    }

    public List<recipeData> recipeList { get; }
}


