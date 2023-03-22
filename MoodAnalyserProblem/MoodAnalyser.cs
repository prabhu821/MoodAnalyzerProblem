using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserProblem;

public class MoodAnalyser
{
    private string message;

    public MoodAnalyser(string message)
    {
        this.message = message;
    }

    public string AnalyserMood()
    {
        try
        {
            if (this.message.Equals(string.Empty))
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.Exceptiontype.EMPTYMESSAGE, "Mood should not be empty");
            }

            if (this.message.Contains("Sad"))
                return "Sad";
            return "Happy";
        }
        catch (NullReferenceException)
        {
            throw new MoodAnalyserCustomException(MoodAnalyserCustomException.Exceptiontype.NULLMESSAGE, "Mood should not be null");
        }
    }
}