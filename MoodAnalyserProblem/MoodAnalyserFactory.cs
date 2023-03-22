using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyserProblem;
public class MoodAnalyserFactory
{
    public static object CreateMoodAnalysis(string className, string constructorName)
    {
        string pattern = @"." + constructorName + "$";
        Match result = Regex.Match(className, pattern);
        if (result.Success)
        {
            try
            {
                Assembly executting = Assembly.GetExecutingAssembly();
                Type MoodAnalyseType = executting.GetType(className);
                return Activator.CreateInstance(MoodAnalyseType);
            }
            catch (ArgumentNullException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.Exceptiontype.NOSUCHCLASS, "Class Not Found");
            }
        }
        else
        {
            throw new MoodAnalyserCustomException(MoodAnalyserCustomException.Exceptiontype.NOSUCHMETHOD, "Class Not Found");
        }
    }
}