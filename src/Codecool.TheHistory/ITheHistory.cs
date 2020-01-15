using System.Collections.Generic;

/*
 * START THE ASSIGNMENT BY READING/UNDERSTANDING THIS FILE!
 * 
 * If we want to implement functionalities which share common features with different implementations,
 * we can use an interface. An interface in C# contains method declarations, without implementation.
 * If a concrete (not abstract) class implements an interface, it has to implement all it's methods.
 * 
 * Why it's good? Because if a class implements an interface we can use polymorphism to access the class' instance
 * through any of the interface it implements. That's what we are using in unit tests (TestBase.cs) to avoid duplicate
 * test case implementations.
*/
namespace Codecool.TheHistory
{
    public interface ITheHistory
    {
        IEnumerable<string> WordsList { get; }

        /// <summary>
        /// Splits the incoming text to words and adds the words to the container of the implementing class
        /// </summary>
        /// <param name="text">A string containing words from the stored data</param>
        void Add(string text);

        /// <summary>
        /// Removes all occurrences of a word from the stored data.
        /// </summary>
        /// <param name="wordToBeRemoved"></param>
        void RemoveWord(string wordToBeRemoved);

        /// <summary>
        /// Empties the stored text
        /// </summary>
        void Clear();

        /// <summary>
        /// Replaces all occurrences of a word to another word
        /// NOTE: Replace() method uses this method!
        /// </summary>
        /// <param name="from">All occurrences of this word will be replaced</param>
        /// <param name="to">All occurrences of this 'from' will be replaced with this word</param>
        void ReplaceOneWord(string from, string to);

        /// <summary>
        /// Replaces all occurrences of a sentence or part of a sentence with another (part of a) sentence
        /// The order of words is important. Also the 'fromWords' and 'toWords' arrays are not necessarily same sized.
        /// NOTE: Replace() method uses this method!
        /// </summary>
        /// <param name="fromWords">Array of words that should be replaced</param>
        /// <param name="toWords">Array of words which should replace the words of 'fromWords'</param>
        void ReplaceMoreWords(string[] fromWords, string[] toWords);

        /// <summary>
        /// DON'T rewrite this method!
        /// Replaces all occurrences of sentences of words with sentences or words
        /// The tests are using this method instead of ReplaceOneWord() or ReplaceMoreWords()
        /// </summary>
        /// <param name="from">The sentence or word that needs to be replaced</param>
        /// <param name="to">The sentence or word which replaces the sentence found in 'from'</param>
        void Replace(string from, string to);

        /// <summary>
        /// Returns the number of words in the stored text
        /// </summary>
        int Size { get; }
    }
}