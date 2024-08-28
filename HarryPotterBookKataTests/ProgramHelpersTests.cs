namespace HarryPotterBookKataTests
{
    using HarryPotterBookKata;

    public class ProgramHelpersTests
    {
        [TestCase("2", 2)]
        [TestCase("-1", 0)]
        [TestCase("abc", 0)]
        [TestCase("!",0)]
        public void validateInputTest(string input, int expected)
        {
            var progHelper = new ProgramHelpers();

            var actual = progHelper.validateInput(input);
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
