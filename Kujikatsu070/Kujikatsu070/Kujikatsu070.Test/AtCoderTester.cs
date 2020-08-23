using System;
using Xunit;
using Kujikatsu070.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu070.Collections;

namespace Kujikatsu070.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"5 3
50 100 80 120 80", @"210")]
        [InlineData(@"1 1
1000", @"1000")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1214
4", @"2")]
        [InlineData(@"3
157", @"3")]
        [InlineData(@"299792458
9460730472580800", @"2")]
        [InlineData(@"111363464574
3", @"1")]
        [InlineData(@"1
1", @"1")]
        [InlineData(@"2
1", @"2")]
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

        [Theory]
        [InlineData(@"6 4
-10 8 2 1 2 6", @"14")]
        [InlineData(@"6 4
-6 -100 50 -2 -5 -3", @"44")]
        [InlineData(@"6 3
-6 -100 50 -2 -5 -3", @"0")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"18
DWANGOMEDIACLUSTER
1
18", @"1")]
        [InlineData(@"18
DDDDDDMMMMMCCCCCCC
1
18", @"210")]
        [InlineData(@"54
DIALUPWIDEAREANETWORKGAMINGOPERATIONCORPORATIONLIMITED
3
20 30 40", @"0
1
2")]
        [InlineData(@"30
DMCDMCDMCDMCDMCDMCDMCDMCDMCDMC
4
5 10 15 20", @"10
52
110
140")]
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
