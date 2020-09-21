using System;
using Xunit;
using ACPC2020Day2.Questions;
using System.Collections.Generic;
using System.Linq;

namespace ACPC2020Day2.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"5
1 2
2 1
2 5
5 2
10 4", @"2")]
        [InlineData(@"4
10 0
10 20
0 10
20 10", @"1")]
        [InlineData(@"5
10 10
10 50
50 30
100 30
40 100", @"-1")]
        public void QuestionGTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionG();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }


        IEnumerable<string> SplitByNewLine(string input) => input?.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None) ?? new string[0];
    }
}
