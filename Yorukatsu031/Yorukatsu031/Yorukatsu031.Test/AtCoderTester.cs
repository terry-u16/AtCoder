using System;
using Xunit;
using Yorukatsu031.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu031.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"happy,newyear,enjoy", @"happy newyear enjoy")]
        [InlineData(@"haiku,atcoder,tasks", @"haiku atcoder tasks")]
        [InlineData(@"abcde,fghihgf,edcba", @"abcde fghihgf edcba")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"7
3 1 4 1 5 9 2", @"4")]
        [InlineData(@"10
0 1 2 3 4 5 6 7 8 9", @"3")]
        [InlineData(@"1
99999", @"1")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 2", @"6")]
        [InlineData(@"5 15", @"1")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 3
1 32
2 63
1 12", @"000001000002
000002000001
000001000001")]
        [InlineData(@"2 3
2 55
2 77
2 99", @"000002000001
000002000002
000002000003")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6 4
-10 8 2 1 2 6", @"14")]
        [InlineData(@"6 4
-6 -100 50 -2 -5 -3", @"44")]
        [InlineData(@"6 3
-6 -100 50 -2 -5 -3", @"0")]
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
