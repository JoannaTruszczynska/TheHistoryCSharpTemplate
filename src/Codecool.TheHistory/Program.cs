using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Codecool.TheHistory
{
    public class Program
    {
        public static int Main()
        {
           TheHistoryList test = new TheHistoryList();
           test.Add("abc def ghi");
           Console.WriteLine(test.Size.ToString());
           //test.ReplaceOneWord("tekst", "slowo");
           return 0;
        }
    }
}