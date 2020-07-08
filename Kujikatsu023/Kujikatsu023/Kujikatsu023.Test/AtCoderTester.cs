using System;
using Xunit;
using Kujikatsu023.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu023.Collections;

namespace Kujikatsu023.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"sippuu", @"Yes")]
        [InlineData(@"iphone", @"No")]
        [InlineData(@"coffee", @"Yes")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1 2 3 1", @"1")]
        [InlineData(@"2 3 2 0", @"-1")]
        [InlineData(@"1000000000 1000000000 1000000000 1000000000000000000", @"0")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 4
##.#
....
##.#
.#.#", @"###
###
.##")]
        [InlineData(@"3 3
#..
.#.
..#", @"#..
.#.
..#")]
        [InlineData(@"4 5
.....
.....
..#..
.....", @"#")]
        [InlineData(@"7 6
......
....#.
.#....
..#...
..#...
......
.#..#.", @"..#
#..
.#.
.#.
#.#")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
aab
ccb", @"6")]
        [InlineData(@"1
Z
Z", @"3")]
        [InlineData(@"52
RvvttdWIyyPPQFFZZssffEEkkaSSDKqcibbeYrhAljCCGGJppHHn
RLLwwdWIxxNNQUUXXVVMMooBBaggDKqcimmeYrhAljOOTTJuuzzn", @"958681902")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6", @"3")]
        [InlineData(@"3141", @"13")]
        [InlineData(@"314159265358", @"9")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 3
1 9
1 7
2 6
2 5
3 1", @"26")]
        [InlineData(@"7 4
1 1
2 1
3 1
4 6
4 5
4 5
4 5", @"25")]
        [InlineData(@"6 5
5 1000000000
2 990000000
3 980000000
6 970000000
6 960000000
4 950000000", @"4900000016")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
7 2 4
12345 67890 2019", @"9009
916936")]
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
