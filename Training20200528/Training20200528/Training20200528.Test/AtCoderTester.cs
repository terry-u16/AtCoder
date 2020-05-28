using System;
using Xunit;
using Training20200528.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Training20200528.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"3
2 3
1 1
3 2", @"10")]
        [InlineData(@"4
1 1
1 1
1 5
1 100", @"101")]
        [InlineData(@"5
3 10
48 17
31 199
231 23
3 2", @"6930")]
        [InlineData(@"2
1 0
1 100", @"101")]
        [InlineData(@"2
1 0
100 1", @"101")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 700
3 500
5 800", @"3")]
        [InlineData(@"2 2000
3 500
5 800", @"7")]
        [InlineData(@"2 400
3 500
5 800", @"2")]
        [InlineData(@"5 25000
20 1000
40 1000
50 1000
30 1000
1 1000", @"66")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 2
1 7 2
7 8 1
8 12 1", @"2")]
        [InlineData(@"3 4
1 3 2
3 4 4
1 4 3", @"3")]
        [InlineData(@"9 4
56 60 4
33 37 2
89 90 3
32 43 1
67 68 3
49 51 3
31 32 3
70 71 1
11 12 3", @"2")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6
1
3
5
2
4
6", @"2")]
        [InlineData(@"5
5
4
3
2
1", @"4")]
        [InlineData(@"7
1
2
3
4
5
6
7", @"0")]
        [InlineData(@"5
5
1
2
3
4", @"1")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 2
1 3
3 1", @"3")]
        [InlineData(@"2 2
1 1
1 1", @"6")]
        [InlineData(@"4 4
3 4 5 6
3 4 5 6", @"16")]
        [InlineData(@"10 9
9 6 5 7 5 9 8 5 6 7
8 6 8 5 5 7 9 9 7", @"191")]
        [InlineData(@"20 20
1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1
1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1", @"846527861")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"20 4
3 7 8 4", @"777773")]
        [InlineData(@"101 9
9 8 7 6 5 4 3 2 1", @"71111111111111111111111111111111111111111111111111")]
        [InlineData(@"15 3
5 4 6", @"654")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 2
3
5
2
7", @"29")]
        [InlineData(@"4 3
2
4
8
1
2
9
3", @"60")]
        public void QuestionGTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionG();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
01
10", @"2")]
        [InlineData(@"3
011
101
110", @"-1")]
        [InlineData(@"6
010110
101001
010100
101000
100000
010000", @"4")]
        public void QuestionHTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionH();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        IEnumerable<string> SplitByNewLine(string input) => input?.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None) ?? new string[0];
    }
}
