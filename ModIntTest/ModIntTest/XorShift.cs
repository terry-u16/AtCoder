using System;
using System.Runtime.CompilerServices;

namespace ModIntTest
{
    public class XorShift
    {
        ulong _x;

        public XorShift() : this((ulong)DateTime.Now.Ticks) { }

        public XorShift(ulong seed)
        {
            _x = seed;
        }

        /// <summary>
        /// [0, (2^64)-1)の乱数を生成します。
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong Next()
        {
            _x = _x ^ (_x << 13);
            _x = _x ^ (_x >> 7);
            _x = _x ^ (_x << 17);
            return _x;
        }

        /// <summary>
        /// [0, <c>exclusiveMax</c>)の乱数を生成します。
        /// </summary>
        /// <param name="exclusiveMax"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Next(int exclusiveMax) => (int)(Next() % (uint)exclusiveMax);

        /// <summary>
        /// [0.0, 1.0)の乱数を生成します。
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double NextDouble()
        {
            const ulong max = 1UL << 50;
            const ulong mask = max - 1;
            return (double)(Next() & mask) / max;
        }
    }
}
