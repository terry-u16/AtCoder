using System;
using Xunit;
using Yorukatsu033.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu033.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"2 11 4", @"4")]
        [InlineData(@"3 9 5", @"3")]
        [InlineData(@"100 1 10", @"0")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
3
1
2", @"2")]
        [InlineData(@"4
3
4
1
2", @"-1")]
        [InlineData(@"5
3
3
4
2
4", @"3")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 4
1 1
2 2
3 3", @"3")]
        [InlineData(@"10 500000
1 100000
1 100000
1 100000
1 100000
1 100000
100000 100000
100000 100000
100000 100000
100000 100000
100000 100000", @"1")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"127", @"4")]
        [InlineData(@"3", @"3")]
        [InlineData(@"44852", @"16")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 3 1
1 1
1 2
2 2
1 2", @"3")]
        [InlineData(@"10 3 2
1 5
2 8
7 10
1 7
3 10", @"1
1")]
        [InlineData(@"10 10 10
1 6
2 9
4 5
4 7
4 7
5 8
6 6
6 7
7 9
10 10
1 8
1 9
1 10
2 8
2 9
2 10
3 8
3 9
3 10
1 10", @"7
9
10
6
8
9
6
7
8
10")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

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
