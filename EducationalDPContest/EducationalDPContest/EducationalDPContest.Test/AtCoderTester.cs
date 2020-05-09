using System;
using Xunit;
using EducationalDPContest.Questions;
using System.Collections.Generic;
using System.Linq;

namespace EducationalDPContest.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"4
10 30 40 20", @"30")]
        [InlineData(@"2
10 10", @"0")]
        [InlineData(@"6
30 10 60 10 60 50", @"40")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 3
10 30 40 50 20", @"30")]
        [InlineData(@"3 1
10 20 10", @"20")]
        [InlineData(@"2 100
10 10", @"0")]
        [InlineData(@"10 4
40 10 20 70 80 10 20 70 80 60", @"40")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
10 40 70
20 50 80
30 60 90", @"210")]
        [InlineData(@"1
100 10 1", @"100")]
        [InlineData(@"7
6 7 8
8 8 3
2 5 2
7 8 6
4 6 8
2 3 4
7 5 1", @"46")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 8
3 30
4 50
5 60", @"90")]
        [InlineData(@"5 5
1 1000000000
1 1000000000
1 1000000000
1 1000000000
1 1000000000", @"5000000000")]
        [InlineData(@"6 15
6 5
5 6
6 4
6 6
3 5
7 2", @"17")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 8
3 30
4 50
5 60", @"90")]
        [InlineData(@"1 1000000000
1000000000 10", @"10")]
        [InlineData(@"6 15
6 5
5 6
6 4
6 6
3 5
7 2", @"17")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        
        [Theory]
        [InlineData(@"axyb
abyxb", @"axb")]
        [InlineData(@"aa
xayaz", @"aa")]
        [InlineData(@"a
z", @"")]
        [InlineData(@"abracadabra
avadakedavra", @"aaadara")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 5
1 2
1 3
3 2
2 4
3 4", @"3")]
        [InlineData(@"6 3
2 3
4 5
5 6", @"2")]
        [InlineData(@"5 8
5 3
2 3
2 4
5 2
5 1
1 4
4 3
1 3", @"3")]
        public void QuestionGTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionG();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 4
...#
.#..
....", @"3")]
        [InlineData(@"5 2
..
#.
..
.#
..", @"0")]
        [InlineData(@"5 5
..#..
.....
#...#
.....
..#..", @"24")]
        [InlineData(@"20 20
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................", @"345263555")]
        public void QuestionHTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionH();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
0.30 0.60 0.80", @"0.612")]
        [InlineData(@"1
0.50", @"0.5")]
        [InlineData(@"5
0.42 0.01 0.42 0.99 0.42", @"0.3821815872")]
        public void QuestionITest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionI();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs.Select(double.Parse), answers.Select(double.Parse));
        }

        [Theory]
        [InlineData(@"3
1 1 1", @"5.5")]
        [InlineData(@"1
3", @"3")]
        [InlineData(@"2
1 2", @"4.5")]
        [InlineData(@"10
1 3 2 3 3 2 3 2 1 3", @"54.48064457488221")]
        public void QuestionJTest(string input, string output)
        {
            var outputs = SplitByNewLine(output).Select(double.Parse).ToArray();
            IAtCoderQuestion question = new QuestionJ();

            var answers = question.Solve(input).Select(o => o.ToString()).Select(double.Parse).ToArray();

            Assert.Equal(outputs.Length, answers.Length);
            for (int i = 0; i < answers.Length; i++)
            {
                Assert.True(Math.Abs(outputs[i] - answers[i]) < 1e-9);
            }
        }


        IEnumerable<string> SplitByNewLine(string input) => input?.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None) ?? new string[0];
    }
}
