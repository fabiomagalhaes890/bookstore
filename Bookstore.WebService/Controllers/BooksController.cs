using Bookstore.Application.Books;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookApplicationService _bookApplicationService;

        public BooksController(IBookApplicationService bookApplicationService)
        {
            _bookApplicationService = bookApplicationService;
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

        [HttpPut("{id}", Name = "PutBook")]
        public async Task<ActionResult<IEnumerable<BookDto>>> Get(Guid id, BookDto bookDto)
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
    }
}
