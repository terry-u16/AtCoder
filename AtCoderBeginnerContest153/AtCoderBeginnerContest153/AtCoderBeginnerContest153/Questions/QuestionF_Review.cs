using AtCoderBeginnerContest153.Questions;
using AtCoderBeginnerContest153.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest153.Questions
{
    // 復習
    public class QuestionF_Review : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nda = inputStream.ReadIntArray();
            var n = nda[0];
            var d = nda[1];
            var a = nda[2];

            var monsters = new Monster[n];
            for (int i = 0; i < n; i++)
            {
                var xh = inputStream.ReadIntArray();
                monsters[i] = new Monster(xh[0], xh[1]);
            }

            Array.Sort(monsters);
            var blasts = new Queue<Blast>();

            long count = 0;
            long damage = 0;

            foreach (var monster in monsters)
            {
                while (blasts.Any() && blasts.Peek().MaxCoordinate < monster.Coordinate)
                {
                    damage -= blasts.Dequeue().Damage;
                }

                if (monster.HP - damage <= 0)
                {
                    continue;
                }

                var maxCoordinate = monster.Coordinate + 2 * d;
                var bomb = (int)Math.Ceiling((double)(monster.HP - damage) / a);
                var singleDamge = a * bomb;
                damage += singleDamge;
                count += bomb;
                blasts.Enqueue(new Blast(singleDamge, maxCoordinate));
            }

            yield return count;
        }

        private struct Monster : IComparable<Monster>
        {
            public int Coordinate { get; }
            public int HP { get; }

            public Monster(int position, int hp)
            {
                Coordinate = position;
                HP = hp;
            }

            public int CompareTo(Monster other) => Coordinate - other.Coordinate;

            public override string ToString() => $"X:{Coordinate}, HP:{HP}";
        }

        private struct Blast
        {
            public int MaxCoordinate { get; }
            public int Damage { get; }

            public Blast(int damage, int maxCoordinate)
            {
                Damage = damage;
                MaxCoordinate = maxCoordinate;
            }

            public override string ToString() => $"Damage:{Damage}, MaxCoordinate:{MaxCoordinate}";
        }
    }
}
