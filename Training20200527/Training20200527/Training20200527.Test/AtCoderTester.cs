using System;
using Xunit;
using Training20200527.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Training20200527.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"7
3 6
1 2
3 1
7 4
5 7
1 4", @"Fennec")]
        [InlineData(@"4
1 4
4 2
2 3", @"Snuke")]
        [InlineData(@"4
1 2
2 3
3 4", @"Snuke")]

        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3
1 3 4
1 3 6", @"60")]
        [InlineData(@"6 5
-790013317 -192321079 95834122 418379342 586260100 802780784
-253230108 193944314 363756450 712662868 735867677", @"835067060")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 3
8 20", @"7")]
        [InlineData(@"2 10
3 5", @"8")]
        [InlineData(@"4 5
10 1 2 22", @"7")]
        [InlineData(@"8 7
1 7 5 6 8 2 6 5", @"5")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
1
1
2
4", @"3")]
        [InlineData(@"7
1
2
1
3
1
4", @"3")]
        [InlineData(@"4
4
4
1", @"3")]
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
