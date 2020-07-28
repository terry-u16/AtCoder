using System;
using Xunit;
using Kujikatsu043.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu043.Collections;

namespace Kujikatsu043.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"4 3 2", @"YES")]
        [InlineData(@"2 3 4", @"NO")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
ABCXYZ", @"CDEZAB")]
        [InlineData(@"0
ABCXYZ", @"ABCXYZ")]
        [InlineData(@"13
ABCDEFGHIJKLMNOPQRSTUVWXYZ", @"NOPQRSTUVWXYZABCDEFGHIJKLM")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4", @"1
3")]
        [InlineData(@"7", @"1
2
4")]
        [InlineData(@"1", @"1")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
0 1 1 2", @"2")]
        [InlineData(@"4
1 1 1 1", @"0")]
        [InlineData(@"7
0 3 2 1 2 2 1", @"24")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1 2
10 10
12 4", @"1")]
        [InlineData(@"100 1
101 101
102 1", @"infinity")]
        [InlineData(@"12000 15700
3390000000 3810000000
5550000000 2130000000", @"113")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1 2 1 3", @"3
5
4
1")]
        [InlineData(@"1
1 1", @"1
1")]
        [InlineData(@"32
29 19 7 10 26 32 27 4 11 20 2 8 16 23 5 14 6 12 17 22 18 30 28 24 15 1 25 3 13 21 19 31 9", @"32
525
5453
40919
237336
1107568
4272048
13884156
38567100
92561040
193536720
354817320
573166440
818809200
37158313
166803103
166803103
37158313
818809200
573166440
354817320
193536720
92561040
38567100
13884156
4272048
1107568
237336
40920
5456
528
33
1")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

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
