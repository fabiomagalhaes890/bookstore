using Bookstore.Domain.Books;
using FluentAssertions;
using Moq;

namespace Bookstore.Tests.Domain.Books
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void Create_WithCorrectInformationsReturnsConstructedProduct()
        {
            var expected = new Mock<Book>();

            expected.SetupGet(x => x.Name).Returns("Clean Code");
            expected.SetupGet(x => x.Price).Returns(29);

            var actual = Book.Create("Clean Code", 29);

            actual.Should().BeEquivalentTo(expected.Object, 
                opt => opt.Excluding(x => x.Id));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "The Book must have name to be registered.")]
        public void Create_WithoutNameReturnsArgumentNullException()
        {
            var actual = Book.Create(string.Empty, 29);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The Book price must be greather than 0.")]
        public void Create_WithPriceEqual0ReturnsArgumentException()
        {
            var actual = Book.Create("Clean Code", 0);
        }
    }
}
