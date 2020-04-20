using System;
using Xunit;
using AtCoderBeginnerContest147.Questions;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderBeginnerContest147.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"5 7 9", @"win")]
        [InlineData(@"13 7 2", @"bust")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"redcoder", @"1")]
        [InlineData(@"vvvvvv", @"0")]
        [InlineData(@"abcdabc", @"2")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1
2 1
1
1 1
1
2 0", @"2")]
        [InlineData(@"3
2
2 1
3 0
2
3 1
1 0
2
1 1
2 0", @"0")]
        [InlineData(@"2
1
2 0
1
1 0", @"1")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1 2 3", @"6")]
        [InlineData(@"10
3 1 4 1 5 9 2 6 5 3", @"237")]
        [InlineData(@"10
3 14 159 2653 58979 323846 2643383 27950288 419716939 9375105820", @"103715602")]
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
