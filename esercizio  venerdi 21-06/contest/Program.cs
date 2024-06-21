using System.Diagnostics;

namespace Contest
{
    public class Program
    {
        int upperBound = 10000;  // Definisce un limite superiore per la ricerca dei numeri primi

        // Funzione statica che determina se un numero è primo
        static bool IsPrime(int n)
        {
            // I numeri minori o uguali a 1 non sono primi
            if (n <= 1) return false;

            // I numeri 2 e 3 sono primi
            if (n <= 3) return true;

            // Se il numero è divisibile per 2 o 3, non è primo
            if (n % 2 == 0 || n % 3 == 0) return false;

            int i = 5;
            // Verifica se il numero è divisibile per qualche numero fino alla sua radice quadrata
            while (i * i <= n)
            {
                // Se il numero è divisibile per i o per (i + 2), non è primo
                if (n % i == 0 || n % (i + 2) == 0) return false;
                i += 6;
            }

            // Se non è stato trovato alcun divisore, il numero è primo
            return true;
        }

        // Funzione statica che stampa i numeri primi fino a un limite superiore
        static void Primes(int upperBound)
        {
            // Cicla tutti i numeri da 0 fino al limite superiore
            for (int i = 0; i < upperBound; i++)
            {
                // Se il numero è primo, lo stampa
                if (IsPrime(i))
                {
                    Console.Write(i);
                }
            }
        }
    
    static void Main(string[] args)
        {
            // un cronometro
            Stopwatch sw = new Stopwatch();
            // attiva il cronometro
            sw.Start();
            // esegue il metodo da misurare
            Primes(10000);
            // ferma il cronometro
            sw.Stop();
            // stampa il tempo trascorso
            Console.WriteLine($"Execution time: {sw.ElapsedMilliseconds} ms");
        }
    }
}
