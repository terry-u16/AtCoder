using System;
using Xunit;
using Kujikatsu094.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu094.Collections;

namespace Kujikatsu094.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"4
2 3 7 9", @"7")]
        [InlineData(@"8
3 1 4 1 5 9 2 6", @"8")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"90", @"4")]
        [InlineData(@"1", @"360")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
3 4 2 1", @"1")]
        [InlineData(@"3
1 1000 1", @"0")]
        [InlineData(@"7
218 786 704 233 645 728 389", @"23")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 4", @"5")]
        [InlineData(@"123 456", @"435")]
        [InlineData(@"123456789012 123456789012", @"123456789012")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 3
1 2 1 3
1 3
2 4
3 3", @"2
3
1")]
        [InlineData(@"10 10
2 5 6 5 2 1 7 9 7 2
5 5
2 4
6 7
2 2
7 8
7 9
1 8
6 9
8 10
6 8", @"1
2
2
1
2
2
6
3
3
3")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 3
10 14 19 34 33", @"202")]
        [InlineData(@"9 14
1 3 5 110 24 21 34 5 3", @"1837")]
        [InlineData(@"9 73
67597 52981 5828 66249 75177 64141 40773 79105 16076", @"8128170")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1 2 300
3 3 600
1 4 800", @"2900
900
0
0")]
        [InlineData(@"5
3 5 400
5 3 700
5 5 1000
5 7 700
7 5 400", @"13800
1600
0
0
0
0")]
        [InlineData(@"6
2 5 1000
5 2 1100
5 5 1700
-2 -5 900
-5 -2 600
-5 -5 2200", @"26700
13900
3200
1200
0
0
0")]
        [InlineData(@"8
2 2 286017
3 1 262355
2 -2 213815
1 -3 224435
-2 -2 136860
-3 -1 239338
-2 2 217647
-1 3 141903", @"2576709
1569381
868031
605676
366338
141903
0
0
0")]
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
