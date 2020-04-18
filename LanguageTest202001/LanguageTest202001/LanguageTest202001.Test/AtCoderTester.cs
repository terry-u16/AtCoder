using System;
using Xunit;
using LanguageTest202001.Questions;
using System.Collections.Generic;
using System.Linq;

namespace LanguageTest202001.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"9 45000", @"4 0 5")]
        [InlineData(@"20 196000", @"-1 -1 -1")]
        [InlineData(@"1000 1234000", @"14 27 959")]
        [InlineData(@"2000 20000000", @"2000 0 0")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new ABC085C();

            var answers = question.Solve(input).Select(o => o.ToString()).First().Split(' ').Select(int.Parse).ToArray();
            var outputBill = outputs.First().Split(' ').Select(int.Parse).ToArray();

            Assert.Equal(CalculateOtoshidama(outputBill[0], outputBill[1], outputBill[2]), CalculateOtoshidama(answers[0], answers[1], answers[2]));
        }

        private int CalculateOtoshidama(int bill10000, int bill5000, int bill1000) => bill10000 * 10000 + bill5000 * 5000 + bill1000 * 1000;

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new PracticeA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
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
