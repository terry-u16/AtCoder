using AtCoderBeginnerContest156.Questions;
using AtCoderBeginnerContest156.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest156.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        int mod = 1000000007;
        int[] facTable = null;
        int[] finvTable = null;
        int[] invTable = null;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nab = inputStream.ReadIntArray();
            var n = nab[0];
            var a = nab[1];
            var b = nab[2];

            InitializeTable(200000);

            var all = GetAllSetMod(n) - 1; // 「0本のとき」を除く

            yield return Mod(Mod(all - NcrMod(n, a), mod) - NcrMod(n, b), mod);
        }

        void InitializeTable(int n)
        {
            facTable = new int[n + 1];
            finvTable = new int[n + 1];
            invTable = new int[n + 1];

            facTable[0] = facTable[1] = 1;
            finvTable[0] = finvTable[1] = 1;
            invTable[1] = 1;

            for (int i = 2; i < facTable.Length; i++)
            {
                facTable[i] = (int)((long)facTable[i - 1] * i % mod);
                invTable[i] = (int)(mod - (long)invTable[mod % i] * (mod / i) % mod);
                finvTable[i] = (int)((long)finvTable[i - 1] * invTable[i] % mod);
            }
        }

        int Mod(int val, int m)
        {
            var answer = (long)val % m;
            if (answer < 0)
            {
                answer += m;
            }
            return (int)answer;
        }

        int GetAllSetMod(int n)
        {
            if (n > 0)
            {
                var k = n / 2;
                var r = n % 2;
                var sq = GetAllSetMod(k);
                return (int)((long)sq * sq % mod * (r == 1 ? 2 : 1) % mod);
            }
            else
            {
                return 1;
            }
        }

        int NcrMod(int n, int r)
        {
            long f = 1;
            for (int i = 0; i < r; i++)
            {
                f = (f * (n - i)) % mod;
            }

            return (int)(f * (finvTable[r] % mod) % mod);
        }
    }
}
