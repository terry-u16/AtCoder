using System;
using Xunit;
using Yorukatsu053.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu053.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"4
3", @"10")]
        [InlineData(@"10
10", @"76")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
2100 2500 2700 2700", @"2 2")]
        [InlineData(@"5
1100 1900 2800 3200 3200", @"3 5")]
        [InlineData(@"20
800 810 820 830 840 850 860 870 880 890 900 910 920 930 940 950 960 970 980 990", @"1 1")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6
1 2 3 4 5 6", @"1")]
        [InlineData(@"2
10 -10", @"20")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3", @"4")]
        [InlineData(@"6", @"30")]
        [InlineData(@"1000", @"972926972")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
2 0
3 1
1 3
4 2
0 4
5 5", @"2")]
        [InlineData(@"3
0 0
1 1
5 2
2 3
3 4
4 5", @"2")]
        [InlineData(@"2
2 2
3 3
0 0
1 1", @"0")]
        [InlineData(@"5
0 0
7 3
2 2
4 8
1 6
8 5
6 9
5 4
9 1
3 7", @"5")]
        [InlineData(@"5
0 0
1 1
5 5
6 6
7 7
2 2
3 3
4 4
8 8
9 9", @"4")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1 5
3 9
7 8", @"3")]
        [InlineData(@"6
8 3
4 9
12 19
18 1
13 5
7 6", @"8")]
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
