using System;
using Xunit;
using Kujikatsu102.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu102.Collections;

namespace Kujikatsu102.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"internationalization", @"i18n")]
        [InlineData(@"smiles", @"s4s")]
        [InlineData(@"xyz", @"x1z")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 2 4", @"Alice")]
        [InlineData(@"2 1 2", @"Borys")]
        [InlineData(@"58 23 42", @"Borys")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"a
4
2 1 p
1
2 2 c
1", @"cpa")]
        [InlineData(@"a
6
2 2 a
2 1 b
1
2 2 c
1
1", @"aabc")]
        [InlineData(@"y
1
2 1 x", @"xy")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 4
1 1
4 4
..#.
..#.
.#..
.#..", @"1")]
        [InlineData(@"4 4
1 4
4 1
.##.
####
####
.##.", @"-1")]
        [InlineData(@"4 4
2 2
3 3
....
....
....
....", @"0")]
        [InlineData(@"4 5
1 2
2 5
#.###
####.
#..##
#..##", @"2")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 5
1 3
2 3
1 4
2 2
1 2", @"1")]
        [InlineData(@"200000 0", @"39999200004")]
        [InlineData(@"176527 15
1 81279
2 22308
2 133061
1 80744
2 44603
1 170938
2 139754
2 15220
1 172794
1 159290
2 156968
1 56426
2 77429
1 97459
2 71282", @"31159505795")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
0 1
0 2
0 3
3 4", @"2")]
        [InlineData(@"2
0 1", @"1")]
        [InlineData(@"10
2 8
6 0
4 1
7 6
2 3
8 6
6 9
2 4
5 8", @"3")]
        public void QuestionGTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionG();

            var answers = SplitByNewLine(question.Solve(input).Trim());

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
