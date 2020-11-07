using System;
using Xunit;
using AtCoderBeginnerContest180.Questions;
using System.Collections.Generic;
using System.Linq;
using AtCoderBeginnerContest180.Collections;

namespace AtCoderBeginnerContest180.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"100 1 2", @"101")]
        [InlineData(@"100 2 1", @"99")]
        [InlineData(@"100 1 1", @"100")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6", @"1
2
3
6")]
        [InlineData(@"720", @"1
2
3
4
5
6
8
9
10
12
15
16
18
20
24
30
36
40
45
48
60
72
80
90
120
144
180
240
360
720")]
        [InlineData(@"1000000007", @"1
1000000007")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 20 2 10", @"2")]
        [InlineData(@"1 1000000000000000000 10 1000000000", @"1000000007")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
0 0 0
1 2 3", @"9")]
        [InlineData(@"3
0 0 0
1 1 1
-1 -1 -1", @"10")]
        [InlineData(@"17
14142 13562 373095
-17320 508075 68877
223606 -79774 9979
-24494 -89742 783178
26457 513110 -64591
-282842 7124 -74619
31622 -77660 -168379
-33166 -24790 -3554
346410 16151 37755
-36055 51275 463989
37416 -573867 73941
-3872 -983346 207417
412310 56256 -17661
-42426 40687 -119285
43588 -989435 -40674
-447213 -59549 -99579
45825 7569 45584", @"6519344")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 2 3", @"3")]
        [InlineData(@"4 3 2", @"6")]
        [InlineData(@"300 290 140", @"211917445")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

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
