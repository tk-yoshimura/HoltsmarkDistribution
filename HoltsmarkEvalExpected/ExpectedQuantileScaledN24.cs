using HoltsmarkExpected;
using MultiPrecision;
using MultiPrecisionRootFinding;

namespace HoltsmarkEvalExpected {
    internal class ExpectedQuantileScaledN24 {
        static void Main() {
            using (StreamWriter sw = new("../../../../results_disused/quantile_precision230_scaled.csv")) {
                using (BinaryWriter sw_bin = new(File.Open("../../../../results_disused/quantile_precision230_scaled.bin", FileMode.Create))) {
                    sw.WriteLine("u:=-log2(p),v:=cquantile(p)*p^(2/3)");
                    
                    MultiPrecision<N24> x = 0;

                    for (MultiPrecision<N24> u0 = 1; u0 < 1024; u0 *= 2) {
                        for (MultiPrecision<N24> u = u0; u < u0 * 2 && u <= 1024; u += u0 / (u0 < 16 ? 32768 : 16384)) {
                            MultiPrecision<N24> p = MultiPrecision<N24>.Pow2(-u);

                            x = NewtonRaphsonFinder<N24>.RootFind(
                                x => (CDFN24.Value(x, complementary: true) - p, -PDFN24.Value(x)),
                                x0: x, overshoot_decay: true, iters: 256
                            );

                            MultiPrecision<N24> v = x * MultiPrecision<N24>.Square(MultiPrecision<N24>.Cbrt(p));

                            Console.WriteLine($"{u}\n{v}\n");

                            sw.WriteLine($"{u},{v}");
                            sw_bin.Write(u);
                            sw_bin.Write(v);
                        }
                    }
                }
            }

            Console.WriteLine("END");
            Console.Read();
        }
    }
}
