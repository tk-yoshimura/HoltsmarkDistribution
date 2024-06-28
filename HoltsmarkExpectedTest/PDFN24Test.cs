using HoltsmarkExpected;
using MultiPrecision;

namespace HoltsmarkExpectedTest {
    [TestClass]
    public class PDFN24Test {
        [TestMethod]
        public void LimitTest() {
            for (double x = 16; x >= 4; x -= 0.125) {
                Console.WriteLine($"Limit\t{x}\t {PDFLimit<N24, Pow2.N32>.Value(x)}");
                Console.WriteLine($"N64  \t{x}\t {PDFNearZero<N24, Pow2.N64>.Value(x)}");
                Console.WriteLine("");
            }
        }

        [TestMethod]
        public void NearZeroTest() {
            for (double x = 0; x <= 16; x += 0.125) {
                Console.WriteLine($"N32\t{x}\t {PDFNearZero<N24, Pow2.N32>.Value(x)}");
                Console.WriteLine($"N48\t{x}\t {PDFNearZero<N24, N48>.Value(x)}");
                Console.WriteLine($"N64\t{x}\t {PDFNearZero<N24, Pow2.N64>.Value(x)}");
                Console.WriteLine("");
            }
        }

        [TestMethod]
        public void Border15p5Test() {
            Assert.IsTrue(PDFLimit<N24, Pow2.N32>.Value(15.5) == PDFNearZero<N24, Pow2.N64>.Value(15.5));
            Assert.IsTrue(PDFN24.Value(15.5) == PDFLimit<N24, Pow2.N32>.Value(15.5));
            Assert.IsTrue(PDFN24.Value(15.5) == PDFNearZero<N24, Pow2.N64>.Value(15.5));
        }

        [TestMethod]
        public void Border15p125Test() {
            Assert.IsTrue(PDFNearZero<N24, N48>.Value(15.125) == PDFNearZero<N24, Pow2.N64>.Value(15.125));
            Assert.IsTrue(PDFN24.Value(15.125) == PDFNearZero<N24, N48>.Value(15.125));
            Assert.IsTrue(PDFN24.Value(15.125) == PDFNearZero<N24, Pow2.N64>.Value(15.125));
        }

        [TestMethod]
        public void Border10p375Test() {
            Assert.IsTrue(PDFNearZero<N24, Pow2.N32>.Value(10.375) == PDFNearZero<N24, N48>.Value(10.375));
            Assert.IsTrue(PDFN24.Value(10.375) == PDFNearZero<N24, Pow2.N32>.Value(10.375));
            Assert.IsTrue(PDFN24.Value(10.375) == PDFNearZero<N24, N48>.Value(10.375));
        }
    }
}