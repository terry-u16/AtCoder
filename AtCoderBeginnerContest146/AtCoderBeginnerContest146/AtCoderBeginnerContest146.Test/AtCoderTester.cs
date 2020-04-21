using System;
using Xunit;
using AtCoderBeginnerContest146.Questions;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderBeginnerContest146.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"SAT", @"1")]
        [InlineData(@"SUN", @"7")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
ABCXYZ", @"CDEZAB")]
        [InlineData(@"0
ABCXYZ", @"ABCXYZ")]
        [InlineData(@"13
ABCDEFGHIJKLMNOPQRSTUVWXYZ", @"NOPQRSTUVWXYZABCDEFGHIJKLM")]
        [InlineData(@"26
ABCXYZ", @"ABCXYZ")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"10 7 100", @"9")]
        [InlineData(@"2 1 100000000000", @"1000000000")]
        [InlineData(@"1000000000 1000000000 100", @"0")]
        [InlineData(@"1234 56789 314159265", @"254309")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1 2
2 3", @"2
1
2")]
        [InlineData(@"8
1 2
2 3
2 4
2 5
4 7
5 6
6 8", @"4
1
2
3
4
1
1
2")]
        [InlineData(@"6
1 2
1 3
1 4
1 5
1 6", @"5
1
2
3
4
5")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"9 3
0001000100", @"1 3 2 3")]
        [InlineData(@"5 4
011110", @"-1")]
        [InlineData(@"6 6
0101010", @"6")]
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
