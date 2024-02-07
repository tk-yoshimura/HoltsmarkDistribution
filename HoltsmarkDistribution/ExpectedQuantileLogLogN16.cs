using MultiPrecision;
using MultiPrecisionRootFinding;

namespace HoltsmarkDistribution {
    internal class ExpectedQuantileLogLogN16 {
        static void Main_() {
            using (StreamWriter sw = new("../../../../results_disused/quantile_precision150_loglog.csv")) {
                sw.WriteLine("u:=-log2(p),v:=log2(cquantile(p)+1)");

                MultiPrecision<Pow2.N16> x = 0;

                for (MultiPrecision<Pow2.N16> u0 = 1; u0 < 16384; u0 *= 2) {
                    for (MultiPrecision<Pow2.N16> u = u0; u < u0 * 2; u += u0 / (u0 < 16 ? 16384 : 4096)) {
                        MultiPrecision<Pow2.N16> p = MultiPrecision<Pow2.N16>.Pow2(-u);

                        x = NewtonRaphsonFinder<Pow2.N16>.RootFind(
                            x => (CDFPadeN16.Value(x, complementary: true) - p, -PDFPadeN16.Value(x)),
                            x0: x, overshoot_decay: true
                        );

                        MultiPrecision<Pow2.N16> v = MultiPrecision<Pow2.N32>.Log2(x.Convert<Pow2.N32>() + 1).Convert<Pow2.N16>();

                        Console.WriteLine($"{u}\n{v}\n");

                        sw.WriteLine($"{u},{v}");
                    }
                }
            }

            Console.WriteLine("END");
            Console.Read();
        }
    }
}
