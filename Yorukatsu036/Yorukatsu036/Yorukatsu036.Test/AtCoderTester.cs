using System;
using Xunit;
using Yorukatsu036.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu036.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"atcoder", @"acdr")]
        [InlineData(@"aaaa", @"aa")]
        [InlineData(@"z", @"z")]
        [InlineData(@"fukuokayamaguchi", @"fkoaaauh")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
apple
orange
apple
1
grape", @"2")]
        [InlineData(@"3
apple
orange
apple
5
apple
apple
apple
apple
apple", @"1")]
        [InlineData(@"1
voldemort
10
voldemort
voldemort
voldemort
voldemort
voldemort
voldemort
voldemort
voldemort
voldemort
voldemort", @"0")]
        [InlineData(@"6
red
red
blue
yellow
yellow
red
5
red
red
yellow
green
blue", @"1")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 2
1 2
2 3", @"POSSIBLE")]
        [InlineData(@"4 3
1 2
2 3
3 4", @"IMPOSSIBLE")]
        [InlineData(@"100000 1
1 99999", @"IMPOSSIBLE")]
        [InlineData(@"5 5
1 3
4 5
2 3
2 4
1 4", @"POSSIBLE")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"125", @"176")]
        [InlineData(@"9999999999", @"12656242944")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 3", @"5
4 3
1 2
3 1
4 5
2 3")]
        [InlineData(@"5 8", @"-1")]
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
