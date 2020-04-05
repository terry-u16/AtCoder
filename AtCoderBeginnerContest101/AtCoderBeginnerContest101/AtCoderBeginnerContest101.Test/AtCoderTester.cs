using System;
using Xunit;
using Atcoder.AtCoderBeginnerContest101.Questions;

namespace Atcoder.AtCoderBeginnerContest101.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"+-++", "2")]
        [InlineData(@"-+--", "-2")]
        [InlineData(@"----", "-4")]
        public void QuestionATest(string input, string output)
        {
            IAtCoderQuestion question = new QuestionA();
            var answer = question.Solve(input);
            Assert.Equal(output, answer);
        }

        [Theory]
        [InlineData(@"12", "Yes")] 
        [InlineData(@"101", "No")] 
        [InlineData(@"999999999", "Yes")]
        public void QuestionBTest(string input, string output)
        {
            IAtCoderQuestion question = new QuestionB();
            var answer = question.Solve(input);
            Assert.Equal(output, answer);
        }

        [Theory]
        [InlineData(@"4 3
2 3 1 4", "2")] 
        [InlineData(@"3 3
1 2 3", "1")] 
        [InlineData(@"8 3
7 3 1 8 4 6 2 5", "4")]
        public void QuestionCTest(string input, string output)
        {
            IAtCoderQuestion question = new QuestionC();
            var answer = question.Solve(input);
            Assert.Equal(output, answer);
        }

        //[Theory]
        //[InlineData(@"", "")] 
        public void QuestionDTest(string input, string output)
        {
            IAtCoderQuestion question = new QuestionD();
            var answer = question.Solve(input);
            Assert.Equal(output, answer);
        }

        //[Theory]
        //[InlineData(@"", "")] 
        public void QuestionETest(string input, string output)
        {
            IAtCoderQuestion question = new QuestionE();
            var answer = question.Solve(input);
            Assert.Equal(output, answer);
        }

        //[Theory]
        //[InlineData(@"", "")] 
        public void QuestionFTest(string input, string output)
        {
            IAtCoderQuestion question = new QuestionF();
            var answer = question.Solve(input);
            Assert.Equal(output, answer);
        }
    }
}
