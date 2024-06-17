using HoltsmarkExpected;
using MultiPrecision;

namespace HoltsmarkExpectedTest {
    [TestClass]
    public class CDFTest {
        [TestMethod]
        public void Border13p4375Test() {
            Assert.IsTrue(
                MultiPrecision<Pow2.N16>.NearlyEqualBits(
                    CDFLimit<Pow2.N16, N24>.Value(13.4375, complementary: true),
                    CDFNearZero<Pow2.N16, Pow2.N32>.Value(13.4375, complementary: true),
                ignore_bits: 2)
            );

            Assert.IsTrue(
                MultiPrecision<Pow2.N16>.NearlyEqualBits(
                    CDFN16.Value(13.4375, complementary: true),
                    CDFNearZero<Pow2.N16, Pow2.N32>.Value(13.4375, complementary: true),
                ignore_bits: 2)
            );

            Assert.IsTrue(
                MultiPrecision<Pow2.N16>.NearlyEqualBits(
                    CDFN16.Value(13.4375, complementary: true),
                    CDFLimit<Pow2.N16, N24>.Value(13.4375, complementary: true),
                ignore_bits: 2)
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
                CDFNearZero<Pow2.N16, Pow2.N32>.Value(10.625, complementary: true)
            );

            Assert.IsTrue(
                CDFN16.Value(10.625, complementary: true) ==
                CDFNearZero<Pow2.N16, N24>.Value(10.625, complementary: true)
            );
        }
    }
}