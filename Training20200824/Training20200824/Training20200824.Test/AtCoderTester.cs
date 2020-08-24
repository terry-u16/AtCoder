using System;
using Xunit;
using Training20200824.Questions;
using System.Collections.Generic;
using System.Linq;
using Training20200824.Collections;

namespace Training20200824.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"5 3
3 1
1 1
4 2", @"6")]
        [InlineData(@"20 5
10 2
4 3
12 1
13 2
9 1", @"2640")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"13", @"4")]
        [InlineData(@"20", @"1")]
        [InlineData(@"2019", @"449")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
1
7
15", @"YES")]
        [InlineData(@"5
1
4
2", @"YES")]
        [InlineData(@"300
57
121
244", @"NO")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 2
8 7 6
rsrpr", @"27")]
        [InlineData(@"7 1
100 10 1
ssssppr", @"211")]
        [InlineData(@"30 5
325 234 123
rspsspspsrpspsppprpsprpssprpsr", @"4996")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 100
30 50
40 40
50 100
60 80", @"190")]
        [InlineData(@"5 100
40 10
30 50
60 80
20 40
20 70", @"200")]
        [InlineData(@"10 654
76 54
62 19
8 5
29 75
28 4
76 16
96 24
79 30
20 64
23 56", @"347")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
ababa", @"2")]
        [InlineData(@"2
xy", @"0")]
        [InlineData(@"13
strangeorange", @"5")]
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
