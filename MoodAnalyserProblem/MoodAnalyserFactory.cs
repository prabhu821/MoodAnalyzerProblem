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
    //UC4
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

    //UC5
    public static object CreateMoodAnalyseUsingParameterizedConstructor(string className, string constructor, string message)
    {
        Type type = typeof(MoodAnalyser);
        if (type.Name.Equals(className) || type.FullName.Equals(className))
        {
            if (type.Name.Equals(constructor))
            {
                ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string) });
                object instance = constructorInfo.Invoke(new object[] { "HAPPY" });
                return instance;
            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.Exceptiontype.NOSUCHMETHOD, "Constructor is Not Found");
            }
        }
        else
        {
            throw new MoodAnalyserCustomException(MoodAnalyserCustomException.Exceptiontype.NOSUCHCLASS, "Class Not Found");
        }
    }
}