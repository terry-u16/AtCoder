using AtCoderBeginnerContest157.Questions;
using AtCoderBeginnerContest157.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest157.Questions
{
    // TLE
    public class QuestionD : AtCoderQuestionBase
    {
        int n, m, k;
        List<int>[] friendList = null;
        int[] blockCount;
        int[] group;
        List<int> groupMemberCount = new List<int>();

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nmk = inputStream.ReadIntArray();
            n = nmk[0];
            m = nmk[1];
            k = nmk[2];

            friendList = new List<int>[n];
            group = Enumerable.Repeat(-1, n).ToArray();
            blockCount = new int[n];

            for (int i = 0; i < n; i++)
            {
                friendList[i] = new List<int>();
            }

            for (int i = 0; i < m; i++)
            {
                var ab = inputStream.ReadIntArray();
                friendList[ab[0] - 1].Add(ab[1] - 1);
                friendList[ab[1] - 1].Add(ab[0] - 1);
            }

            int groupIndex = 0;
            for (int i = 0; i < n; i++)
            {
                if (group[i] == -1)
                {
                    var friendGroup = SearchFriends(i);
                    
                    foreach (var friend in friendGroup)
                    {
                        group[friend] = groupIndex;
                    }

                    groupMemberCount.Add(friendGroup.Count);
                    groupIndex++;
                }
            }

            for (int i = 0; i < k; i++)
            {
                var cd = inputStream.ReadIntArray();
                if (group[cd[0] - 1] == group[cd[1] - 1])
                {
                    blockCount[cd[0] - 1] += 1;
                    blockCount[cd[1] - 1] += 1;
                }
            }

            yield return string.Join(" ", Enumerable.Range(0, n).Select(i => GetFriendCount(i).ToString()));
        }

        List<int> SearchFriends(int me)
        {
            var todo = new Stack<int>();
            var seen = new bool[n];
            var friends = new List<int>();

            todo.Push(me);
            seen[me] = true;
            while (todo.Count > 0)
            {
                var current = todo.Pop();
                friends.Add(current);

                foreach (var friend in friendList[current].Where(i => !seen[i]))
                {
                    todo.Push(friend);
                    seen[friend] = true;
                }
            }

            return friends;
        }

        int GetFriendCount(int me)
        {
            return groupMemberCount[group[me]] - friendList[me].Count - blockCount[me] - 1;
        }
    }
}
