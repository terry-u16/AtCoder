using System;
using Xunit;
using PAST003.Questions;
using System.Collections.Generic;
using System.Linq;
using PAST003.Collections;

namespace PAST003.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"AbC
ABc", @"case-insensitive")]
        [InlineData(@"xyz
xyz", @"same")]
        [InlineData(@"aDs
kjH", @"different")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 1 6
2 1 1
1 1
1 2
2 2 1
1 1
1 2", @"1
0
0
0")]
        [InlineData(@"5 5 30
1 3
2 3 5
1 3
2 2 1
2 4 5
2 5 2
2 2 3
1 4
2 4 1
2 2 2
1 1
1 5
2 5 3
2 4 4
1 4
1 2
2 3 3
2 4 3
1 3
1 5
1 3
2 1 3
1 1
2 2 4
1 1
1 4
1 5
1 4
1 1
1 5", @"0
4
3
0
3
10
9
4
4
4
0
0
9
3
9
0
3")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 3 4", @"54")]
        [InlineData(@"4 3 21", @"large")]
        [InlineData(@"12 34 5", @"16036032")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"10
.###..#..###.###.#.#.###.###.###.###.###.
.#.#.##....#...#.#.#.#...#.....#.#.#.#.#.
.#.#..#..###.###.###.###.###...#.###.###.
.#.#..#..#.....#...#...#.#.#...#.#.#...#.
.###.###.###.###...#.###.###...#.###.###.", @"0123456789")]
        [InlineData(@"29
.###.###.###.###.###.###.###.###.###.#.#.###.#.#.#.#.#.#.###.###.###.###..#..###.###.###.###.###.#.#.###.###.###.###.
...#.#.#...#.#.#.#.#.#...#.#...#.#.#.#.#.#...#.#.#.#.#.#.#.....#.#.#.#.#.##..#.#...#.#.#...#.#...#.#...#.#.....#...#.
.###.#.#...#.###.#.#.###.###...#.###.###.###.###.###.###.###...#.###.#.#..#..###...#.###.###.###.###.###.###.###.###.
.#...#.#...#...#.#.#.#.#...#...#.#.#...#.#.#...#...#...#.#.#...#...#.#.#..#..#.#...#...#.#...#.#...#.#.....#...#.#...
.###.###...#.###.###.###.###...#.###...#.###...#...#...#.###...#.###.###.###.###...#.###.###.###...#.###.###.###.###.", @"20790697846444679018792642532")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 2 3
1 2
2 3
5 10 15
1 2
2 1 20
1 1", @"10
10
20")]
        [InlineData(@"30 10 20
11 13
30 14
6 4
7 23
30 8
17 4
6 23
24 18
26 25
9 3
18 4 36 46 28 16 34 19 37 23 25 7 24 16 17 41 24 38 6 29 10 33 38 25 47 8 13 8 42 40
2 1 9
1 8
1 9
2 20 24
2 26 18
1 20
1 26
2 24 31
1 4
2 21 27
1 25
1 29
2 10 14
2 2 19
2 15 36
2 28 6
2 13 5
1 12
1 11
2 14 43", @"18
19
37
29
8
24
18
25
46
10
18
42
23
4
17
8
24
7
25
16")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
yc
ys", @"yy")]
        [InlineData(@"2
rv
jh", @"-1")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1 2 2
1 1", @"3")]
        [InlineData(@"1 2 2
2 1", @"2")]
        [InlineData(@"5 -2 3
1 1
-1 1
0 1
-2 1
-3 1", @"6")]
        public void QuestionGTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionG();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 5
1 4
2 2 20", @"10")]
        [InlineData(@"4 5
1 2 3 4
2 20 100", @"164")]
        [InlineData(@"10 19
1 3 4 5 7 8 10 13 15 17
2 1000 10", @"138")]
        [InlineData(@"2 6
4 5
2 4 10000", @"17")]

        public void QuestionHTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionH();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
19
4 1 1
4 1 2
4 2 1
4 2 2
3
4 1 1
4 1 2
4 2 1
4 2 2
1 1 2
4 1 1
4 1 2
4 2 1
4 2 2
2 2 1
4 1 1
4 1 2
4 2 1
4 2 2", @"0
1
2
3
0
2
1
3
1
3
0
2
3
1
2
0")]
        [InlineData(@"3
9
2 2 3
3
1 2 1
2 3 2
1 1 3
3
4 1 1
4 2 2
4 2 3", @"1
6
8")]
        public void QuestionITest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionI();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 5
5 3 2 4 8", @"1
2
-1
2
1")]
        [InlineData(@"5 10
13 16 6 15 10 18 13 17 11 3", @"1
1
2
2
3
1
3
2
4
5")]
        [InlineData(@"10 30
35 23 43 33 38 25 22 39 22 6 41 1 15 41 3 20 50 17 25 14 1 22 5 10 34 38 1 12 15 1", @"1
2
1
2
2
3
4
2
5
6
2
7
6
3
7
6
1
7
4
8
9
6
9
9
4
4
10
9
8
-1")]
        public void QuestionJTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionJ();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 4
1 2 1
2 3 2
3 1 3
1 3 2", @"3
3
1")]
        [InlineData(@"10 20
3 6 3
6 5 6
10 8 10
5 7 3
1 3 1
4 10 4
5 4 6
10 7 4
7 9 3
9 8 4
8 1 4
3 7 1
2 3 2
9 8 3
8 1 10
8 2 8
9 10 9
2 1 8
4 9 6
1 7 4", @"7
3
7
7
5
9
7
7
10
7")]
        public void QuestionKTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionK();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
3 1 200 1000
5 20 30 40 50 2
5
1 1 1 2 2", @"20
30
40
200
1000")]
        [InlineData(@"10
6 8 24 47 29 73 13
1 4
5 72 15 68 49 16
5 65 20 93 64 91
6 100 88 63 50 90 44
2 6 1
10 14 2 76 28 21 78 43 11 97 70
5 31 9 62 84 40
8 10 46 96 23 98 19 38 51
2 37 77
20
1 1 1 1 2 2 2 1 1 2 2 2 2 2 1 2 1 2 2 1", @"100
88
72
65
93
77
68
63
50
90
64
91
49
46
44
96
37
31
62
20")]
        public void QuestionLTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionL();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 2
1 2
2 3
2
2
1 3", @"3")]
        [InlineData(@"5 5
1 2
1 3
1 4
1 5
2 3
1
3
2 3 5", @"4")]
        public void QuestionMTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionM();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionNTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionN();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionOTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionO();

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
