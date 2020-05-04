using System;
using Xunit;
using AtCoderBeginnerContest127.Questions;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderBeginnerContest127.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"30 100", @"100")]
        [InlineData(@"12 100", @"50")]
        [InlineData(@"0 100", @"0")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 10 20", @"30
50
90
170
330
650
1290
2570
5130
10250")]
        [InlineData(@"4 40 60", @"200
760
3000
11960
47800
191160
764600
3058360
12233400
48933560")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 2
1 3
2 4", @"2")]
        [InlineData(@"10 3
3 6
5 7
6 9", @"1")]
        [InlineData(@"100000 1
1 100000", @"100000")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 2
5 1 4
2 3
1 5", @"14")]
        [InlineData(@"10 3
1 8 5 7 100 4 52 33 13 5
3 10
4 30
1 4", @"338")]
        [InlineData(@"3 2
100 100 100
3 99
3 99", @"300")]
        [InlineData(@"11 3
1 1 1 1 1 1 1 1 1 1 1
3 1000000000
4 1000000000
3 1000000000", @"10000000001")]
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

        IEnumerable<string> SplitByNewLine(string input) => input?.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None) ?? new string[0];
    }
}
