using System;
using Xunit;
using AtCoderBeginnerContest123.Questions;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderBeginnerContest123.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"1
2
4
8
9
15", @"Yay!")]
        [InlineData(@"15
18
26
35
36
18", @":(")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"29
20
7
35
120", @"215")]
        [InlineData(@"101
86
119
108
57", @"481")]
        [InlineData(@"123
123
123
123
123", @"643")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
3
2
4
3
5", @"7")]
        [InlineData(@"10
123
123
123
123
123", @"5")]
        [InlineData(@"10000000007
2
3
5
7
11", @"5000000008")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 2 2 8
4 6
1 5
3 8", @"19
17
15
14
13
12
10
8")]
        [InlineData(@"3 3 3 5
1 10 100
2 20 200
1 10 100", @"400
310
310
301
301")]
        [InlineData(@"10 10 10 20
7467038376 5724769290 292794712 2843504496 3381970101 8402252870 249131806 6310293640 6690322794 6082257488
1873977926 2576529623 1144842195 1379118507 6003234687 4925540914 3902539811 3326692703 484657758 2877436338
4975681328 8974383988 2882263257 7690203955 514305523 6679823484 4263279310 585966808 3752282379 620585736", @"23379871545
22444657051
22302177772
22095691512
21667941469
21366963278
21287912315
21279176669
21160477018
21085311041
21059876163
21017997739
20703329561
20702387965
20590247696
20383761436
20343962175
20254073196
20210218542
20150096547")]
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
