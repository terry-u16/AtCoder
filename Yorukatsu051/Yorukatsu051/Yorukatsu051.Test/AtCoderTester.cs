using System;
using Xunit;
using Yorukatsu051.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu051.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"Sunny", @"Cloudy")]
        [InlineData(@"Rainy", @"Sunny")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
3 1 2
6 1 1", @"Yes")]
        [InlineData(@"1
2 100 100", @"No")]
        [InlineData(@"2
5 1 1
100 1 1", @"No")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1 10 100", @"Yes")]
        [InlineData(@"4
1 2 3 4", @"No")]
        [InlineData(@"3
1 4 1", @"Yes")]
        [InlineData(@"2
1 1", @"No")]
        [InlineData(@"6
2 7 1 8 2 8", @"Yes")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 8 2", @"3")]
        [InlineData(@"0 5 1", @"6")]
        [InlineData(@"9 9 2", @"0")]
        [InlineData(@"1 1000000000000000000 3", @"333333333333333333")]
        [InlineData(@"10 10 10", @"1")]
        [InlineData(@"0 10 10", @"2")]
        [InlineData(@"0 0 1", @"1")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3
1 2 1
1 3 1
2 3 3", @"1")]
        [InlineData(@"3 2
1 2 1
2 3 1", @"0")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 3
1 9
1 7
2 6
2 5
3 1", @"26")]
        [InlineData(@"7 4
1 1
2 1
3 1
4 6
4 5
4 5
4 5", @"25")]
        [InlineData(@"6 5
5 1000000000
2 990000000
3 980000000
6 970000000
6 960000000
4 950000000", @"4900000016")]
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
