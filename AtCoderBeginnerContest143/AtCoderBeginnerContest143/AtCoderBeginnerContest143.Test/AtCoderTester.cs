using System;
using Xunit;
using AtCoderBeginnerContest143.Questions;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderBeginnerContest143.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"12 4", @"4")]
        [InlineData(@"20 15", @"0")]
        [InlineData(@"20 30", @"0")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
3 1 2", @"11")]
        [InlineData(@"7
5 0 7 8 3 3 2", @"312")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"10
aabbbbaaca", @"5")]
        [InlineData(@"5
aaaaa", @"1")]
        [InlineData(@"20
xxzaffeeeeddfkkkkllq", @"10")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
3 4 2 1", @"1")]
        [InlineData(@"3
1 1000 1", @"0")]
        [InlineData(@"7
218 786 704 233 645 728 389", @"23")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 2 5
1 2 3
2 3 3
2
3 2
1 3", @"0
1")]
        [InlineData(@"4 0 1
1
2 1", @"-1")]
        [InlineData(@"5 4 4
1 2 2
2 3 2
3 4 3
4 5 2
20
2 1
3 1
4 1
5 1
1 2
3 2
4 2
5 2
1 3
2 3
4 3
5 3
1 4
2 4
3 4
5 4
1 5
2 5
3 5
4 5", @"0
0
1
2
0
0
1
2
0
0
0
1
1
1
0
0
2
2
1
0")]
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
