using System;
using Xunit;
using Kujikatsu085.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu085.Collections;

namespace Kujikatsu085.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"4
3", @"10")]
        [InlineData(@"10
10", @"76")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1 2 3", @"11")]
        [InlineData(@"4
141421356 17320508 22360679 244949", @"437235829")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
3 1 4 1 5
3
5 4 3", @"YES")]
        [InlineData(@"7
100 200 500 700 1200 1600 2000
6
100 200 500 700 1600 1600", @"NO")]
        [InlineData(@"1
800
5
100 100 100 100 100", @"NO")]
        [InlineData(@"15
1 2 2 3 3 3 4 4 4 4 5 5 5 5 5
9
5 4 3 2 1 2 3 4 5", @"YES")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"7 7
1 3
2 7
3 4
4 5
4 6
5 6
6 7", @"4")]
        [InlineData(@"3 3
1 2
1 3
2 3", @"0")]
        [InlineData(@"6 5
1 2
2 3
3 4
4 5
5 6", @"5")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"10", @"5")]
        [InlineData(@"1111111111111111111", @"162261460")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 5
1 2
1 3
3 4
3 5
4 5", @"4")]
        [InlineData(@"5 1
1 2", @"-1")]
        [InlineData(@"4 3
1 2
1 3
2 3", @"3")]
        [InlineData(@"10 39
7 2
7 1
5 6
5 8
9 10
2 8
8 7
3 10
10 1
8 10
2 3
7 4
3 9
4 10
3 4
6 1
6 7
9 5
9 7
6 9
9 4
4 6
7 5
8 3
2 5
9 2
10 7
8 6
8 9
7 3
5 3
4 5
6 3
2 10
5 10
4 2
6 2
8 4
10 6", @"21")]
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
