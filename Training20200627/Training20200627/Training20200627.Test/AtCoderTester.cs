using System;
using Xunit;
using Training20200627.Questions;
using System.Collections.Generic;
using System.Linq;
using Training20200627.Collections;

namespace Training20200627.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"5
2 5
1 5
2 4
3 2", @"14")]
        [InlineData(@"10
7 9
8 1
9 6
10 8
8 6
10 3
5 8
4 8
2 5", @"192")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 5 2
xoooo
oooox
ooooo
oxxoo", @"3")]
        [InlineData(@"4 5 2
ooooo
oxoox
oooox
oxxoo", @"0")]
        [InlineData(@"8 6 3
oooooo
oooooo
oooooo
oooooo
oxoooo
oooooo
oooooo
oooooo", @"4")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 3
2 3
3 5", @"10")]
        [InlineData(@"3 7
1 2 1
2 1 2", @"2")]
        [InlineData(@"4 8
701687787 500872619 516391519 599949380
458299111 633119409 377269575 717229869", @"317112176525562171")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1 -1 3", @"3")]
        [InlineData(@"6
2 -1 -1 9 -1 9", @"36")]
        [InlineData(@"5
1 -1 -1 -1 1000000000", @"999999972")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
0 0
0 1
1 0
1 1
0 2
2 0
-2 0
0 -2", @"2.8284271247")]
        [InlineData(@"6
3 4
1 3
4 3
2 2
0 1
2 0
5 5
-1 2
-1 -3
2 1
2 6
4 -3", @"2.2360679775")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            AssertNearlyEqual(outputs, answers, 1e-6);
        }

        [Theory]
        [InlineData(@"5
1 2
1 3
1 4
4 5
3
2 3
2 5
2 4", @"3
4
3")]
        [InlineData(@"6
1 2
2 3
3 4
4 5
5 6
4
1 3
1 4
1 5
1 6", @"3
4
5
6")]
        [InlineData(@"7
3 1
2 1
2 4
2 5
3 6
3 7
5
4 5
1 6
5 6
4 7
5 3", @"3
3
5
5
4")]
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
