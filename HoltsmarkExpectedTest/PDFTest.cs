using HoltsmarkExpected;
using MultiPrecision;

namespace HoltsmarkExpectedTest {
    [TestClass]
    public class PDFTest {
        [TestMethod]
        public void Border13p5Test() {
            Assert.IsTrue(PDFLimit<Pow2.N16, N24>.Value(13.5) == PDFNearZero<Pow2.N16, N48>.Value(13.5));
        }

        [TestMethod]
        public void Border10p4375Test() {
            Assert.IsTrue(PDFNearZero<Pow2.N16, N24>.Value(10.4375) == PDFNearZero<Pow2.N16, Pow2.N32>.Value(10.4375));
        }

        [TestMethod]
        public void Border13p25Test() {
            Assert.IsTrue(PDFNearZero<Pow2.N16, Pow2.N32>.Value(13.25) == PDFNearZero<Pow2.N16, N48>.Value(13.25));
        }
    }
}