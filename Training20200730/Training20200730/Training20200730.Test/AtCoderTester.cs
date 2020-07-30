using System;
using Xunit;
using Training20200730.Questions;
using System.Collections.Generic;
using System.Linq;
using Training20200730.Collections;

namespace Training20200730.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"5 3 7
1
3
6
9
12", @"5")]
        [InlineData(@"7 5 3
0
2
4
7
8
11
15", @"4")]
        [InlineData(@"8 2 9
3
4
5
13
15
22
26
32", @"13")]
        [InlineData(@"3 3 4
5
6
7", @"0")]
        [InlineData(@"3 1 100
5
6
7", @"4")]
        [InlineData(@"1 100 100
1", @"2")]
        [InlineData(@"2 100 100
1
2", @"2")]
        [InlineData(@"5 100 100
1
2
3
4
5", @"0")]
        [InlineData(@"5 2 100
1
4
7
9
10
14", @"0")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 4
1 2 2000
2 3 2004
3 4 1999
4 5 2001
3
1 2000
1 1999
3 1995", @"1
3
5")]
        [InlineData(@"4 5
1 2 2005
3 1 2001
3 4 2002
1 4 2004
4 2 2003
5
1 2003
2 2003
1 2001
3 2003
4 2004", @"3
3
4
1
1")]
        [InlineData(@"4 5
1 2 10
1 2 1000
2 3 10000
2 3 100000
3 1 200000
4
1 0
2 10000
3 100000
4 0", @"3
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
        [InlineData(@"4 8
7 9 8 9", @"5")]
        [InlineData(@"3 8
6 6 9", @"0")]
        [InlineData(@"8 5
3 6 2 8 7 6 5 9", @"19")]
        [InlineData(@"33 3
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3", @"8589934591")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
1
2
4
5
10", @"2")]
        [InlineData(@"10
11
12
13
14
15
16
17
18
19
20", @"0")]
        [InlineData(@"20
1
2
3
4
5
6
7
8
9
10
11
12
13
14
15
16
17
18
19
20", @"94")]
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
