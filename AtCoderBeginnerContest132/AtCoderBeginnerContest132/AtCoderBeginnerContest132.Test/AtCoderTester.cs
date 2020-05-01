using System;
using Xunit;
using AtCoderBeginnerContest132.Questions;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderBeginnerContest132.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"ASSA", @"Yes")]
        [InlineData(@"STOP", @"No")]
        [InlineData(@"FFEE", @"Yes")]
        [InlineData(@"FREE", @"No")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
1 3 5 4 2", @"2")]
        [InlineData(@"9
9 6 3 2 5 8 7 4 1", @"5")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6
9 1 4 4 6 7", @"2")]
        [InlineData(@"8
9 1 14 5 5 4 4 14", @"0")]
        [InlineData(@"14
99592 10342 29105 78532 83018 11639 92015 77204 30914 21912 34519 80835 100000 1", @"42685")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 3", @"3
6
1")]
        [InlineData(@"2000 3", @"1998
3990006
327341989")]
        [InlineData(@"2 2", @"1
0")]
        [InlineData(@"2 1", @"2")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 4
1 2
2 3
3 4
4 1
1 3", @"2")]
        [InlineData(@"3 3
1 2
2 3
3 1
1 2", @"-1")]
        [InlineData(@"2 0
1 2", @"-1")]
        [InlineData(@"6 8
1 2
2 3
3 4
4 5
5 1
1 4
1 5
4 6
1 6", @"2")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        IEnumerable<string> SplitByNewLine(string input) => input?.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None) ?? new string[0];
    }
}
