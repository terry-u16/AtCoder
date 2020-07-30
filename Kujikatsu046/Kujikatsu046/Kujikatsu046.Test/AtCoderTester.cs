using System;
using Xunit;
using Kujikatsu046.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu046.Collections;

namespace Kujikatsu046.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"2 10 20", @"30
50
90
170
330
650
1290
2570
5130
10250")]
        [InlineData(@"4 40 60", @"200
760
3000
11960
47800
191160
764600
3058360
12233400
48933560")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2", @"9")]
        [InlineData(@"200", @"10813692")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"198 1.10", @"217")]
        [InlineData(@"1 0.01", @"0")]
        [InlineData(@"1000000000000000 9.99", @"9990000000000000")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"10000", @"3")]
        [InlineData(@"1000003", @"7")]
        [InlineData(@"9876543210", @"6")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
1
3
2
4", @"2")]
        [InlineData(@"6
3
2
5
1
4
6", @"4")]
        [InlineData(@"8
6
3
1
2
7
4
8
5", @"5")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
3 4 3
3 2 3", @"1")]
        [InlineData(@"2
2 1
1 2", @"-1")]
        [InlineData(@"4
1 2 3 4
5 6 7 8", @"0")]
        [InlineData(@"5
28 15 22 43 31
20 22 43 33 32", @"-1")]
        [InlineData(@"5
4 46 6 38 43
33 15 18 27 37", @"3")]
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
