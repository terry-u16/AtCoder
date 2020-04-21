using System;
using Xunit;
using AtCoderBeginnerContest145.Questions;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderBeginnerContest145.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"2", @"4")]
        [InlineData(@"100", @"10000")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6
abcabc", @"Yes")]
        [InlineData(@"6
abcadc", @"No")]
        [InlineData(@"1
z", @"No")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
0 0
1 0
0 1", @"2.2761423749")]
        [InlineData(@"2
-879 981
-866 890", @"91.9238815543")]
        [InlineData(@"8
-406 10
512 859
494 362
-955 -475
128 553
-986 -885
763 77
449 310", @"7641.9817824387")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            NearlyEquals(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3", @"2")]
        [InlineData(@"2 2", @"0")]
        [InlineData(@"999999 999999", @"151840682")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 60
10 10
100 100", @"110")]
        [InlineData(@"3 60
10 10
10 20
10 30", @"60")]
        [InlineData(@"3 60
30 10
30 20
30 30", @"50")]
        [InlineData(@"10 100
15 23
20 18
13 17
24 12
18 29
19 27
23 21
18 20
27 15
22 25", @"145")]
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

        IEnumerable<string> SplitByNewLine(string input) => input?.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None) ?? new string[0];

        void NearlyEquals(IEnumerable<string> expected, IEnumerable<string> actual, double absoluteError = 1.0e-6)
        {
            foreach (var pair in expected.Zip(actual, (exp, act) => new { exp, act }))
            {
                NearlyEquals(double.Parse(pair.exp), double.Parse(pair.act), absoluteError);
            }
        }

        void NearlyEquals(double expected, double actual, double absoluteError = 1.0e-6) => Assert.InRange(actual - expected, -absoluteError, absoluteError);
    }
}
