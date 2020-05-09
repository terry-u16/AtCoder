using System;
using Xunit;
using AtCoderBeginnerContest119.Questions;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderBeginnerContest119.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"2019/04/30", @"Heisei")]
        [InlineData(@"2019/11/01", @"TBD")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

//        [Theory]
//        [InlineData(@"2
//10000 JPY
//0.10000000 BTC", @"48000.0")]
//        [InlineData(@"3
//100000000 JPY
//100.00000000 BTC
//0.00000001 BTC", @"138000000.0038")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

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
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 3 4
100
600
400
900
1000
150
2000
899
799", @"350
1400
301
399")]
        [InlineData(@"1 1 3
1
10000000000
2
9999999999
5000000000", @"10000000000
10000000000
14999999998")]
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
