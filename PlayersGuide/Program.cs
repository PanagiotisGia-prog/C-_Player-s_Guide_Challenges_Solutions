using System.Runtime.ConstrainedExecution;

namespace PlayersGuide
{
    class Program
    {
        static Random choose = new Random();
        static int manticorePlacement;
        static void Main(string[] _)
        {
            Console.Title = "C# Player's Guide";
            bool gameRuns = true;

            int cityHealth = 15;
            int manticoreHealth = 10;
            int rounds = 0;

            BattleInit(round: rounds, cityMaxHealth: cityHealth, manticoreMaxHealth: manticoreHealth);

            while(gameRuns)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Do you want to play again (Enter Y/N): ");
                
                string replay = (Console.ReadLine() ?? string.Empty).ToLower().Trim();
                
                switch(replay)
                {
                    case "y":
                    case "yes":
                        Console.WriteLine("Restarting the game...");
                        Thread.Sleep(1000);
                        Console.Clear();
                        BattleInit(round: rounds, cityMaxHealth: cityHealth, manticoreMaxHealth: manticoreHealth);
                    continue;

                    case "n":
                    case "no":
                        Console.WriteLine("Thank you for playing!");
                    return;

                    default:
                        Console.WriteLine("Invalid invalid input please enter (Y/N)");
                    continue;
                }
                
            }

            Console.WriteLine("Press any key to close the game!");
            Console.ReadKey(true);
        }

        /// <summary>
        /// This method will initiate the game and keep it running in a loop until one of the lives reach 0. 
        /// </summary>
        /// <param name="round"></param>
        /// <param name="cityMaxHealth"></param>
        /// <param name="manticoreMaxHealth"></param>
        static void BattleInit(int round, int cityMaxHealth, int manticoreMaxHealth)
        {
            manticorePlacement = choose.Next(0, 101);
            //Console.WriteLine($"Manticore's ship is stationed: {manticorePlacement}"); //Debug

            int cityCurrentHealth = cityMaxHealth;
            int manticoreCurrentHealth = manticoreMaxHealth;
            int cannonDamage = 0;

            Console.WriteLine("The manticore is stationed somewhere near the city of Consolas\n" +
            "you need to destroy it quick otherwise the city will fall!");
            Console.WriteLine("----------------------------------------------------------------");

            // TODO: You need to add a while loop here for keeping the game running
            while (cityCurrentHealth != 0)
            {
                Console.WriteLine($"STATUS: Round: {++round} City: {cityCurrentHealth}/{cityMaxHealth} Manticore: {manticoreCurrentHealth}/{manticoreMaxHealth}");
                
                // We check which round is we're currently are and if it's a multiple with 3 or 5 we increase the damage by 3 and if it's both then by 10 
                if (round % 3 == 0 && round % 5 == 0)
                {
                    cannonDamage += 10;
                    Console.WriteLine($"The cannon is expected to deal {cannonDamage} damage this round.");   
                }
                else if (round % 3 == 0 || round % 5 == 0)
                {
                    cannonDamage += 3;
                    Console.WriteLine($"The cannon is expected to deal {cannonDamage} damage this round.");   
                }
                else
                {
                    cannonDamage += 1;
                    Console.WriteLine($"The cannon is expected to deal {cannonDamage} damage this round.");
                }

                // We ask for the user to choose a range between 0 - 100
                while(true)
                {
                    int userChoice;
                    Console.Write("Enter desired cannon range: ");
                    try
                    {
                        userChoice = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Invalid Orders! Please choose a range between 0-100\n" + ex.Message);
                        continue;
                    }

                    if (userChoice < 0 || userChoice > 100) // Of course if we wanted to add punishing mechanics we could allow the user to choose these ranges
                    {
                        Console.WriteLine("You know the ship is somewhere between 0 and 100 so it's better strategy to remain in these range");
                        continue;
                    }
                    else if (userChoice > manticorePlacement)
                    {
                        Console.WriteLine("That round was OVERSHOT of the target.");
                    }
                    else if (userChoice < manticorePlacement)
                    {
                        Console.WriteLine("That round was FELL SHORT of the target.");
                    }
                    else
                    {
                        Console.WriteLine("That round was a DIRECT HIT!");
                        manticoreCurrentHealth -= cannonDamage;
                    }
                    break;
                }

                if (manticoreCurrentHealth <= 0)
                {
                    break;
                }

                cityCurrentHealth -= 1;
                cannonDamage = 0;
                Console.WriteLine("----------------------------------------------------------------");
            }

            EndGame(cityHealth: cityCurrentHealth, manticoreHealth: manticoreCurrentHealth);
        }

        /// <summary>
        /// This functions checks whether the city's or ship's life reach 0 and cocludes the victor
        /// </summary>
        /// <param name="cityHealth"></param>
        /// <param name="manticoreHealth"></param>
        static void EndGame(int cityHealth, int manticoreHealth)
        {
            if (manticoreHealth <= 0)
            {
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
            }
            else if (cityHealth <= 0)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("The city has been oblitared! The Manticore has prevailed!");
            }
        }
    }
}
