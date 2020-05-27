using Hitachi2020.Questions;
using Hitachi2020.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Hitachi2020.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var abm = inputStream.ReadIntArray();
            var couponCount = abm[2];

            var refrigeratorPrices = inputStream.ReadIntArray();
            var microwavePrices = inputStream.ReadIntArray();
            var cheapest = refrigeratorPrices.Min() + microwavePrices.Min();

            var coupons = new Coupon[couponCount];
            for (int i = 0; i < couponCount; i++)
            {
                var xyc = inputStream.ReadIntArray();
                coupons[i] = new Coupon(xyc[0] - 1, xyc[1] - 1, xyc[2]);
            }

            foreach (var coupon in coupons)
            {
                var price = refrigeratorPrices[coupon.RefrigeratorNo] + microwavePrices[coupon.MicrowaveNo] - coupon.Discount;
                cheapest = Math.Min(cheapest, price);
            }

            yield return cheapest;
        }

        struct Coupon
        {
            public int RefrigeratorNo { get; }
            public int MicrowaveNo { get; }
            public int Discount { get; }

            public Coupon(int refrigeratorNo, int microwaveNo, int discount)
            {
                RefrigeratorNo = refrigeratorNo;
                MicrowaveNo = microwaveNo;
                Discount = discount;
            }
        }
    }
}
