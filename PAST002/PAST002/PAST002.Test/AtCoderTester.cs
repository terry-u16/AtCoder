using System;
using Xunit;
using PAST002.Questions;
using System.Collections.Generic;
using System.Linq;
using PAST002.Collections;

namespace PAST002.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"1F 5F", @"4")]
        [InlineData(@"B1 B7", @"6")]
        [InlineData(@"1F B1", @"1")]
        [InlineData(@"B9 9F", @"17")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"abbc", @"b")]
        [InlineData(@"cacca", @"c")]
        [InlineData(@"b", @"b")]
        [InlineData(@"babababacaca", @"a")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
....#....
...##X...
..#####..
.#X#####.
#########", @"....X....
...XXX...
..XX###..
.#X#####.
#########")]
        [InlineData(@"2
.#.
#X#", @".X.
#X#")]
        [InlineData(@"10
.........#.........
........###........
.......#####.......
......#######......
.....#########.....
....###########....
...#############...
..###############..
.#################.
X#X########X#X####X", @".........X.........
........XXX........
.......XXXXX.......
......XXXXXXX......
.....XXXXXXXXX.....
....XXXXXXXXXXX....
...XXX##XXXXXXXX...
..XXX####XXXXXXXX..
.XXX######XXXXX##X.
X#X########X#X####X")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"ab", @"7")]
        [InlineData(@"aa", @"6")]
        [InlineData(@"aabbaabb", @"33")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6
1 3 2 5 6 4", @"1 2 2 3 3 3")]
        [InlineData(@"3
3 2 1", @"2 1 2")]
        [InlineData(@"2
1 2", @"1 1")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1 3
2 2
2 4", @"3
7
9")]
        [InlineData(@"5
5 3
4 1
3 4
2 1
1 5", @"5
6
10
11
14")]
        [InlineData(@"6
1 8
1 6
2 9
3 1
3 2
4 1", @"8
17
23
25
26
27")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6
1 a 5
2 3
1 t 8
1 c 10
2 21
2 4", @"9
168
0")]
        [InlineData(@"4
1 x 5
1 y 8
2 7
1 z 8", @"29")]
        [InlineData(@"3
1 p 3
1 q 100000
2 100000", @"9999400018")]
        public void QuestionGTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionG();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 4
1S23
4567
89G1", @"17")]
        [InlineData(@"1 11
S134258976G", @"20")]
        [InlineData(@"3 3
S12
4G7
593", @"-1")]
        public void QuestionHTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionH();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
2 4 3 1", @"1
2
2
1")]
        [InlineData(@"1
2 1", @"1
1")]
        [InlineData(@"3
4 7 5 1 6 3 2 8", @"1
3
2
1
2
1
1
3")]
        public void QuestionITest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionI();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"(ab)c", @"abbac")]
        [InlineData(@"past", @"past")]
        [InlineData(@"(d(abc)e)()", @"dabccbaeeabccbad")]
        public void QuestionJTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionJ();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
))(
3 5 7
2 6 5", @"8")]
        [InlineData(@"1
(
10
20", @"20")]
        [InlineData(@"10
))())((()(
13 18 17 3 20 20 6 14 14 2
20 1 19 5 2 19 2 19 9 4", @"18")]
        [InlineData(@"4
()()
17 8 3 19
5 3 16 3", @"0")]
        public void QuestionKTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionK();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 2 2
3 1 4", @"3 4")]
        [InlineData(@"3 3 2
3 1 4", @"-1")]
        [InlineData(@"3 2 1
3 1 4", @"1 4")]
        [InlineData(@"4 2 2
3 6 5 5", @"3 5")]
        public void QuestionLTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionL();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        public void QuestionMTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionM();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 4
1 3 6 10
3 6 6 20
4 7
-1 -1
1 4
7 13", @"30
0
10
0")]
        [InlineData(@"2 3
-3 5 4 100
1 9 7 30
1 9
1 8
8 10", @"130
100
30")]
        [InlineData(@"10 10
17 2 17 1000000000
7 12 12 1000000000
2 12 8 1000000000
2 12 2 1000000000
3 9 16 1000000000
8 13 15 1000000000
8 1 3 1000000000
15 9 17 1000000000
16 5 5 1000000000
13 12 9 1000000000
17 3
4 10
1 9
5 3
17 12
14 19
19 17
17 11
16 17
12 16", @"1000000000
1000000000
0
0
5000000000
4000000000
6000000000
3000000000
5000000000
3000000000")]
        public void QuestionNTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionN();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

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
