using System;
using Xunit;
using AtCoderBeginnerContest153.Questions;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderBeginnerContest153.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"10 4", @"3")]
        [InlineData(@"1 10000", @"1")]
        [InlineData(@"10000 1", @"10000")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"10 3
4 5 6", @"Yes")]
        [InlineData(@"20 3
4 5 6", @"No")]
        [InlineData(@"210 5
31 41 59 26 53", @"Yes")]
        [InlineData(@"211 5
31 41 59 26 53", @"No")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 1
4 1 5", @"5")]
        [InlineData(@"8 9
7 9 3 2 3 8 4 6", @"0")]
        [InlineData(@"3 0
1000000000 1000000000 1000000000", @"3000000000")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2", @"3")]
        [InlineData(@"4", @"7")]
        [InlineData(@"1000000000000", @"1099511627775")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

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
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3 2
1 2
5 4
9 2", @"2")]
        [InlineData(@"9 4 1
1 5
2 4
3 3
4 2
5 1
6 2
7 3
8 4
9 5", @"5")]
        [InlineData(@"3 0 1
300000000 1000000000
100000000 1000000000
200000000 1000000000", @"3000000000")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3 2
1 2
5 4
9 2", @"2")]
        [InlineData(@"9 4 1
1 5
2 4
3 3
4 2
5 1
6 2
7 3
8 4
9 5", @"5")]
        [InlineData(@"3 0 1
300000000 1000000000
100000000 1000000000
200000000 1000000000", @"3000000000")]
        public void QuestionF_ReviewTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF_Review();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        IEnumerable<string> SplitByNewLine(string input) => input?.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None) ?? new string[0];
    }
}
