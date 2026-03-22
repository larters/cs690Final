namespace mealPlanner.Tests;

public class fileTest
{
    [Fact]
    public void Test1()
    {
        string testFilename = "test.notexist.txt";

        // start from file not exist, need to delete file first before test
        Assert.True(!File.Exists(testFilename));

        FileSaver fileSaver = new FileSaver(testFilename);

        // check created
        Assert.True(File.Exists(testFilename));
    }

    [Fact]
    public void Test2()
    {
        // make sure this is a new file, not used before
        string testFilename = "test.notexist2.txt";

        // start from file not exist, need to delete file first before test
        Assert.True(!File.Exists(testFilename));

        FileSaver fileSaver = new FileSaver(testFilename);

        // check created
        Assert.True(File.Exists(testFilename));

        string testNewline = "newline";
        fileSaver.AppendLine(testNewline);

        string[] content = File.ReadAllLines(testFilename);


        // check if readout is same as writein
        Assert.Equal(content[0], testNewline);
    }
}



public class fridgeTest
{
    [Fact]
    public void Test1()
    {
        fridge myfridge;

        ingredientData ingredientTest = new ingredientData("ingredientTest");

        myfridge = new fridge("test fridge");

        myfridge.add(ingredientTest);        

        Assert.Equal(myfridge.ingredientList[0].ToString(), "ingredientTest");

    }


    [Fact]
    public void Test2()
    {
        fridge myfridge;

        ingredientData ingredientTest1 = new ingredientData("ingredientTest1");
        ingredientData ingredientTest2 = new ingredientData("ingredientTest2");

        myfridge = new fridge("test fridge");

        myfridge.add(ingredientTest1);        
        myfridge.add(ingredientTest2);     

        myfridge.remove(ingredientTest2);  


        Assert.Equal(myfridge.ingredientList[0].ToString(), "ingredientTest1");
        Assert.Equal(myfridge.ingredientList.Count, 1);

    }


    [Fact]
    public void Test3()
    {
        fridge myfridge;

        ingredientData ingredientTest1 = new ingredientData("ingredientTest1");
        ingredientData ingredientTest2 = new ingredientData("ingredientTest2");

        myfridge = new fridge("test fridge");

        myfridge.add(ingredientTest1);        
        myfridge.add(ingredientTest2);     

        myfridge.consume("ingredientTest2");  


        Assert.Equal(myfridge.ingredientList[0].ToString(), "ingredientTest1");
        Assert.Equal(myfridge.ingredientList.Count, 1);
    }


    [Fact]
    public void Test4()
    {
        fridge myfridge;

        ingredientData ingredientTest1 = new ingredientData("ingredientTest1");
        ingredientData ingredientTest2 = new ingredientData("ingredientTest2");

        myfridge = new fridge("test fridge");

        myfridge.add(ingredientTest1);        
        myfridge.add(ingredientTest2);     

        var res1 = myfridge.hasIngrediet("ingredientTest2");  
        var res2 = myfridge.hasIngrediet("ingredientTest3");  


        Assert.Equal(res1, true);
        Assert.Equal(res2, false);
    }

    
}

public class recipeBookTest
{
    [Fact]
    public void Test1()
    {
        recipeBook myrecipeBook;

        recipeData recipe1 = new recipeData("recipe1=ingredient1+ingredient2");
        recipeData recipe2 = new recipeData("recipe2=ingredient3+ingredient4");

        myrecipeBook = new recipeBook("my  recipeBook");

        myrecipeBook.add(recipe1);        
        myrecipeBook.add(recipe2);     

        myrecipeBook.remove(recipe1);  


        Assert.Equal(myrecipeBook.recipeList[0].ToString(), "recipe2=ingredient3+ingredient4");

    }

   [Fact]
    public void Test2()
    {
        recipeBook myrecipeBook;

        recipeData recipe1 = new recipeData("recipe1=ingredient1+ingredient2");

        myrecipeBook = new recipeBook("my  recipeBook");

        myrecipeBook.add(recipe1);        


        Assert.Equal(myrecipeBook.recipeList[0].ToString(), "recipe1=ingredient1+ingredient2");

    }


}

