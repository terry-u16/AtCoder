using System;
using Xunit;
using Yorukatsu050.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu050.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"2 2919", @"3719")]
        [InlineData(@"22 3051", @"3051")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
3 2 2 4 1
1 2 2 2 1", @"14")]
        [InlineData(@"4
1 1 1 1
1 1 1 1", @"5")]
        [InlineData(@"7
3 3 4 5 4 5 3
5 3 4 4 2 3 2", @"29")]
        [InlineData(@"1
2
3", @"5")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
1 2 2 1", @"2")]
        [InlineData(@"5
3 1 2 3 1", @"5")]
        [InlineData(@"8
4 23 75 0 23 96 50 100", @"221")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
2 2 4", @"4 0 4")]
        [InlineData(@"5
3 8 7 5 5", @"2 4 12 2 8")]
        [InlineData(@"3
1000000000 1000000000 0", @"0 2000000000 0")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"FTFFTFFF
4 2", @"Yes")]
        [InlineData(@"FTFFTFFF
-2 -2", @"Yes")]
        [InlineData(@"FF
1 0", @"No")]
        [InlineData(@"TF
1 0", @"No")]
        [InlineData(@"FFTTFF
0 0", @"Yes")]
        [InlineData(@"TTTT
1 0", @"No")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"11 3 2
ooxxxoxxxoo", @"6")]
        [InlineData(@"5 2 3
ooxoo", @"1
5")]
        [InlineData(@"5 1 0
ooooo", @"")]
        [InlineData(@"16 4 3
ooxxoxoxxxoxoxxo", @"11
16")]
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
