using Bookstore.Domain.Books;
using FluentAssertions;
using Moq;
using Xunit;

namespace BookstoreWeb.Tests.Domain.Books
{
    public class BookTests
    {
        [Fact]
        public void Create_WithCorrectInformations_ReturnsConstructedBook()
        {
            //Arrange
            var expected = new Mock<Book>();

            expected.SetupGet(x => x.Name).Returns("Clean Code");
            expected.SetupGet(x => x.Price).Returns(29);

            //Act
            var actual = Book.Create("Clean Code", 29);

            //Assert
            actual.Should().BeEquivalentTo(expected.Object,
                opt => opt.Excluding(x => x.Id));
        }

        [Fact]
        public void Create_WithoutName_ReturnsArgumentNullException()
        {
            //Act
            Action action = () => Book.Create(string.Empty, 29);

            //Assert
            action.Should()
                .Throw<ArgumentException>()
                .WithMessage("The Book must have name to be registered.");
        }

        [Fact]
        public void Create_WithPriceEqual0_ReturnsArgumentException()
        {
            //Act
            Action action = () => Book.Create("Clean Code", 0);

            //Assert
            action.Should()
                .Throw<ArgumentException>()
                .WithMessage("The Book price must be greather than 0.");
        }
    }
}
