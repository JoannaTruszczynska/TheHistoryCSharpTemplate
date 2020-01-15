using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.TheHistory
{
    public class TheHistoryList : ITheHistory
    {
        /// <summary>
        /// This implementation should use a string List, so don't change that!
        /// </summary>
        private List<string> _wordsList = new List<string>();

        public void Add(string text)
        {
            // TODO: Check the ITheHistory interface for more information
            throw new NotImplementedException();
        }

        public void Clear()
        {
            // TODO: Check the ITheHistory interface for more information
            throw new NotImplementedException();
        }

        public void RemoveWord(string wordToBeRemoved)
        {
            // TODO: Check the ITheHistory interface for more information
            throw new NotImplementedException();
        }

        public void ReplaceMoreWords(string[] fromWords, string[] toWords)
        {
            // TODO: Check the ITheHistory interface for more information
            throw new NotImplementedException();
        }

        public void ReplaceOneWord(string from, string to)
        {
            // TODO: Check the ITheHistory interface for more information
            throw new NotImplementedException();
        }

        // TODO: Check the ITheHistory interface for more information
        public int Size => throw new NotImplementedException();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string word in _wordsList)
            {
                sb.Append(word).Append(" ");
            }

            if (sb.Length > 0)
            {
                // Last Space Char
                sb.Remove(sb.Length - 1, 1);
            }

            return sb.ToString();
        }

        /// <summary>
        /// DON'T rewrite this method!
        /// Replaces all occurrences of sentences of words with sentences or words
        /// The tests are using this method instead of ReplaceOneWord() or ReplaceMoreWords()
        /// </summary>
        /// <param name="from">The sentence or word that needs to be replaced</param>
        /// <param name="to">The sentence or word which replaces the sentence found in 'from'</param>
        public void Replace(string from, string to)
        {
            string[] fromWords = from.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] toWords = to.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (fromWords.Length == 1 && toWords.Length == 1)
            {
                ReplaceOneWord(from, to);
            }
            else
            {
                ReplaceMoreWords(fromWords, toWords);
            }
        }
    }
}