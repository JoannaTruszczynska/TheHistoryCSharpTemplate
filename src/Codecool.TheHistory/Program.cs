using System.Runtime.InteropServices.WindowsRuntime;

namespace Codecool.TheHistory
{
    public class Program
    {
        public static int Main()
        {
           TheHistoryArray test = new TheHistoryArray();
           test.Add("some    new text");
           test.Clear();
           return 0;
        }
    }
}