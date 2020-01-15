using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Codecool.TheHistory.UnitTests
{
    public class TestBase
    {
        protected ITheHistory _theHistory;

        protected void Setup(string name)
        {
            switch (name)
            {
                case "Array":
                {
                    _theHistory = new TheHistoryArray();
                    break;
                }

                case "List":
                {
                    _theHistory = new TheHistoryList();
                    break;
                }

                case "LinkedList":
                {
                    _theHistory = new TheHistoryLinkedList();
                    break;
                }
            }
        }

        protected static string Repeat(string s, int n)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < n; i++)
            {
                sb.Append(s).Append(" ");
            }

            if (sb.Length > 0) sb.Remove(sb.Length - 1, 1); // last space char
            return sb.ToString();
        }

        protected string ReadIliad()
        {
            var path = Directory.GetParent(Environment.CurrentDirectory).Parent?.Parent?.FullName + "/data/Iliad.txt";
            var text = File.ReadAllText(path);

            return text.Replace("\n", "").Replace("\r", "");
        }
    }
}
