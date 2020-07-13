using System;
using Xunit;
using Kujikatsu029.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu029.Collections;

namespace Kujikatsu029.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"1199", @"ABC")]
        [InlineData(@"1200", @"ARC")]
        [InlineData(@"4208", @"AGC")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 3
1 2 3 4
1 3
2 3
2 4", @"2")]
        [InlineData(@"6 5
8 6 9 1 2 1
1 3
4 2
4 3
4 6
4 6", @"3")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
2 10 8 40", @"2")]
        [InlineData(@"4
5 13 8 1000000000", @"1")]
        [InlineData(@"3
1000000000 1000000000 1000000000", @"1000000000")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"xyz
4", @"aya")]
        [InlineData(@"a
25", @"z")]
        [InlineData(@"codefestival
100", @"aaaafeaaivap")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 5 4
11100
10001
00111", @"2")]
        [InlineData(@"3 5 8
11100
10001
00111", @"0")]
        [InlineData(@"4 10 4
1110010010
1000101110
0011101001
1101000111", @"3")]
        [InlineData(@"1 1 1
1", @"0")]
        [InlineData(@"1 2 1
11", @"1")]
        [InlineData(@"2 1 1
1
1", @"1")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
oof", @"575111451")]
        [InlineData(@"37564
whydidyoudesertme", @"318008117")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
1 2
3 1
4 3
3 5
2
2 6
5 7", @"Yes
5
6
6
5
7")]
        [InlineData(@"5
1 2
3 1
4 3
3 5
3
2 6
4 3
5 7", @"No")]
        [InlineData(@"4
1 2
2 3
3 4
1
1 0", @"Yes
0
-1
-2
-3")]
        [InlineData(@"4
1 2
2 3
3 4
4
1 1
2 2
3 3
4 4", @"Yes
1
2
3
4")]
        [InlineData(@"1
1
1 1", @"Yes
1")]
        [InlineData(@"4
1 2
2 3
3 4
4
1 1
2 1
3 1
4 1", @"No")]
        [InlineData(@"3
1 2
2 3
2
1 1
3 2", @"No")]
        public void QuestionGTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionG();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        void AssertNearlyEqual(IEnumerable<string> expected, IEnumerable<string> actual, double acceptableError = 1e-6)
        {
            Assert.Equal(expected.Count(), actual.Count());
            foreach (var (exp, act) in (expected, actual).Zip().Select(p => (double.Parse(p.v1), double.Parse(p.v2))))
            {
                var error = act - exp;
                Assert.InRange(Math.Abs(error), 0, acceptableError);
            }
        }

        IEnumerable<string> SplitByNewLine(string input) => input?.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None) ?? new string[0];
    }
}
