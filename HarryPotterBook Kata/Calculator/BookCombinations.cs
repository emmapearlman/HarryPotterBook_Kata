namespace HarryPotterBook_Kata.Calculator
{
    using System.Collections.Generic;
    using System.Linq;

    internal class BookCombinations
    {
        private List<List<int>> _bookGroups;
        /// <summary>
        /// Creates list of books
        /// </summary>
        public BookCombinations() => _bookGroups = [];

        /// <summary>
        /// adds Book to list
        /// </summary>
        /// <param name="book">integer</param>
        public void AddBook(int book) => _bookGroups.Add([book]);

        /// <summary>
        /// adds multiple books to list
        /// </summary>
        /// <param name="books">array of integers</param>
        public void AddBooks(int[] books) => _bookGroups.Add(new List<int>(books));

        /// <summary>
        /// get groups that don't contain a given book
        /// </summary>
        /// <param name="book">integer</param>
        /// <returns>List of integers</returns>
        public IEnumerable<List<int>> GetGroupsThatDoNotContainGivenBook(int book) => _bookGroups.Where(bg => !bg.Contains(book));

        /// <summary>
        /// gets a collection of groups
        /// </summary>
        public IReadOnlyCollection<List<int>> Groups => _bookGroups.AsReadOnly();
    }
}
