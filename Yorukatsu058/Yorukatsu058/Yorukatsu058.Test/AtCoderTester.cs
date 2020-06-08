using System;
using Xunit;
using Yorukatsu058.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu058.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"3
3 1 2
2 5 4
3 6", @"14")]
        [InlineData(@"4
2 3 4 1
13 5 8 24
45 9 15", @"74")]
        [InlineData(@"2
1 2
50 50
50", @"150")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"7
3 1 4 1 5 9 2", @"4")]
        [InlineData(@"10
0 1 2 3 4 5 6 7 8 9", @"3")]
        [InlineData(@"1
99999", @"1")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 2
8 7 6
rsrpr", @"27")]
        [InlineData(@"7 1
100 10 1
ssssppr", @"211")]
        [InlineData(@"30 5
325 234 123
rspsspspsrpspsppprpsprpssprpsr", @"4996")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"-9", @"1011")]
        [InlineData(@"123456789", @"11000101011001101110100010101")]
        [InlineData(@"0", @"0")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
2 5 4 6", @"5")]
        [InlineData(@"9
0 0 0 0 0 0 0 0 0", @"45")]
        [InlineData(@"19
885 8 1 128 83 32 256 206 639 16 4 128 689 32 8 64 885 969 1", @"37")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1 1
5 1
5 5", @"1")]
        [InlineData(@"2
10 10
20 20", @"0")]
        [InlineData(@"9
1 1
2 1
3 1
4 1
5 1
1 2
1 3
1 4
1 5", @"16")]
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
