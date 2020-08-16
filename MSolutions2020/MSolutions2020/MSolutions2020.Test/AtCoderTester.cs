using System;
using Xunit;
using MSolutions2020.Questions;
using System.Collections.Generic;
using System.Linq;
using MSolutions2020.Collections;

namespace MSolutions2020.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"725", @"7")]
        [InlineData(@"1600", @"2")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"7 2 5
3", @"Yes")]
        [InlineData(@"7 4 2
3", @"No")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 3
96 98 95 100 20", @"Yes
No")]
        [InlineData(@"3 2
1001 869120 1001", @"No")]
        [InlineData(@"15 7
3 1 4 1 5 9 2 6 5 3 5 8 9 7 9", @"Yes
Yes
No
Yes
Yes
No
Yes
Yes")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"7
100 130 130 130 115 115 150", @"1685")]
        [InlineData(@"6
200 180 160 140 120 100", @"1000")]
        [InlineData(@"2
157 193", @"1216")]
        [InlineData(@"8
100 130 130 130 115 115 150 10", @"1685")]
        [InlineData(@"5
10 10 10 10 10", @"1000")]
        [InlineData(@"5
100 110 120 130 140", @"1400")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

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
        [InlineData(@"15
1 2 300
3 3 600
3 3 600
3 3 600
3 3 600
3 3 600
3 3 600
3 3 600
3 3 600
3 3 600
3 3 600
3 3 600
3 3 600
3 3 600
1 4 800", @"2900
900
0
0
0
0
0
0
0
0
0
0
0
0
0")]

        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
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
