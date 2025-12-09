

namespace MathGame.MohamedAbdelmeged.Models;

public class Game
{
    public string GameType { get; set; }
    private DateTime StartedAt { get; } = DateTime.Now;
    public DateTime FinishedAt { get; set; }
    public int Score { get; set; }
    
    public double TimeSpent()
    {
        return Math.Round((FinishedAt - StartedAt).TotalMinutes, 2);
    }

    public Game(string gameType)
    {
        GameType = gameType;
    }
}