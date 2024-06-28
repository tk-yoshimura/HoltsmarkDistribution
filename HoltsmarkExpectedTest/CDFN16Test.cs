using HoltsmarkExpected;
using MultiPrecision;

namespace HoltsmarkExpectedTest {
    [TestClass]
    public class CDFN16Test {
        [TestMethod]
        public void LimitTest() {
            for (double x = 16; x >= 4; x -= 0.125) {
                Console.WriteLine($"Limit\t{x}\t {CDFLimit<Pow2.N16, N24>.Value(x, complementary: true)}");
                Console.WriteLine($"N48  \t{x}\t {CDFNearZero<Pow2.N16, N48>.Value(x, complementary: true)}");
                Console.WriteLine("");
            }
        }

        [TestMethod]
        public void NearZeroTest() {
            for (double x = 0; x <= 16; x += 0.125) {
                Console.WriteLine($"N24\t{x}\t {CDFNearZero<Pow2.N16, N24>.Value(x, complementary: true)}");
                Console.WriteLine($"N32\t{x}\t {CDFNearZero<Pow2.N16, Pow2.N32>.Value(x, complementary: true)}");
                Console.WriteLine($"N48\t{x}\t {CDFNearZero<Pow2.N16, N48>.Value(x, complementary: true)}");
                Console.WriteLine("");
            }
        }

        [TestMethod]
        public void Border13p5Test() {
            Assert.IsTrue(
                CDFNearZero<Pow2.N16, N48>.Value(13.5, complementary: true) ==
                CDFLimit<Pow2.N16, N24>.Value(13.5, complementary: true)
            );

            Assert.IsTrue(
                CDFN16.Value(13.5, complementary: true) ==
                CDFNearZero<Pow2.N16, N48>.Value(13.5, complementary: true)
            );

            Assert.IsTrue(
                CDFN16.Value(13.5, complementary: true) ==
                CDFLimit<Pow2.N16, N24>.Value(13.5, complementary: true)
            );
        }

        [TestMethod]
        public void Border13p375Test() {
            Assert.IsTrue(
                CDFNearZero<Pow2.N16, N48>.Value(13.375, complementary: true) ==
                CDFNearZero<Pow2.N16, Pow2.N32>.Value(13.375, complementary: true)
            );

            Assert.IsTrue(
                CDFN16.Value(13.375, complementary: true) ==
                CDFNearZero<Pow2.N16, N48>.Value(13.375, complementary: true)
            );

            Assert.IsTrue(
                CDFN16.Value(13.375, complementary: true) ==
                CDFNearZero<Pow2.N16, Pow2.N32>.Value(13.375, complementary: true)
            );
        }

        [TestMethod]
        public void Border10p625Test() {
            Assert.IsTrue(
                CDFNearZero<Pow2.N16, N24>.Value(10.625, complementary: true) ==
                CDFNearZero<Pow2.N16, Pow2.N32>.Value(10.625, complementary: true)
            );

            Assert.IsTrue(
                CDFN16.Value(10.625, complementary: true) ==
                CDFNearZero<Pow2.N16, N24>.Value(10.625, complementary: true)
            );

            Assert.IsTrue(
                CDFN16.Value(10.625, complementary: true) ==
                CDFNearZero<Pow2.N16, Pow2.N32>.Value(10.625, complementary: true)
            );
        }
    }
}