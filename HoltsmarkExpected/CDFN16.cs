using MultiPrecision;

namespace HoltsmarkExpected {
    public static class CDFN16 {
        public static MultiPrecision<Pow2.N16> Value(MultiPrecision<Pow2.N16> x, bool complementary = false) {
            if (x == 0) {
                return complementary ? 0.5 : 0;
            }

            x = MultiPrecision<Pow2.N16>.Abs(x);

            if (x >= 13.4375) {
                return CDFLimit<Pow2.N16, N24>.Value(x, complementary);
            }

            if (x <= 10.625) {
                return CDFNearZero<Pow2.N16, N24>.Value(x, complementary);
            }

            return CDFNearZero<Pow2.N16, Pow2.N32>.Value(x, complementary);
        }
    }
}
