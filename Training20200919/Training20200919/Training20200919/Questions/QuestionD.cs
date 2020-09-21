using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200919.Algorithms;
using Training20200919.Collections;
using Training20200919.Numerics;
using Training20200919.Questions;

namespace Training20200919.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var woodCount = io.ReadInt();
            var cutLimit = io.ReadInt();
            var woods = io.ReadIntArray(woodCount);

            var result = SearchExtensions.BoundaryBinarySearch(CanCat, 1000000000, 0);
            io.WriteLine(result);

            bool CanCat(int l)
            {
                var count = 0;
                foreach (var wood in woods)
                {
                    count += (wood + l - 1) / l - 1;
                }
                return count <= cutLimit;
            }
        }
    }
}
