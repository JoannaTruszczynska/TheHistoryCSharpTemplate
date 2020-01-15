using FluentAssertions;
using Xunit;

namespace Codecool.TheHistory.UnitTests
{
    public class TestTheHistoryCorrectness : TestBase
    {
        [Theory]
        [MemberData(nameof(TestTypes))]
        public void Add_Simple(string name)
        {
            Setup(name);

            _theHistory.Add("abc def ghi");
            _theHistory.ToString().Should().Be("abc def ghi");

            _theHistory.Add("x y z w");
            _theHistory.ToString().Should().Be("abc def ghi x y z w");
        }

        [Theory]
        [MemberData(nameof(TestTypes))]
        public void Add_MultipleSpaces(string name)
        {
            Setup(name);

            _theHistory.Add("multiple       spaces");
            _theHistory.ToString().Should().Be("multiple spaces");
            _theHistory.Size.Should().Be(2);
        }

        [Theory]
        [MemberData(nameof(TestTypes))]
        public void Add_OtherWhitespace(string name)
        {
            Setup(name);

            _theHistory.Add("newlines\nand tabs\ttoo");
            _theHistory.ToString().Should().Be("newlines and tabs too");
            _theHistory.Size.Should().Be(4);
        }

        [Theory]
        [MemberData(nameof(TestTypes))]
        public void Size(string name)
        {
            Setup(name);

            _theHistory.Size.Should().Be(0);
            _theHistory.Add("abc def ghi");
            _theHistory.Size.Should().Be(3);
        }

        [Theory]
        [MemberData(nameof(TestTypes))]
        public void Clear(string name)
        {
            Setup(name);

            _theHistory.Add("abc def ghi");
            _theHistory.ToString().Should().NotBe("");

            _theHistory.Clear();
            _theHistory.ToString().Should().Be("");
        }

        [Theory]
        [MemberData(nameof(TestTypes))]
        public void ReplaceOneWord_Simple(string name)
        {
            Setup(name);

            _theHistory.Add("abc def ghi abc def ghi");
            _theHistory.Replace("abc", "ABC");
            _theHistory.Replace("def", "DEF");
            _theHistory.ToString().Should().Be("ABC DEF ghi ABC DEF ghi");
        }

        [Theory]
        [MemberData(nameof(TestTypes))]
        public void ReplaceOneWord_PartOfWordOnly(string name)
        {
            Setup(name);

            _theHistory.Add("carpet car motorcar Nicaragua");
            _theHistory.Replace("car", "AUTOMOBILE");
            _theHistory.ToString().Should().Be("carpet AUTOMOBILE motorcar Nicaragua");
        }

        [Theory]
        [MemberData(nameof(TestTypes))]
        public void RemoveWord_Found(string name)
        {
            Setup(name);

            _theHistory.Add("hello world hello hello world");
            _theHistory.RemoveWord("hello");
            _theHistory.ToString().Should().Be("world world");
        }

        [Theory]
        [MemberData(nameof(TestTypes))]
        public void RemoveWord_NotFound(string name)
        {
            Setup(name);

            _theHistory.Add("hello world hello hello world");
            _theHistory.RemoveWord("x");
            _theHistory.ToString().Should().Be("hello world hello hello world");
        }

        [Theory]
        [MemberData(nameof(TestTypes))]
        public void ReplaceMoreWords_Equal(string name)
        {
            Setup(name);

            _theHistory.Add("replace me replace me me replace me");
            _theHistory.Replace("replace me", "HAPPY FUN");
            _theHistory.ToString().Should().Be("HAPPY FUN HAPPY FUN me HAPPY FUN");
        }

        [Theory]
        [MemberData(nameof(TestTypes))]
        public void ReplaceMoreWords_Insert(string name)
        {
            Setup(name);

            _theHistory.Add("x y z x y z w");
            _theHistory.Replace("x y", "X X Y Y");
            _theHistory.ToString().Should().Be("X X Y Y z X X Y Y z w");
        }

        [Theory]
        [MemberData(nameof(TestTypes))]
        public void ReplaceMoreWords_Delete(string name)
        {
            Setup(name);

            _theHistory.Add("x y z x y z w");
            _theHistory.Replace("x y", "XY");
            _theHistory.ToString().Should().Be("XY z XY z w");
        }

        [Theory]
        [MemberData(nameof(TestTypes))]
        public void ReplaceMoreWords_NotFound(string name)
        {
            Setup(name);

            _theHistory.Add("replace me replace me me replace me");
            _theHistory.Replace("replace replace me", "HAPPY FUN");
            _theHistory.ToString().Should().Be("replace me replace me me replace me");
        }

        [Theory]
        [MemberData(nameof(TestTypes))]
        public void ReplaceMoreWords__MultipleRuns(string name)
        {
            Setup(name);

            _theHistory.Add("x x x y x x x x y x x");
            _theHistory.Replace("x x", "XX");
            _theHistory.ToString().Should().Be("XX x y XX XX y XX");
        }

        [Theory]
        [MemberData(nameof(TestTypes))]
        public void ReplaceMoreWords__Everything(string name)
        {
            Setup(name);

            var text = "this is the text that I would like to be replaced";
            _theHistory.Add(text);
            _theHistory.Replace(text, "everything");
            _theHistory.ToString().Should().Be("everything");
        }

        [Theory]
        [MemberData(nameof(TestTypes))]
        public void ReplaceMoreWords__EndOfString(string name)
        {
            Setup(name);

            _theHistory.Add("end of string end of");
            _theHistory.Replace("end of string", "END OF STRING");
            _theHistory.ToString().Should().Be("END OF STRING end of");
        }

        [Theory]
        [MemberData(nameof(TestTypes))]
        public void ReplaceMoreWords__ExtendPart(string name)
        {
            Setup(name);

            _theHistory.Add("Il Pet Il Pet");
            _theHistory.Replace("Il", "Pet Il");
            _theHistory.ToString().Should().Be("Pet Il Pet Pet Il Pet");
        }

        [Theory]
        [MemberData(nameof(TestTypes))]
        public void ReplaceMoreWords__PartOfWordOnly(string name)
        {
            Setup(name);

            _theHistory.Add("foo bar baz");

            _theHistory.Replace("o b", "X");
            _theHistory.ToString().Should().Be("foo bar baz");

            _theHistory.Replace("foo b", "X");
            _theHistory.ToString().Should().Be("foo bar baz");

            _theHistory.Replace("o bar", "X");
            _theHistory.ToString().Should().Be("foo bar baz");

            _theHistory.Replace("o bar b", "X");
            _theHistory.ToString().Should().Be("foo bar baz");
        }
    }
}
