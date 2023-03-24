using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserProblem;

public class MoodAnalyserCustomException : Exception
{
    public enum Exceptiontype
    {
        NULLMESSAGE, 
        EMPTYMESSAGE,
        NOSUCHFIELD, 
        NOSUCHMETHOD,
        NOSUCHCLASS, 
    }
    public Exceptiontype type;
    public MoodAnalyserCustomException(Exceptiontype type, string message) : base(message)

    {
        this.type = type;
    }
}