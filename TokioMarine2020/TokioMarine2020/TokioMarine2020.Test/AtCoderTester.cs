using System;
using Xunit;
using TokioMarine2020.Questions;
using System.Collections.Generic;
using System.Linq;
using TokioMarine2020.Collections;

namespace TokioMarine2020.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"takahashi", @"tak")]
        [InlineData(@"naohiro", @"nao")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1 2
3 1
3", @"YES")]
        [InlineData(@"1 2
3 2
3", @"NO")]
        [InlineData(@"1 2
3 3
3", @"NO")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 1
1 0 0 1 0", @"1 2 2 1 2")]
        [InlineData(@"5 2
1 0 0 1 0", @"3 3 4 4 3")]
        [InlineData(@"5 3
0 0 0 0 0", @"4 4 5 4 4")]
        [InlineData(@"5 4
0 0 0 0 0", @"5 5 5 5 5")]
        [InlineData(@"5 200000
0 0 0 0 0", @"5 5 5 5 5")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1 2
2 3
3 4
3
1 1
2 5
3 5", @"0
3
3")]
        [InlineData(@"15
123 119
129 120
132 112
126 109
118 103
115 109
102 100
130 120
105 105
132 115
104 102
107 107
127 116
121 104
121 115
8
8 234
9 244
10 226
11 227
12 240
13 237
14 206
15 227", @"256
255
250
247
255
259
223
253")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
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
