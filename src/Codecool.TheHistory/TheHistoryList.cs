using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Codecool.TheHistory
{
    public class TheHistoryList : TheHistoryAbstract
    {
        /// <summary>
        /// This implementation should use a string List, so don't change that!
        /// </summary>
        private List<string> _wordsList = new List<string>();

        /// <summary>
        /// Don't change this either. It's needed for testing.
        /// </summary>
        public override IEnumerable<string> WordsList => _wordsList;
        
        public override int Size => _wordsList.Count;

        public override void Add(string text)
        {
            string pattern = @"\s+";
            List<string> newText = new List<string>(System.Text.RegularExpressions.Regex.Split(text, pattern));

            foreach (var VARIABLE in newText)
            {
                _wordsList.Add(VARIABLE);
            }
        }

        public override void Clear()
        {
            _wordsList = new List<string>();
        }

        public override void RemoveWord(string wordToBeRemoved)
        {
            var removeList = new List<int>();
            //_wordsList = new List<string>(_wordsList.Where(w => !w.Contains(wordToBeRemoved)));
            for (int index = 0; index < _wordsList.Count; index++)
            {
                if (_wordsList[index] == wordToBeRemoved)
                {
                    removeList.Add(index);
                }
            }
            
            removeList.Reverse();
            foreach (var i in removeList)
            {
                _wordsList.RemoveAt(i);
            }
        }

        public override void ReplaceMoreWords(string[] fromWords, string[] toWords)
        {
            // TODO: Check the ITheHistory interface for more information
            throw new NotImplementedException();
        }

        public override void ReplaceOneWord(string from, string to)
        {
            for (int index = 0; index < _wordsList.Count; index++)
            {
               if (_wordsList[index] == from)
               {
                   _wordsList[index] = to;
               } 
            }
        }
    }
}