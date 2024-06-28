using HoltsmarkExpected;
using MultiPrecision;

namespace HoltsmarkExpectedTest {
    [TestClass]
    public class PDFN16Test {
        [TestMethod]
        public void LimitTest() {
            for (double x = 16; x >= 4; x -= 0.125) {
                Console.WriteLine($"Limit\t{x}\t {PDFLimit<Pow2.N16, N24>.Value(x)}");
                Console.WriteLine($"N48  \t{x}\t {PDFNearZero<Pow2.N16, N48>.Value(x)}");
                Console.WriteLine("");
            }
        }

        [TestMethod]
        public void NearZeroTest() {
            for (double x = 0; x <= 16; x += 0.125) {
                Console.WriteLine($"N24\t{x}\t {PDFNearZero<Pow2.N16, N24>.Value(x)}");
                Console.WriteLine($"N32\t{x}\t {PDFNearZero<Pow2.N16, Pow2.N32>.Value(x)}");
                Console.WriteLine($"N48\t{x}\t {PDFNearZero<Pow2.N16, N48>.Value(x)}");
                Console.WriteLine("");
            }
        }

        [TestMethod]
        public void Border13p5Test() {
            Assert.IsTrue(PDFLimit<Pow2.N16, N24>.Value(13.5) == PDFNearZero<Pow2.N16, N48>.Value(13.5));
            Assert.IsTrue(PDFN16.Value(13.5) == PDFLimit<Pow2.N16, N24>.Value(13.5));
            Assert.IsTrue(PDFN16.Value(13.5) == PDFNearZero<Pow2.N16, N48>.Value(13.5));
        }

        [TestMethod]
        public void Border13p25Test() {
            Assert.IsTrue(PDFNearZero<Pow2.N16, Pow2.N32>.Value(13.25) == PDFNearZero<Pow2.N16, N48>.Value(13.25));
            Assert.IsTrue(PDFN16.Value(13.25) == PDFNearZero<Pow2.N16, Pow2.N32>.Value(13.25));
            Assert.IsTrue(PDFN16.Value(13.25) == PDFNearZero<Pow2.N16, N48>.Value(13.25));
        }

        [TestMethod]
        public void Border10p375Test() {
            Assert.IsTrue(PDFNearZero<Pow2.N16, N24>.Value(10.375) == PDFNearZero<Pow2.N16, Pow2.N32>.Value(10.375));
            Assert.IsTrue(PDFN16.Value(10.375) == PDFNearZero<Pow2.N16, N24>.Value(10.375));
            Assert.IsTrue(PDFN16.Value(10.375) == PDFNearZero<Pow2.N16, Pow2.N32>.Value(10.375));
        }
    }
}