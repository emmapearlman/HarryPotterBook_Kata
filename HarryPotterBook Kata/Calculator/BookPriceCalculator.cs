namespace HarryPotterBook_Kata.Calculator
{
    using System;
    using System.Collections.Generic;

    public class BookPriceCalculator
    {

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

            var lowestPrice = decimal.MaxValue;

            foreach (BookCombinations combo in combos)
            {
                var comboPrice = CalculateComboPrice(combo);

                if (comboPrice < lowestPrice)
                {
                    lowestPrice = comboPrice;
                }
            }

            return lowestPrice;
        }

        /// <summary>
        /// Calculate the price of a given combination
        /// </summary>
        /// <param name="combo">list of books</param>
        /// <returns>price as a decimal</returns>
        private decimal CalculateComboPrice(BookCombinations combo)
        {
            var comboPrice = 0m;

            foreach (List<int> books in combo.Groups)
            {
                var discountFactor = CalculateDiscountFactor(books);
                comboPrice += books.Count * BookPriceCalculatorHelpers.singlePrice * discountFactor;
            }

            return comboPrice;
        }

        /// <summary>
        /// Calculates a list of Book Combinations
        /// </summary>
        /// <param name="books">List of Books</param>
        /// <returns>List of Book Combinations</returns>
        private List<BookCombinations> CalculateCombos(List<int> books)
        {
            List<BookCombinations> combos = [];

            for (int i = 1; i <= books.Distinct().Count(); i++)
            {
                var combo = new BookCombinations();

                foreach (int bookNumber in books)
                {
                    var groups = combo.GetGroupsThatDoNotContainGivenBook(bookNumber);

                    List<int>? group = groups.FirstOrDefault(g => g.Count < i);

                    if (group != null)
                    {
                        group.Add(bookNumber);
                    }
                    else
                    {
                        combo.AddBook(bookNumber);
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
                    return BookPriceCalculatorHelpers.twoBooksDiscountFactor;
                case 3:
                    return BookPriceCalculatorHelpers.threeBooksDiscountFactor;
                case 4:
                    return BookPriceCalculatorHelpers.fourBooksDiscountFactor;
                case 5:
                    return BookPriceCalculatorHelpers.fiveBooksDiscountFactor;
                default:
                    return 1;
            }
        }

    }
}
