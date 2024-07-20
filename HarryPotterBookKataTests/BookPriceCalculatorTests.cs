namespace HarryPotterBookKataTests
{
    using HarryPotterBook_Kata.Calculator;
    using HarryPotterBook_Kata.Enums;

    public class Tests
    {
        private BookPriceCalculator _bookPriceCalculator;

        [SetUp]
        public void Init()
        {
            _bookPriceCalculator = new BookPriceCalculator();
        }

        [Test]
        public void ZeroBooks_CostsZero()
        {
            List<int> books = CreateListofBooks();

            var cost = _bookPriceCalculator.Calculate(books);

            Assert.That(cost, Is.EqualTo(0));

        }

        [TestCase(Books.PhilosophersStone)]
        [TestCase(Books.ChamberOfSecrets)]
        [TestCase(Books.PrisonerofAzkaban)]
        [TestCase(Books.GobletofFire)]
        [TestCase(Books.OrderofthePhoenix)]
        public void OneCopyOfABook_CostsEight(int bookNumber)
        {
            List<int> books = CreateListofBooks(bookNumber);

            var cost = _bookPriceCalculator.Calculate(books);

            Assert.That(cost, Is.EqualTo(8));
        }

        [TestCase(Books.PhilosophersStone, Books.PhilosophersStone)]
        [TestCase(Books.ChamberOfSecrets, Books.ChamberOfSecrets)]
        public void TwoCoppiesOfSameBook_CostsSixteen(int firstBook, int secondBook)
        {
            List<int> books = CreateListofBooks(firstBook, secondBook);

            var cost = _bookPriceCalculator.Calculate(books);

            Assert.That(cost, Is.EqualTo(16));
        }

        [Test]
        public void TwoDifferentBooks_GetFivePercentDiscount()
        {
            List<int> books = CreateListofBooks((int)Books.PhilosophersStone, (int)Books.PrisonerofAzkaban);

            var cost = _bookPriceCalculator.Calculate(books);

            Assert.That(cost, Is.EqualTo(15.2m));
        }

        [Test]
        public void ThreeDifferentBooks_GetTenPercentDiscount()
        {
            List<int> books = CreateListofBooks(
                (int)Books.PhilosophersStone,
                (int)Books.GobletofFire,
                (int)Books.PrisonerofAzkaban
                );

            var cost = _bookPriceCalculator.Calculate(books);

            Assert.That(cost, Is.EqualTo(21.6m));
        }

        [Test]
        public void FourDifferentBooks_GetTwentyPercentDiscount()
        {
            List<int> books = CreateListofBooks(
                (int)Books.PhilosophersStone,
                (int)Books.ChamberOfSecrets,
                (int)Books.OrderofthePhoenix,
                (int)Books.GobletofFire
                );

            var cost = _bookPriceCalculator.Calculate(books);

            Assert.That(cost, Is.EqualTo(25.6m));
        }

        [Test]
        public void FiveDifferentBooks_GetTwentyFivePercentDiscount()
        {
            List<int> books = CreateListofBooks(
                (int)Books.PhilosophersStone,
                (int)Books.ChamberOfSecrets,
                (int)Books.PrisonerofAzkaban,
                (int)Books.GobletofFire,
                (int)Books.OrderofthePhoenix
                ); ;

            var cost = _bookPriceCalculator.Calculate(books);

            Assert.That(cost, Is.EqualTo(30));
        }

        [Test]
        public void ThreeBooksTwoDifferent_GetFivePercentDiscountOnTwoOfThem()
        {
            List<int> books = CreateListofBooks(
                (int)Books.PhilosophersStone,
                (int)Books.ChamberOfSecrets,
                (int)Books.PhilosophersStone
                );

            var cost = _bookPriceCalculator.Calculate(books);

            Assert.That(cost, Is.EqualTo(23.2m));
        }

        [Test]
        public void ManyBooks_GetsBestPrice()
        {
            List<int> books = CreateListofBooks(
                (int)Books.PhilosophersStone,
                (int)Books.PhilosophersStone,
                (int)Books.ChamberOfSecrets,
                (int)Books.ChamberOfSecrets,
                (int)Books.PrisonerofAzkaban,
                (int)Books.PrisonerofAzkaban,
                (int)Books.GobletofFire,
                (int)Books.OrderofthePhoenix
            );

            var cost = _bookPriceCalculator.Calculate(books);

            Assert.That(cost, Is.EqualTo(51.2m));
        }

        private List<int> CreateListofBooks(params int[] books)
        {
            List<int> booksList = [.. books];

            return booksList;
        }
    }
}