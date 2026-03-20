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


    
    }
}

public class recipeBookTest
{
    [Fact]
    public void Test1()
    {
        recipeBook myfridge;
    }
}

