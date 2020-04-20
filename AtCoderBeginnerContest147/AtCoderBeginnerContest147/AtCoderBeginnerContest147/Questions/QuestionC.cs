using AtCoderBeginnerContest147.Questions;
using AtCoderBeginnerContest147.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace AtCoderBeginnerContest147.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        List<Testimony>[] testimonies;
        
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            testimonies = Enumerable.Range(0, n).Select(_ => new List<Testimony>()).ToArray();

            for (int i = 0; i < n; i++)
            {
                var a = inputStream.ReadInt();
                for (int j = 0; j < a; j++)
                {
                    var xy = inputStream.ReadIntArray();
                    testimonies[i].Add(new Testimony(xy[0] - 1, xy[1] == 1));
                }
            }

            var max = 0;
            for (int honestFlag = 0; honestFlag < 1 << n; honestFlag++)
            {
                var honestFlagVector = new BitVector32(honestFlag);
                if (IsValid(honestFlagVector))
                {
                    max = Math.Max(max, GetHonestCount(honestFlagVector));
                }
            }

            yield return max;
        }

        bool IsValid(BitVector32 honestFlag)    // 正直者は1、不親切は0
        {
            for (int person = 0; person < testimonies.Length; person++)
            {
                if (honestFlag[1 << person])
                {
                    foreach (var testimony in testimonies[person])
                    {
                        if (honestFlag[1 << testimony.Target] != testimony.IsHonest)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        int GetHonestCount(BitVector32 honestFlag) => Enumerable.Range(0, testimonies.Length).Count(i => honestFlag[1 << i]);
    }

    struct Testimony
    {
        public int Target { get; }
        public bool IsHonest { get; }

        public Testimony(int target, bool isHonest)
        {
            Target = target;
            IsHonest = isHonest;
        }

        public override string ToString() => $"Target:{Target}, IsHonest:{IsHonest}";
    }
}
