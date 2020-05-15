using System;
using Xunit;
using Yorukatsu040.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu040.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"3 4 5", @"6")]
        [InlineData(@"5 12 13", @"30")]
        [InlineData(@"45 28 53", @"630")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1 0 1
2 1 2
1 0 1", @"Yes")]
        [InlineData(@"2 2 2
2 1 2
2 2 2", @"No")]
        [InlineData(@"0 8 8
0 8 8
0 8 8", @"Yes")]
        [InlineData(@"1 8 6
2 9 7
0 7 7", @"No")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 4
##.#
....
##.#
.#.#", @"###
###
.##")]
        [InlineData(@"3 3
#..
.#.
..#", @"#..
.#.
..#")]
        [InlineData(@"4 5
.....
.....
..#..
.....", @"#")]
        [InlineData(@"7 6
......
....#.
.#....
..#...
..#...
......
.#..#.", @"..#
#..
.#.
.#.
#.#")]
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
2 3", @"2
1
2")]
        [InlineData(@"8
1 2
2 3
2 4
2 5
4 7
5 6
6 8", @"4
1
2
3
4
1
1
2")]
        [InlineData(@"6
1 2
1 3
1 4
1 5
1 6", @"5
1
2
3
4
5")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 100 90 80
98
40
30
21
80", @"23")]
        [InlineData(@"8 100 90 80
100
100
90
90
90
80
80
80", @"0")]
        [InlineData(@"8 1000 800 100
300
333
400
444
500
555
600
666", @"243")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3
1 2 4
2 3 3
1 3 5", @"7")]
        [InlineData(@"2 2
1 2 1
2 1 1", @"inf")]
        [InlineData(@"6 5
1 2 -1000000000
2 3 -1000000000
3 4 -1000000000
4 5 -1000000000
5 6 -1000000000", @"-5000000000")]
        [InlineData(@"5 6
1 2 1
2 3 1
3 4 1
4 2 1
2 5 1
1 5 10000000", @"inf")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        IEnumerable<string> SplitByNewLine(string input) => input?.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None) ?? new string[0];
    }
}
