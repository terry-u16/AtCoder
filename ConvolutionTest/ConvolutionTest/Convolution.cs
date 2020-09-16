using System;
using System.Linq;
using System.Runtime.CompilerServices;
using AtCoder;
using Xunit;

public class ConvolutionTest
{
    [Theory]
    [InlineData(1, 1, 42)]
    [InlineData(4, 6, 42)]
    [InlineData(64, 64, 123)]
    [InlineData(100, 100, 42)]
    [InlineData(1, 10000, 12345)]
    [InlineData(4876, 12878, 26861194601)]
    [InlineData(7314, 3890, 5890635110)]
    public void ConvolutionMod998244353Test(int lengthA, int lengthB, ulong seed) => ConvolutionMod<Mod998244353>(lengthA, lengthB, seed);

    [Theory]
    [InlineData(1, 1, 42)]
    [InlineData(4, 6, 42)]
    [InlineData(64, 64, 123)]
    [InlineData(100, 100, 42)]
    [InlineData(1, 10000, 12345)]
    [InlineData(4876, 12878, 26861194601)]
    [InlineData(7314, 3890, 5890635110)]
    public void ConvolutionMod163577857Test(int lengthA, int lengthB, ulong seed) => ConvolutionMod<Mod163577857>(lengthA, lengthB, seed);

    [Theory]
    [InlineData(1, 1, 42)]
    [InlineData(4, 6, 42)]
    [InlineData(64, 64, 123)]
    [InlineData(100, 100, 42)]
    [InlineData(1, 10000, 12345)]
    [InlineData(4876, 12878, 26861194601)]
    [InlineData(7314, 3890, 5890635110)]
    public void ConvolutionMod469762049Test(int lengthA, int lengthB, ulong seed) => ConvolutionMod<Mod469762049>(lengthA, lengthB, seed);

    private void ConvolutionMod<T>(int lengthA, int lengthB, ulong seed) where T : struct, IStaticMod
    {
        var rand = new XorShift(seed);
        var a = new StaticModInt<T>[lengthA];
        var b = new StaticModInt<T>[lengthB];
        var aRaw = new ulong[lengthA];
        var bRaw = new ulong[lengthB];

        for (int i = 0; i < a.Length; i++)
        {
            aRaw[i] = rand.Next();
            a[i] = StaticModInt<T>.Raw((int)(aRaw[i] % default(T).Mod));
        }

        for (int i = 0; i < b.Length; i++)
        {
            bRaw[i] = rand.Next();
            b[i] = StaticModInt<T>.Raw((int)(bRaw[i] % default(T).Mod));
        }

        var expected = new StaticModInt<T>[a.Length + b.Length - 1];
        for (int i = 0; i < a.Length; i++)
        {
            for (int j = 0; j < b.Length; j++)
            {
                expected[i + j] += a[i] * b[j];
            }
        }

        // 各種オーバーロードについてテスト
        var actualModInt = AtCoder.Math.Convolution(a, b);
        var actualModIntSpan = AtCoder.Math.Convolution((ReadOnlySpan<StaticModInt<T>>)a, b);
        var actualInt = AtCoder.Math.Convolution<T>(a.Select(ai => ai.Value).ToArray(), b.Select(bi => bi.Value).ToArray());
        var actualUInt = AtCoder.Math.Convolution<T>(a.Select(ai => (uint)ai.Value).ToArray(), b.Select(bi => (uint)bi.Value).ToArray());
        var actualLong = AtCoder.Math.Convolution<T>(a.Select(ai => (long)ai.Value).ToArray(), b.Select(bi => (long)bi.Value).ToArray());
        var actualULong = AtCoder.Math.Convolution<T>(aRaw, bRaw);

        Assert.Equal(expected, actualModInt);
        Assert.Equal(expected, actualModIntSpan.ToArray());
        Assert.Equal(expected.Select(ei => ei.Value), actualInt);
        Assert.Equal(expected.Select(ei => (uint)ei.Value), actualUInt);
        Assert.Equal(expected.Select(ei => (long)ei.Value), actualLong);
        Assert.Equal(expected.Select(ei => (ulong)ei.Value), actualULong);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(0, 1)]
    [InlineData(4, 0)]
    [InlineData(0, 123456)]
    public void ConvolutionEmptyTest(int lengthA, int lengthB)
    {
        var aInt = new int[lengthA];
        var bInt = new int[lengthB];
        var aUInt = new uint[lengthA];
        var bUInt = new uint[lengthB];
        var aLong = new long[lengthA];
        var bLong = new long[lengthB];
        var aULong = new ulong[lengthA];
        var bULong = new ulong[lengthB];
        var aMod = new StaticModInt<Mod998244353>[lengthA];
        var bMod = new StaticModInt<Mod998244353>[lengthB];

        var actualInt = AtCoder.Math.Convolution(aInt, bInt);
        var actualUInt = AtCoder.Math.Convolution(aUInt, bUInt);
        var actualLong = AtCoder.Math.Convolution(aLong, bLong);
        var actualULong = AtCoder.Math.Convolution(aULong, bULong);
        var actualModInt = AtCoder.Math.Convolution(aMod, bMod);
        var actualModIntSpan = AtCoder.Math.Convolution((ReadOnlySpan<StaticModInt<Mod998244353>>)aMod, bMod);

        Assert.Equal(Array.Empty<int>(), actualInt);
        Assert.Equal(Array.Empty<uint>(), actualUInt);
        Assert.Equal(Array.Empty<long>(), actualLong);
        Assert.Equal(Array.Empty<ulong>(), actualULong);
        Assert.Equal(Array.Empty<StaticModInt<Mod998244353>>(), actualModInt);
        Assert.Equal(Array.Empty<StaticModInt<Mod998244353>>(), actualModIntSpan.ToArray());
    }

    [Theory]
    [InlineData(1, 1, 42)]
    [InlineData(4, 6, 42)]
    [InlineData(64, 64, 123)]
    [InlineData(100, 100, 42)]
    [InlineData(1, 10000, 12345)]
    [InlineData(4876, 12878, 26861194601)]
    [InlineData(7314, 3890, 5890635110)]
    public void ConvolutionLLTest(int lengthA, int lengthB, ulong seed)
    {
        var rand = new XorShift(seed);
        var a = new long[lengthA];
        var b = new long[lengthB];

        for (int i = 0; i < a.Length; i++)
        {
            a[i] = rand.Next(1_000_000) - 500_000;
        }

        for (int i = 0; i < b.Length; i++)
        {
            b[i] = rand.Next(1_000_000) - 500_000;
        }

        var expected = new long[a.Length + b.Length - 1];
        for (int i = 0; i < a.Length; i++)
        {
            for (int j = 0; j < b.Length; j++)
            {
                expected[i + j] += a[i] * b[j];
            }
        }

        var actual = AtCoder.Math.ConvolutionLong(a, b);

        Assert.Equal(expected, actual);
    }

    /// <summary>
    /// 163577857 = 39×2^22 + 1
    /// </summary>
    readonly struct Mod163577857 : IStaticMod
    {
        public uint Mod => 163577857;
        public bool IsPrime => true;
    }

    /// <summary>
    /// 469762049 = 7×2^26 + 1
    /// </summary>
    readonly struct Mod469762049 : IStaticMod
    {
        public uint Mod => 469762049;
        public bool IsPrime => true;
    }
}
