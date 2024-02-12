using SupermarketCheckoutLib;
using IDatabaseLib;
using Moq;
namespace SupermarkedCheckoutLib.Tests
{
    public class CheckoutControllerTestFixture : IDisposable
    {
        public CheckoutController checkoutControllerObj;
        public Mock<IDatabase> fakedb;
        public PricesTable pT; // Testable so bring in the test environment
        public CheckoutControllerTestFixture()
        {
            pT = new PricesTable();
            pT.priceDict = new()
            {
                { 'A' , Tuple.Create( 50, "3 for 130") },
                { 'B' , Tuple.Create( 30, "2 for 45") },
                { 'C', Tuple.Create(20, "") },
                { 'D', Tuple.Create(10, "") }
            };
        
            fakedb = new Mock<IDatabase>();
            fakedb.Setup(x => x.GetPricesTable()).Returns(() =>
            {
                return pT;
            });
            checkoutControllerObj = new(fakedb.Object);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
    public class CheckoutControllerTestSuite : IClassFixture<CheckoutControllerTestFixture>
    {
        public CheckoutControllerTestFixture _fixture = new CheckoutControllerTestFixture();
        public CheckoutControllerTestSuite(CheckoutControllerTestFixture fixture)
        {
            _fixture = fixture;
        }
        [Fact]
        public void TestInstanceCreated()
        {
            // Arrange Act & Assert
            Assert.NotNull(_fixture.checkoutControllerObj);
        }
        [Fact]
        public void GivenEmptyStringZeroExpected()
        {
            // Arrange
            double expectedResult = 0;

            string input = "";

            // Act
            double actualResult = _fixture.checkoutControllerObj.Checkout(input);

            // Assert

            Assert.Equal(actualResult, expectedResult);

        }
        [Fact]
        public void SingleItem()
        {
            double expectedResult = 50;
            string input = "A";

            double actualResult = _fixture.checkoutControllerObj.Checkout(input);

            Assert.Equal(actualResult, expectedResult);
        }
        [Fact]
        public void SameItemRepeats()
        {
            double expectedResult = 180;
            string input = "AAAA";

            double actualResult = _fixture.checkoutControllerObj.Checkout(input);

            Assert.Equal(actualResult, expectedResult);
        }
        [Fact]
        public void TwoDifferentItems()
        {
            double expectedResult = 80;
            string input = "AB";

            double actualResult = _fixture.checkoutControllerObj.Checkout(input);

            Assert.Equal(actualResult, expectedResult);
        }
        [Fact]
        public void VariousItemsWithOffers()
        {
            double expectedResult = 110;

            string input = "CDBA";

            double actualResult = _fixture.checkoutControllerObj.Checkout(input);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}