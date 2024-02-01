using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        bool showMenu = true;
        while (showMenu)
        {
            showMenu = MainMenu();
        }
    }

    static bool MainMenu()
    {
        Console.Clear();
        Console.WriteLine("===============OPERAZIONI==============");
        Console.WriteLine("Scegli l'operazione da effettuare:");
        Console.WriteLine("1.: Login");
        Console.WriteLine("2.: Logout");
        Console.WriteLine("3.: Verifica ora e data di login");
        Console.WriteLine("4.: Lista degli accessi");
        Console.WriteLine("5.: Esci");
        Console.WriteLine("========================================");
        Console.Write("\r\nInserisci la tua scelta: ");

        switch (Console.ReadLine())
        {
            case "1":
                Utente.Login();
                Console.ReadLine();
                return true;
            case "2":
                Utente.Logout();
                Console.ReadLine();
                return true;
            case "3":
                Utente.VerificaAccesso();
                Console.ReadLine();
                return true;
            case "4":
                Utente.StampaAccessi();
                Console.ReadLine();
                return true;
            case "5":
                return false;
            default:
                return true;
        }
    }
}

static class Utente
{
    private static string username;
    private static string password;
    private static DateTime? ultimoAccesso;
    private static List<DateTime> storicoAccessi = new List<DateTime>();

    public static void Login()
    {
        Console.Write("Inserisci username: ");
        string inputUsername = Console.ReadLine();

        Console.Write("Inserisci password: ");
        string inputPassword = Console.ReadLine();

        Console.Write("Conferma password: ");
        string confermaPassword = Console.ReadLine();

        if (!string.IsNullOrEmpty(inputUsername) && inputPassword == confermaPassword)
        {
            username = inputUsername;
            password = inputPassword;
            ultimoAccesso = DateTime.Now;
            storicoAccessi.Add(ultimoAccesso.Value);
            Console.WriteLine("Login effettuato con successo!");
        }
        else
        {
            Console.WriteLine("Errore durante il login. Assicurati di inserire una username e password corrette.");
        }
    }

    public static void Logout()
    {
        if (!string.IsNullOrEmpty(username))
        {
            username = null;
            password = null;
            ultimoAccesso = null;
            Console.WriteLine("Logout effettuato.");
        }
        else
        {
            Console.WriteLine("Nessun utente loggato.");
        }
    }

    public static void VerificaAccesso()
    {
        if (ultimoAccesso.HasValue)
        {
            Console.WriteLine($"Ultimo accesso: {ultimoAccesso.Value}");
        }
        else
        {
            Console.WriteLine("Nessun utente loggato.");
        }
    }

    public static void StampaAccessi()
    {
        Console.WriteLine("Storico accessi:");
        foreach (var accesso in storicoAccessi)
        {
            Console.WriteLine(accesso);
        }
    }
}
