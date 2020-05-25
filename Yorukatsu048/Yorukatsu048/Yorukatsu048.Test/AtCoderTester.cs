using System;
using Xunit;
using Yorukatsu048.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu048.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"8 3 4", @"4")]
        [InlineData(@"8 0 4", @"0")]
        [InlineData(@"6 2 4", @"2")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
0 0
1 0
0 1", @"2.2761423749")]
        [InlineData(@"2
-879 981
-866 890", @"91.9238815543")]
        [InlineData(@"8
-406 10
512 859
494 362
-955 -475
128 553
-986 -885
763 77
449 310", @"7641.9817824387")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1 6", @"2")]
        [InlineData(@"12345 678901", @"175897")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 2 4", @"5
4
1
0")]
        [InlineData(@"3 1 3", @"3
0")]
        [InlineData(@"7 3 7", @"7
8
4
2
0
0")]
        [InlineData(@"10 4 8", @"10
12
10
8
4
1
0
0
0")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 5", @"0")]
        [InlineData(@"4 5", @"2")]
        [InlineData(@"5 5", @"4")]
        [InlineData(@"100000 2", @"1")]
        [InlineData(@"100000 100000", @"50000")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3 10
1 2 20
2 3 30
1 3 45", @"35")]
        [InlineData(@"2 2 10
1 2 100
2 2 100", @"-1")]
        [InlineData(@"4 5 10
1 2 1
1 4 1
3 4 1
2 2 100
3 3 100", @"0")]
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
