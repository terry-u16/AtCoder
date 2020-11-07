using System;
using Xunit;
using Training20201015.Questions;
using System.Collections.Generic;
using System.Linq;
using Training20201015.Collections;

namespace Training20201015.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"5 7 1
1 4 3 4 2 3 1", @"4
2
5
3
1")]
        [InlineData(@"5 7 2
1 4 3 4 2 3 1", @"3
2
1
5
4")]
        [InlineData(@"10 20 300
9 1 2 5 8 1 9 3 5 6 4 5 4 6 8 3 2 7 9 6", @"3
7
2
4
5
9
6
1
8
10")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
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
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
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
