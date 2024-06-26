﻿using HoltsmarkPadeApprox;
using MultiPrecision;
using MultiPrecisionIntegrate;

namespace HoltsmarkEvalExpected {
    internal class EvalEntropy {
        static void Main_() {
            using StreamWriter sw = new("../../../../results/entropy_precision60.csv");

            static MultiPrecision<Pow2.N16> info(MultiPrecision<Pow2.N16> x) {
                MultiPrecision<Pow2.N16> px = PDFPadeN16.Value(x);

                if (px == 0) {
                    return 0;
                }

                return -px * MultiPrecision<Pow2.N16>.Log(px);
            };

            (MultiPrecision<Pow2.N16> value, MultiPrecision<Pow2.N16> error, _) =
                GaussKronrodIntegral<Pow2.N16>.AdaptiveIntegrate(info, 0, MultiPrecision<Pow2.N16>.PositiveInfinity, 
                1e-120, GaussKronrodOrder.G32K65, maxdepth: 128
            );

            value *= 2;
            error *= 2;

            Console.WriteLine($"{value}\n{error:e20}");

            sw.WriteLine($"entropy,error");
            sw.WriteLine($"{value},{error:e20}");

            sw.Close();

            Console.WriteLine("END");
            Console.Read();
        }
    }
}
