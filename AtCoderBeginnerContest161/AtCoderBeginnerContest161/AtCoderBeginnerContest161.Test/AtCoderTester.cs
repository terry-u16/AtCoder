using System;
using Xunit;
using AtCoderBeginnerContest161.Questions;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderBeginnerContest161.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"1 2 3", @"3 1 2")]
        [InlineData(@"100 100 100", @"100 100 100")]
        [InlineData(@"41 59 31", @"31 41 59")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input);

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 1
5 4 2 1", @"Yes")]
        [InlineData(@"3 2
380 19 1", @"No")]
        [InlineData(@"12 3
4 56 78 901 2 345 67 890 123 45 6 789", @"Yes")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input);

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"7 4", @"1")]
        [InlineData(@"2 6", @"2")]
        [InlineData(@"1000000000000000000 1", @"0")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"15", @"23")]
        [InlineData(@"1", @"1")]
        [InlineData(@"13", @"21")]
        [InlineData(@"100000", @"3234566667")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"11 3 2
ooxxxoxxxoo", @"6
")]
        [InlineData(@"5 2 3
ooxoo", @"1
5
")]
        [InlineData(@"5 1 0
ooooo", @"")]
        [InlineData(@"16 4 3
ooxxoxoxxxoxoxxo", @"11
16")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input);

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"15", @"23")]
        [InlineData(@"1", @"1")]
        [InlineData(@"13", @"21")]
        [InlineData(@"100000", @"3234566667")]
        public void QuestionD_ReviewTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD_Review();

            var answers = question.Solve(input).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"11 3 2
ooxxxoxxxoo", @"6")]
        [InlineData(@"5 2 3
ooxoo", @"1
5")]
        [InlineData(@"5 1 0
ooooo", null)]
        [InlineData(@"16 4 3
ooxxoxoxxxoxoxxo", @"11
16")]
        public void QuestionE_ReviewTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE_Review();

            var answers = question.Solve(input).ToArray();

            Assert.Equal(outputs, answers);
        }

        IEnumerable<string> SplitByNewLine(string input) => input?.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None) ?? new string[0];
    }
}
