using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Codecool.TheHistory
{
    public class Program
    {
        public static int Main()
        {
           TheHistoryLinkedList test = new TheHistoryLinkedList();
           test.Add("hello world hello hello world");
           Console.WriteLine(test.Size.ToString());
           //test.ReplaceOneWord("tekst", "slowo");
          // test.ReplaceOneWord("abc", "ABC");
           test.RemoveWord("hello");
           return 0;
        }
    }
}