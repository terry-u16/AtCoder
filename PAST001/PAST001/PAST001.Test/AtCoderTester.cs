using System;
using Xunit;
using PAST001.Questions;
using System.Collections.Generic;
using System.Linq;
using PAST001.Collections;

namespace PAST001.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"678", @"1356")]
        [InlineData(@"abc", @"error")]
        [InlineData(@"0x8", @"error")]
        [InlineData(@"012", @"24")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"10
9
10
3
100
100
90
80
10
30
10", @"up 1
down 7
up 97
stay
down 10
down 10
down 70
up 20
down 20")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 18 25 20 9 13", @"18")]
        [InlineData(@"95 96 97 98 99 100", @"98")]
        [InlineData(@"19 92 3 35 78 1", @"35")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6
1
5
6
3
2
6", @"6 4")]
        [InlineData(@"7
5
4
3
2
7
6
1", @"Correct")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6 7
1 1 2
1 2 3
1 3 4
1 1 5
1 5 6
3 1
2 6", @"NYYNYY
NNYNNN
NNNYNN
NNNNNN
NNNNNY
YNNNYN")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"FisHDoGCaTAAAaAAbCAC", @"AAAaAAbCACCaTDoGFisH")]
        [InlineData(@"AAAAAjhfgaBCsahdfakGZsZGdEAA", @"AAAAAAAjhfgaBCsahdfakGGdEZsZ")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6
10 10 -10 -10 -10
10 -10 -10 -10
-10 -10 -10
10 -10
-10", @"40")]
        [InlineData(@"3
1 1
1", @"3")]
        public void QuestionGTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionG();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
5 3 3 5
6
1 2 1
2 2
2 2
3 100
3 1
1 1 3", @"9")]
        [InlineData(@"10
241 310 105 738 405 490 158 92 68 20
20
2 252
1 4 36
2 69
1 5 406
3 252
1 3 8
1 10 10
3 11
1 4 703
3 1
2 350
3 10
2 62
2 3
2 274
1 2 1
3 126
1 4 702
3 6
2 174", @"390")]
        [InlineData(@"2
3 4
3
1 2 9
2 4
3 4", @"0")]
        public void QuestionHTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionH();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 4
YYY 100
YYN 20
YNY 10
NYY 25", @"30")]
        [InlineData(@"5 4
YNNNN 10
NYNNN 10
NNYNN 10
NNNYN 10", @"-1")]
        [InlineData(@"10 14
YNNYNNNYYN 774472905
YYNNNNNYYY 75967554
NNNNNNNNNN 829389188
NNNNYYNNNN 157257407
YNNYNNYNNN 233604939
NYYNNNNNYY 40099278
NNNNYNNNNN 599672237
NNNYNNNNYY 511018842
NNNYNNYNYN 883299962
NNNNNNNNYN 883093359
NNNNNYNYNY 54742561
NYNNYYYNNY 386272705
NNNNYYNNNN 565075143
NNYNYNNNYN 123300589", @"451747367")]
        public void QuestionITest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionI();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 6
9 9 9 9 1 0
9 9 9 9 1 9
9 9 9 1 1 1
9 1 1 1 9 1
0 1 9 9 9 0", @"10")]
        [InlineData(@"10 10
1 2 265 1544 0 1548 4334 9846 58 0
21 0 50 44 2 388 5 0 0 4
170 0 2 1 54 1379 50 3 41 0
310 0 1 0 2163 0 226 26 3 12
151 33 0 9 0 0 0 36 365 2286
0 3 12 3 9 317 645 100 21 4
52 1 569 0 144 0 6 202 25 0
8869 19 2058 1948 1252 1002 7 1750 0 5
0 3 8 29 2 4403 0 0 0 5
0 17 93 9367 159 6 1 216 0 0", @"246")]
        public void QuestionJTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionJ();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"7
-1
1
1
2
2
3
3
6
7 1
4 1
2 3
5 1
5 2
2 5", @"Yes
Yes
No
Yes
Yes
No")]
        [InlineData(@"20
4
11
12
-1
1
13
13
4
6
20
1
1
20
10
8
8
20
10
18
1
20
18 14
11 3
2 13
13 11
10 15
9 5
17 11
18 10
1 16
9 4
19 6
5 10
17 8
15 8
5 16
6 20
3 19
10 12
5 13
18 1", @"No
No
No
No
No
No
No
Yes
No
Yes
No
No
No
Yes
No
Yes
No
No
No
Yes")]
        public void QuestionKTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionK();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionLTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionL();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6 2
10 30
20 60
10 10
30 100
50 140
40 120
10 3
30 1", @"3.0000000000000")]
        [InlineData(@"6 2
1 20
1 3
32 100
1 1
1 2
2 5
10 100
96 874", @"9.0000000000000")]
        public void QuestionMTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionM();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 10 5
1 3 100
8 10 123
4 6 3", @"3")]
        [InlineData(@"22 30 10
0 30 1000000000
0 30 1000000000
0 30 1000000000
7 30 261806
6 19 1
5 18 1238738
12 28 84
10 14 5093
9 20 9
15 26 8739840
6 8 240568
14 19 198
2 4 1102
1 29 5953283
9 20 183233
9 13 44580
6 23 787237159
12 14 49
28 29 9020727
14 20 318783
2 19 9862194
9 30 166652", @"3805189325")]
        public void QuestionNTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionN();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionOTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionO();

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
