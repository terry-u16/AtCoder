using System;
using Xunit;
using Yorukatsu057.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu057.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"3
10 2 5
6 3 4", @"5")]
        [InlineData(@"4
13 21 6 19
11 30 6 15", @"6")]
        [InlineData(@"1
1
50", @"0")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1214
4", @"2")]
        [InlineData(@"3
157", @"3")]
        [InlineData(@"299792458
9460730472580800", @"2")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1 0 1
2 1 2
1 0 1", @"Yes")]
        [InlineData(@"2 2 2
2 1 2
2 2 2", @"No")]
        [InlineData(@"0 8 8
0 8 8
0 8 8", @"Yes")]
        [InlineData(@"1 8 6
2 9 7
0 7 7", @"No")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3", @"2")]
        [InlineData(@"2 2", @"0")]
        [InlineData(@"999999 999999", @"151840682")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 5
4 2 1
2 3 1", @"2")]
        [InlineData(@"3 8
4 2 1
2 3 1", @"0")]
        [InlineData(@"11 14
3 1 4 1 5 9 2 6 5 3 5
8 9 7 9 3 2 3 8 4 6 2", @"12")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"A??C", @"8")]
        [InlineData(@"ABCBC", @"3")]
        [InlineData(@"????C?????B??????A???????", @"979596887")]
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
