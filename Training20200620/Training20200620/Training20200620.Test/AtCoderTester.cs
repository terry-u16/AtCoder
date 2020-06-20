using System;
using Xunit;
using Training20200620.Questions;
using System.Collections.Generic;
using System.Linq;
using Training20200620.Collections;

namespace Training20200620.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"10
3 2
4 20
3 40
6 100", @"140")]
        [InlineData(@"10
5 4
9 10
3 7
3 1
2 6
4 5", @"18")]
        [InlineData(@"22
5 3
5 40
8 50
3 60
4 70
6 80", @"210")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1 2 3", @"1")]
        [InlineData(@"5
3 11 14 5 13", @"2")]
        [InlineData(@"5
1 1 1 1 1", @"2")]
        [InlineData(@"5
2 2 2 2 2", @"2")]
        [InlineData(@"3
1 3 7", @"1")]
        [InlineData(@"4
16 16 16 16", @"2")]
        [InlineData(@"4
7 9", @"1")]
        [InlineData(@"3
100 28 28", @"1")]
        [InlineData(@"5
1 1 1 1 7", @"2")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 3
10 14 19 34 33", @"202")]
        [InlineData(@"9 14
1 3 5 110 24 21 34 5 3", @"1837")]
        [InlineData(@"9 73
67597 52981 5828 66249 75177 64141 40773 79105 16076", @"8128170")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 5
1 2
2 3
2 4
4 1
4 3", @"3
1
2
4")]
        [InlineData(@"4 5
1 2
2 3
2 4
1 4
4 3", @"-1")]
        [InlineData(@"6 9
1 2
2 3
3 4
4 5
5 6
5 1
5 2
6 1
6 2", @"4
2
3
4
5")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 3 2 3
1 4 1 100
1 2 1 10
1 3 20 1", @"999999999999998
999999999999989
999999999999979
999999999999897")]
        [InlineData(@"8 12 3 8
2 8 685087149 857180777
6 7 298270585 209942236
2 4 346080035 234079976
2 5 131857300 22507157
4 8 30723332 173476334
2 6 480845267 448565596
1 4 181424400 548830121
4 5 57429995 195056405
7 8 160277628 479932440
1 6 475692952 203530153
3 5 336869679 160714712
2 7 389775999 199123879", @"999999574976994
999999574976994
999999574976994
999999574976994
999999574976994
999999574976994
999999574976994
999999574976994")]
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
