using MultiPrecision;

namespace HoltsmarkDistribution {
    internal class ConvCheck {
        static void Main_() {
            using (StreamWriter sw = new("../../../../results_disused/convcheck_n16.txt")) {

                for (double x = 0; x <= 64; x += 0.0625) {
                    Console.WriteLine($"{nameof(x)} = {x}");
                    sw.WriteLine($"{nameof(x)} = {x}");

                    MultiPrecision<Pow2.N16> nz24 = PDFNearZero<Pow2.N16, N24>.Value(x);
                    Console.WriteLine($"{nameof(nz24)}, {nz24}");
                    sw.WriteLine($"{nameof(nz24)}, {nz24}");

                    MultiPrecision<Pow2.N16> nz32 = PDFNearZero<Pow2.N16, Pow2.N32>.Value(x);
                    Console.WriteLine($"{nameof(nz32)}, {nz32}");
                    sw.WriteLine($"{nameof(nz32)}, {nz32}");

                    if (nz24 != nz32) {
                        MultiPrecision<Pow2.N16> nz48 = PDFNearZero<Pow2.N16, N48>.Value(x);
                        Console.WriteLine($"{nameof(nz48)}, {nz48}");
                        sw.WriteLine($"{nameof(nz48)}, {nz48}");

                        if (nz32 != nz48) {
                            MultiPrecision<Pow2.N16> nz64 = PDFNearZero<Pow2.N16, Pow2.N64>.Value(x);
                            Console.WriteLine($"{nameof(nz64)}, {nz64}");
                            sw.WriteLine($"{nameof(nz64)}, {nz64}");
                        }
                    }


                    MultiPrecision<Pow2.N16> lm24 = PDFLimit<Pow2.N16, N24>.Value(x);
                    Console.WriteLine($"{nameof(lm24)}, {lm24}");
                    sw.WriteLine($"{nameof(lm24)}, {lm24}");

                    MultiPrecision<Pow2.N16> lm32 = PDFLimit<Pow2.N16, Pow2.N32>.Value(x);
                    Console.WriteLine($"{nameof(lm32)}, {lm32}");
                    sw.WriteLine($"{nameof(lm32)}, {lm32}");

                    if (lm24 != lm32) {
                        MultiPrecision<Pow2.N16> lm48 = PDFLimit<Pow2.N16, N48>.Value(x);
                        Console.WriteLine($"{nameof(lm48)}, {lm48}");
                        sw.WriteLine($"{nameof(lm48)}, {lm48}");

                        if (lm32 != lm48) {
                            MultiPrecision<Pow2.N16> lm64 = PDFLimit<Pow2.N16, Pow2.N64>.Value(x);
                            Console.WriteLine($"{nameof(lm64)}, {lm64}");
                            sw.WriteLine($"{nameof(lm64)}, {lm64}");
                        }
                    }
                }
            }

            Console.WriteLine("END");
            Console.Read();
        }
    }
}
