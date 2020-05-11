using System;
using Xunit;
using Yorukatsu037.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu037.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"ABA", @"Yes")]
        [InlineData(@"BBA", @"Yes")]
        [InlineData(@"BBB", @"No")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 3
10
15
11
14
12", @"2")]
        [InlineData(@"5 3
5
7
5
7
7", @"0")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 9 2 3", @"2")]
        [InlineData(@"10 40 6 8", @"23")]
        [InlineData(@"314159265358979323 846264338327950288 419716939 937510582", @"532105071133627368")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 2
3
2 1 1", @"1 1
2 3")]
        [InlineData(@"3 5
5
1 2 3 4 5", @"1 4 4 4 3
2 5 4 5 3
2 5 5 5 3")]
        [InlineData(@"1 1
1
1", @"1")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
1 -3 1 0", @"4")]
        [InlineData(@"5
3 -6 4 -5 7", @"0")]
        [InlineData(@"6
-1 4 3 2 -5 4", @"8")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
1 5
3 3", @"3")]
        [InlineData(@"3
6 5
-1 10
3 3", @"5")]
        [InlineData(@"4
7 10
-10 3
4 3
-4 3", @"16")]
        [InlineData(@"20
-8 1
26 4
0 5
9 1
19 4
22 20
28 27
11 8
-3 20
-25 17
10 4
-18 27
24 28
-11 19
2 27
-2 18
-1 12
-24 29
31 29
29 7", @"110")]
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
