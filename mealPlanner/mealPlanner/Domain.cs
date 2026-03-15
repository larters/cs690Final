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

    public recipeData(string name) {
        this.Name = name;
    }

    public override string ToString() {
        return this.Name;
    }
}



public class fridge {
    public string owner;
    public List<string> menu { get;set; }

    public fridge(string name) {
        this.owner = name;
    }

    public override string ToString() {
        return this.owner;
    }

    public string add(ingredientData ingredient) {
        ingredientList.Add(ingredient);
        return ingredient.Name;
    }

    public List<ingredientData> ingredientList;
}


public class recipeBook {
    public string owner;

    public recipeBook(string name) {
        this.owner = "";
        this.owner = name;
    }

    public override string ToString() {
        return this.owner;
    }

    public string add(recipeData recipe) {
        recipeList.Add(recipe);
        return recipe.Name;
    }

    public List<recipeData> recipeList { get; }
}


