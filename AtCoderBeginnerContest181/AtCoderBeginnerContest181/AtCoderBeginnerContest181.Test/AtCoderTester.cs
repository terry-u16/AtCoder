using System;
using Xunit;
using AtCoderBeginnerContest181.Questions;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderBeginnerContest181.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"2", @"White")]
        [InlineData(@"5", @"Black")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
1 3
3 5", @"18")]
        [InlineData(@"3
11 13
17 47
359 44683", @"998244353")]
        [InlineData(@"1
1 1000000", @"500000500000")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
0 1
0 2
0 3
1 1", @"Yes")]
        [InlineData(@"14
5 5
0 1
2 5
8 0
2 1
0 0
3 6
8 6
5 9
7 9
3 4
9 2
9 8
7 2", @"No")]
        [InlineData(@"9
8 2
2 3
1 3
3 7
1 0
8 8
5 6
9 7
0 1", @"Yes")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1234", @"Yes")]
        [InlineData(@"1333", @"No")]
        [InlineData(@"8", @"Yes")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 3
1 2 3 4 7
1 3 8", @"3")]
        [InlineData(@"7 7
31 60 84 23 16 13 32
96 80 73 76 87 57 29", @"34")]
        [InlineData(@"15 10
554 525 541 814 661 279 668 360 382 175 833 783 688 793 736
496 732 455 306 189 207 976 73 567 759", @"239")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        IEnumerable<string> SplitByNewLine(string input) => input?.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None) ?? new string[0];
    }
}
