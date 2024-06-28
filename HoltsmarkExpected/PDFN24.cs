using MultiPrecision;

namespace HoltsmarkExpected {
    public static class PDFN24 {
        public static MultiPrecision<N24> Value(MultiPrecision<N24> x) {
            x = MultiPrecision<N24>.Abs(x);

            if (x >= 15.5) {
                return PDFLimit<N24, Pow2.N32>.Value(x);
            }

            if (x <= 10.375) {
                return PDFNearZero<N24, Pow2.N32>.Value(x);
            }

            if (x <= 15.125) {
                return PDFNearZero<N24, N48>.Value(x);
            }

            return PDFNearZero<N24, Pow2.N64>.Value(x);
        }
    }
}
