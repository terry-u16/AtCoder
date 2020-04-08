using System;
using Xunit;
using AtcoderBeginnerContest160.Questions;
using System.Collections.Generic;
using System.Linq;

namespace AtcoderBeginnerContest160.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"sippuu", @"Yes")]
        [InlineData(@"iphone", @"No")]
        [InlineData(@"coffee", @"Yes")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1024", @"2020")]
        [InlineData(@"0", @"0")]
        [InlineData(@"1000000000", @"2000000000")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"20 3
5 10 15", @"10")]
        [InlineData(@"20 3
0 5 15", @"10")]
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
        [InlineData(@"1 2 2 2 1
2 4
5 1
3", @"12")]
        [InlineData(@"2 2 2 2 2
8 6
9 1
2 1", @"25")]
        [InlineData(@"2 2 4 4 4
11 12 13 14
21 22 23 24
1 2 3 4", @"74")]
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
