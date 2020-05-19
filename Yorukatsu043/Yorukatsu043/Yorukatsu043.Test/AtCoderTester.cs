using System;
using Xunit;
using Yorukatsu043.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu043.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"2 2", @"25")]
        [InlineData(@"8 10", @"100")]
        [InlineData(@"19 99", @"-1")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
1 2 1 1 3", @"Yes")]
        [InlineData(@"4
1 3 2 1", @"No")]
        [InlineData(@"5
1 2 3 4 5", @"Yes")]
        [InlineData(@"1
1000000000", @"Yes")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
3 5 -1", @"12
8
10")]
        [InlineData(@"5
1 1 1 2 0", @"4
4
4
2
4")]
        [InlineData(@"6
-679 -2409 -3258 3095 -3291 -4462", @"21630
21630
19932
8924
21630
19288")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

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
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6
ooxoox", @"SSSWWS")]
        [InlineData(@"3
oox", @"-1")]
        [InlineData(@"10
oxooxoxoox", @"SSWWSSSWWS")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 2
1 2
3 4
3 4
2 1", @"0")]
        [InlineData(@"2 3
1 10 80
80 10 1
1 2 3
4 5 6", @"2")]
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
