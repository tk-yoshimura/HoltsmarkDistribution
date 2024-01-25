using MultiPrecision;

namespace HoltsmarkDistribution {
    public class CDFLimit<N, M> where N : struct, IConstant where M : struct, IConstant {
        private static readonly List<MultiPrecision<M>> gamma_table = [], coef_table = [];
        private static readonly List<MultiPrecision<M>> sin_table = [
            0,
            1 / MultiPrecision<M>.Sqrt2,
            -1,
            1 / MultiPrecision<M>.Sqrt2,
            0,
            -1 / MultiPrecision<M>.Sqrt2,
            1,
            -1 / MultiPrecision<M>.Sqrt2,
        ];

        public static MultiPrecision<N> Value(MultiPrecision<N> x, bool complementary = false, int max_terms = 8192) {
            MultiPrecision<M> v = MultiPrecision<M>.Sqrt(1 / x.Convert<M>()), v3 = v * v * v, v6 = v3 * v3;

            MultiPrecision<M> s = 0, u = 2 * v3 * MultiPrecision<M>.RcpPI;

            for (int k = 1, conv_times = 0; k <= max_terms; k += 2) {
                MultiPrecision<M> c0 = CoefTable(k), c1 = CoefTable(k + 1);

                MultiPrecision<M> ds = u * (c0 - v3 * c1);

                if (s.Exponent - ds.Exponent > MultiPrecision<N>.Bits) {
                    conv_times++;

                    if (conv_times >= 4) {
                        return complementary ? s.Convert<N>() : (0.5 - s).Convert<N>();
                    }
                }
                else {
                    conv_times = 0;
                }

                if (s.Exponent > MultiPrecision<M>.Bits - MultiPrecision<N>.Bits) {
                    break;
                }

                s += ds;
                u *= v6;
            }

            return MultiPrecision<N>.NaN;
        }

        private static MultiPrecision<M> GammaTable(int n) {
            for (int k = gamma_table.Count; k <= n; k++) {
                MultiPrecision<M> g = MultiPrecision<M>.Gamma(MultiPrecision<M>.Div(3 * k + 2, 2));
                gamma_table.Add(g);
            }

            return gamma_table[n];
        }

        private static MultiPrecision<M> CoefTable(int n) {
            for (int k = coef_table.Count; k <= n; k++) {
                MultiPrecision<M> c = GammaTable(k) * sin_table[k % 8] * TaylorSeries<M>.Table(k) / (3 * k);
                coef_table.Add(c);
            }

            return coef_table[n];
        }
    }
}
