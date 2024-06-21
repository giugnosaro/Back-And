using System;
using esercizio_venerdi_21_06;

class Program
{
    static void Main()
    {
        Console.WriteLine("Inserisci il nome:");
        string nome = Console.ReadLine();

        Console.WriteLine("Inserisci il cognome:");
        string cognome = Console.ReadLine();

        Console.WriteLine("Inserisci la data di nascita (gg/mm/aaaa):");
        string dataDiNascita = Console.ReadLine();

        Console.WriteLine("Inserisci il sesso (Uomo/Donna):");
        string sessoInput = Console.ReadLine();
        Contribuente.Sesso genere;
        while (!Enum.TryParse(sessoInput, true, out genere))
        {
            Console.WriteLine("Input non valido. Inserisci il sesso (Uomo/Donna):");
            sessoInput = Console.ReadLine();
        }

        Console.WriteLine("Inserisci il comune di residenza:");
        string comuneDiResidenza = Console.ReadLine();

        Console.WriteLine("Inserisci la provincia di residenza:");
        string provinciaResidenza = Console.ReadLine();

        Console.WriteLine("Inserisci il reddito annuale:");
        int redditoAnnuale;
        while (!int.TryParse(Console.ReadLine(), out redditoAnnuale))
        {
            Console.WriteLine("Input non valido. Inserisci un valore numerico per il reddito annuale:");
        }

        Contribuente contribuente = new Contribuente(nome, cognome, dataDiNascita, genere, comuneDiResidenza, provinciaResidenza, redditoAnnuale);

        // Mostra il riepilogo delle informazioni
        Console.WriteLine("\nRiepilogo del Contribuente:");
        Console.WriteLine(contribuente.MostraRiepilogo());

        Console.ReadLine(); // Attendi l'input per visualizzare il riepilogo
    }
}
