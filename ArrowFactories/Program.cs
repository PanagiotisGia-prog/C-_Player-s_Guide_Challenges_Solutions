namespace ArrowFactories
{
    internal class Program
    {
        public static void Main(string[] _)
        {
            int cost = 0;
            
            // We store the values of enumarations in var variables
            var arrowHeads = Enum.GetValues(typeof(ArrowHead));
            var fletchings = Enum.GetValues(typeof(Fletching));
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Vin Fletcher's Arrow Pricelist");
            Console.WriteLine("--------------------");
            Console.WriteLine("Available Arrowheads:");
            
            /*
            * We iterate the enums of Arrowhead and fletching to showcase them in the terminal
            */
            foreach(var arrow in arrowHeads)
            {
                if (arrow.Equals(ArrowHead.Steel))
                    cost = 10;
                else if (arrow.Equals(ArrowHead.Wood))
                    cost = 3;
                else
                    cost = 5;
                Console.WriteLine($"-> {arrow}: {cost} Gold");
            }
            
            Console.WriteLine("--------------------");
            Console.WriteLine("Available Fletchings:");
            
            foreach(var fletch in fletchings)
            {
                if (fletch.Equals(Fletching.Plastic))
                    cost = 10;
                else if (fletch.Equals(Fletching.Turkey))
                    cost = 5;
                else
                    cost = 3;
                Console.WriteLine($"-> {fletch}: {cost} Gold");
            }
           
            Console.WriteLine("--------------------");
            Console.WriteLine("Shaft: 0.05 Gold per centimeter");
            Console.WriteLine("--------------------");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("--------------------");
            Console.WriteLine("Pre-Defined Arrows");
            Console.WriteLine("--------------------");
            Console.WriteLine("Elite Arrow: 24.75 Gold");
            Console.WriteLine("Begginer Arrow: 9.75 Gold");
            Console.WriteLine("Marksman Arrow: 16.25 Gold");
            Console.WriteLine("--------------------");
            Console.WriteLine();

            string arrowHead = "";
            string fletching = "";
            float shaftLength = 0f;


            // We initialise the Arrow class
            Console.ForegroundColor = ConsoleColor.Gray;
            Arrow myArrow = new Arrow(arrowHead: arrowHead, fletching: fletching, shaft: shaftLength);
            
            Console.WriteLine("You want a custom or a pre-defined arrow? (Enter '1' for Custom or '2' for pre-define)");
            bool hasOrdered = false;

            while (!hasOrdered)
            {
                int chooseArrow = Convert.ToInt32(Console.ReadLine());
                
                switch(chooseArrow)
                {
                    case 1:
                        myArrow.GetCost();
                    break;

                    case 2:
                        Console.WriteLine("Enter the arrow you want: Elite, Begginer or Marksman arrow?");
                        bool hasChosenArrow = false;

                        while(!hasChosenArrow)
                        {
                            string choosePreDefinedArrow = (Console.ReadLine() ?? string.Empty).ToLower().Trim();

                            switch(choosePreDefinedArrow)
                            {
                                case "elite":
                                    Arrow.GetEliteArrow();
                                break;

                                case "begginer":
                                    Arrow.GetBegginerArrow();
                                break;

                                case "marksman":
                                    Arrow.GetMarksmanArrow();
                                break;

                                default:
                                    Console.WriteLine("Please choose only from the available collection of arrows!");
                                continue;
                            }
                            hasChosenArrow = true;
                        }
                    break;

                    default:
                        Console.WriteLine("Please choose if you want custom or pre-defined arrow!");
                    continue;
                }
                hasOrdered = true;
            }
        }
    }
}