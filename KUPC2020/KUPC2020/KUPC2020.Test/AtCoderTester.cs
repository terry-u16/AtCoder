using System;
using Xunit;
using KUPC2020.Questions;
using System.Collections.Generic;
using System.Linq;
using KUPC2020.Collections;

namespace KUPC2020.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"3
1 2
2 3
4 6", @"7")]
        [InlineData(@"1
0 0", @"0")]
        [InlineData(@"4
-2 3
1 4
5 2
4 -2", @"15")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 2
2 4
1 5", @"2")]
        [InlineData(@"2 3
4 5 6
1 2 3", @"0")]
        [InlineData(@"20 20
2 8 12 17 19 29 41 53 57 62 63 65 67 70 71 74 76 77 96 100
2 3 9 13 15 16 20 26 28 33 38 39 46 51 58 59 74 92 93 99
2 5 6 9 19 20 22 24 26 35 41 45 56 60 62 74 76 81 83 96
3 7 10 11 13 15 17 20 22 26 34 35 43 59 68 78 82 83 85 93
1 7 11 14 17 26 37 41 45 49 62 63 64 67 71 74 88 89 91 94
12 15 17 19 22 24 28 29 31 46 50 51 55 59 64 65 74 79 91 95
7 11 17 22 23 27 29 33 37 39 45 50 51 52 62 67 69 71 85 90
9 11 12 18 22 30 40 41 43 49 51 59 62 71 74 94 95 96 99 100
15 17 21 23 24 28 33 39 44 45 48 52 54 59 72 76 88 89 99 100
1 6 12 13 14 21 25 37 48 49 56 57 71 72 77 79 83 85 93 98
10 20 22 25 34 45 49 52 58 60 62 67 69 74 75 77 81 84 96 97
6 7 23 36 41 43 45 46 50 51 52 57 58 61 73 74 85 87 94 97
4 20 26 36 37 41 44 45 47 51 56 57 72 73 74 79 86 91 97 98
8 10 17 24 25 29 31 32 34 46 53 57 60 71 74 78 79 80 90 91
12 15 16 17 27 32 33 35 41 51 55 56 58 67 69 71 74 89 90 91
4 13 17 24 25 27 39 40 43 48 51 54 61 62 63 68 72 76 87 90
8 10 12 18 22 37 40 43 46 50 51 58 59 65 74 85 86 89 96 98
1 9 16 17 19 34 37 50 54 55 57 58 59 69 72 76 77 84 92 99
3 10 11 12 13 17 24 28 36 39 45 49 50 58 74 78 79 80 84 93
5 15 16 20 22 24 29 41 44 55 56 60 62 63 68 73 85 86 93 100", @"188926982")]
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
