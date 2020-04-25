using Yorukatsu025.Questions;
using Yorukatsu025.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu025.Questions
{
    /// <summary>
    /// ABC155 E
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadLine().ToCharArray();

            var billCount = 0;
            var kuriagari = 0;
            for (int i = n.Length - 1; i >= 0; i--)
            {
                var digit = (n[i] - '0') + kuriagari;
                if (digit >= 6)
                {
                    kuriagari = 1;
                    billCount += 10 - digit;
                }
                else if (digit == 5)
                {
                    if (i > 0 && n[i - 1] - '0' >= 5)
                    {
                        kuriagari = 1;
                        billCount += 10 - digit;
                    }
                    else
                    {
                        kuriagari = 0;
                        billCount += digit;
                    }
                }
                else
                {
                    kuriagari = 0;
                    billCount += digit;
                }
            }

            if (kuriagari >= 1)
            {
                billCount += kuriagari;
            }

            yield return billCount;
        }
    }
}
