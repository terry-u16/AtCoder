using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200923.Algorithms;
using Training20200923.Collections;
using Training20200923.Numerics;
using Training20200923.Questions;
using System.Text.RegularExpressions;

namespace Training20200923.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/tenka1-2012-qualB/tasks/tenka1_2012_6
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var camelCase = new Regex("^(?<prefix>_*)(?<first>[a-z][0-9a-z]*)(?<second>[A-Z][0-9a-z]*)*(?<suffix>_*)$");
            var snakeCase = new Regex("^(?<prefix>_*)(?<first>[a-z][0-9a-z]*)(?<second>_[a-z][0-9a-z]*)*(?<suffix>_*)$");

            var s = io.ReadString();

            if (camelCase.IsMatch(s))
            {
                var matches = camelCase.Match(s);

                var result = matches.Groups["prefix"].Value + matches.Groups["first"].Value;

                foreach (Capture capture in matches.Groups["second"].Captures)
                {
                    result += "_" + capture.Value.ToLower();
                }

                result += matches.Groups["suffix"].Value;

                io.WriteLine(result);
            }
            else if (snakeCase.IsMatch(s))
            {
                var matches = snakeCase.Match(s);

                var result = matches.Groups["prefix"].Value + matches.Groups["first"];

                foreach (Capture capture in matches.Groups["second"].Captures)
                {
                    var added = capture.Value.Trim('_');
                    result += added.Substring(0, 1).ToUpper() + added.Substring(1);
                }

                result += matches.Groups["suffix"].Value;

                io.WriteLine(result);
            }
            else
            {
                io.WriteLine(s);
            }
        }
    }
}
