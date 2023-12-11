using System;
using System.Threading;

class Program
{
    static void Main()
    {
        RiceCooker.choisirMode();
    }
}

class RiceCooker
{
    public static void choisirMode()
    {
        afficherModes();
        string[] modes = modesDisponibles();

        Console.WriteLine("Choisissez un mode de cuisson :");
        string choix = promptSelect("Choisissez un mode de cuisson :", modes);
        int tempsCuisson = determinerTemps(choix);

        if (tempsCuisson > 0)
        {
            afficherAlertes(tempsCuisson);
        }
    }

    static void afficherModes()
    {
        Console.WriteLine("Modes disponibles :");
        Console.WriteLine("1. Riz Blanc");
        Console.WriteLine("2. Riz Complet");
        Console.WriteLine("3. Cuisson Vapeur");
        Console.WriteLine("4. Autre aliment");
    }

    static string[] modesDisponibles()
    {
        return new string[] { "Riz Blanc", "Riz Complet", "Cuisson Vapeur", "Autre aliment" };
    }

    static int determinerTemps(string choix)
    {
        switch (choix)
        {
            case "Riz Blanc":
            case "Riz Complet":
            case "Cuisson Vapeur":
                afficherModeSelectionne(choix);
                return 2;
            case "Autre aliment":
                return determinerTempsAutreAliment();
            default:
                afficherErreurChoix();
                return 0;
        }
    }

    static void afficherModeSelectionne(string choix)
    {
        Console.WriteLine($"Mode {choix} sélectionné");
    }

    static int determinerTempsAutreAliment()
    {
        Console.WriteLine("Entrez le temps de cuisson en secondes pour l'autre aliment :");
        int tempsPersonnalise = int.Parse(Console.ReadLine());

        return tempsPersonnalise > 0 ? tempsPersonnalise : afficherTempsInvalide();
    }

    static int afficherTempsInvalide()
    {
        Console.WriteLine("Temps invalide.");
        return 0;
    }

    static void afficherErreurChoix()
    {
        Console.WriteLine("Choix non valide");
    }

    static void afficherAlertes(int tempsCuisson)
    {
        Console.WriteLine("Types d'alertes disponibles :");
        string[] alertes = { "Son", "Lumières clignotantes" };

        Console.WriteLine("Choisissez le type d'alerte pour signaler la fin de la cuisson :");
        string choixAlerte = promptSelect("Choisissez le type d'alerte pour signaler la fin de la cuisson :", alertes);

        if (Array.Exists(alertes, alerte => alerte == choixAlerte))
        {
            alerteSelectionnee(choixAlerte, tempsCuisson);
        }
    }

    static void alerteSelectionnee(string choixAlerte, int tempsCuisson)
    {
        Thread alertThread = new Thread(() => afficherAlerte(choixAlerte, tempsCuisson));
        alertThread.Start();

        string[] optionsApresCuisson = { "Éteindre", "Maintenir au chaud" };
        string choixApresCuisson = promptSelect("Que voulez-vous faire maintenant?", optionsApresCuisson);

        traiterChoixApresCuisson(choixApresCuisson);
    }

    static void afficherAlerte(string choixAlerte, int tempsCuisson)
    {
        Thread.Sleep(tempsCuisson * 1000);
        string message = messageAlerte(choixAlerte);
        Console.WriteLine(message);
    }

    static string messageAlerte(string choixAlerte)
    {
        if (choixAlerte == "Son")
        {
            return "*BIP*BIP*BIP* La cuisson est terminée !";
        }
        else
        {
            return "*lumières clignotantes* La cuisson est terminée !";
        }
    }

    static void traiterChoixApresCuisson(string choixApresCuisson)
    {
        switch (choixApresCuisson)
        {
            case "Éteindre":
                Console.WriteLine("Le rice cooker a été éteint.");
                break;
            case "Maintenir au chaud":
                Console.WriteLine("Le riz est maintenu au chaud.");
                break;
            default:
                Console.WriteLine("Choix non valide. Le rice cooker sera éteint par défaut.");
                break;
        }
    }

    static string promptSelect(string message, string[] options)
    {
        Console.WriteLine(message);
        foreach (var option in options)
        {
            Console.WriteLine(option);
        }
        return Console.ReadLine();
    }
}
