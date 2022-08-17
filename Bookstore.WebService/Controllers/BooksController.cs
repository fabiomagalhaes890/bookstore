using Bookstore.Application.Books;
using Bookstore.Application.Books.ChangeBooks;
using Bookstore.Application.Books.CreateBooks;
using Bookstore.Application.Books.GetBooksDetails;
using Bookstore.Application.Books.RemoveBooks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Bookstore.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookApplicationService _bookApplicationService;
        private readonly IMediator _mediator;

        public BooksController(IBookApplicationService bookApplicationService, IMediator mediator)
        {
            _bookApplicationService = bookApplicationService;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllBooks")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAll()
        {
            try
            {
                var result = await _bookApplicationService.GetAll();
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}", Name = "GetBook")]
        public async Task<ActionResult<IEnumerable<BookDto>>> Get(Guid id)
        {
            try
            {
                var result = await _bookApplicationService.Get(id);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost(Name = "PostBook")]
        public async Task<ActionResult<IEnumerable<BookDto>>> Post(BookDto bookDto)
        {
            try
            {
                var result = await _bookApplicationService.Add(bookDto);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut(Name = "PutBook")]
        public async Task<ActionResult<IEnumerable<BookDto>>> Get(BookDto bookDto)
        {
            try
            {
                var result = await _bookApplicationService.Update(bookDto);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}", Name = "DeleteBook")]
        public async Task<ActionResult<IEnumerable<BookDto>>> Delete(Guid id)
        {
            try
            {
                var result = await _bookApplicationService.Get(id);

                if (result == null)
                    return NotFound();

                _bookApplicationService.RemoveAsync(result);

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // using cqrs
        [HttpPost(Name = "CreateBook")]
        [ProducesResponseType(typeof(BookDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> RegisterBook([FromBody]RegisterBookRequest request)
        {            
            var book = await _mediator.Send(new RegisterBookCommand(request.Name, request.Price));
            return Created(string.Empty, book);
        }

        [HttpGet("{id}", Name = "GetBooks")]
        [ProducesResponseType(typeof(List<BookDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBooks([FromRoute]Guid bookId)
        {
            var books = await _mediator.Send(new GetBookDetailsQuery(bookId));
            return Ok(books);
        }

        [HttpPut("{id}", Name = "UpdateBook")]
        [ProducesResponseType(typeof(List<BookDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateBook([FromRoute] Guid bookId, [FromBody] RegisterBookRequest request)
        {
            await _mediator.Send(new ChangeBookCommand(bookId, request.Name, request.Price));
            return Ok();
        }

        [HttpDelete("{id}", Name = "RemoveBook")]
        [ProducesResponseType(typeof(List<BookDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RemoveBook([FromRoute] Guid bookId)
        {
            await _mediator.Send(new RemoveBookCommand(bookId));
            return Ok();
        }
    }
}
