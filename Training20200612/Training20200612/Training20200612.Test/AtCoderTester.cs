using System;
using Xunit;
using Training20200612.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Training20200612.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"3
10 10
20 20
30 30", @"20")]
        [InlineData(@"3
20 10
20 20
20 30", @"20")]
        [InlineData(@"6
1 1000000000
1 1000000000
1 1000000000
1 1000000000
1 1000000000
1 1000000000", @"-2999999997")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"8
abacbabc", @"2")]
        [InlineData(@"8
abababab", @"0")]
        [InlineData(@"5
abcde", @"5")]
        [InlineData(@"26
codefestivaltwozeroonefive", @"14")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 5
1
1
2
3
4", @"4")]
        [InlineData(@"8 21
10
4
2
30
22
20
8
14", @"0")]
        [InlineData(@"20 100000000
35576749
38866484
6624951
39706038
11133516
25490903
14701702
17888322
14423251
32111678
24509097
43375049
35298298
21158709
30489274
37977301
19510726
28841291
10293962
12022699", @"45")]
        [InlineData(@"16 8
1
1
1
1
1
1
1
1
1
1
1
1
1
1
1
1", @"12870")]
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
