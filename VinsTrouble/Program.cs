namespace VinsTrouble
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

            string arrowHead = "";
            string fletching = "";
            float shaftLength = 0f;


            // We initialise the Arrow class
            Arrow myArrow = new Arrow(arrowHead: arrowHead, fletching: fletching, shaft: shaftLength);
            myArrow.GetCost();  
            var readArrowhead = myArrow.GetArrowHead();
            var readFlecthing = myArrow.GetFletching();
            var readShaft = myArrow.GetShaft();      
            Console.WriteLine($"Your arrow has: {readArrowhead} arrowhead, {readFlecthing} fletching and it's shaft is {readShaft} cm");
        }
    }
}