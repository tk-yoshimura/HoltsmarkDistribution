﻿using HoltsmarkExpected;
using HoltsmarkPadeApprox;
using MultiPrecision;

namespace HoltsmarkEvalPadeApprox {
    internal class EvalCDFPadeN16 {
        static void Main() {
            MultiPrecision<Pow2.N16> max_err = "1e-150";

            using (StreamWriter sw = new("../../../../results_disused/cdf_pade_eval.csv")) {
                sw.WriteLine("x,cdferror,ccdferror");

                for (double x = 0; x < 1; x += 1d / 4096) {
                    MultiPrecision<Pow2.N16> cdf_expected = CDFN16.Value(x);
                    MultiPrecision<Pow2.N16> ccdf_expected = CDFN16.Value(x, complementary: true);

                    MultiPrecision<Pow2.N16> cdf_actual = CDFPadeN16.Value(x);
                    MultiPrecision<Pow2.N16> ccdf_actual = CDFPadeN16.Value(x, complementary: true);

                    MultiPrecision<Pow2.N16> cdf_error = MultiPrecision<Pow2.N16>.Abs(cdf_expected - cdf_actual) / cdf_expected;
                    MultiPrecision<Pow2.N16> ccdf_error = MultiPrecision<Pow2.N16>.Abs(ccdf_expected - ccdf_actual) / ccdf_expected;

                    Console.WriteLine($"{x}\n{cdf_error:e10}\n{ccdf_error:e10}");
                    sw.WriteLine($"{x},{cdf_error:e20},{ccdf_error:e20}");

                    if (cdf_error >= max_err || ccdf_error >= max_err) {
                        Console.ReadLine();
                    }
                }

                for (double x0 = 1; x0 < 4294967296; x0 *= 2) {
                    for (double x = x0; x < x0 * 2; x += x0 / 2048) {
                        MultiPrecision<Pow2.N16> cdf_expected = CDFN16.Value(x);
                        MultiPrecision<Pow2.N16> ccdf_expected = CDFN16.Value(x, complementary: true);

                        MultiPrecision<Pow2.N16> cdf_actual = CDFPadeN16.Value(x);
                        MultiPrecision<Pow2.N16> ccdf_actual = CDFPadeN16.Value(x, complementary: true);

                        MultiPrecision<Pow2.N16> cdf_error = MultiPrecision<Pow2.N16>.Abs(cdf_expected - cdf_actual) / cdf_expected;
                        MultiPrecision<Pow2.N16> ccdf_error = MultiPrecision<Pow2.N16>.Abs(ccdf_expected - ccdf_actual) / ccdf_expected;

                        Console.WriteLine($"{x}\n{cdf_error:e10}\n{ccdf_error:e10}");
                        sw.WriteLine($"{x},{cdf_error:e20},{ccdf_error:e20}");

                        if (cdf_error >= max_err || ccdf_error >= max_err) {
                            Console.ReadLine();
                        }
                    }
                }
            }

            Console.WriteLine("END");
            Console.Read();
        }
    }
}
