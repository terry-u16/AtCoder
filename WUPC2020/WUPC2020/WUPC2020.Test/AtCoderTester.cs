using System;
using Xunit;
using WUPC2020.Questions;
using System.Collections.Generic;
using System.Linq;

namespace WUPC2020.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"1 3", @"EVEN")]
        [InlineData(@"2 6", @"ODD")]
        [InlineData(@"10 10", @"ODD")]
        [InlineData(@"848385 77857173", @"ODD")]
        [InlineData(@"19320616 19451005", @"EVEN")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
5 7 5", @"4")]
        [InlineData(@"5
4 2 16 8 1", @"75")]
        [InlineData(@"9
-111111111 222222222 -333333333 444444444 -555555555 666666666 -777777777 888888888 -999999999", @"222221086")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
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

        [Theory]
        [InlineData(@"3", @"3")]
        [InlineData(@"15", @"27")]
        [InlineData(@"1000000000000", @"24586301676657")]
        [InlineData(@"8", @"23")]
        [InlineData(@"10", @"23")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 1 10
1 2
2 4
3 3", @"16")]
        [InlineData(@"3 1 10
53 1576
78 2115
89 2006", @"0")]
        [InlineData(@"4 8 800
10 49275367
474 100000000
9 2587424
20 99999999", @"3137370110")]
        public void QuestionGTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionG();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 4
1 2
2 3
3 4
4 2
3
2 4
1 2
2 4", @"NO
YES")]
        [InlineData(@"2 0
2
2 1
2 2", @"YES
NO")]
        [InlineData(@"7 9
1 4
1 5
1 6
2 4
2 5
2 6
3 4
3 5
3 6
4
2 7
2 1
1 4
2 3", @"NO
YES
YES")]
        public void QuestionJTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionJ();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
1 2 3 4
1 2
1 3
3 4", @"13
19
9
11")]
        [InlineData(@"5
123 456 789 119 1
5 2
3 1
1 2
1 4", @"1366
1940
1276
2616
3426")]
        public void QuestionMTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionM();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        IEnumerable<string> SplitByNewLine(string input) => input?.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None) ?? new string[0];
    }
}
