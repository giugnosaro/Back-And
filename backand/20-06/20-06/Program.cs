using System;
using System.Collections.Generic;

internal class Program
{
    static List<string> accessList = new List<string>(); // Lista degli accessi

    static char Choice()
    {
        char answer;
        do
        {
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input) && input.Length == 1)
            {
                answer = input[0];
            }
            else
            {
                answer = '\0';
            }
        } while (answer < '1' || answer > '6');
        return answer;
    }

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("Scrivi una scelta (1-6): ");
            char input = Choice();
            Console.WriteLine($"Hai scelto: {input}");

            switch (input)
            {
                case '1':
                    Console.WriteLine("Hai scelto 1");
                    LoginManager();
                    break;
                case '2':
                    Console.WriteLine("Hai scelto 2");
                    Logout();
                    break;
                case '3':
                    Console.WriteLine("Hai scelto 3");
                    Verifica();
                    break;
                case '4':
                    Console.WriteLine("Hai scelto 4");
                    ListaDiAccessi();
                    break;
                case '5':
                    Console.WriteLine("Hai scelto 5");
                    Exit();
                    return;
                case '6':
                    Console.WriteLine("Hai scelto 6");
                    Register();
                    break;
            }
        }
    }

    static void LoginManager()
    {
        Console.Write("Inserisci il nome utente: ");
        string username = Console.ReadLine();
        Console.Write("Inserisci la password: ");
        string password = Console.ReadLine();
        Console.Write("Conferma la password: ");
        string confirmPassword = Console.ReadLine();

        if (Authenticate(username, password, confirmPassword))
        {
            Console.WriteLine("Accesso effettuato con successo!");
            accessList.Add($"Login: {username} - {DateTime.Now}");
        }
    }

    static bool Authenticate(string username, string password, string confirmPassword)
    {
        
        if (string.IsNullOrEmpty(username))
        {
            Console.WriteLine("Inserisci un nome utente valido.");
            return false;
        }

        
        if (password != confirmPassword)
        {
            Console.WriteLine("Le password non coincidono.");
            return false;
        }

       
        Console.WriteLine("Autenticazione riuscita!");
        return true;
    }

    static void Register()
    {
        Console.Write("Inserisci il nome utente per la registrazione: ");
        string username = Console.ReadLine();
        if (string.IsNullOrEmpty(username))
        {
            Console.WriteLine("Inserisci un nome utente valido.");
            return;
        }

        Console.Write("Inserisci la password: ");
        string password = Console.ReadLine();
        Console.Write("Conferma la password: ");
        string confirmPassword = Console.ReadLine();

        if (Authenticate(username, password, confirmPassword))
        {
            Console.WriteLine("Registrazione effettuata con successo!");
            accessList.Add($"Registrazione: {username} - {DateTime.Now}");
        }
    }

    static void Logout()
    {
        Console.WriteLine("Logout effettuato.");
        accessList.Add($"Logout - {DateTime.Now}");
    }

    static void Verifica()
    {
        Console.WriteLine("Verifica in corso...");
        accessList.Add($"Verifica - {DateTime.Now}");
    }

    static void ListaDiAccessi()
    {
        Console.WriteLine("Lista degli accessi:");
        foreach (var access in accessList)
        {
            Console.WriteLine(access);
        }
    }

    static void Exit()
    {
        Console.WriteLine("Uscita dal programma.");
    }
}

