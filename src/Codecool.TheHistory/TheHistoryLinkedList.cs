using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;

namespace Codecool.TheHistory
{
    public class TheHistoryLinkedList : TheHistoryAbstract
    {
        /// <summary>
        /// This implementation should use a string LinkedList, so don't change that!
        /// </summary>
        private LinkedList<string> _wordsList = new LinkedList<string>();

        /// <summary>
        /// Don't change this either. It's needed for testing.
        /// </summary>
        public override IEnumerable<string> WordsList => _wordsList;

        public override int Size => _wordsList.Count;

        public override void Add(string text)
        {
            string pattern = @"\s+";
            LinkedList<string> newText = new LinkedList<string>(System.Text.RegularExpressions.Regex.Split(text, pattern));


            foreach (var VARIABLE in newText)
            {
                _wordsList.AddLast(VARIABLE);
            }

           
        }

        public override void Clear()
        {
           _wordsList.Clear();
        }

        public override void RemoveWord(string wordToBeRemoved)
        {
            var counter = 0;
            while (counter == 0)
            {
                foreach (var i in _wordsList)
                {
                    if (i == wordToBeRemoved)
                    {
                        _wordsList.Remove(i);
                        counter = 0;
                        break;
                    }
                    if (i == _wordsList.ElementAt(_wordsList.Count-1))
                    {
                        counter = 1;
                    }
                }
            }
        }

        public override void ReplaceMoreWords(string[] fromWords, string[] toWords)
        {
            // TODO: Check the ITheHistory interface for more information
            throw new NotImplementedException();
        }

        public override void ReplaceOneWord(string from, string to)
        {
            LinkedListNode<string> find = _wordsList.Find(from);
            while (find != null)
            {
                _wordsList.AddBefore(find, to);
                _wordsList.Remove(find);

                find = _wordsList.Find(from);
            }
        }
    }
}