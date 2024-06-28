using MultiPrecision;

namespace HoltsmarkExpected {
    public static class CDFN24 {
        public static MultiPrecision<N24> Value(MultiPrecision<N24> x, bool complementary = false) {
            if (x == 0) {
                return complementary ? 0.5 : 0;
            }

            x = MultiPrecision<N24>.Abs(x);

            if (x >= 15.5) {
                return CDFLimit<N24, Pow2.N32>.Value(x, complementary);
            }

            if (x <= 10.625) {
                return CDFNearZero<N24, Pow2.N32>.Value(x, complementary);
            }

            if (x <= 15.25) {
                return CDFNearZero<N24, N48>.Value(x, complementary);
            }

            return CDFNearZero<N24, Pow2.N64>.Value(x, complementary);
        }
    }
}
