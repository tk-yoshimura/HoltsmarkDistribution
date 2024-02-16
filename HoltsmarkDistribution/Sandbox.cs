using MultiPrecision;

namespace HoltsmarkDistribution {
    internal class Sandbox {
        static void Main_() {

            for (int k = 0; k <= 100; k++) {
                MultiPrecision<Pow2.N16> p = MultiPrecision<Pow2.N16>.Div(k, 100);
                MultiPrecision<Pow2.N16> x = -QuantilePadeN16.Value(p);
                MultiPrecision<Pow2.N16> y = CDFPadeN16.Value(x) + 0.5;

                Console.WriteLine($"{p},{x:e30},{y:e144}");
            }

            Console.WriteLine("END");
            Console.Read();
        }
    }
}
