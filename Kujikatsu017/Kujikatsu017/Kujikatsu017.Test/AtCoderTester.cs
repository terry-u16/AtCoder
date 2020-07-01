using System;
using Xunit;
using Kujikatsu017.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu017.Collections;

namespace Kujikatsu017.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"3
apple
orange
apple", @"2")]
        [InlineData(@"5
grape
grape
grape
grape
grape", @"1")]
        [InlineData(@"4
aaaa
a
aaa
aa", @"4")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"36
24", @"GREATER")]
        [InlineData(@"850
3777", @"LESS")]
        [InlineData(@"9720246
22516266", @"LESS")]
        [InlineData(@"123456789012345678901234567890
234567890123456789012345678901", @"LESS")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
3 3 3 3", @"1")]
        [InlineData(@"5
2 4 1 4 2", @"2")]
        [InlineData(@"6
1 2 2 3 3 3", @"0")]
        [InlineData(@"1
1000000000", @"1")]
        [InlineData(@"8
2 7 1 8 2 8 1 8", @"5")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6
1 3 -4 2 2 -2", @"3")]
        [InlineData(@"7
1 -1 1 -1 1 -1 1", @"12")]
        [InlineData(@"5
1 -2 3 -4 5", @"0")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 100 90 80
98
40
30
21
80", @"23")]
        [InlineData(@"8 100 90 80
100
100
90
90
90
80
80
80", @"0")]
        [InlineData(@"8 1000 800 100
300
333
400
444
500
555
600
666", @"243")]
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
