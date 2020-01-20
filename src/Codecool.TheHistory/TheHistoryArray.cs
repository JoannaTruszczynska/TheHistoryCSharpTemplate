using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Channels;

namespace Codecool.TheHistory
{
   public class TheHistoryArray : TheHistoryAbstract
    {
        /// <summary>
        /// This implementation should use a string Array, so don't change that!
        /// </summary>
        private string[] _wordsArray = new string[0];

        private string[] _split;
        private string[] arrayTemp;
        /// <summary>
        /// Don't change this either. It's needed for testing.
        /// </summary>
        public override IEnumerable<string> WordsList => _wordsArray;

        public override int Size => _wordsArray.Length;
        
        public override void Add(string text)
        {
            string textTemp = null;
            int index = 0;
            while (index < text.Length)
            {
                if (!(text[index].ToString().Equals(" ")|text[index].ToString().Equals("\n")|text[index].ToString().Equals("\t")))

                {
                    textTemp = textTemp + text[index];
                    index += 1;
                }
                else
                {
                    int next = 1;
                    while (text[index+next].ToString().Equals(" ")|text[index+next].ToString().Equals("\n")|text[index+next].ToString().Equals("\t"))
                    {
                        next += 1;
                    }

                    textTemp = textTemp + text[index];
                    index = index + next;
                }
            }
            _split = textTemp.Split(new char[] { ' ', '\n', '\t' });
            _wordsArray = _wordsArray.Concat(_split).ToArray();
           
        }

        public override void Clear()
        {
           _wordsArray = Array.Empty<string>();
        }

        public override void RemoveWord(string wordToBeRemoved)
        {
            _wordsArray = _wordsArray.Where(w => w != wordToBeRemoved).ToArray();
        }

        public override void ReplaceMoreWords(string[] fromWords, string[] toWords)
        {
            // TODO: Check the ITheHistory interface for more information
            throw new NotImplementedException();
            //int indexFromWords = 0;
            //int index = 0;
            //while (indexFromWords < fromWords.Length )
            //{
            //    while (index < _wordsArray.Length)
            //    {
            //        if (fromWords[indexFromWords] == _wordsArray[index])
            //        {
                        
            //        }
            //    }
            //}
            
            
            //for (int indexFromWords = 0; indexFromWords < fromWords.Length-1; indexFromWords++)
            //{
            //    for (int index = 0; index < _wordsArray.Length - 1; index++)
            //    {
            //        if (fromWords[indexFromWords] == _wordsArray[index])
            //        {

            //        }
            //    }
            //}
        }

        public override void ReplaceOneWord(string from, string to)
        {
            for (int index = 0; index < _wordsArray.Length; index++)
            {
                if (_wordsArray[index] == from)
                {
                    _wordsArray[index] = to;
                }
            }
        }
    }
}