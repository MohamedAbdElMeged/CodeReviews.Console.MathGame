using MathGame.MohamedAbdelmeged.Models;

namespace MathGame.MohamedAbdelmeged.Helpers;

public static class ConsoleHelper
{
    private static void PrintLineSeparator()
    {
        Console.WriteLine("-&-&-&-&-&-&-&-&-&-&-&-&-&\n");
    }
    public static void PrintWelcome()
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("Welcome To Math Game");
        ResetColor();
        PrintLineSeparator();
    }
    public static void PrintGoodBye()
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("Good Bye! ");
        ResetColor();
    }

    private static void ResetColor()
    {
        Console.ForegroundColor = ConsoleColor.Black;
    }
    public static void PrintSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        ResetColor();
        PrintLineSeparator();
        
    }

    public static void PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        ResetColor();
        PrintLineSeparator();
    }

    public static void PrintOptions(string optionsName, List<string> options)
    {
        Console.WriteLine($"Please Choose your {optionsName}");
        for (int i = 0; i < options.Count; i++)
        {
            Console.WriteLine($"{i+1} - {options[i]}");
        }
        
    }

    public static void PrintEquation(int firstTerm, char operatorTerm, int secondTerm)
    {
        Console.WriteLine($"{firstTerm} {operatorTerm} {secondTerm} = ???");
    }

    public static void PrintGameScore(Game game, bool isJustFinished = true)
    {
        if (isJustFinished)
        {
            Console.WriteLine("Game Finished");
        }
        Console.WriteLine($"You Played {game.GameType} and answered {game.Score} / 5 in {game.TimeSpent()} minutes");
        PrintLineSeparator();
    }
}