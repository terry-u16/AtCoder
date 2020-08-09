using System;
using Xunit;
using Asakatsu20200810.Questions;
using System.Collections.Generic;
using System.Linq;
using Asakatsu20200810.Collections;

namespace Asakatsu20200810.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"1 21", @"Yes")]
        [InlineData(@"100 100", @"No")]
        [InlineData(@"12 10", @"No")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3 3", @"9")]
        [InlineData(@"2 2 4", @"0")]
        [InlineData(@"5 3 5", @"15")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"-1 -1 2
2 3 4 5", @"YES
YES")]
        [InlineData(@"0 1 1
-2 0 4 3", @"NO
YES")]
        [InlineData(@"0 0 5
-2 -2 2 1", @"YES
NO")]
        [InlineData(@"0 0 2
0 0 4 4", @"YES
YES")]
        [InlineData(@"0 0 5
-4 -4 4 4", @"YES
YES")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1", @"a")]
        [InlineData(@"2", @"aa
ab")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
3 2 1
2 2 1
1 1 1
3
1
4
9", @"3
9
14")]
        [InlineData(@"3
1 1 1
1 1 1
9 9 9
1
4", @"27")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
0 0 300 10
0 100 10 100
0 200 10 200
0 300 10 300", @"3")]
        [InlineData(@"4
0 0 100 10
0 90 10 10
0 100 30 100
-20 100 10 10", @"3")]
        [InlineData(@"1
0 0 3 3", @"0")]
        [InlineData(@"4
58 -49 38 109
45 -29 200 56
-32 123 103 98
49 -234 289 43", @"4.874179")]
        [InlineData(@"8
100 100 30 50
100 50 93 123
100 0 89 111
50 100 13 18
50 0 155 86
0 100 30 58
0 50 58 49
0 0 98 153", @"7.666667")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            AssertNearlyEqual(outputs, answers);
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
