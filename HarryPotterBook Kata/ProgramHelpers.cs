namespace HarryPotterBookKata
{
    public class ProgramHelpers
    {

        public int validateInput(string? input)
        {
            var res = int.TryParse(input, out var quantity);

            if (res == false || quantity < 0)
            {
                Console.WriteLine("Input is not a number, or negative, I'll assume zero");
                return 0;
            }

            return quantity;
        }
    }
}