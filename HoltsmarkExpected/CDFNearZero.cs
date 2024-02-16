using MultiPrecision;

namespace HoltsmarkExpected {
    public class CDFNearZero<N, M> where N : struct, IConstant where M : struct, IConstant {
        private static readonly MultiPrecision<M> norm = MultiPrecision<M>.Div(2, 3 * MultiPrecision<M>.PI);
        private static readonly List<MultiPrecision<M>> gamma_table = [], coef_table = [];

        public static MultiPrecision<N> Value(MultiPrecision<N> x, bool complementary = false, int max_terms = 8192) {
            if (x == 0) {
                return 0;
            }

            MultiPrecision<M> x2 = MultiPrecision<M>.Square(x.Convert<M>()), x4 = x2 * x2;

            MultiPrecision<M> s = 0, u = norm * x.Convert<M>();

            for (int k = 0, conv_times = 0; k <= max_terms; k += 2) {
                MultiPrecision<M> c0 = CoefTable(k), c1 = CoefTable(k + 1);

                MultiPrecision<M> ds = u * (c0 - x2 * c1);

                if (s.Exponent - ds.Exponent > MultiPrecision<N>.Bits) {
                    conv_times++;

                    if (conv_times >= 4) {
                        return complementary ? (0.5 - s).Convert<N>() : s.Convert<N>();
                    }
                }
                else {
                    conv_times = 0;
                }

                if (s.Exponent > MultiPrecision<M>.Bits - MultiPrecision<N>.Bits) {
                    break;
                }

                s += ds;
                u *= x4;
            }

            return MultiPrecision<N>.NaN;
        }

        private static MultiPrecision<M> GammaTable(int n) {
            for (int k = gamma_table.Count; k <= n; k++) {
                MultiPrecision<M> g = MultiPrecision<M>.Gamma(MultiPrecision<M>.Div(4 * k + 2, 3));
                gamma_table.Add(g);
            }

            return gamma_table[n];
        }

        private static MultiPrecision<M> CoefTable(int n) {
            for (int k = coef_table.Count; k <= n; k++) {
                MultiPrecision<M> c = GammaTable(k) * TaylorSeries<M>.Table(2 * k + 1);
                coef_table.Add(c);
            }

            return coef_table[n];
        }
    }
}
