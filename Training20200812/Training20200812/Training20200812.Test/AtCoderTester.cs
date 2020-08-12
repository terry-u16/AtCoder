using System;
using Xunit;
using Training20200812.Questions;
using System.Collections.Generic;
using System.Linq;
using Training20200812.Collections;

namespace Training20200812.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"3
0 10
5 -5
-5 -5", @"10.000000000000000000000000000000000000000000000000")]
        [InlineData(@"5
1 1
1 0
0 1
-1 0
0 -1", @"2.828427124746190097603377448419396157139343750753")]
        [InlineData(@"5
1 1
2 2
3 3
4 4
5 5", @"21.213203435596425732025330863145471178545078130654")]
        [InlineData(@"3
0 0
0 1
1 0", @"1.414213562373095048801688724209698078569671875376")]
        [InlineData(@"1
90447 91000", @"128303.000000000000000000000000000000000000000000000000")]
        [InlineData(@"2
96000 -72000
-72000 54000", @"120000.000000000000000000000000000000000000000000000000")]
        [InlineData(@"10
1 2
3 4
5 6
7 8
9 10
11 12
13 14
15 16
17 18
19 20", @"148.660687473185055226120082139313966514489855137208")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            AssertNearlyEqual(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
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
