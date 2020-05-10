using System;
using Xunit;
using AtCoderBeginnerContest167.Questions;
using System.Collections.Generic;
using System.Linq;
using AtCoderBeginnerContest167.Collections;

namespace AtCoderBeginnerContest167.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"chokudai
chokudaiz", @"Yes")]
        [InlineData(@"snuke
snekee", @"No")]
        [InlineData(@"a
aa", @"Yes")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 1 1 3", @"2")]
        [InlineData(@"1 2 3 4", @"0")]
        [InlineData(@"1 2 3 6", @"-2")]
        [InlineData(@"2000000000 0 0 2000000000", @"2000000000")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3 10
60 2 2 4
70 8 7 9
50 2 3 9", @"120")]
        [InlineData(@"3 3 10
100 3 1 4
100 1 5 9
100 2 6 5", @"-1")]
        [InlineData(@"8 5 22
100 3 7 5 3 1
164 4 5 2 7 8
334 7 2 7 2 9
234 4 7 2 8 2
541 5 4 3 3 6
235 4 8 6 9 7
394 3 6 1 6 2
872 8 4 3 7 2", @"1067")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 5
3 2 4 1", @"4")]
        [InlineData(@"6 727202214173249351
6 5 2 5 3 2", @"2")]
        [InlineData(@"3 4
2 3 2", @"3")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 2 1", @"6")]
        [InlineData(@"100 100 0", @"73074801")]
        [InlineData(@"60522 114575 7559", @"479519525")]
        [InlineData(@"3 1 1", @"0")]
        [InlineData(@"1 1 0", @"1")]
        [InlineData(@"1 100 0", @"100")]
        [InlineData(@"2 2 1", @"4")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
)
(()", @"Yes")]
        [InlineData(@"2
)(
()", @"No")]
        [InlineData(@"4
((()))
((((((
))))))
()()()", @"Yes")]
        [InlineData(@"3
(((
)
)", @"No")]
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
