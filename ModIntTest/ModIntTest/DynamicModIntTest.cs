using System;
using AtCoder;
using Xunit;
using ModInt = AtCoder.DynamicModInt<AtCoder.ModID0>;

namespace ModIntTest
{
    public class DynamicModIntTest
    {
        const int Mod = 1000000007;
        const int Seed = 42;
        const int N = 10000000;

        public DynamicModIntTest()
        {
            DynamicModInt<ModID0>.Mod = 1000000007;
            DynamicModInt<ModID1>.Mod = 15;
        }

        [Fact]
        public void ConstructorTest()
        {
            var rand = new XorShift(Seed);

            ConstructorSubTest(0);
            ConstructorSubTest(-1);
            ConstructorSubTest(Mod);
            ConstructorSubTest(-Mod);

            for (int i = 0; i < N; i++)
            {
                ConstructorSubTest((long)rand.Next());
            }
        }

        private static void ConstructorSubTest(long x)
        {
            var m = new ModInt(x);

            x %= Mod;
            if (x < 0)
            {
                x += Mod;
            }

            Assert.Equal(x, m.Value);
        }

        [Fact]
        public void RawTest()
        {
            var rand = new XorShift(Seed);

            RawSubTest(0);
            RawSubTest(Mod - 1);

            for (int i = 0; i < N; i++)
            {
                RawSubTest((int)(rand.Next() % Mod));
            }
        }

        private static void RawSubTest(int x)
        {
            var m = ModInt.Raw(x);
            Assert.Equal(x, m.Value);
        }

        [Fact]
        public void IncrementTest()
        {
            const long init = Mod - N + 5;
            var m = new ModInt(init);

            for (int i = 0; i < N; i++)
            {
                var expected = (init + i) % Mod;
                Assert.Equal(expected, m++);
            }
        }

        [Fact]
        public void DecrementTest()
        {
            const long init = Mod + N - 5;
            var m = new ModInt(init);

            for (int i = 0; i < N; i++)
            {
                var expected = (init - i) % Mod;
                Assert.Equal(expected, m--);
            }
        }

        [Fact]
        public void AddTest()
        {
            var rand = new XorShift(Seed);
            const long max = 1L << 60;
            for (int i = 0; i < N; i++)
            {
                var a = (long)(rand.Next() % (max >> 1) - max);
                var b = (long)(rand.Next() % (max >> 1) - max);
                var ma = new ModInt(a);
                var mb = new ModInt(b);

                var expected = (a + b) % Mod;
                if (expected < 0)
                {
                    expected += Mod;
                }

                var actual = ma + mb;

                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void SubtractTest()
        {
            var rand = new XorShift(Seed);
            const long max = 1L << 60;
            for (int i = 0; i < N; i++)
            {
                var a = (long)(rand.Next() % (max >> 1)) - max;
                var b = (long)(rand.Next() % (max >> 1)) - max;
                var ma = new ModInt(a);
                var mb = new ModInt(b);

                var expected = (a - b) % Mod;
                if (expected < 0)
                {
                    expected += Mod;
                }

                var actual = ma - mb;

                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void MultiplicationTest()
        {
            var rand = new XorShift(Seed);
            const int max = 1 << 30;
            for (int i = 0; i < N; i++)
            {
                var a = (int)(rand.Next() % (max >> 1)) - max;
                var b = (int)(rand.Next() % (max >> 1)) - max;
                var ma = new ModInt(a);
                var mb = new ModInt(b);

                var expected = (long)a * b % Mod;
                if (expected < 0)
                {
                    expected += Mod;
                }

                var actual = ma * mb;

                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void DivisionTest()
        {
            var rand = new XorShift(Seed);
            for (int i = 0; i < N; i++)
            {
                var a = rand.Next(Mod);
                var b = rand.Next(Mod);
                var divided = new ModInt(a) / b;

                var actual = ((long)divided.Value * b) % Mod;

                Assert.Equal(a, actual);
            }
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 8)]
        [InlineData(4, 4)]
        [InlineData(7, 13)]
        [InlineData(8, 2)]
        [InlineData(11, 11)]
        [InlineData(13, 7)]
        [InlineData(14, 14)]
        public void DivisionNotPrimeTest(int input, int expected)
        {
            var m = DynamicModInt<ModID1>.Raw(input);
            var actual = 1 / m;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NegateTest()
        {
            var rand = new XorShift(Seed);
            for (int i = 0; i < N; i++)
            {
                var m = rand.Next(Mod);

                var actual = +m + -m;

                Assert.Equal(0, actual);
            }
        }

        [Fact]
        public void PowTest()
        {
            var rand = new XorShift(Seed);

            Assert.Equal(1, ModInt.Raw(100).Pow(0));
            Assert.Equal(100, ModInt.Raw(100).Pow(1));

            for (int i = 0; i < N; i++)
            {
                var x = rand.Next(Mod);
                var n = rand.Next(Mod);

                var actual = ModInt.Raw(x).Pow(n);

                long expected = 1;
                while (n > 0)
                {
                    if ((n & 1) > 0)
                    {
                        expected *= x;
                        expected %= Mod;
                    }
                    x = (int)((long)x * x % Mod);
                    n >>= 1;
                }

                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void EqualTest()
        {
            var rand = new XorShift(Seed);
            for (int i = 0; i < N; i++)
            {
                var a = rand.Next(Mod);
                var b = a + (long)Mod * rand.Next(Mod);

                var ma = new ModInt(a);
                var mb = new ModInt(b);

                Assert.True(ma == mb);
                Assert.False(ma != mb);
            }
        }

        [Fact]
        public void NotEqualTest()
        {
            var rand = new XorShift(Seed);
            for (int i = 0; i < N; i++)
            {
                var a = (long)(rand.Next() % long.MaxValue);
                var b = (long)(rand.Next() % long.MaxValue);

                if (a % Mod == b % Mod)
                {
                    continue;
                }

                var ma = new ModInt(a);
                var mb = new ModInt(b);

                Assert.False(ma == mb);
                Assert.True(ma != mb);
            }
        }

        [Fact]
        public void ToStringTest()
        {
            var rand = new XorShift(Seed);
            for (int i = 0; i < N; i++)
            {
                var a = (long)(rand.Next() % long.MaxValue);

                var m = new ModInt(a);

                Assert.Equal((a % Mod).ToString(), m.ToString());
            }
        }
    }
}
