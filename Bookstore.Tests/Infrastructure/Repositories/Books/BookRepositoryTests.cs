using Bookstore.Domain.Books;
using Bookstore.Infrastructure.Base;
using Bookstore.Infrastructure.Repositories;
using Bookstore.Infrastructure.Repositories.Books;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Tests.Infrastructure.Repositories.Books
{
    [TestClass]
    public class BookRepositoryTests
    {
        private readonly BookstoreContext _context;
        private readonly IRepositoryBase<Book> _bookRepository;
        private List<Book> _books;

        public BookRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<BookstoreContext>()
            .UseInMemoryDatabase(databaseName: "BookstoreDbTests")
            .Options;

            _context = new BookstoreContext(options);
            _bookRepository = new BookRepository(_context);
            _books = new List<Book>();
        }

        [TestInitialize]
        public void TestInit()
        {
            _books = new List<Book>()
            {
                Book.Create("Clean Code", 199),
                Book.Create("DDD", 199)
            };

            foreach (var book in _books) 
                _bookRepository.Add(book);
        }

        [TestCleanup]
        public void TestClean()
        {
            foreach (var book in _books)
                _bookRepository.RemoveAsync(book);
        }

        [TestMethod, TestCategory("Data")]
        public void Get_AllBooksRegistered()
        {
            var expected = _books;
            var actual = _bookRepository.GetAll().Result;
            actual.Count().Should().Be(expected.Count);
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod, TestCategory("Data")]
        public void Get_BookByIdReturnsCorrectBook()
        {
            var expected = _books.First();
            var actual = _bookRepository.Get(expected.Id).Result;
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod, TestCategory("Data")]
        public void Get_BookByIdWhenParamNotExistsReturnsNull()
        {
            var actual = _bookRepository.Get(Guid.NewGuid()).Result;
            actual.Should().BeNull();
        }

        [TestMethod, TestCategory("Data")]
        public void Remove_BookByIdReturnsNull()
        {
            var expected = _books.First();
            var actual = _bookRepository.Get(expected.Id).Result;
            actual.Should().BeEquivalentTo(expected);

            if (actual == null)
                return;

            _bookRepository.RemoveAsync(actual);
            actual = _bookRepository.Get(actual.Id).Result;

            actual.Should().BeNull();
        }

        [TestMethod, TestCategory("Data")]
        public void Update_BookReturnsUpdatedBook()
        {
            var expected = _books.First();
            var actual = _bookRepository.Get(expected.Id).Result;
            
            actual.Should().BeEquivalentTo(expected);

            expected.Price = 55;

            if (actual == null)
                return;
                        
            actual.Price = 55;

            _bookRepository.Update(actual);            
            actual = _bookRepository.Get(actual.Id).Result;

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
