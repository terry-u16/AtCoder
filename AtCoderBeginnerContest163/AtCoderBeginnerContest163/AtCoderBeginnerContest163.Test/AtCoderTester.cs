using System;
using Xunit;
using AtCoderBeginnerContest163.Questions;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderBeginnerContest163.Test
{
    public class AtCoderTester
    {
        //[Theory]
        //[InlineData(@"1", @"6.28318530717958623200")]
        //[InlineData(@"73", @"458.67252742410977361942")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"41 2
5 6", @"30")]
        [InlineData(@"10 2
5 6", @"-1")]
        [InlineData(@"11 2
5 6", @"0")]
        [InlineData(@"314 15
9 26 5 35 8 9 79 3 23 8 46 2 6 43 3", @"9")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
1 1 2 2", @"2
2
0
0
0")]
        [InlineData(@"10
1 1 1 1 1 1 1 1 1", @"9
0
0
0
0
0
0
0
0
0")]
        [InlineData(@"7
1 2 3 4 5 6", @"1
1
1
1
1
1
0")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 2", @"10")]
        [InlineData(@"200000 200001", @"1")]
        [InlineData(@"141421 35623", @"220280457")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
1 3 4 2", @"20")]
        [InlineData(@"6
5 5 6 1 1 1", @"58")]
        [InlineData(@"6
8 6 9 1 2 1", @"85")]
        public void QuestionEReviewTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionEReview();

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
