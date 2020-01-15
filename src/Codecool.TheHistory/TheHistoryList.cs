using System;
using System.Collections.Generic;

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
        
        public override int Size => throw new NotImplementedException();

        public override void Add(string text)
        {
            // TODO: Check the ITheHistory interface for more information
            throw new NotImplementedException();
        }

        public override void Clear()
        {
            // TODO: Check the ITheHistory interface for more information
            throw new NotImplementedException();
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