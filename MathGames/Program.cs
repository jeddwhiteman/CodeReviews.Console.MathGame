// See https://aka.ms/new-console-template for more information
using MathGames;
using System.ComponentModel.Design;
using System.Security.AccessControl;
Console.WriteLine("Please type your name: ");
var name = Console.ReadLine();

List<GameHistory> history = new List<GameHistory>();

while (true)
{
    var date = DateTime.UtcNow;

    Console.WriteLine("-------------------------------------------------------------------");
    Console.WriteLine($"Hello {name?.ToUpper()}. It's {date.DayOfWeek}. This is your math game.");

    Console.WriteLine($@"What game would you like to play? Choose options from below:
A - Addition
S - Subtraction
M - Muliplication
D - Division
V - View Previous games
Q - Quit the program");
    Console.WriteLine("-------------------------------------------------------------------");
    string gameSelected = Console.ReadLine();


    Menu(gameSelected);
}


void Menu(string gameSelection)
{
    switch (gameSelection?.Trim().ToLower())
    {
        case "a":
            AdditionGame();
            break;

        case "s":
            SubtractionGame();
            break;
        case "m":
            MultiplicationGame();
            break;
        case "d":
            DivisionGame();
            break;
        case "v":
            DisplayPreviousGames();
            break;
        case "q":
            Console.WriteLine("Goodbye");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid Option");
            break;
    }
}
void AdditionGame()
{
    Console.WriteLine("Addition game has been selected");
    while (true)
    {
        Random randomNumber = new Random();

        int numberOne = randomNumber.Next(100);
        int numberTwo = randomNumber.Next(100);

        Console.WriteLine($"What is {numberOne} + {numberTwo}");

        var userAnswer = Console.ReadLine();

        if (int.Parse(userAnswer) == (numberOne + numberTwo))
        {
            Console.WriteLine("You are correct!");
            history.Add(new GameHistory() { UserName = name, GameResult = "Win", GameType = "Addition", DateOfGame = DateTime.UtcNow.ToLocalTime()});
            break;
        }
        else
        {
            Console.WriteLine("Try again!");
            history.Add(new GameHistory() { UserName = name, GameResult = "Loss", GameType = "Addition", DateOfGame = DateTime.UtcNow.ToLocalTime() });
        }
    }

}
void SubtractionGame()
{
    Console.WriteLine("Subtraction game has been selected");
    while (true)
    {
        Random randomNumber = new Random();

        int numberOne = randomNumber.Next(100);
        int numberTwo = randomNumber.Next(100);

        Console.WriteLine($"What is {numberOne} - {numberTwo}");

        var userAnswer = Console.ReadLine();

        if (int.Parse(userAnswer) == (numberOne - numberTwo))
        {
            Console.WriteLine("You are correct!");
            history.Add(new GameHistory() { UserName = name, GameResult = "Win", GameType = "Subtraction", DateOfGame = DateTime.UtcNow.ToLocalTime() });
            break;
        }
        else
        {
            Console.WriteLine("Try again!");
            history.Add(new GameHistory() { UserName = name, GameResult = "Loss", GameType = "Subtraction", DateOfGame = DateTime.UtcNow.ToLocalTime() });
        }
    }
}
void MultiplicationGame()
{
    Console.WriteLine("Multiplication game has been selected");
    while (true)
    {
        Random randomNumber = new Random();

        int numberOne = randomNumber.Next(100);
        int numberTwo = randomNumber.Next(100);

        Console.WriteLine($"What is {numberOne} * {numberTwo}");

        var userAnswer = Console.ReadLine();


        if (int.Parse(userAnswer) == (numberOne * numberTwo))
        {
            Console.WriteLine("You are correct!");
            history.Add(new GameHistory() { UserName = name, GameResult = "Win", GameType = "Multiplication", DateOfGame = DateTime.UtcNow.ToLocalTime() });
            break;
        }
        else
        {
            Console.WriteLine("Try again!");
            history.Add(new GameHistory() { UserName = name, GameResult = "Loss", GameType = "Multiplication", DateOfGame = DateTime.UtcNow.ToLocalTime() });
        }
    }
}
void DivisionGame()
{
    Console.WriteLine("Division game has been selected");
    while (true)
    {
        Random randomNumber = new Random();

        int numberOne = randomNumber.Next(100), numberTwo = randomNumber.Next(1,100);

        while (numberTwo == 0 || numberOne % numberTwo != 0)
        {
            numberOne = randomNumber.Next(100);
            numberTwo = randomNumber.Next(100);
        }

        Console.WriteLine($"What is {numberOne} / {numberTwo}");

        var userAnswer = Console.ReadLine();

        if (numberOne % numberTwo == 0)


        if (int.Parse(userAnswer) == (numberOne / numberTwo))
        {
            Console.WriteLine("You are correct!");
            history.Add(new GameHistory() { UserName = name, GameResult = "Win", GameType = "Division", DateOfGame = DateTime.UtcNow.ToLocalTime() });
            break;
        }
        else
        {
            Console.WriteLine("Try again!");
            history.Add(new GameHistory() { UserName = name, GameResult = "Loss", GameType = "Division", DateOfGame = DateTime.UtcNow.ToLocalTime() });
        }
    }
}
void DisplayPreviousGames()
{
    int gameId = 1;
    Console.WriteLine();
    foreach (var historyItem in history)
    {
        Console.WriteLine($"Game Id: {gameId}, Username: {historyItem.UserName}, Game Type: {historyItem.GameType}, Game Result: {historyItem.GameResult}, Date Played: {historyItem.DateOfGame.ToLocalTime()}");
        gameId++;
    }

}