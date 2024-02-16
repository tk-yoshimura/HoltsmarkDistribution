using MultiPrecision;

namespace HoltsmarkExpected {
    public static class TaylorSeries<N> where N : struct, IConstant {
        private static readonly List<MultiPrecision<N>> table = [
            1,
            1
        ];

        public static MultiPrecision<N> Table(int n) {
            for (int k = table.Count; k <= n; k++) {
                MultiPrecision<N> c = table[^1] / k;
                table.Add(c);
            }

            return table[n];
        }
    }
}
