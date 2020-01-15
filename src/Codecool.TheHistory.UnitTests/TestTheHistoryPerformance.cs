using System.Linq;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Codecool.TheHistory.UnitTests
{
    public class TestTheHistoryPerformance : TestBase
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly int _n;

        public TestTheHistoryPerformance(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _n = 250000;
        }

        [Theory(Timeout = 5000)]
        [MemberData(nameof(TestTypes))]
        public void Remove(string name)
        {
            Setup(name);

            var time = RunAndTime(() =>
            {
                _theHistory.Add(Repeat("foo bar", _n));
                _theHistory.RemoveWord("bar");

                _theHistory.Size.Should().Be(_n);
            });

            _testOutputHelper.WriteLine("Time: " + time + " ms");
        }

        [Theory(Timeout = 5000)]
        [MemberData(nameof(TestTypes))]
        public void ReplaceOneWord(string name)
        {
            Setup(name);

            var time = RunAndTime(() =>
            {
                _theHistory.Add(Repeat("foo bar", _n));
                _theHistory.Replace("bar", "baz");

                _theHistory.Size.Should().Be(_n * 2);
            });

            _testOutputHelper.WriteLine("Time: " + time + " ms");
        }

        [Theory(Timeout = 5000)]
        [MemberData(nameof(TestTypes))]
        public void ReplaceMultipleWords__delete(string name)
        {
            Setup(name);

            var time = RunAndTime(() => 
            {

                _theHistory.Add(Repeat("x", _n));
                _theHistory.Replace("x x x x x", "foo");

                _theHistory.Size.Should().Be(_n / 5);

            });

            _testOutputHelper.WriteLine("Time: " + time + " ms");
        }

        [Theory(Timeout = 5000)]
        [MemberData(nameof(TestTypes))]
        public void ReplaceMultipleWords__insert(string name)
        {
            Setup(name);

            var time = RunAndTime(() =>
            {
                _theHistory.Add(Repeat("x", _n));
                _theHistory.Replace("x x", "1 2 3 4");

                _theHistory.Size.Should().Be(_n * 2);
            });

            _testOutputHelper.WriteLine("Time: " + time + " ms");
        }

        [Theory(Timeout = 5000)]
        [MemberData(nameof(TestTypes))]
        public void ReplaceMultipleWords__equal(string name)
        {
            Setup(name);

            var time = RunAndTime(() => 
            {
                _theHistory.Add(Repeat("x", _n));
                _theHistory.Replace("x x", "y y");

                _theHistory.Size.Should().Be(_n);
            });

            _testOutputHelper.WriteLine("Time: " + time + " ms");
        }

        [Theory(Timeout = 5000)]
        [MemberData(nameof(TestTypes))]
        public void RemoveInIliad(string name)
        {
            Setup(name);

            var time = RunAndTime(() =>
            {
                _theHistory.Add(Repeat(ReadIliad(), 10));

                var targetLength = _theHistory.WordsList.Count(x => !x.Equals("king") && !x.Equals("Zeus") && !x.Equals("Apollo") && !x.Equals("it"));

                _theHistory.RemoveWord("king");
                _theHistory.RemoveWord("Zeus");
                _theHistory.RemoveWord("Apollo");
                _theHistory.RemoveWord("it");

                _theHistory.Size.Should().Be(targetLength);
            });

            _testOutputHelper.WriteLine("Time: " + time + " ms");
        }

        [Theory(Timeout = 5000)]
        [MemberData(nameof(TestTypes))]
        public void ReplaceOneWordInIliad(string name)
        {
            Setup(name);

            var time = RunAndTime(() =>
            {
                _theHistory.Add(Repeat(ReadIliad(), 10));

                var targetLength = _theHistory.Size;

                _theHistory.Replace("Achilles", "Il");
                _theHistory.Replace("Agamemnon", "Il");
                _theHistory.Replace("Priam", "Trumm");
                _theHistory.Replace("chariot", "tank");
                _theHistory.Replace("bow", "missile");
                _theHistory.Replace("arrow", "nuke");
                _theHistory.Replace("the", "the");

                _theHistory.Size.Should().Be(targetLength);
            });

            _testOutputHelper.WriteLine("Time: " + time + " ms");
        }
    }
}
