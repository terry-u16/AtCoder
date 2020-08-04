using System;
using Xunit;
using Kujikatsu051.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu051.Collections;

namespace Kujikatsu051.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"3", @"6")]
        [InlineData(@"10", @"10")]
        [InlineData(@"999999999", @"1999999998")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"7
beat
vet
beet
bed
vet
bet
beet", @"beet
vet")]
        [InlineData(@"8
buffalo
buffalo
buffalo
buffalo
buffalo
buffalo
buffalo
buffalo", @"buffalo")]
        [InlineData(@"7
bass
bass
kick
kick
bass
kick
kick", @"kick")]
        [InlineData(@"4
ushi
tapu
nichia
kun", @"kun
nichia
tapu
ushi")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 3 5
1
2
3
6
12", @"3")]
        [InlineData(@"6 3 3
7
6
2
8
10
6", @"3")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
3 1 3 2", @"1")]
        [InlineData(@"6
105 119 105 119 105 119", @"0")]
        [InlineData(@"4
1 1 1 1", @"2")]
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

        [Theory]
        [InlineData(@"4 1 2 5", @"40")]
        [InlineData(@"2 5 6 0", @"1")]
        [InlineData(@"90081 33447 90629 6391049189", @"577742975")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"87654
30", @"10")]
        [InlineData(@"87654
138", @"100")]
        [InlineData(@"87654
45678", @"-1")]
        [InlineData(@"31415926535
1", @"31415926535")]
        [InlineData(@"1
31415926535", @"-1")]
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
