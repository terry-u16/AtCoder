﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest171.Algorithms;
using AtCoderBeginnerContest171.Collections;
using AtCoderBeginnerContest171.Extensions;
using AtCoderBeginnerContest171.Numerics;
using AtCoderBeginnerContest171.Questions;

namespace AtCoderBeginnerContest171.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadLong();
            var name = new List<long>();

            do
            {
                n--;
                var c = n % 26;
                name.Add(c);
                n /= 26;
            } while (n > 0);

            yield return string.Concat(name.Select(c => (char)(c + 'a')).Reverse());
        }
    }
}
