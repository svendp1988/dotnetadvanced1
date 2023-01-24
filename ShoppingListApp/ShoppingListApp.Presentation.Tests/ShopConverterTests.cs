using ShoppingListApp.Domain;
using ShoppingListApp.Presentation.Converters;

namespace ShoppingListApp.Presentation.Tests
{
    public class ShopConverterTests
    {
        ShopConverter _converter;

        [SetUp]
        public void Setup()
        {
            _converter = new ShopConverter();
        }

        [Test]
        public void Convert_ShopIsNull_ShouldReturnQuestionMarks()
        {
            Shop shop = new Shop();
            var result = _converter.Convert(shop, null, null, null);
            Assert.That(result.Equals("???"));
        }

        [Test]
        public void Convert_ShopIsNotNull_ShouldReturnNameOfShop()
        {
            Shop shop = new Shop();
            shop.Name = "Delhaize";
            var result = _converter.Convert(shop, null, null, null);
            Assert.That(result.Equals(shop.Name));
        }

    }
}