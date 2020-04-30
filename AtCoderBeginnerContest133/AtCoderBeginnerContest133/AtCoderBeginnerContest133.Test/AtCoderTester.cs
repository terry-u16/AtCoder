using System;
using Xunit;
using AtCoderBeginnerContest133.Questions;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderBeginnerContest133.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"4 2 9", @"8")]
        [InlineData(@"4 2 7", @"7")]
        [InlineData(@"4 2 8", @"8")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 2
1 2
5 5
-2 8", @"1")]
        [InlineData(@"3 4
-3 7 8 2
-12 1 10 2
-2 8 9 3", @"2")]
        [InlineData(@"5 1
1
2
3
4
5", @"10")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2020 2040", @"2")]
        [InlineData(@"4 5", @"20")]
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
        [InlineData(@"4 3
1 2
2 3
3 4", @"6")]
        [InlineData(@"5 4
1 2
1 3
1 4
4 5", @"48")]
        [InlineData(@"16 22
12 1
3 1
4 16
7 12
6 2
2 15
5 16
14 16
10 11
3 10
3 13
8 6
16 8
9 12
4 3", @"271414432")]
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
