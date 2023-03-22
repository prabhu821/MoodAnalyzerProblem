using MoodAnalyserProblem;

namespace MoodAnalyserTestCase;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    //TC1.1
    [TestCategory("Sad Mood")]
    public void AnalyseMood_ShouldReturnSad()
    {
        string message = "I am in Sad Mood";
        MoodAnalyser moodAnalyser = new MoodAnalyser(message);
        string check = moodAnalyser.AnalyserMood();
        Assert.AreEqual(check, "Sad");
    }

    [TestMethod]
    //TC1.2
    [TestCategory("In Any Mood")]
    public void AnalyseMood_ShouldReturnHappy()
    {
        string message = "I am in Any Mood";
        MoodAnalyser moodAnalyser = new MoodAnalyser(message);
        string check = moodAnalyser.AnalyserMood();
        Assert.AreEqual(check, "Happy");
    }

    [TestMethod]
    //TC2.1
    [DataRow("I am in Happy Mood")]
    [DataRow(null)]
    public void TestMethodAnalayzerForHappyMood()
    {
        ///AAA methodology
        ///arrange
        string message = "Im in Happy mood";

        //Act
        MoodAnalyser analyser = new MoodAnalyser(message);
        string Actual = analyser.AnalyserMood();

        //Assert
        Assert.AreEqual(Actual, "Happy");
    }

    [TestMethod]
    //TC3.1, TC3.2
    public void Given_Empty_Mood_Should_Throw_MoodAnalysisException_EmptyMood()
    {
        try
        {
            string message = "";
            MoodAnalyser moodAnalyser = new MoodAnalyser(message);
            string check = moodAnalyser.AnalyserMood();
        }
        catch (MoodAnalyserCustomException e)
        {
            Assert.AreEqual("Mood should not be empty", e.Message);
        }
    }

    //TC4.1
    [TestMethod]
    public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject()
    {
        string message = null;
        object check = new MoodAnalyser(message);
        object obj = MoodAnalyserFactory.CreateMoodAnalysis("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyser");
        check.Equals(obj);
    }
    //TC4.2
    [TestMethod]
    public void TestMethodClassNameImproperShouldThrowMoodAnalyserException()
    {
        try
        {
            object expected = new MoodAnalyser();
            object obj = MoodAnalyserFactory.CreateMoodAnalysis("erMoodAnalyserProbelm.MoodAnalys", "MoodAnalyser");
            expected.Equals(obj);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    //TC4.3
    [TestMethod]
    public void TestMethodConstructorNameImproperShouldThrowMoodAnalyserException()
    {
        try
        {
            object expected = new MoodAnalyser();
            object obj = MoodAnalyserFactory.CreateMoodAnalysis("MoodAnalyserProbelm.AnalyseMood", "MoodAnalyser");
            expected.Equals(obj);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    //TC5.1
    [TestMethod]
    public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject_UsingParameterisedConstructor()
    {
        object check = new MoodAnalyser("HAPPY");
        object obj = MoodAnalyserFactory.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyser", "HAPPY");
        check.Equals(obj);
    }
    //TC5.2
    [TestMethod]
    public void GivenImproperClassName_ShouldThrowMoodAnalyserCustomException_UsingParameterisedConstructor()
    {
        string check = "Class Not Found";
        try
        {
            object moodAnalyseObject = MoodAnalyserFactory.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyser", "HAPPY");
        }
        catch (MoodAnalyserCustomException e)
        {
            Assert.AreEqual(check, e.Message);
        }
    }
    //TC5.3
    [TestMethod]
    public void GivenImproperConstructorName_ShouldThrowMoodAnalyserCustomException_UsingParameterisedConstructor()
    {
        string check = "Constructor Not Found";
        try
        {
            object moodAnalyseObject = MoodAnalyserFactory.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyser", "HAPPY");
        }
        catch (MoodAnalyserCustomException e)
        {
            Assert.AreEqual(check, e.Message);
        }
    }
}