using System;
using Xunit;
using AtCoderBeginnerContest168.Questions;
using System.Collections.Generic;
using System.Linq;
using AtCoderBeginnerContest168.Collections;

namespace AtCoderBeginnerContest168.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"16", @"pon")]
        [InlineData(@"2", @"hon")]
        [InlineData(@"183", @"bon")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"7
nikoandsolstice", @"nikoand...")]
        [InlineData(@"40
ferelibenterhominesidquodvoluntcredunt", @"ferelibenterhominesidquodvoluntcredunt")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 4 9 0", @"5.00000000000000000000")]
        [InlineData(@"3 4 10 40", @"4.56425719433005567605")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();
            AssertNearlyEqual(outputs, answers, 1e-9);
        }

        [Theory]
        [InlineData(@"4 4
1 2
2 3
3 4
4 2", @"Yes
1
2
2")]
        [InlineData(@"6 9
3 4
6 1
2 4
5 3
4 6
1 5
6 2
4 5
5 6", @"Yes
6
5
5
1
1")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1 2
-1 1
2 -1", @"5")]
        [InlineData(@"10
3 2
3 2
-1 1
2 -1
-3 -9
-8 12
7 7
8 1
8 2
8 4", @"479")]
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
