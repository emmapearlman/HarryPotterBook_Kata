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
            Console.WriteLine("But... You can get discounts if you buy more than one title.");
            Console.WriteLine($"Sorry, buying mutiple copies of say, {Books.PhilosophersStone} means you pay full price for each one!");

            do
            {
                BuyBooks();
                Console.Write("Please enter 'q' to quit, or press any other key to continue. ");

            } while (!"q".Equals(Console.ReadLine(), StringComparison.CurrentCultureIgnoreCase));
        }

        public static void BuyBooks()
        {
            var progHelper = new ProgramHelpers();
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------");

            var basket = new BookCombinations();
            var priceCalculator = new BookPriceCalculator();
            List<int> list = new();

            foreach (Books bookVolume in Enum.GetValues(typeof(Books)))
            {
                Console.Write($"Please enter the number of copies of {bookVolume.ToString()} you want to buy: ");
                string? input = Console.ReadLine();
                int quantity = progHelper.validateInput(input);

                if (quantity > 0)
                {
                    for (int i = 0; i < quantity; i++)
                    {
                        list.Add((int)bookVolume);
                    }
                }
            }


            Console.WriteLine();
            Console.WriteLine($"The total price is €: {priceCalculator.Calculate(list)}");
        }
    }
}
