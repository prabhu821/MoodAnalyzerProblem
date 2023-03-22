// See https://aka.ms/new-console-template for more information
using MoodAnalyserProblem;

Console.WriteLine("Mood Analyzer Problem");
string message1 = "I am in Sad mood";
MoodAnalyser mood1 = new MoodAnalyser(message1);
mood1.AnalyserMood();

string message2 = "I am in any mood";
MoodAnalyser mood2 = new MoodAnalyser(message2);
mood2.AnalyserMood();