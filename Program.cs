// Requirements
// You need to create a Math game containing the 4 basic operations
// The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100. Example: Your app shouldn't present the division 7/2 to the user, since it doesn't result in an integer.
// Users should be presented with a menu to choose an operation
// You should record previous games in a List and there should be an option in the menu for the user to visualize a history of previous games
// You don't need to record results on a database. Once the program is closed the results will be deleted.

List<string> gameHistoryPoints = new List<string>();

void displayGameHistory()
{
    Console.Clear();

    bool isEmpty = !gameHistoryPoints.Any();

    if (!isEmpty)
    {
        Console.WriteLine("Your scores:");
        int number = gameHistoryPoints.Count() - 1;

        if (gameHistoryPoints.Count() == 1)
        {
            Console.Write(gameHistoryPoints[0]);
        }
        else
        {
            for (int i = 0; i < gameHistoryPoints.Count() - 1; i++)
            {
                Console.Write(gameHistoryPoints[i] + ", ");
            }
            Console.Write(gameHistoryPoints[gameHistoryPoints.Count - 1]);
        }
    }
    else
    {
        Console.WriteLine("No Games on record");
    }
    Thread.Sleep(2000);
};

void game()
{
    int totalScore = 0;

    for (int i = 0; i < 4; i++)
    {
        Console.Clear();
        Random random = new Random();
        int equasion = random.Next(1, 5);
        int randomA = random.Next(0, 100);
        int randomB = random.Next(0, 100);

        string equasionSymbol = "";
        decimal correctScore = 0;

        if (equasion == 1)
        {
            equasionSymbol = "+";
            correctScore = randomA + randomB;
        }
        else if (equasion == 2)
        {
            equasionSymbol = "-";
            correctScore = randomA - randomB;
        }
        else if (equasion == 3)
        {
            equasionSymbol = "*";
            correctScore = randomA * randomB;
        }
        else if (equasion == 4)
        {
            randomA = random.Next(1, 100);
            randomB = random.Next(1, 100);

            while (randomA % randomB != 0)
            {
                randomA = random.Next(1, 100);
                randomB = random.Next(1, 100);
            }

            equasionSymbol = "/";
            correctScore = randomA / randomB;
        }

        Console.WriteLine("Answer the current equasion");
        Console.WriteLine($"{randomA} {equasionSymbol} {randomB}");

        int answer = Convert.ToInt32(Console.ReadLine());

        if (answer == correctScore)
        {
            Console.Clear();
            Console.WriteLine("Correct Score!");
            totalScore++;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Wrong");
        }
        Thread.Sleep(2000);
    }


    gameHistoryPoints.Add(Convert.ToString(totalScore));


    Console.Clear();
    Console.WriteLine($"Your score is: {totalScore}");
    Thread.Sleep(5000);
}


while (true)
{
    Console.Clear();
    Console.WriteLine("Math the game!");
    Console.WriteLine();
    Console.WriteLine("Choose an option!");
    Console.WriteLine("1. Play");
    Console.WriteLine("2. History");
    Console.WriteLine("3. Exit");

    int option = Convert.ToInt32(Console.ReadLine());

    if (option == 1)
    {
        game();
    }
    else if (option == 2)
    {
        displayGameHistory();
    }
    else if(option == 3)
    {
        System.Environment.Exit(0);
    }
}