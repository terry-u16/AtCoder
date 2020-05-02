using System;
using Xunit;
using Asakatsu20200503.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Asakatsu20200503.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"1 3", @"3")]
        [InlineData(@"0 1", @"0")]
        [InlineData(@"32 21", @"58")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 2
2 0
0 0
-1 0
1 0", @"2
1")]
        [InlineData(@"3 4
10 10
-10 -10
3 3
1 2
2 3
3 5
3 5", @"3
1
2")]
        [InlineData(@"5 5
-100000000 -100000000
-100000000 100000000
100000000 -100000000
100000000 100000000
0 0
0 0
100000000 100000000
100000000 -100000000
-100000000 100000000
-100000000 -100000000", @"5
4
3
2
1")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"UUD", @"7")]
        [InlineData(@"UUDUUDUD", @"77")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
6 9 4 2 11", @"11 6")]
        [InlineData(@"2
100 0", @"100 0")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
2 5 4 6", @"5")]
        [InlineData(@"9
0 0 0 0 0 0 0 0 0", @"45")]
        [InlineData(@"19
885 8 1 128 83 32 256 206 639 16 4 128 689 32 8 64 885 969 1", @"37")]
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
