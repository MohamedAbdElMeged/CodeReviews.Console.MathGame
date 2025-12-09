using MathGame.MohamedAbdelmeged.Helpers;
using MathGame.MohamedAbdelmeged.Models;

namespace MathGame.MohamedAbdelmeged.Services;

public static class GameService
{
    public static bool StartGame()
    {
        var gameIsOpen = true;
        var optionsName = "Main Menu";
        List<string> options = ["Play New Game", "View Previous Score", "Play Random Game", "Exit"];
        ConsoleHelper.PrintOptions(optionsName,options);
        var optionInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(optionInput) && Int32.TryParse(optionInput, out var input))
        {
            switch (input)
            {
                case 1:
                    HandlePLayNewGameOption();
                    break;
                case 2:
                    HandleViewPreviousScoreOption();
                    break;
                case 3:
                    HandlePlayRandomGameOption();
                    break;
                case 4:
                    gameIsOpen = false;
                    break;
                default:
                    gameIsOpen = true;
                    break;
            }
        }

        return gameIsOpen;
    }

    private static void HandleViewPreviousScoreOption()
    {
        if (GameHistory.Games.Count == 0)
        {
            ConsoleHelper.PrintError("No Previous Score");
            return;
        }
        foreach (var game in GameHistory.Games)
        {
            ConsoleHelper.PrintGameScore(game,false);
        }
    }


    private static void HandlePLayNewGameOption()
    {
        var optionsName = "Game Options";
        List<string> options = ["Addition", "Subtraction", "Multiplication", "Division"];
        ConsoleHelper.PrintOptions(optionsName,options);
        var optionInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(optionInput) && Int32.TryParse(optionInput, out var input))
        {
            switch (input)
            {
                case 1:
                    HandleAdditionGame();
                    break;
                case 2:
                    HandleSubtractionGame();
                    break;
                case 3:
                    HandleMultiplicationGame();
                    break;
                case 4:
                    HandleDivisionGame();
                    break;
            }
        }

        
    }

    private static void HandleDivisionGame()
    {
        var game = new Game("Division");
        var random = new Random();
        for (int i = 0; i < 5; i++)
        {
            var firstTerm = random.Next(1, 100);
            var secondTerm = random.Next(1, 100);
            while (firstTerm % secondTerm != 0 || firstTerm <= secondTerm || secondTerm == 1)
            {
                firstTerm = random.Next(1, 100);
                secondTerm = random.Next(1, 100);
            }
            ConsoleHelper.PrintEquation(firstTerm, '/', secondTerm);
            var answeredRight = HandleUserAnswer((firstTerm / secondTerm));
            if (answeredRight)
            {
                game.Score += 1;
            }
        }
        game.FinishedAt = DateTime.Now;
        GameHistory.Games.Add(game);
        ConsoleHelper.PrintGameScore(game,true);
    }

    private static void HandleMultiplicationGame()
    {
        var game = new Game("Multiplication");
        var random = new Random();
        for (int i = 0; i < 5; i++)
        {
            var firstTerm = random.Next(1, 12);
            var secondTerm = random.Next(1, 12);
            ConsoleHelper.PrintEquation(firstTerm, '*', secondTerm);
            var answeredRight = HandleUserAnswer((firstTerm * secondTerm));
            if (answeredRight)
            {
                game.Score += 1;
            }
        }
        game.FinishedAt = DateTime.Now;
        GameHistory.Games.Add(game);
        ConsoleHelper.PrintGameScore(game,true);
    }

    private static void HandleSubtractionGame()
    {
        var game = new Game("Subtraction");
        var random = new Random();
        for (int i = 0; i < 5; i++)
        {
            var firstTerm = random.Next(50, 101);
            var secondTerm = random.Next(1, 40);
            ConsoleHelper.PrintEquation(firstTerm, '-', secondTerm);
            var answeredRight = HandleUserAnswer((firstTerm - secondTerm));
            if (answeredRight)
            {
                game.Score += 1;
            }
        }
        game.FinishedAt = DateTime.Now;
        GameHistory.Games.Add(game);
        ConsoleHelper.PrintGameScore(game,true);
    }

    private static void HandleAdditionGame()
    {
        var game = new Game("Addition");
        var random = new Random();
        for (int i = 0; i < 5; i++)
        {
            var firstTerm = random.Next(1, 101);
            var secondTerm = random.Next(1, 101);
            ConsoleHelper.PrintEquation(firstTerm, '+', secondTerm);
            var answeredRight = HandleUserAnswer((firstTerm+secondTerm));
            if (answeredRight)
            {
                game.Score += 1;
            }
        }
        game.FinishedAt = DateTime.Now;
        GameHistory.Games.Add(game);
        ConsoleHelper.PrintGameScore(game,true);
    }

    private static bool HandleUserAnswer(int rightAnswer)
    {
        var userAnswerInput = Console.ReadLine();
        
        if (string.IsNullOrEmpty(userAnswerInput) || !Int32.TryParse(userAnswerInput, out var userAnswer))
        {
            return false;
        }

        return userAnswer == rightAnswer;
    }
    
    private static void HandlePlayRandomGameOption()
    {
        var random = new Random();
        var randomGameType = random.Next(1, 5);
    
        switch (randomGameType)
        {
            case 1:
                HandleAdditionGame();
                break;
            case 2:
                HandleSubtractionGame();
                break;
            case 3:
                HandleMultiplicationGame();
                break;
            case 4:
                HandleDivisionGame();
                break;
        }
    }
}