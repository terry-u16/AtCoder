using System;
using Xunit;
using AtCoderBeginnerContest137.Questions;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderBeginnerContest137.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"-13 3", @"-10")]
        [InlineData(@"1 -33", @"34")]
        [InlineData(@"13 3", @"39")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 7", @"5 6 7 8 9")]
        [InlineData(@"4 0", @"-3 -2 -1 0 1 2 3")]
        [InlineData(@"1 100", @"100")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
acornistnt
peanutbomb
constraint", @"1")]
        [InlineData(@"2
oneplustwo
ninemodsix", @"0")]
        [InlineData(@"5
abaaaaaaaa
oneplustwo
aaaaaaaaba
twoplusone
aaaabaaaaa", @"4")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 4
4 3
4 1
2 2", @"5")]
        [InlineData(@"5 3
1 2
1 3
1 4
2 1
2 3", @"10")]
        [InlineData(@"1 1
2 1", @"0")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 4
4 3
4 1
2 2", @"5")]
        [InlineData(@"5 3
1 2
1 3
1 4
2 1
2 3", @"10")]
        [InlineData(@"1 1
2 1", @"0")]
        public void QuestionDPriorityQueueTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD_PriorityQueue();

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
