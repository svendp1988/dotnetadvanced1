namespace Exercise1.FizzBuzz.AppLogic.Tests
{
    public class FizzBuzzServiceTests
    {
        private FizzBuzzService sut;
        private readonly int defaultInteger = 5;

        [SetUp]
        public void BeforeEach()
        {
            sut = new FizzBuzzService();
        }

        [TearDown]
        public void AfterEach()
        {
            sut = null;
        }
        
        [Test]
        [TestCase(2, 3, 1, "1")]
        [TestCase(4, 5, 4, "1 2 3 Fizz")]
        [TestCase(5, 4, 4, "1 2 3 Buzz")]
        [TestCase(2, 3, 15, "1 Fizz Buzz Fizz 5 FizzBuzz 7 Fizz Buzz Fizz 11 FizzBuzz 13 Fizz Buzz")]
        [TestCase(2, 2, 4, "1 FizzBuzz 3 FizzBuzz")]
        public void ReturnsCorrectFizzBuzzTextWhenParametersAreValid(int fizzFactor, int buzzFactor, int lastNumber, string expected)
        {
            Assert.That(sut.GenerateFizzBuzzText(fizzFactor, buzzFactor, lastNumber), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(1)]
        [TestCase(11)]
        public void ThrowsValidationExceptionWhenFizzFactorIsNotInRange(int fizzFactor)
        {
            Assert.That(() => sut.GenerateFizzBuzzText(fizzFactor, defaultInteger, defaultInteger),
                Throws.TypeOf<FizzBuzzValidationException>());
        }

        [Test]
        [TestCase(1)]
        [TestCase(11)]
        public void ThrowsValidationExceptionWhenBuzzFactorIsNotInRange(int buzzFactor)
        {
            Assert.That(() => sut.GenerateFizzBuzzText(defaultInteger, buzzFactor, defaultInteger),
                Throws.TypeOf<FizzBuzzValidationException>());
        }

        [Test]
        [TestCase(0)]
        [TestCase(251)]
        public void ThrowsValidationExceptionWhenLastNumberIsNotInRange(int lastNumber)
        {
            Assert.That(() => sut.GenerateFizzBuzzText(defaultInteger, defaultInteger, lastNumber),
                Throws.TypeOf<FizzBuzzValidationException>());
        }
    }
}