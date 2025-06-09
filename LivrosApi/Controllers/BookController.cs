using LivrosApi.Dto.Author;
using LivrosApi.Dto.Book;
using LivrosApi.Models;
using LivrosApi.Services.Author;
using LivrosApi.Services.Book;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LivrosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookInterface _bookInterface;
        public BookController(IBookInterface bookInterface)
        {
            _bookInterface = bookInterface;
        }


        [HttpGet("ListBooks")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> ListBooks()
        {
            var books = await _bookInterface.ListBooks();
            return Ok(books);
        }

        [HttpGet("GetBookById/{bookId}")]
        public async Task<ActionResult<ResponseModel<BookModel>>> GetBookById(int bookId)
        {
            var book = await _bookInterface.GetBookById(bookId);
            return Ok(book);
        }

        [HttpGet("GetBookByAuthorId/{authorId}")]
        public async Task<ActionResult<ResponseModel<BookModel>>> GetBookByAuthorId(int authorId)
        {
            var book = await _bookInterface.GetBookByAuthorId(authorId);
            return Ok(book);
        }

        [HttpPost("CreateBook")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> CreateBook(BookCreateDto bookCreateDto)
        {
            var books = await _bookInterface.CreateBook(bookCreateDto);
            return Ok(books);
        }

        [HttpPut("EditBook")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> EditBook(BookEditDto bookEditDto)
        {
            var books = await _bookInterface.EditBook(bookEditDto);
            return Ok(books);
        }

        [HttpDelete("DeleteBook/{bookId}")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> DeleteBook(int bookId)
        {
            var books = await _bookInterface.DeleteBook(bookId);
            return Ok(books);
        }
    }
}
