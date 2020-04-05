using System;
using Xunit;
using Atcoder.PracticeContest.Questions;

namespace Atcoder.PracticeContest.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"1
2 3
test", "6 test")]
        [InlineData(@"72
128 256
myonmyon", "456 myonmyon")]
        public void QuestionATest(string input, string output)
        {
            IAtCoderQuestion question = new QuestionA();
            var answer = question.Solve(input);
            Assert.Equal(output, answer);
        }

        //[Theory]
        //[InlineData("", "")] 
        public void QuestionBTest(string input, string output)
        {
            IAtCoderQuestion question = new QuestionB();
            var answer = question.Solve(input);
            Assert.Equal(output, answer);
        }

        //[Theory]
        //[InlineData("", "")] 
        public void QuestionCTest(string input, string output)
        {
            IAtCoderQuestion question = new QuestionC();
            var answer = question.Solve(input);
            Assert.Equal(output, answer);
        }

        //[Theory]
        //[InlineData("", "")] 
        public void QuestionDTest(string input, string output)
        {
            IAtCoderQuestion question = new QuestionD();
            var answer = question.Solve(input);
            Assert.Equal(output, answer);
        }

        //[Theory]
        //[InlineData("", "")] 
        public void QuestionETest(string input, string output)
        {
            IAtCoderQuestion question = new QuestionE();
            var answer = question.Solve(input);
            Assert.Equal(output, answer);
        }
        //[Theory]
        //[InlineData("", "")] 
        public void QuestionFTest(string input, string output)
        {
            IAtCoderQuestion question = new QuestionF();
            var answer = question.Solve(input);
            Assert.Equal(output, answer);
        }
    }
}
