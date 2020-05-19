using PAST002.Algorithms;
using PAST002.Collections;
using PAST002.Questions;
using PAST002.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PAST002.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (s, t) = inputStream.ReadValue<string, string>();
            yield return Math.Abs(GetFloor(s) - GetFloor(t));
        }

        int GetFloor(string s)
        {
            var result = s switch
            {
                "B9" => 0,
                "B8" => 1,
                "B7" => 2,
                "B6" => 3,
                "B5" => 4,
                "B4" => 5,
                "B3" => 6,
                "B2" => 7,
                "B1" => 8,
                "1F" => 9,
                "2F" => 10,
                "3F" => 11,
                "4F" => 12,
                "5F" => 13,
                "6F" => 14,
                "7F" => 15,
                "8F" => 16,
                "9F" => 17,
                _ => -1
            };
            return result;  
        }
    }
}
