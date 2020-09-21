using System;
using Xunit;
using Training20200919.Questions;
using System.Collections.Generic;
using System.Linq;
using Training20200919.Collections;

namespace Training20200919.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"2
12 5
1000 2000", @"1")]
        [InlineData(@"3
21 -11
81234 94124 52141", @"3")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"hihi", @"Yes")]
        [InlineData(@"hi", @"Yes")]
        [InlineData(@"ha", @"No")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 4 2 3 7
1 1 9
1 2 7
1 3 15
1 4 6
2 2 3
2 4 6
3 3 6", @"37")]
        [InlineData(@"4 5 3 2 9
2 3 5
3 1 4
2 2 2
4 1 9
3 5 3
3 3 8
1 4 5
1 5 7
2 4 8", @"26")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 3
7 9", @"4")]
        [InlineData(@"3 0
3 4 5", @"5")]
        [InlineData(@"10 10
158260522 877914575 602436426 24979445 861648772 623690081 433933447 476190629 262703497 211047202", @"292638192")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"abcbcba", @"21")]
        [InlineData(@"mississippi", @"53")]
        [InlineData(@"ababacaca", @"33")]
        [InlineData(@"aaaaa", @"5")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
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
