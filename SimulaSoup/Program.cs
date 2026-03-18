namespace SimulaSoup
{
    class Program
    {
        
        static (Type type, Ingridient main, Seasoning seasoning) soup;
        static string chooseType = "";
        static string chooseMain = "";
        static string chooseSeasoning = "";
        static void Main(string[] _)
        {
            Console.Title = "Simula's Soup";

            Console.WriteLine("Choose your desired soup for Simula to make it!");
            Console.WriteLine("Choose one from the following: Types, Main Ingredients and Seasoning");
            Console.WriteLine("      Menu\n---------------\n     Types\n---------------\n- Soup\n- Stew\n- Gumbo" +
            "\n---------------\nMain Ingrediens\n---------------\n- Mushrooms\n- Chicken\n- Carrots\n- Potatoes" +
            "\n---------------\n   Seasoning\n---------------\n- Spicy\n- Salty\n- Sweet");
            
            Console.WriteLine();
            soup = GetSoup();
            
            Console.WriteLine();
            PrepareSoup(soup);
        }

        /// <summary>
        /// The method returns the user's chosen values of each enum
        /// </summary>
        /// <returns></returns>
        static (Type type, Ingridient ingridient, Seasoning seasoning) GetSoup()
        {
            // We create some booleans to check if the player has chosen from each enumeration
            bool hasChosenType = false;
            bool hasChosenMain = false;
            bool hasChosenSeasoning = false;

            while (!hasChosenType)
            {
                Console.Write("Choose what type you want: ");
                try
                {
                    chooseType = (Console.ReadLine() ?? string.Empty).ToLower().Trim();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid input. Make sure you entered correctly the type that you wanted\n" + ex.Message);
                    continue;
                }

                switch (chooseType)
                {
                    case "soup":
                        soup.type = Type.Soup;
                    break;

                    case "stew":
                        soup.type = Type.Stew;
                    break;

                    case "gumbo":
                        soup.type = Type.Gumbo;
                    break;

                    default:
                        Console.WriteLine("Only choose types from the menu!");
                    continue;
                }
                hasChosenType = true;
            }

            while (!hasChosenMain)
            {
                Console.Write("Choose what main ingredient you want: ");
                try
                {
                    chooseMain = (Console.ReadLine() ?? string.Empty).ToLower().Trim();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid input. Make sure you entered correctly the main ingrdient that you wanted\n" + ex.Message);
                    continue;
                }

                switch(chooseMain)
                {
                    case "mushrooms":
                    case "mushroom":
                        soup.main = Ingridient.Mushrooms;
                    break;

                    case "chicken":
                    case "chickens":
                        soup.main = Ingridient.Chicken;
                    break;

                    case "carrot":
                    case "carrots":
                        soup.main = Ingridient.Carrots;
                    break;

                    case "potatoes":
                    case "potato":
                        soup.main = Ingridient.Potatoes;
                    break;

                    default:
                        Console.WriteLine("Only choose ingredients from the menu!");
                    continue;
                }
                hasChosenMain = true;
            }

            while (!hasChosenSeasoning)
            {
                Console.Write("Choose what seasoning you want: ");
                try
                {
                    chooseSeasoning = (Console.ReadLine() ?? string.Empty).ToLower().Trim();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid input. Make sure you entered correctly the seasoning that you wanted\n" + ex.Message);
                    continue;
                }

                switch (chooseSeasoning)
                {
                    case "spicy":
                        soup.seasoning = Seasoning.Spicy;
                    break;

                    case "salty":
                        soup.seasoning = Seasoning.Salty;
                    break;

                    case "sweet":
                        soup.seasoning = Seasoning.Sweet;
                    break;

                    default:
                        Console.WriteLine("Only choose seasoning from menu!");
                    break;
                }
                hasChosenSeasoning = true;
            }
            
            return (soup.type, soup.main, soup.seasoning);
        }

        /// <summary>
        /// Prints the whole message from the tuple variable
        /// </summary>
        /// <param name="soup"></param>
        static void PrepareSoup((Type type, Ingridient ingridient, Seasoning seasoning) soup)
        {
            Console.WriteLine($"{soup.seasoning} {soup.ingridient} {soup.type}");           
        }
    }
}