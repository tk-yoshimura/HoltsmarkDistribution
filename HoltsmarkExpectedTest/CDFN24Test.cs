using HoltsmarkExpected;
using MultiPrecision;

namespace HoltsmarkExpectedTest {
    [TestClass]
    public class CDFN24Test {
        [TestMethod]
        public void LimitTest() {
            for (double x = 16; x >= 4; x -= 0.125) {
                Console.WriteLine($"Limit\t{x}\t {CDFLimit<N24, Pow2.N32>.Value(x, complementary: true)}");
                Console.WriteLine($"N64  \t{x}\t {CDFNearZero<N24, Pow2.N64>.Value(x, complementary: true)}");
                Console.WriteLine("");
            }
        }

        [TestMethod]
        public void NearZeroTest() {
            for (double x = 0; x <= 16; x += 0.125) {
                Console.WriteLine($"N32\t{x}\t {CDFNearZero<N24, Pow2.N32>.Value(x, complementary: true)}");
                Console.WriteLine($"N48\t{x}\t {CDFNearZero<N24, N48>.Value(x, complementary: true)}");
                Console.WriteLine($"N64\t{x}\t {CDFNearZero<N24, Pow2.N64>.Value(x, complementary: true)}");
                Console.WriteLine("");
            }
        }

        [TestMethod]
        public void Border15p5Test() {
            Assert.IsTrue(
                CDFNearZero<N24, Pow2.N64>.Value(15.5, complementary: true) ==
                CDFLimit<N24, Pow2.N32>.Value(15.5, complementary: true)
            );

            Assert.IsTrue(
                CDFN24.Value(15.5, complementary: true) ==
                CDFNearZero<N24, Pow2.N64>.Value(15.5, complementary: true)
            );

            Assert.IsTrue(
                CDFN24.Value(15.5, complementary: true) ==
                CDFLimit<N24, Pow2.N32>.Value(15.5, complementary: true)
            );
        }

        [TestMethod]
        public void Border15p25Test() {
            Assert.IsTrue(
                CDFNearZero<N24, Pow2.N64>.Value(15.25, complementary: true) ==
                CDFNearZero<N24, N48>.Value(15.25, complementary: true)
            );

            Assert.IsTrue(
                CDFN24.Value(15.25, complementary: true) ==
                CDFNearZero<N24, Pow2.N64>.Value(15.25, complementary: true)
            );

            Assert.IsTrue(
                CDFN24.Value(15.25, complementary: true) ==
                CDFNearZero<N24, N48>.Value(15.25, complementary: true)
            );
        }

        [TestMethod]
        public void Border10p625Test() {
            Assert.IsTrue(
                CDFNearZero<N24, Pow2.N32>.Value(10.625, complementary: true) ==
                CDFNearZero<N24, N48>.Value(10.625, complementary: true)
            );

            Assert.IsTrue(
                CDFN24.Value(10.625, complementary: true) ==
                CDFNearZero<N24, Pow2.N32>.Value(10.625, complementary: true)
            );

            Assert.IsTrue(
                CDFN24.Value(10.625, complementary: true) ==
                CDFNearZero<N24, N48>.Value(10.625, complementary: true)
            );
        }
    }
}