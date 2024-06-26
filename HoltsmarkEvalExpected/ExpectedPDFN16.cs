﻿using HoltsmarkExpected;
using MultiPrecision;

namespace HoltsmarkEvalExpected {
    internal class ExpectedPDFN16 {
        static void Main_() {
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

                for (MultiPrecision<Pow2.N16> x = MultiPrecision<Pow2.N16>.Ldexp(1, 12); x.Exponent <= 1024; x *= 2) {
                    MultiPrecision<Pow2.N16> y = PDFN16.Value(x);

                    Console.WriteLine($"{x}\n{y}");
                    sw.WriteLine($"2^{x.Exponent},{y}");
                }
            }

            using (BinaryWriter sw = new(File.Open("../../../../results_disused/pdf_precision150.bin", FileMode.Create))) {
                for (MultiPrecision<Pow2.N16> x = 0, h = 1 / 32768d; x < 1; x += h) {
                    MultiPrecision<Pow2.N16> y = PDFN16.Value(x);

                    Console.WriteLine($"{x}\n{y}");
                    sw.Write(x);
                    sw.Write(y);
                }

                for (MultiPrecision<Pow2.N16> x0 = 1; x0.Exponent < 32; x0 *= 2) {
                    for (MultiPrecision<Pow2.N16> x = x0, h = x0 / 16384; x < x0 * 2; x += h) {
                        MultiPrecision<Pow2.N16> y = PDFN16.Value(x);

                        Console.WriteLine($"{x}\n{y}");
                        sw.Write(x);
                        sw.Write(y);
                    }
                }

                for (int xexp = 32; xexp < 1024; xexp *= 2) {
                    for (MultiPrecision<Pow2.N16> x0 = MultiPrecision<Pow2.N16>.Ldexp(1, xexp); x0.Exponent < xexp * 2; x0 *= 2) {
                        for (MultiPrecision<Pow2.N16> x = x0, h = x0 / (262144 / xexp); x < x0 * 2; x += h) {
                            MultiPrecision<Pow2.N16> y = PDFN16.Value(x);

                            Console.WriteLine($"{x}\n{y}");
                            sw.Write(x);
                            sw.Write(y);
                        }
                    }
                }
            }

            Console.WriteLine("END");
            Console.Read();
        }
    }
}
