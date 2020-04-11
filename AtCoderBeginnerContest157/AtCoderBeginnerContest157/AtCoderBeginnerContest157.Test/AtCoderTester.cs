using System;
using Xunit;
using AtCoderBeginnerContest157.Questions;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderBeginnerContest157.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"5", @"3")]
        [InlineData(@"2", @"1")]
        [InlineData(@"100", @"50")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"84 97 66
79 89 11
61 59 7
7
89
7
87
79
24
84
30", @"Yes")]
        [InlineData(@"41 7 46
26 89 2
78 92 8
5
6
45
16
57
17", @"No")]
        [InlineData(@"60 88 34
92 41 43
65 73 48
10
60
43
88
11
48
73
65
41
92
34", @"Yes")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3
1 7
3 2
1 7", @"702")]
        [InlineData(@"3 2
2 1
2 3", @"-1")]
        [InlineData(@"3 1
1 0", @"-1")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 4 1
2 1
1 3
3 2
3 4
4 1", @"0 1 0 1")]
        [InlineData(@"5 10 0
1 2
1 3
1 4
1 5
3 2
2 4
2 5
4 3
5 3
4 5", @"0 0 0 0 0")]
        [InlineData(@"10 9 3
10 1
6 7
8 2
2 5
8 4
7 3
10 9
6 4
5 8
2 6
7 5
3 1", @"1 3 5 4 3 3 3 3 1 0")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 4 1
2 1
1 3
3 2
3 4
4 1", @"0 1 0 1")]
        [InlineData(@"5 10 0
1 2
1 3
1 4
1 5
3 2
2 4
2 5
4 3
5 3
4 5", @"0 0 0 0 0")]
        [InlineData(@"10 9 3
10 1
6 7
8 2
2 5
8 4
7 3
10 9
6 4
5 8
2 6
7 5
3 1", @"1 3 5 4 3 3 3 3 1 0")]
        public void QuestionD_UnionFindTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD_UnionFind();

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

        IEnumerable<string> SplitByNewLine(string input) => input?.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None) ?? new string[0];
    }
}
