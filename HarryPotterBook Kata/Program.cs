namespace HarryPotterBookKata
{
    using HarryPotterBook_Kata.Calculator;
    using HarryPotterBook_Kata.Enums;

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, and welcome to a very special book shop!");
            Console.WriteLine("We only sell the first five Harry Potter books, yes really!");
            Console.WriteLine("Please visit your local Waterstones or independent book shop to buy the others.");   
            Console.WriteLine("And... You can get discounts if you buy more than one title.");
            Console.WriteLine($"Sorry, buying mutiple copies of say, {Books.PhilosophersStone} means you pay full price!");
            Console.WriteLine("Please visit your local Waterstones or independent book shop to buy the others.");
            Console.WriteLine("Press any key to start your purchase, or q to see the total");

            do
            {
                BuyBooks();
                Console.Write("Please enter 'q' key to quit, or any key to continue for another round : ");

            } while (!"q".Equals(Console.ReadLine(), StringComparison.CurrentCultureIgnoreCase));
        }

        public static void BuyBooks()
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------");

            var basket = new BookCombinations();
            var priceCalculator = new BookPriceCalculator();
            List<int> list = new();

            foreach (Books bookVolume in Enum.GetValues(typeof(Books)))
            {
                Console.Write($"Please enter the nmber of copies of {bookVolume.ToString()} you want to buy: ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int quantity))
                {
                    for (int i = 0; i < quantity; i++)
                    {
                        list.Add((int)bookVolume);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, we assume quantity 0");
                }
            }


            Console.WriteLine();
            Console.WriteLine($"The total price is €: {priceCalculator.Calculate(list)}");
        }
    }
}
