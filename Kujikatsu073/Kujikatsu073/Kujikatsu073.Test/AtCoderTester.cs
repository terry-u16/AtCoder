using System;
using Xunit;
using Kujikatsu073.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu073.Collections;

namespace Kujikatsu073.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"1024", @"2020")]
        [InlineData(@"0", @"0")]
        [InlineData(@"1000000000", @"2000000000")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 2
2 0
0 0
-1 0
1 0", @"2
1")]
        [InlineData(@"3 4
10 10
-10 -10
3 3
1 2
2 3
3 5
3 5", @"3
1
2")]
        [InlineData(@"5 5
-100000000 -100000000
-100000000 100000000
100000000 -100000000
100000000 100000000
0 0
0 0
100000000 100000000
100000000 -100000000
-100000000 100000000
-100000000 -100000000", @"5
4
3
2
1")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 2 6", @"7")]
        [InlineData(@"7 3 4", @"8")]
        [InlineData(@"314159265 35897932 384626433", @"48518828981938099")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1 10
3 5", @"3")]
        [InlineData(@"2 10
3 5
2 6", @"2")]
        [InlineData(@"4 1000000000
1 1
1 10000000
1 30000000
1 99999999", @"860000004")]
        [InlineData(@"5 500
35 44
28 83
46 62
31 79
40 43", @"9")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 4 1
1 2
2 3
3 4
3 5", @"2")]
        [InlineData(@"5 4 5
1 2
1 3
1 4
1 5", @"1")]
        [InlineData(@"2 1 2
1 2", @"0")]
        [InlineData(@"9 6 1
1 2
2 3
3 4
4 5
5 6
4 7
7 8
8 9", @"5")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 5
3 3
4 4
2 5", @"8")]
        [InlineData(@"3 6
3 3
4 4
2 5", @"9")]
        [InlineData(@"7 14
10 5
7 4
11 4
9 8
3 6
6 2
8 9", @"32")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 3
rrr
brg", @"2")]
        [InlineData(@"6 3
xya
xya
ayz
ayz
xaz
xaz", @"0")]
        [InlineData(@"4 2
ay
xa
xy
ay", @"0")]
        [InlineData(@"5 5
aaaaa
abbba
ababa
abbba
aaaaa", @"24")]
        [InlineData(@"7 10
xxxxxxxxxx
ccccxxffff
cxxcxxfxxx
cxxxxxffff
cxxcxxfxxx
ccccxxfxxx
xxxxxxxxxx", @"130")]
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
