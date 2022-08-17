using AutoMapper;
using Bookstore.Application.Books;
using Bookstore.Domain.Books;
using Bookstore.Infrastructure.Repositories.Books;
using FluentAssertions;
using Moq;

namespace Bookstore.Tests.Application.Books
{
    [TestClass]
    public class BookApplicationServiceTest
    {
        private readonly BookApplicationService _bookApplicationService;
        private readonly Mock<IBookRepository> _bookRepository;
        private readonly IMapper _mapper;

        public BookApplicationServiceTest()
        {
            _bookRepository = new Mock<IBookRepository>();
            
            var books = GetBooks();
            var book = GetBook("Clean Code", 29.9m);

            _bookRepository.Setup(x => x.GetAll()).Returns(books);
            _bookRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(book);
            _bookRepository.Setup(x => x.Add(It.IsAny<Book>())).Returns(book);
            _bookRepository.Setup(x => x.Update(It.IsAny<Book>())).Returns(book);

            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(Book).Assembly, typeof(BookDto).Assembly));
            _mapper = new Mapper(configuration);;

            _bookApplicationService = new BookApplicationService(_bookRepository.Object, _mapper);
        }

        [TestMethod, TestCategory("Unit")]
        public void Get_ServiceBookByIdReturnsBookFound()
        {
            var expected = new Mock<Book>();
            expected.SetupGet(x => x.Name).Returns("Clean Code");
            expected.SetupGet(x => x.Price).Returns(29.9m);

            var actual = _bookApplicationService.Get(It.IsAny<Guid>()).Result;
            actual.Should().BeEquivalentTo(expected.Object, 
                opt => opt.Excluding(x => x.Id));
        }

        [TestMethod, TestCategory("Unit")]
        public void Get_ServiceBookByIdReturnsBookNotFound()
        {
            var result = Task.FromResult((Book)null);
            _bookRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(result);

            var actual = _bookApplicationService.Get(It.IsAny<Guid>()).Result;
            actual.Should().BeNull();
        }

        [TestMethod, TestCategory("Unit")]
        public void Get_ServiceAllBooksRegistered()
        {
            var book1 = new Mock<Book>();
            book1.SetupGet(x => x.Name).Returns("Clean Code");
            book1.SetupGet(x => x.Price).Returns(29.9m);

            var book2 = new Mock<Book>();
            book2.SetupGet(x => x.Name).Returns("Domain Driven Design");
            book2.SetupGet(x => x.Price).Returns(32.9m);

            var expected = new List<Book>() { book1.Object, book2.Object };
            var actual = _bookApplicationService.GetAll().Result;
            
            actual.Count().Should().Be(expected.Count);
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod, TestCategory("Unit")]
        public void Add_ServiceWithCorrectInformationBookReturnsCreatedBook()
        {
            var expected = new Mock<Book>();
            expected.SetupGet(x => x.Name).Returns("Clean Code");
            expected.SetupGet(x => x.Price).Returns(29.9m);

            var book = GetBook("Clean Code", 29.9m).Result;
            var bookDto = _mapper.Map<BookDto>(book);

            var actual = _bookApplicationService.Add(It.IsAny<BookDto>()).Result;
            actual.Should().BeEquivalentTo(expected.Object,
                opt => opt.Excluding(x => x.Id));
        }

        [TestMethod, TestCategory("Unit")]
        [ExpectedException(typeof(AggregateException), "The Book must have name to be registered.")]
        public void Add_ServiceWithIncorrectInformationBookReturnsCreatedBook()
        {
            var book = GetBook(string.Empty, 0m);
            _bookRepository.Setup(x => x.Add(It.IsAny<Book>())).Returns(book);

            var actual = _bookApplicationService.Add(It.IsAny<BookDto>()).Result;
        }

        [TestMethod, TestCategory("Unit")]
        public void Update_ServiceWithCorrectInformationBookReturnsCreatedBook()
        {
            var expected = new Mock<Book>();
            expected.SetupGet(x => x.Name).Returns("Clean Code");
            expected.SetupGet(x => x.Price).Returns(29.9m);

            var book = GetBook("Clean Code", 29.9m).Result;
            var bookDto = _mapper.Map<BookDto>(book);
            
            var actual = _bookApplicationService.Update(bookDto).Result;
            actual.Should().BeEquivalentTo(expected.Object,
                opt => opt.Excluding(x => x.Id));
        }

        [TestMethod, TestCategory("Unit")]
        [ExpectedException(typeof(AggregateException), "The Book must have name to be registered.")]
        public void Update_ServiceWithIncorrectInformationBookReturnsCreatedBook()
        {
            var book = GetBook(string.Empty, 0m);
            _bookRepository.Setup(x => x.Update(It.IsAny<Book>())).Returns(book);

            var actual = _bookApplicationService.Update(It.IsAny<BookDto>()).Result;
        }

        private static async Task<IEnumerable<Book>> GetBooks()
        {
            var books = new List<Book>()
            {
                Book.Create("Clean Code", 29.9m),
                Book.Create("Domain Driven Design", 32.9m),
            };

            return await Task.FromResult(books);
        }

        private static async Task<Book> GetBook(string name, decimal price)
        {
            var book = Book.Create(name, price);
            return await Task.FromResult(book);
        }
    }
}
