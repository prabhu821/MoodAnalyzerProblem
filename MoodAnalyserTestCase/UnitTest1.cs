using MoodAnalyserProblem;

namespace MoodAnalyserTestCase
{
    [TestClass]
    public class UnitTest1
    {
        //TC1.1
        [TestMethod]
        [TestCategory("Sad Mood")]
        public void TestMethodAnalyzerForSadMood()
        {
            ///AAA methodology
            ///Arrange
            string message = "Im in sad mood";

            //Act
            MoodAnalyser analyser = new MoodAnalyser(message);
            string Actual = analyser.AnalyserMood();

            //Assert
            Assert.AreEqual(Actual, "sad");
        }
        //TC1.2
        [TestMethod]
        [TestCategory("In Any Mood")]
        public void TestMethodAnalayzerForAnyMood()
        {
            ///AAA methodology
            ///arrange
            string message = "Im in any mood";

            //Act
            MoodAnalyser analyser = new MoodAnalyser(message);
            string Actual = analyser.AnalyserMood();

            //Assert
            Assert.AreEqual(Actual, "happy");
        }
    }
}