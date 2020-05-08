using System;
using Xunit;
using Yorukatsu035.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu035.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"A", @"T")]
        [InlineData(@"G", @"C")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1214
4", @"2")]
        [InlineData(@"3
157", @"3")]
        [InlineData(@"299792458
9460730472580800", @"2")]
        [InlineData(@"11111
5", @"1")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"01B0", @"00")]
        [InlineData(@"0BB1", @"1")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"9 3
8 3
4 2
2 1", @"4")]
        [InlineData(@"100 6
1 1
2 3
3 9
4 27
5 81
6 243", @"100")]
        [InlineData(@"9999 10
540 7550
691 9680
700 9790
510 7150
415 5818
551 7712
587 8227
619 8671
588 8228
176 2461", @"139815")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"??2??5", @"768")]
        [InlineData(@"?44", @"1")]
        [InlineData(@"7?4", @"0")]
        [InlineData(@"?6?42???8??2??06243????9??3???7258??5??7???????774????4?1??17???9?5?70???76???", @"153716888")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 4
2 2 4", @"5")]
        [InlineData(@"5 8
9 9 9 9 9", @"0")]
        [InlineData(@"10 10
3 1 4 1 5 9 2 6 5 3", @"152")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 4
2 2 4", @"5")]
        [InlineData(@"5 8
9 9 9 9 9", @"0")]
        [InlineData(@"10 10
3 1 4 1 5 9 2 6 5 3", @"152")]
        public void QuestionF_AnotherTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF_Another();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        IEnumerable<string> SplitByNewLine(string input) => input?.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None) ?? new string[0];
    }
}
