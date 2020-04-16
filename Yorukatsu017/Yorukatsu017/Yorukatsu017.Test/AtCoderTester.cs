using System;
using Xunit;
using Yorukatsu017.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu017.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"6
G W Y P Y W", @"Four")]
        [InlineData(@"9
G W W G P W P G G", @"Three")]
        [InlineData(@"8
P Y W G Y W Y Y", @"Four")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 5
.....
.#.#.
.....", @"11211
1#2#1
11211")]
        [InlineData(@"3 5
#####
#####
#####", @"#####
#####
#####")]
        [InlineData(@"6 6
#####.
#.#.##
####.#
.#..#.
#.##..
#.#...", @"#####3
#8#7##
####5#
4#65#2
#5##21
#4#310")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
4 8", @"8")]
        [InlineData(@"3
1 1 3", @"3")]
        [InlineData(@"3
4 2 5", @"5")]
        [InlineData(@"4
-100 -100 -100 -100", @"0")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"0 0 1 2", @"UURDDLLUUURRDRDDDLLU")]
        // [InlineData(@"-2 -2 1 1", @"UUURRRRDDDLLDLLULUUURRURRDDDLLDL")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 3
0 1 1
1 0 1
1 4 0
1 2
3 3", @"3")]
        [InlineData(@"4 3
0 12 71
81 0 53
14 92 0
1 1 2 1
2 1 1 2
2 2 1 3
1 1 2 2", @"428")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 3
10 14 19 34 33", @"202")]
        [InlineData(@"9 14
1 3 5 110 24 21 34 5 3", @"1837")]
        [InlineData(@"9 73
67597 52981 5828 66249 75177 64141 40773 79105 16076", @"8128170")]
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
