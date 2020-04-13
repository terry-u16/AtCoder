using System;
using Xunit;
using AtCoderBeginnerContest154.Questions;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderBeginnerContest154.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"red blue
3 4
red", @"2 4")]
        [InlineData(@"red blue
5 5
blue", @"5 4")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"sardine", @"xxxxxxx")]
        [InlineData(@"xxxx", @"xxxx")]
        [InlineData(@"gone", @"xxxx")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
2 6 1 4 5", @"YES")]
        [InlineData(@"6
4 1 3 1 6 2", @"NO")]
        [InlineData(@"2
10000000 10000000", @"NO")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 3
1 2 2 4 5", @"7.000000000000")]
        [InlineData(@"4 1
6 6 6 6", @"3.500000000000")]
        [InlineData(@"10 4
17 13 13 12 15 20 10 13 17 11", @"32.000000000000")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs.Select(double.Parse), answers.Select(double.Parse));
        }

        [Theory]
        [InlineData(@"100
1", @"19")]
        [InlineData(@"25
2", @"14")]
        [InlineData(@"314159
2", @"937")]
        [InlineData(@"9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999
3", @"117879300")]
        [InlineData(@"100
3", @"0")]
        [InlineData(@"99999
1", @"45")]
        [InlineData(@"1
1", @"1")]
        [InlineData(@"200
2", @"99")]
        [InlineData(@"201
2", @"100")]
        [InlineData(@"210
2", @"109")]
        [InlineData(@"200
1", @"20")]
        [InlineData(@"200
3", @"81")]
        [InlineData(@"1000
3", @"729")]
        [InlineData(@"1011
3", @"730")]
        [InlineData(@"1
2", @"0")]
        [InlineData(@"10000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
3", @"117879300")]
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
