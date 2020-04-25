using System;
using Xunit;
using Yorukatsu025.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu025.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"sippuu", @"Yes")]
        [InlineData(@"iphone", @"No")]
        [InlineData(@"coffee", @"Yes")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
2100 2500 2700 2700", @"2 2")]
        [InlineData(@"5
1100 1900 2800 3200 3200", @"3 5")]
        [InlineData(@"20
800 810 820 830 840 850 860 870 880 890 900 910 920 930 940 950 960 970 980 990", @"1 1")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6", @"3")]
        [InlineData(@"2", @"2")]
        [InlineData(@"11", @"5")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
())", @"(())")]
        [InlineData(@"6
)))())", @"(((()))())")]
        [InlineData(@"8
))))((((", @"(((())))(((())))")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"9", @"0")]
        [InlineData(@"10", @"1")]
        [InlineData(@"100", @"543")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"36", @"8")]
        [InlineData(@"91", @"3")]
        [InlineData(@"998", @"3")]
        [InlineData(@"445", @"13")]
        [InlineData(@"314159265358979323846264338327950288419716939937551058209749445923078164062862089986280348253421170", @"243")]
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
