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
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var taskCount = inputStream.ReadInt();
            var waitingTasks = Enumerable.Repeat(0, taskCount).Select(_ => new List<int>()).ToArray();
            var taskQueue = new PriorityQueue<int>(true);

            for (int i = 0; i < taskCount; i++)
            {
                var (beginningDay, point) = inputStream.ReadValue<int, int>();
                waitingTasks[beginningDay - 1].Add(point);
            }

            var total = 0;
            for (int day = 0; day < taskCount; day++)
            {
                foreach (var task in waitingTasks[day])
                {
                    taskQueue.Enqueue(task);
                }

                total += taskQueue.Dequeue();
                yield return total;
            }
        }
    }
}
