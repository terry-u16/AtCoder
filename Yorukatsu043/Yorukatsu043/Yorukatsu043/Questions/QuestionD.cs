using Yorukatsu043.Questions;
using Yorukatsu043.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu043.Questions
{
    /// <summary>
    /// ABC147 C
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var statements = Enumerable.Range(0, n).Select(_ => new List<Statement>()).ToArray();

            for (int i = 0; i < n; i++)
            {
                var a = inputStream.ReadInt();
                for (int j = 0; j < a; j++)
                {
                    var xy = inputStream.ReadIntArray();
                    statements[i].Add(new Statement(xy[0] - 1, xy[1] == 1));
                }
            }


            var maxHonest = 0;
            for (int flag = 0; flag < 1 << n; flag++)
            {
                var isVaild = true;
                for (int person = 0; person < n; person++)
                {
                    if ((flag & (1 << person)) > 0)
                    {
                        foreach (var statement in statements[person])
                        {
                            var isHonest = (flag & (1 << statement.Person)) > 0;
                            if (isHonest != statement.IsHonest)
                            {
                                isVaild = false;
                            }
                        }
                    }
                }
                if (isVaild)
                {
                    maxHonest = Math.Max(maxHonest, CountOne(flag));
                }
            }

            yield return maxHonest;
        }

        int CountOne(int n)
        {
            var count = 0;
            while (n > 0)
            {
                if ((n & 1) > 0)
                {
                    count++;
                }
                n >>= 1;
            }
            return count;
        }

        struct Statement
        {
            public int Person { get; }
            public bool IsHonest { get; }

            public Statement(int person, bool isHonest)
            {
                Person = person;
                IsHonest = isHonest;
            }
        }
    }
}
