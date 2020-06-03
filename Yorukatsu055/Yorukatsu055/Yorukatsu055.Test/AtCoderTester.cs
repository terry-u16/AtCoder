using System;
using Xunit;
using Yorukatsu055.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu055.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"4 5", @"Possible")]
        [InlineData(@"1 1", @"Impossible")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
3 4 6", @"10")]
        [InlineData(@"5
7 46 11 20 11", @"90")]
        [InlineData(@"7
994 518 941 851 647 2 581", @"4527")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
2
3", @"6")]
        [InlineData(@"5
2
5
10
1000000000000000000
1000000000000000000", @"1000000000000000000")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 2 5
1 2 5 7", @"11")]
        [InlineData(@"7 1 100
40 43 45 105 108 115 124", @"84")]
        [InlineData(@"7 1 2
24 35 40 68 72 99 103", @"12")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3 2
1 4 3
2 5 7
8 9 6
1
4 8", @"5")]
        [InlineData(@"4 2 3
3 7
1 4
5 2
6 8
2
2 2
2 2", @"0
0")]
        [InlineData(@"5 5 4
13 25 7 15 17
16 22 20 2 9
14 11 12 1 19
10 6 23 8 18
3 21 5 24 4
3
13 13
2 10
13 13", @"0
5
0")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1 2 1 3", @"3
5
4
1")]
        [InlineData(@"1
1 1", @"1
1")]
        [InlineData(@"32
29 19 7 10 26 32 27 4 11 20 2 8 16 23 5 14 6 12 17 22 18 30 28 24 15 1 25 3 13 21 19 31 9", @"32
525
5453
40919
237336
1107568
4272048
13884156
38567100
92561040
193536720
354817320
573166440
818809200
37158313
166803103
166803103
37158313
818809200
573166440
354817320
193536720
92561040
38567100
13884156
4272048
1107568
237336
40920
5456
528
33
1")]
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
