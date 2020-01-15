using Xunit;

namespace Codecool.TheHistory.UnitTests
{
    public class TestTheHistoryCorrectness : TestBase
    {
        [Theory]
        [InlineData("Array")]
        [InlineData("List")]
        [InlineData("LinkedList")]
        public void Add_Simple(string name)
        {
            Setup(name);

            _theHistory.Add("abc def ghi");
            Assert.Equal("abc def ghi", _theHistory.ToString());
            _theHistory.Add("x y z w");
            Assert.Equal("abc def ghi x y z w", _theHistory.ToString());
        }

        [Theory]
        [InlineData("Array")]
        [InlineData("List")]
        [InlineData("LinkedList")]
        public void Add_MultipleSpaces(string name)
        {
            Setup(name);

            _theHistory.Add("multiple       spaces");
            Assert.Equal("multiple spaces", _theHistory.ToString());
            Assert.Equal(2, _theHistory.Size);
        }

        [Theory]
        [InlineData("Array")]
        [InlineData("List")]
        [InlineData("LinkedList")]
        public void Add_OtherWhitespace(string name)
        {
            Setup(name);

            _theHistory.Add("newlines\nand tabs\ttoo");
            Assert.Equal("newlines and tabs too", _theHistory.ToString());
            Assert.Equal(4, _theHistory.Size);
        }

        [Theory]
        [InlineData("Array")]
        [InlineData("List")]
        [InlineData("LinkedList")]
        public void Size(string name)
        {
            Setup(name);

            Assert.Equal(0, _theHistory.Size);
            _theHistory.Add("abc def ghi");
            Assert.Equal(3, _theHistory.Size);
        }

        [Theory]
        [InlineData("Array")]
        [InlineData("List")]
        [InlineData("LinkedList")]
        public void Clear(string name)
        {
            Setup(name);

            _theHistory.Add("abc def ghi");
            Assert.NotEqual("", _theHistory.ToString());

            _theHistory.Clear();
            Assert.Equal("", _theHistory.ToString());
        }

        [Theory]
        [InlineData("Array")]
        [InlineData("List")]
        [InlineData("LinkedList")]
        public void ReplaceOneWord_Simple(string name)
        {
            Setup(name);

            _theHistory.Add("abc def ghi abc def ghi");
            _theHistory.Replace("abc", "ABC");
            _theHistory.Replace("def", "DEF");

            Assert.Equal("ABC DEF ghi ABC DEF ghi", _theHistory.ToString());
        }

        [Theory]
        [InlineData("Array")]
        [InlineData("List")]
        [InlineData("LinkedList")]
        public void ReplaceOneWord_PartOfWordOnly(string name)
        {
            Setup(name);

            _theHistory.Add("carpet car motorcar Nicaragua");
            _theHistory.Replace("car", "AUTOMOBILE");

            Assert.Equal("carpet AUTOMOBILE motorcar Nicaragua", _theHistory.ToString());
        }

        [Theory]
        [InlineData("Array")]
        [InlineData("List")]
        [InlineData("LinkedList")]
        public void RemoveWord_Found(string name)
        {
            Setup(name);

            _theHistory.Add("hello world hello hello world");
            _theHistory.RemoveWord("hello");
            Assert.Equal("world world", _theHistory.ToString());
        }

        [Theory]
        [InlineData("Array")]
        [InlineData("List")]
        [InlineData("LinkedList")]
        public void RemoveWord_NotFound(string name)
        {
            Setup(name);

            _theHistory.Add("hello world hello hello world");
            _theHistory.RemoveWord("x");
            Assert.Equal("hello world hello hello world", _theHistory.ToString());
        }

        [Theory]
        [InlineData("Array")]
        [InlineData("List")]
        [InlineData("LinkedList")]
        public void ReplaceMoreWords_Equal(string name)
        {
            Setup(name);

            _theHistory.Add("replace me replace me me replace me");
            _theHistory.Replace("replace me", "HAPPY FUN");
            Assert.Equal("HAPPY FUN HAPPY FUN me HAPPY FUN", _theHistory.ToString());
        }

        [Theory]
        [InlineData("Array")]
        [InlineData("List")]
        [InlineData("LinkedList")]
        public void ReplaceMoreWords_Insert(string name)
        {
            Setup(name);

            _theHistory.Add("x y z x y z w");
            _theHistory.Replace("x y", "X X Y Y");
            Assert.Equal("X X Y Y z X X Y Y z w", _theHistory.ToString());
        }

        [Theory]
        [InlineData("Array")]
        [InlineData("List")]
        [InlineData("LinkedList")]
        public void ReplaceMoreWords_Delete(string name)
        {
            Setup(name);

            _theHistory.Add("x y z x y z w");
            _theHistory.Replace("x y", "XY");
            Assert.Equal("XY z XY z w", _theHistory.ToString());
        }

        [Theory]
        [InlineData("Array")]
        [InlineData("List")]
        [InlineData("LinkedList")]
        public void ReplaceMoreWords_NotFound(string name)
        {
            Setup(name);

            _theHistory.Add("replace me replace me me replace me");
            _theHistory.Replace("replace replace me", "HAPPY FUN");
            Assert.Equal("replace me replace me me replace me", _theHistory.ToString());
        }

        [Theory]
        [InlineData("Array")]
        [InlineData("List")]
        [InlineData("LinkedList")]
        public void ReplaceMoreWords__MultipleRuns(string name)
        {
            Setup(name);

            _theHistory.Add("x x x y x x x x y x x");
            _theHistory.Replace("x x", "XX");
            Assert.Equal("XX x y XX XX y XX", _theHistory.ToString());
        }

        [Theory]
        [InlineData("Array")]
        [InlineData("List")]
        [InlineData("LinkedList")]
        public void ReplaceMoreWords__Everything(string name)
        {
            Setup(name);

            var text = "this is the text that I would like to be replaced";
            _theHistory.Add(text);
            _theHistory.Replace(text, "everything");
            Assert.Equal("everything", _theHistory.ToString());
        }

        [Theory]
        [InlineData("Array")]
        [InlineData("List")]
        [InlineData("LinkedList")]
        public void ReplaceMoreWords__EndOfString(string name)
        {
            Setup(name);


            _theHistory.Add("end of string end of");
            _theHistory.Replace("end of string", "END OF STRING");
            Assert.Equal("END OF STRING end of", _theHistory.ToString());
        }

        [Theory]
        [InlineData("Array")]
        [InlineData("List")]
        [InlineData("LinkedList")]
        public void ReplaceMoreWords__ExtendPart(string name)
        {
            Setup(name);

            _theHistory.Add("Il Pet Il Pet");
            _theHistory.Replace("Il", "Pet Il");
            Assert.Equal("Pet Il Pet Pet Il Pet", _theHistory.ToString());
        }

        [Theory]
        [InlineData("Array")]
        [InlineData("List")]
        [InlineData("LinkedList")]
        public void ReplaceMoreWords__PartOfWordOnly(string name)
        {
            Setup(name);

            _theHistory.Add("foo bar baz");

            _theHistory.Replace("o b", "X");
            Assert.Equal("foo bar baz", _theHistory.ToString());

            _theHistory.Replace("foo b", "X");
            Assert.Equal("foo bar baz", _theHistory.ToString());

            _theHistory.Replace("o bar", "X");
            Assert.Equal("foo bar baz", _theHistory.ToString());

            _theHistory.Replace("o bar b", "X");
            Assert.Equal("foo bar baz", _theHistory.ToString());
        }
    }
}
