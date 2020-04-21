using Yorukatsu021.Questions;
using Yorukatsu021.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu021.Questions
{
    /// <summary>
    /// ABC157 E
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var s = inputStream.ReadLine();
            var q = inputStream.ReadInt();

            var segmentationTree = new SegmentationTree(s);

            for (int i = 0; i < q; i++)
            {
                var query = inputStream.ReadLine().Split(' ');

                switch (query[0])
                {
                    case "1":
                        segmentationTree.Update(int.Parse(query[1]) - 1, query[2][0]);
                        break;
                    case "2":
                        yield return segmentationTree.GetVariety(int.Parse(query[1]) - 1, int.Parse(query[2]) - 1);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public class SegmentationTree
    {
        private readonly int _bufferLength;
        private readonly int _leafCount;
        private readonly int[,] _charCount;
        private readonly char[] _rawString;
        const int alphabetCount = 'z' - 'a' + 1;

        public SegmentationTree(string s)
        {
            _leafCount = GetMinimumPow2(s.Length);
            _bufferLength = 2 * _leafCount - 1;
            _charCount = new int[_bufferLength, alphabetCount];

            for (int i = 0; i < s.Length; i++)
            {
                Update(i, s[i]);
            }

            _rawString = s.ToCharArray();

        }

        public void Update(int index, char newChar)
        {
            var oldChar = _rawString?[index];
            if (oldChar != null)
            {
                _rawString[index] = newChar;
            }
            index += _leafCount - 1;
            var tempIndex = index;

            _charCount[index, newChar - 'a']++;
            while (index > 0)
            {
                index = (index - 1) / 2;
                _charCount[index, newChar - 'a']++;
            }

            index = tempIndex;
            if (oldChar != null)
            {
                _charCount[index, oldChar.Value - 'a']--;
                while (index > 0)
                {
                    index = (index - 1) / 2;
                    _charCount[index, oldChar.Value - 'a']--;
                }
            }
        }

        public int GetVariety(int begin, int end) => GetVariety(begin, end + 1, 0, 0, _leafCount).Count();

        private IEnumerable<char> GetVariety(int begin, int end, int currentIndex, int currentLeft, int currentRight)
        {
            if (currentRight <= begin || end <= currentLeft)    // 全く被らない
            {
                return Enumerable.Empty<char>();
            }
            else if (begin <= currentLeft && currentRight <= end)   // 全部被る
            {
                return GetCharsAt(currentIndex);
            }
            else    // 一部被る
            {
                var leftChars = GetVariety(begin, end, currentIndex * 2 + 1, currentLeft, (currentLeft + currentRight) / 2);
                var rightChars = GetVariety(begin, end, currentIndex * 2 + 2, (currentLeft + currentRight) / 2, currentRight);
                return leftChars.Union(rightChars);
            }
        }

        private IEnumerable<char> GetCharsAt(int index)
        {
            for (int i = 0; i < alphabetCount; i++)
            {
                if (_charCount[index, i] > 0)
                {
                    yield return (char)(i + 'a');
                }
            }
        }

        private int GetMinimumPow2(int n)
        {
            var p = 1;
            while (p < n)
            {
                p *= 2;
            }
            return p;
        }
    }
}
