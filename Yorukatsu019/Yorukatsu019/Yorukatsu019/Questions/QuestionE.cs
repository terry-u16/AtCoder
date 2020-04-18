using Yorukatsu019.Questions;
using Yorukatsu019.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu019.Questions
{
    /// <summary>
    /// ABC153 F
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nda = inputStream.ReadIntArray();
            var monsterCount = nda[0];
            long bombRadius = nda[1];
            long bombAttack = nda[2];

            var monsters = new Monster[monsterCount];
            for (int i = 0; i < monsterCount; i++)
            {
                var xh = inputStream.ReadIntArray();
                monsters[i] = new Monster(xh[0], xh[1]);
            }
            Array.Sort(monsters);

            long totalBombCount = 0;
            long totalDamage = 0;
            var brasts = new Queue<Brast>();
            foreach (var monster in monsters)
            {
                while (brasts.Any() && brasts.Peek().EndPosition < monster.Position)
                {
                    var brast = brasts.Dequeue();
                    totalDamage -= brast.Damage;
                }

                var currentMonsterHp = monster.HP - totalDamage;
                if (currentMonsterHp > 0)
                {
                    var bombCount = (int)Math.Ceiling((double)currentMonsterHp / bombAttack);
                    totalDamage += bombAttack * bombCount;
                    totalBombCount += bombCount;

                    var brast = new Brast(bombAttack * bombCount, monster.Position + bombRadius * 2);
                    brasts.Enqueue(brast);
                }
            }

            yield return totalBombCount;
        }
    }

    struct Monster : IComparable<Monster>
    {
        public int Position { get; }
        public int HP { get; }

        public Monster(int position, int hp)
        {
            Position = position;
            HP = hp;
        }

        public int CompareTo(Monster other) => Position.CompareTo(other.Position);
    }

    struct Brast
    {
        public long Damage { get; }
        public long EndPosition { get; }

        public Brast(long damage, long endPosition)
        {
            Damage = damage;
            EndPosition = endPosition;
        }
    }
}
