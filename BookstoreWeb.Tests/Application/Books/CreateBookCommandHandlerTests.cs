using AutoFixture;
using Bookstore.Application.Books.CreateBooks;
using Bookstore.Domain.Books;
using Bookstore.Help.Configs;
using Bookstore.Infrastructure.Repositories.Books;
using FluentAssertions;
using Moq;

namespace BookstoreWeb.Tests.Application.Books
{
    public class CreateBookCommandHandlerTests
    {
        [Fact]
        public async void CreateBook_GivenIsValidBook_ReturnsCreatedBook()
        {
            var _mapper = ConfigurationMap.CreateMap();

            //Arrange
            var fixture = new Fixture();
            var createBookCommand = fixture.Create<CreateBookCommand>();
            var expected = _mapper.Map<Book>(createBookCommand);

            var _bookRepository = new Mock<IBookRepository>();
            _bookRepository.Setup(x => x.Add(It.IsAny<Book>())).Returns(Task.FromResult(expected));

            var createBookCommandHandler = new CreateBookCommandHandler(_bookRepository.Object);

            //Act
            var actual = await createBookCommandHandler.Handle(createBookCommand, CancellationToken.None);

            //Assert
            actual.Should().BeEquivalentTo(expected, opt => opt.Excluding(x => x.Id));
        }
    }
}
