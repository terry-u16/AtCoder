using System;
using Xunit;
using Training20200524.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Training20200524.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"5 9
0 0", @"2")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1 2
80 84", @"84")]
        [InlineData(@"3 4
37 29 70 41
85 69 76 50
53 10 95 100", @"250")]
        [InlineData(@"8 2
31000000 41000000
59000000 26000000
53000000 58000000
97000000 93000000
23000000 84000000
62000000 64000000
33000000 83000000
27000000 95000000", @"581000000")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
5 7
2 6
8 10", @"18")]
        [InlineData(@"5
1 71
43 64
13 35
14 54
79 85", @"334")]
        [InlineData(@"11
15004200 341668840
277786703 825590503
85505967 410375631
797368845 930277710
90107929 763195990
104844373 888031128
338351523 715240891
458782074 493862093
189601059 534714600
299073643 971113974
98291394 443377420", @"8494550716")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 5
0 1 0 1 0
1 0 0 0 1", @"9")]
        [InlineData(@"3 6
1 0 0 0 1 0
1 1 1 0 1 0
1 0 1 1 0 1", @"15")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
5 6
12 4
14 7
21 2", @"23")]
        [InlineData(@"6
100 1
100 1
100 1
100 1
100 1
1 30", @"105")]
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
