using System;
using Xunit;
using Training20200706.Questions;
using System.Collections.Generic;
using System.Linq;
using Training20200706.Collections;

namespace Training20200706.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"3.0000", @"2.8708930019")]
        [InlineData(@"0.0400", @"0.0400000000")]
        [InlineData(@"1000000000000000000.0000", @"90.1855078128")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            AssertNearlyEqual(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 50
3
14
15
9", @"48")]
        [InlineData(@"3 21
16
11
2", @"20")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
3
1 1 0
1 0 1
1 1 0", @"5")]
        [InlineData(@"5
3
1 1 1 0 1
1 1 0 0 0
1 0 0 0 1", @"5")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3
..#
#..
...", @"2")]
        [InlineData(@"10 37
.....................................
...#...####...####..###...###...###..
..#.#..#...#.##....#...#.#...#.#...#.
..#.#..#...#.#.....#...#.#...#.#...#.
.#...#.#..##.#.....#...#.#.###.#.###.
.#####.####..#.....#...#..##....##...
.#...#.#...#.#.....#...#.#...#.#...#.
.#...#.#...#.##....#...#.#...#.#...#.
.#...#.####...####..###...###...###..
.....................................", @"209")]
        [InlineData(@"2 2
.#
#.", @"-1")]

        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"11
8 3 2 4 8 7 2 4 0 8 8", @"10")]
        [InlineData(@"40
1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0 0 1 1", @"7069052760")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 3
3 1
1 1
4 2", @"6")]
        [InlineData(@"20 5
10 2
4 3
12 1
13 2
9 1", @"2640")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
2
8
1
10
9", @"18")]
        [InlineData(@"8
1
10
4
5
6
2
9
3", @"26")]
        [InlineData(@"15
182243672
10074562
977552215
122668426
685444213
3784162
463324752
560071245
134465220
21447865
654556327
183481051
20041805
405079805
564327789", @"3600242976")]
        public void QuestionGTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionG();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
OI", @"7")]
        [InlineData(@"20
JIOIJOIJOJOIIIOJIOII", @"4976")]
        public void QuestionHTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionH();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 3 1
1 2 2
2 3 9
2 4 5", @"16")]
        [InlineData(@"5 6 2
1 2 5
1 3 3
2 3 4
2 5 7
3 4 6
4 5 5", @"12")]
        public void QuestionITest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionI();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1 1 200 500
300", @"1")]
        [InlineData(@"1 8 10 200
30 40 10 20 30 40 10 20", @"6")]
        [InlineData(@"5 5 10 17
12 19 25 13 25
14 16 18 11 10
19 17 24 26 12
23 11 16 19 14
18 23 27 11 16", @"0")]
        [InlineData(@"4 7 10 240
17 12 15 18 19 15 23
22 12 41 16 27 10 10
15 69 18 11 10 23 15
12 20 13 12 17 18 15", @"9")]
        public void QuestionJTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionJ();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6
0 1 2 3 4 5", @"3")]
        [InlineData(@"3
0 0 0", @"6")]
        [InlineData(@"54
0 0 1 0 1 2 1 2 3 2 3 3 4 4 5 4 6 5 7 8 5 6 6 7 7 8 8 9 9 10 10 11 9 12 10 13 14 11 11 12 12 13 13 14 14 15 15 15 16 16 16 17 17 17", @"115295190")]
        [InlineData(@"6
0 1 0 0 1 2", @"24")]
        public void QuestionKTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionK();

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
