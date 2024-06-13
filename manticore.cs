int manticoreLocation = AskForNumberInRange();
Console.Clear();

Console.WriteLine("""
    Player 2, it is your turn.
    ----------------------------------------------
    """);

int cityHealth = 15;
int manticoreHealth = 15;
int numberGuess;
int round = 1;
int damage = CannonDamage(round);

while (cityHealth > 0 || manticoreHealth > 0)
{
    damage = CannonDamage(round);
    cityHealth = cityHealth - 1;

    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"""
        STATUS: Round: {round} City: {cityHealth}/15 Manticore: {manticoreHealth}/15
        The Cannon is expected to hit {damage} damage this round.
        Enter desired cannon range: 
        """);
    
    numberGuess = Convert.ToInt32(Console.ReadLine());
    if (numberGuess == manticoreLocation)
    {
        manticoreHealth = manticoreHealth -= damage;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("That round was a direct hit!");
    }
    else if (numberGuess > manticoreLocation)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("That round you shot over the Manticore, reel it back!");
    }
    else 
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("That round you were too short, try going higher!");
    }
    if (cityHealth <= 0)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("The city is lost.");break;
    }
    if (manticoreHealth <= 0)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("We've taken down the Manticore! Huzzah!");break;
    }
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("----------------------------------------------");
    round++;
}

int CannonDamage(int round) 
{
    if (round % 3 == 0 & round % 5 != 0)
        return damage = 3;
    else if (round % 3 == 0 & round % 5 == 0)
        return damage = 10;
    else if (round % 3 != 0 & round % 5 == 0)
        return damage = 5;
    else return damage = 1;
}
int AskForNumberInRange()
{
    Console.WriteLine("Player 1 choose the Manticore location: ");
    
    string numberText = Console.ReadLine();
    int number = Convert.ToInt32(numberText);
    while (number <= 0 || number >= 101)
    {
        Console.Write("Please enter a number between 1 and 100: ");
        number = Convert.ToInt32(Console.ReadLine());
    }
    return number;
}
