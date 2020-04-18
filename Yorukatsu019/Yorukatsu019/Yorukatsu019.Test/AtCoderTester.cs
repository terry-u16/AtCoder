using System;
using Xunit;
using Yorukatsu019.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu019.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"4
3 8 5 1", @"Yes")]
        [InlineData(@"4
3 8 4 1", @"No")]
        [InlineData(@"10
1 8 10 5 8 12 34 100 11 3", @"No")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 5
4 9
2 4", @"12")]
        [InlineData(@"4 30
6 18
2 5
3 10
7 9", @"130")]
        [InlineData(@"1 100000
1000000000 100000", @"100000000000000")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
acornistnt
peanutbomb
constraint", @"1")]
        [InlineData(@"2
oneplustwo
ninemodsix", @"0")]
        [InlineData(@"5
abaaaaaaaa
oneplustwo
aaaaaaaaba
twoplusone
aaaabaaaaa", @"4")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 10
6 1 2 7", @"2")]
        [InlineData(@"3 5
3 3 3", @"3")]
        [InlineData(@"10 53462
103 35322 232 342 21099 90000 18843 9010 35221 19352", @"36")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3 2
1 2
5 4
9 2", @"2")]
        [InlineData(@"9 4 1
1 5
2 4
3 3
4 2
5 1
6 2
7 3
8 4
9 5", @"5")]
        [InlineData(@"3 0 1
300000000 1000000000
100000000 1000000000
200000000 1000000000", @"3000000000")]
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
