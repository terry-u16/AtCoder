using AtCoderBeginnerContest149.Questions;
using AtCoderBeginnerContest149.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest149.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadIntArray();
            var jankenMaxRound = nk[0];
            var restrictionK = nk[1];

            var points = inputStream.ReadIntArray();
            var hostileHands = inputStream.ReadLine().Select(JankenExtension.GetJankenHand).ToArray();
            var myHands = new JankenHand?[jankenMaxRound];

            var totalPoint = 0;

            for (int round = 0; round < jankenMaxRound; round++)
            {
                var previousStrictRound = round - restrictionK;
                var superiorHand = hostileHands[round].GetSuperiorHand();
                if (previousStrictRound < 0 || myHands[previousStrictRound] != superiorHand)
                {
                    myHands[round] = superiorHand;
                    totalPoint += points[(int)superiorHand];
                }
            }

            yield return totalPoint;
        }
    }

    enum JankenHand
    {
        Rock = 0,
        Scissors = 1,
        Paper = 2
    }

    static class JankenExtension
    {
        internal static bool Wins(this JankenHand myHand, JankenHand hostileHand) => ((int)hostileHand - (int)myHand + 3) % 3 == 1;

        internal static JankenHand GetSuperiorHand(this JankenHand hostileHand) => (JankenHand)(((int)hostileHand - 1 + 3) % 3);

        internal static JankenHand GetJankenHand(char hand)
        {
            switch (hand)
            {
                case 'r':
                    return JankenHand.Rock;
                case 's':
                    return JankenHand.Scissors;
                case 'p':
                    return JankenHand.Paper;
                default:
                    throw new ArgumentException(nameof(hand));
            }
        }
    }
}
