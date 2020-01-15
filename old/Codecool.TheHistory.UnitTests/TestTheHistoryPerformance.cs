using Xunit;

namespace Codecool.TheHistory.UnitTests
{
    public class TestTheHistoryPerformance : TestBase
    {
        [Theory(Timeout = 5000)]
        [InlineData("Array")]
        [InlineData("List")]
        [InlineData("LinkedList")]
        public void Remove(string name)
        {
            Setup(name);

            var n = 250000;

            _theHistory.Add(Repeat("foo bar", n));
            _theHistory.RemoveWord("bar");

            Assert.Equal(n, _theHistory.Size);
        }

        [Theory(Timeout = 5000)]
        [InlineData("Array")]
        [InlineData("List")]
        [InlineData("LinkedList")]
        public void ReplaceOneWord(string name)
        {
            Setup(name);

            var n = 250_000;

            _theHistory.Add(Repeat("foo bar", n));
            _theHistory.Replace("bar", "baz");

            Assert.Equal(n * 2, _theHistory.Size);
        }

        [Theory(Timeout = 5000)]
        [InlineData("Array")]
        [InlineData("List")]
        [InlineData("LinkedList")]
        public void ReplaceMultipleWords__delete(string name)
        {
            Setup(name);

            var n = 250_000;

            _theHistory.Add(Repeat("x", n));
            _theHistory.Replace("x x x x x", "foo");

            Assert.Equal(n / 5, _theHistory.Size);
        }

        [Theory(Timeout = 5000)]
        [InlineData("Array")]
        [InlineData("List")]
        [InlineData("LinkedList")]
        public void ReplaceMultipleWords__insert(string name)
        {
            Setup(name);

            var n = 250_000;

            _theHistory.Add(Repeat("x", n));
            _theHistory.Replace("x x", "1 2 3 4");

            Assert.Equal(n * 2, _theHistory.Size);
        }

        [Theory(Timeout = 5000)]
        [InlineData("Array")]
        [InlineData("List")]
        [InlineData("LinkedList")]
        public void ReplaceMultipleWords__equal(string name)
        {
            Setup(name);

            var n = 250_000;

            _theHistory.Add(Repeat("x", n));
            _theHistory.Replace("x x", "y y");

            Assert.Equal(n, _theHistory.Size);
        }

        [Theory(Timeout = 5000)]
        [InlineData("Array")]
        [InlineData("List")]
        [InlineData("LinkedList")]
        public void RemoveInIliad(string name)
        {
            Setup(name);

            var n = 10;

            _theHistory.Add(Repeat(ReadIliad(), n));
            _theHistory.RemoveWord("king");
            _theHistory.RemoveWord("Zeus");
            _theHistory.RemoveWord("Apollo");
            _theHistory.RemoveWord("it");

            Assert.Equal(151969 * n, _theHistory.Size);
        }

        [Theory(Timeout = 5000)]
        [InlineData("Array")]
        [InlineData("List")]
        [InlineData("LinkedList")]
        public void ReplaceOneWordInIliad(string name)
        {
            Setup(name);

            var n = 10;

            _theHistory.Add(Repeat(ReadIliad(), n));
            _theHistory.Replace("Achilles", "Il");
            _theHistory.Replace("Agamemnon", "Il");
            _theHistory.Replace("Priam", "Trumm");
            _theHistory.Replace("chariot", "tank");
            _theHistory.Replace("bow", "missile");
            _theHistory.Replace("arrow", "nuke");
            _theHistory.Replace("the", "the");

            Assert.Equal(153268 * n, _theHistory.Size);
        }
    }
}
