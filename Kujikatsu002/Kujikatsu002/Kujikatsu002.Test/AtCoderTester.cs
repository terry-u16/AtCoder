using System;
using Xunit;
using Kujikatsu002.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Kujikatsu002.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"3 5 2
10 3
5 2
2 5", @"2")]
        [InlineData(@"10 587586158 185430194
894597290 708587790
680395892 306946994
590262034 785368612
922328576 106880540
847058850 326169610
936315062 193149191
702035777 223363392
11672949 146832978
779291680 334178158
615808191 701464268", @"8")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 5", @"10")]
        [InlineData(@"7 3", @"11")]
        [InlineData(@"1000000000 1000000000", @"500000000000000000")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"8 3
ACACTACG
3 7
2 3
1 8", @"2
0
3")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"ABCABC", @"3")]
        [InlineData(@"C", @"0")]
        [InlineData(@"ABCACCBABCBCAABCB", @"6")]
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

        [Theory]
        [InlineData(@"2 3
8 20", @"7")]
        [InlineData(@"2 10
3 5", @"8")]
        [InlineData(@"4 5
10 1 2 22", @"7")]
        [InlineData(@"8 7
1 7 5 6 8 2 6 5", @"5")]
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
