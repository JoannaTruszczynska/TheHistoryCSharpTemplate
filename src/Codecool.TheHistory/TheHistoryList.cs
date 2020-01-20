using System;
using System.Collections.Generic;
using System.IO;

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
            // TODO: Check the ITheHistory interface for more information
            throw new NotImplementedException();
        }

        public override void ReplaceMoreWords(string[] fromWords, string[] toWords)
        {
            // TODO: Check the ITheHistory interface for more information
            throw new NotImplementedException();
        }

        public override void ReplaceOneWord(string from, string to)
        {
            // TODO: Check the ITheHistory interface for more information
            throw new NotImplementedException();
        }
    }
}