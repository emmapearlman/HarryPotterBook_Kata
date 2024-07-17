namespace HarryPotterBook_Kata.Calculator
{
    using System;
    using System.Collections.Generic;

    public class BookPriceCalculator
    {

        //consts to hold price & discounts
        private const decimal singlePrice = 8;
        private const decimal twoBooksDiscountFactor = 0.95m;
        private const decimal threeBooksDiscountFactor = 0.9m;
        private const decimal fourBooksDiscountFactor = 0.8m;
        private const decimal fiveBooksDiscountFactor = 0.75m;

        /// <summary>
        /// Calculate price of one or more books, with discounts
        /// </summary>
        /// <param name="books">list of books as integers</param>
        /// <returns>Price as a decimal</returns>
        public decimal Calculate(List<int> books)
        {
            //no books in the list
            if (!books.Any())
                return 0;

            List<BookCombinations> combos = CalculateCombos(books);

            var minPrice = decimal.MaxValue;

            foreach (BookCombinations combo in combos)
            {
                var comboPrice = CalculateComboPrice(combo);

                if (comboPrice < minPrice)
                {
                    minPrice = comboPrice;
                }
            }

            return minPrice;
        }

        /// <summary>
        /// Calculate the price of a given combination
        /// </summary>
        /// <param name="combo">list of books</param>
        /// <returns>price as a decimal</returns>
        private decimal CalculateComboPrice(BookCombinations combo)
        {
            decimal comboPrice = 0;

            foreach (List<int> books in combo.Groups)
            {
                var discountFactor = CalculateDiscountFactor(books);
                comboPrice += books.Count * singlePrice * discountFactor;
            }

            return comboPrice;
        }

        /// <summary>
        /// Returns a list of Book Combinations
        /// </summary>
        /// <param name="books">List of Books</param>
        /// <returns>List of Book Combinations</returns>
        private List<BookCombinations> CalculateCombos(List<int> books)
        {
            List<BookCombinations> combos = [];

            for (int i = 1; i <= books.Distinct().Count(); i++)
            {
                var combo = new BookCombinations();

                foreach (int book in books)
                {
                    IEnumerable<List<int>> groups = combo.GetGroupsThatDoNotContainBook(book);

                    List<int>? group = groups.FirstOrDefault(g => g.Count < i);
                    if (group != null)
                    {
                        group.Add(book);
                    }
                    else
                    {
                        combo.AddBook(book);
                    }
                }

                combos.Add(combo);
            }

            return combos;
        }

        /// <summary>
        /// Calculates discount factor
        /// </summary>
        /// <param name="books">List of bookd</param>
        /// <returns>factor as a decimal</returns>
        private decimal CalculateDiscountFactor(List<int> books)
        {
            switch (books.Distinct().Count())
            {
                case 2:
                    return twoBooksDiscountFactor;
                case 3:
                    return threeBooksDiscountFactor;
                case 4:
                    return fourBooksDiscountFactor;
                case 5:
                    return fiveBooksDiscountFactor;
                default:
                    return 1;
            }
        }

    }
}
