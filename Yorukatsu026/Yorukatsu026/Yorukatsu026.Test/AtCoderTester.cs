using System;
using Xunit;
using Yorukatsu026.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu026.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"20", @"15800")]
        [InlineData(@"60", @"47200")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1500 2000 1600 3 2", @"7900")]
        [InlineData(@"1500 2000 1900 3 2", @"8500")]
        [InlineData(@"1500 2000 500 90000 100000", @"100000000")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"yx
axy", @"Yes")]
        [InlineData(@"ratcode
atlas", @"Yes")]
        [InlineData(@"cd
abc", @"No")]
        [InlineData(@"w
ww", @"Yes")]
        [InlineData(@"zzz
zzz", @"No")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 4", @"5")]
        [InlineData(@"123 456", @"435")]
        [InlineData(@"123456789012 123456789012", @"123456789012")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 4", @"5")]
        [InlineData(@"123 456", @"435")]
        [InlineData(@"123456789012 123456789012", @"123456789012")]
        public void QuestionDReviewTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD_Review();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"10", @"5")]
        [InlineData(@"1111111111111111111", @"162261460")]
        [InlineData(@"101", @"15")]
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
