using System;
using Xunit;
using AtCoderBeginnerContest141.Questions;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderBeginnerContest141.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"Sunny", @"Cloudy")]
        [InlineData(@"Rainy", @"Sunny")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"RUDLUDR", @"Yes")]
        [InlineData(@"DULL", @"No")]
        [InlineData(@"UUUUUUUUUUUUUUU", @"Yes")]
        [InlineData(@"ULURU", @"No")]
        [InlineData(@"RDULULDURURLRDULRLR", @"Yes")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6 3 4
3
1
3
2", @"No
No
Yes
No
No
No")]
        [InlineData(@"6 5 4
3
1
3
2", @"Yes
Yes
Yes
Yes
Yes
Yes")]
        [InlineData(@"10 13 15
3
1
4
1
5
9
2
6
5
3
5
8
9
7
9", @"No
No
No
No
Yes
No
No
No
Yes
No")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3
2 13 8", @"9")]
        [InlineData(@"4 4
1 9 3 5", @"6")]
        [InlineData(@"1 100000
1000000000", @"0")]
        [InlineData(@"10 1
1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000", @"9500000000")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
ababa", @"2")]
        [InlineData(@"2
xy", @"0")]
        [InlineData(@"13
strangeorange", @"5")]
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
