using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace Codecool.TheHistory
{
   public class TheHistoryArray : TheHistoryAbstract
    {
        /// <summary>
        /// This implementation should use a string Array, so don't change that!
        /// </summary>
        private string[] _wordsArray = new string[0];

        private string[] _split;
        /// <summary>
        /// Don't change this either. It's needed for testing.
        /// </summary>
        public override IEnumerable<string> WordsList => _wordsArray;

        public override int Size => _split.Length;
        
        public override void Add(string text)
        {
            // TODO: Check the ITheHistory interface for more information

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

            foreach (var VARIABLE in _wordsArray)
            {
                Console.WriteLine(VARIABLE);
            }
            


          

            //string[] split = text.Split(new char[] { ' ', '\n', '\t' });

            //foreach (var word in split)
            //{
            //    if (word.Contains(' '))
            //    {
                    
            //    }
            //}
            
            
            
            //

            //foreach (var VARIABLE in split)
            //{
            //    if (VARIABLE.Contains(' ') | VARIABLE.Contains('\n') | VARIABLE.Contains('\t'))
            //    {
            //        VARIABLE.Remove();
            //    }
            //}
           
            //_wordsArray = _wordsArray.Concat(split).ToArray();
            //foreach (var VARIABLE in _wordsArray)
            //{
            //     Console.WriteLine(VARIABLE);
            //}
           
            
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