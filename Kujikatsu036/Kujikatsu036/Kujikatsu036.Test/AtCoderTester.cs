using System;
using Xunit;
using Kujikatsu036.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu036.Collections;

namespace Kujikatsu036.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"5
3
10000
9000", @"48000")]
        [InlineData(@"2
3
10000
9000", @"20000")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
hoge
english
hoge
enigma", @"No")]
        [InlineData(@"9
basic
c
cpp
php
python
nadesico
ocaml
lua
assembly", @"Yes")]
        [InlineData(@"8
a
aa
aaa
aaaa
aaaaa
aaaaaa
aaa
aaaaaaa", @"No")]
        [InlineData(@"3
abc
arc
agc", @"No")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6
1 2 3 4 5 6", @"1")]
        [InlineData(@"2
10 -10", @"20")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 2
5 1 4
2 3
1 5", @"14")]
        [InlineData(@"10 3
1 8 5 7 100 4 52 33 13 5
3 10
4 30
1 4", @"338")]
        [InlineData(@"3 2
100 100 100
3 99
3 99", @"300")]
        [InlineData(@"11 3
1 1 1 1 1 1 1 1 1 1 1
3 1000000000
4 1000000000
3 1000000000", @"10000000001")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 4
1 2
2 3
3 4
4 1
1 3", @"2")]
        [InlineData(@"3 3
1 2
2 3
3 1
1 2", @"-1")]
        [InlineData(@"2 0
1 2", @"-1")]
        [InlineData(@"6 8
1 2
2 3
3 4
4 5
5 1
1 4
1 5
4 6
1 6", @"2")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 4
2 2 4", @"5")]
        [InlineData(@"5 8
9 9 9 9 9", @"0")]
        [InlineData(@"10 10
3 1 4 1 5 9 2 6 5 3", @"152")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        void AssertNearlyEqual(IEnumerable<string> expected, IEnumerable<string> actual, double acceptableError = 1e-6)
        {
            Assert.Equal(expected.Count(), actual.Count());
            foreach (var (exp, act) in (expected, actual).Zip().Select(p => (double.Parse(p.v1), double.Parse(p.v2))))
            {
                var error = act - exp;
                Assert.InRange(Math.Abs(error), 0, acceptableError);
            }
        }

        IEnumerable<string> SplitByNewLine(string input) => input?.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None) ?? new string[0];
    }
}
