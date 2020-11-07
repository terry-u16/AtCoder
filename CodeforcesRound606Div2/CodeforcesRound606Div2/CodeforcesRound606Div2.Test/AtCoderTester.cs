using System;
using Xunit;
using CodeforcesRound606Div2.Questions;
using System.Collections.Generic;
using System.Linq;

namespace CodeforcesRound606Div2.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"6
18
1
9
100500
33
1000000000", @"10
1
9
45
12
81")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
6
40 6 40 3 20 1
1
1024
4
2 4 8 16
3
3 1 7", @"4
10
4
0")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
7 7 3 5
1 2
2 3
3 4
4 5
5 6
6 7
7 5
4 5 2 3
1 2
2 3
3 4
4 1
4 2
4 3 2 1
1 2
2 3
4 1", @"4
0
1")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        IEnumerable<string> SplitByNewLine(string input) => input?.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None) ?? new string[0];
    }
}
