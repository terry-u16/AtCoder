using System;
using Xunit;
using Yorukatsu034.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu034.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"3
4
2", @"7")]
        [InlineData(@"4
4
4", @"16")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6
aabbca", @"2")]
        [InlineData(@"10
aaaaaaaaaa", @"1")]
        [InlineData(@"45
tgxgdqkyjzhyputjjtllptdfxocrylqfqjynmfbfucbir", @"9")]
        [InlineData(@"2
aa", @"1")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
2 4
1 9
1 8
4 9
3 12", @"Yes")]
        [InlineData(@"3
334 1000
334 1000
334 1000", @"No")]
        [InlineData(@"30
384 8895
1725 9791
170 1024
4 11105
2 6
578 1815
702 3352
143 5141
1420 6980
24 1602
849 999
76 7586
85 5570
444 4991
719 11090
470 10708
1137 4547
455 9003
110 9901
15 8578
368 3692
104 1286
3 4
366 12143
7 6649
610 2374
152 7324
4 7042
292 11386
334 5720", @"Yes")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"azzel
apple", @"Yes")]
        [InlineData(@"chokudai
redcoder", @"No")]
        [InlineData(@"abcdefghijklmnopqrstuvwxyz
ibyhqfrekavclxjstdwgpzmonu", @"Yes")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3 3
1 2 3
1 2 1
2 3 1
3 1 4", @"2")]
        [InlineData(@"3 3 2
1 3
2 3 2
1 3 6
1 2 2", @"4")]
        [InlineData(@"4 6 3
2 3 4
1 2 4
2 3 3
4 3 1
1 4 1
4 2 2
3 1 6", @"3")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"A??C", @"8")]
        [InlineData(@"ABCBC", @"3")]
        [InlineData(@"????C?????B??????A???????", @"979596887")]
        [InlineData(@"A??BC", @"23")]
        [InlineData(@"A??", @"1")]
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
