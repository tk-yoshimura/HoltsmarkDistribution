using MultiPrecision;

namespace HoltsmarkDistribution {
    internal class ExpectedN12 {
        static void Main() {
            using (StreamWriter sw = new("../../../../results/pdf_precision150.csv")) {
                sw.WriteLine("x,pdf(x)");

                for (double x = 0; x < 1; x += 1d / 1024) {
                    MultiPrecision<Pow2.N16> y = PDFN16.Value(x);

                    Console.WriteLine($"{x}\n{y}");
                    sw.WriteLine($"{x},{y}");
                }

                for (double x0 = 1; x0 < 4096; x0 *= 2) {
                    for (double x = x0; x < x0 * 2; x += x0 / 512) {
                        MultiPrecision<Pow2.N16> y = PDFN16.Value(x);

                        Console.WriteLine($"{x}\n{y}");
                        sw.WriteLine($"{x},{y}");
                    }
                }

                for (MultiPrecision<Pow2.N16> v = MultiPrecision<Pow2.N16>.Ldexp(1, 12); v.Exponent <= 1024; v *= 2) {
                    MultiPrecision<Pow2.N16> y = PDFN16.Value(v);

                    Console.WriteLine($"{v}\n{y}");
                    sw.WriteLine($"2^{v.Exponent},{y}");
                }
            }

            //using (BinaryWriter stream = new(File.Open("../../../../results_disused/pdf_n16.bin", FileMode.Create))) {
            //    for (double x = 0; x <= 256; x += 1d / 1024) {
            //        MultiPrecision<Pow2.N16> y = PDFN16.Value(x);

            //        Console.WriteLine($"{x}\n{y}");
            //        stream.Write(y);
            //    }
            //}

            Console.WriteLine("END");
            Console.Read();
        }
    }
}
