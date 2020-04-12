using System;
using Xunit;
using AtCoderBeginnerContest155.Questions;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderBeginnerContest155.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"5 7 5", @"Yes")]
        [InlineData(@"4 4 4", @"No")]
        [InlineData(@"4 9 6", @"No")]
        [InlineData(@"3 3 4", @"Yes")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
6 7 9 10 31", @"APPROVED")]
        [InlineData(@"3
28 27 24", @"DENIED")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"7
beat
vet
beet
bed
vet
bet
beet", @"beet
vet")]
        [InlineData(@"8
buffalo
buffalo
buffalo
buffalo
buffalo
buffalo
buffalo
buffalo", @"buffalo")]
        [InlineData(@"7
bass
bass
kick
kick
bass
kick
kick", @"kick")]
        [InlineData(@"4
ushi
tapu
nichia
kun", @"kun
nichia
tapu
ushi")]
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
