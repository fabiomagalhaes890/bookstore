using Bookstore.Application.Books.CreateBooks;
using Bookstore.Application.Books.DeleteBooks;
using Bookstore.Application.Books.GetBooksDetails;
using Bookstore.Application.Books.UpdateBooks;
using Bookstore.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

namespace Bookstore.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateBook")]
        [ProducesResponseType(typeof(BookResponse), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create([FromBody] CreateBookCommand request)
        {            
            var book = await _mediator.Send(new CreateBookCommand(request.Name, request.Price));
            return Created(string.Empty, book);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<BookResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById([FromRoute]Guid bookId)
        {
            var books = await _mediator.Send(new GetBookDetailsQuery(bookId));
            return Ok(books);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<BookResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var books = await _mediator.Send(new GetBooksQuery());
            return Ok(books);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Update([FromRoute] Guid bookId, [FromBody] UpdateBookCommand request)
        {
            await _mediator.Send(new UpdateBookCommand(bookId, request.Name, request.Price));
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> RemoveBook([FromRoute] Guid bookId)
        {
            await _mediator.Send(new DeleteBookCommand(bookId));
            return NoContent();
        }
    }
}
