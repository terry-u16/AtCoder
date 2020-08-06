using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200806.Algorithms;
using Training20200806.Collections;
using Training20200806.Extensions;
using Training20200806.Numerics;
using Training20200806.Questions;
using static Training20200806.Algorithms.AlgorithmHelpers;

namespace Training20200806.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc027/tasks/arc027_3
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (specialTickets, normalTickets) = inputStream.ReadValue<int, int>();
            var tickets = specialTickets + normalTickets;
            var toppingCount = inputStream.ReadInt();
            var toppings = new Topping[toppingCount];

            for (int i = 0; i < toppings.Length; i++)
            {
                var (t, h) = inputStream.ReadValue<int, int>();
                toppings[i] = new Topping(t, h);
            }

            var maxHappiness = new int[toppingCount + 1, specialTickets + 1, tickets + 1];

            for (int i = 0; i < toppings.Length; i++)
            {
                for (int selected = 0; selected <= specialTickets; selected++)
                {
                    for (int used = 0; used <= tickets; used++)
                    {
                        UpdateWhenLarge(ref maxHappiness[i + 1, selected, used], maxHappiness[i, selected, used]);

                        if (selected < specialTickets && used + toppings[i].Tickets <= tickets)
                        {
                            UpdateWhenLarge(ref maxHappiness[i + 1, selected + 1, used + toppings[i].Tickets], maxHappiness[i, selected, used] + toppings[i].Happiness);
                        }
                    }
                }
            }

            var max = 0;
            for (int selected = 0; selected <= specialTickets; selected++)
            {
                for (int used = 0; used <= tickets; used++)
                {
                    UpdateWhenLarge(ref max, maxHappiness[toppingCount, selected, used]);
                }
            }

            yield return max;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Topping
        {
            public int Tickets { get; }
            public int Happiness { get; }

            public Topping(int tickets, int happiness)
            {
                Tickets = tickets;
                Happiness = happiness;
            }

            public void Deconstruct(out int tickets, out int happiness) => (tickets, happiness) = (Tickets, Happiness);
            public override string ToString() => $"{nameof(Tickets)}: {Tickets}, {nameof(Happiness)}: {Happiness}";
        }
    }
}
