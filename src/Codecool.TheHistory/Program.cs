using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Codecool.TheHistory
{
    public class Program
    {
        public static int Main()
        {
           TheHistoryLinkedList test = new TheHistoryLinkedList();
           test.Add("carpet car motorcar Nicaragua");
           Console.WriteLine(test.Size.ToString());
           //test.ReplaceOneWord("tekst", "slowo");
           test.ReplaceOneWord("car", "AUTOMOBILE");
           //test.RemoveWord("hello");
           return 0;
        }
    }
}