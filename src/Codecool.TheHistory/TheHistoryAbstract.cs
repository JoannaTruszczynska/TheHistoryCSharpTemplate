using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codecool.TheHistory
{
    public abstract class TheHistoryAbstract : ITheHistory
    {
        public abstract IEnumerable<string> WordsList { get; }
        public virtual int Size => WordsList.Count();

        public abstract void Add(string text);
        public abstract void RemoveWord(string wordToBeRemoved);
        public abstract void Clear();
        public abstract void ReplaceOneWord(string @from, string to);
        public abstract void ReplaceMoreWords(string[] fromWords, string[] toWords);

        /// <summary>
        /// DON'T rewrite this method!
        /// Replaces all occurrences of sentences of words with sentences or words
        /// The tests are using this method instead of ReplaceOneWord() or ReplaceMoreWords()
        /// </summary>
        /// <param name="from">The sentence or word that needs to be replaced</param>
        /// <param name="to">The sentence or word which replaces the sentence found in 'from'</param>
        public void Replace(string from, string to)
        {
            var fromWords = from.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var toWords = to.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (fromWords.Length == 1 && toWords.Length == 1)
            {
                ReplaceOneWord(from, to);
            }
            else
            {
                ReplaceMoreWords(fromWords, toWords);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var word in WordsList)
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
    }
}