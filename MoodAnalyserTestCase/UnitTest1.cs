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
}