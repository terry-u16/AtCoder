using System;
using Xunit;
using Kujikatsu030.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu030.Collections;

namespace Kujikatsu030.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"4 12", @"16")]
        [InlineData(@"8 20", @"12")]
        [InlineData(@"1 1", @"2")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"20", @"15800")]
        [InlineData(@"60", @"47200")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
2 3 5
3 4 1", @"3")]
        [InlineData(@"3
2 3 3
2 2 1", @"0")]
        [InlineData(@"3
17 7 1
25 6 14", @"-1")]
        [InlineData(@"12
757232153 372327760 440075441 195848680 354974235 458054863 463477172 740174259 615762794 632963102 529866931 64991604
74164189 98239366 465611891 362739947 147060907 118867039 63189252 78303147 501410831 110823640 122948912 572905212", @"5")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1 2 3", @"6")]
        [InlineData(@"10
3 1 4 1 5 9 2 6 5 3", @"237")]
        [InlineData(@"10
3 14 159 2653 58979 323846 2643383 27950288 419716939 9375105820", @"103715602")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1", @"0")]
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
        [InlineData(@"2
BWWB", @"4")]
        [InlineData(@"4
BWBBWWWB", @"288")]
        [InlineData(@"5
WWWWWWWWWW", @"0")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"9
1 3 6 13 15 18 19 29 31
10
4
1 8
7 3
6 7
8 5", @"4
2
1
2")]
        public void QuestionGTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionG();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }


        [Theory]
        [InlineData(@"9
1 3 6 13 15 18 19 29 31
10
4
1 8
7 3
6 7
8 5", @"4
2
1
2")]
        public void QuestionGDoublingTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionG_Doubling();

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
