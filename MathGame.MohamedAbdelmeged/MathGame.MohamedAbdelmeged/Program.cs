
using MathGame.MohamedAbdelmeged.Helpers;
using MathGame.MohamedAbdelmeged.Services;


ConsoleHelper.PrintWelcome();

var gameIsOpen = true;
while (gameIsOpen)
{
    gameIsOpen = GameService.StartGame();
}
ConsoleHelper.PrintGoodBye();