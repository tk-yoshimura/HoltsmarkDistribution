using MultiPrecision;

namespace HoltsmarkExpected {
    public static class PDFN16 {
        public static MultiPrecision<Pow2.N16> Value(MultiPrecision<Pow2.N16> x) {
            x = MultiPrecision<Pow2.N16>.Abs(x);

            if (x >= 13.5) {
                return PDFLimit<Pow2.N16, N24>.Value(x);
            }

            if (x <= 10.375) {
                return PDFNearZero<Pow2.N16, N24>.Value(x);
            }

            if (x <= 13.25) {
                return PDFNearZero<Pow2.N16, Pow2.N32>.Value(x);
            }

            return PDFNearZero<Pow2.N16, N48>.Value(x);
        }
    }
}
