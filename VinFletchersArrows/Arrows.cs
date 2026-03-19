public class Arrow
{
    public string _arrowHead;
    public string _fletching;
    public float _shaft;

    public Arrow(string arrowHead, string fletching, float shaft)
    {
        _arrowHead = arrowHead;
        _fletching = fletching;
        _shaft = shaft;
    }

    /// <summary>
    /// We calculate the total cost for the arrow depending on the materials the user choses
    /// </summary>
    /// <returns></returns>
    public float GetCost()
    {
        float arrowHeadCost = 0f;
        float fletchingCost = 0f;


        while (arrowHeadCost <= 0f)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Choose a material for the arrowhead: ");
            _arrowHead = (Console.ReadLine() ?? string.Empty).ToLower().Trim();
            switch(_arrowHead)
            {
                case "steel":
                    arrowHeadCost = 10.0f;
                break;

                case "wood":
                    arrowHeadCost = 3.0f;
                break;

                case "obsidiant":
                    arrowHeadCost = 5.0f;
                break;

                default:
                    Console.WriteLine("You need to choose an available material for the arrowHead.");
                continue;
            }
        }

        while (fletchingCost <= 0f)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Choose a material for the fletching: ");
            _fletching = (Console.ReadLine() ?? string.Empty).ToLower().Trim();
            switch(_fletching)
            {
                case "plastic":
                    fletchingCost = 10.0f;
                break;

                case "turkey":
                    fletchingCost = 5.0f;
                break;

                case "goose":
                    fletchingCost = 3.0f;
                break;

                default:
                    Console.WriteLine("You need to choose an available material for the fletching.");
                continue;
            }
        }

        while(_shaft < 60.0f || _shaft > 100.0f)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("How many centimeters do you want the shaft to be: ");
            try
            {
                _shaft = Convert.ToSingle(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Please put a valid number." + ex.Message);
                continue;
            }

            if (_shaft < 60.0f || _shaft > 100.0f)
            {
                Console.WriteLine("Sorry the valid centimeters for the shaft length are 60cm to 100cm.");
                continue;
            }
        }
        
        _shaft *= 0.05f;

        float totalCost = arrowHeadCost + fletchingCost + _shaft;
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"The total cost for your arrow is {totalCost} Gold");
        return totalCost;
    }
}