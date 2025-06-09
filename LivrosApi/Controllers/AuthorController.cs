using LivrosApi.Dto.Author;
using LivrosApi.Models;
using LivrosApi.Services.Author;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LivrosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {

        private readonly IAuthorInterface _authorInterface;
        public AuthorController(IAuthorInterface authorInterface)
        {
            _authorInterface = authorInterface;
        }


        [HttpGet("ListAuthors")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> ListAuthors()
        {
            var authors = await _authorInterface.ListAuthors();
            return Ok(authors);
        }

        [HttpGet("GetAuthorById/{authorId}")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> GetAuthorById(int authorId)
        {
            var author = await _authorInterface.GetAuthorById(authorId);
            return Ok(author);
        }

        [HttpGet("GetAuthorByBookId/{bookId}")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> GetAuthorByBookId(int bookId)
        {
            var author = await _authorInterface.GetAuthorByBookId(bookId);
            return Ok(author);
        }

        [HttpPost("CreateAuthor")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> CreateAuthor(AuthorCreateDto authorCreateDto)
        {
            var authors = await _authorInterface.CreateAuthor(authorCreateDto);
            return Ok(authors);
        }

        [HttpPut("EditAuthor")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> EditAuthor(AuthorEditDto authorEditDto)
        {
            var authors = await _authorInterface.EditAuthor(authorEditDto);
            return Ok(authors);
        }

        [HttpDelete("DeleteAuthor/{authorId}")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> DeleteAuthor(int authorId)
        {
            var authors = await _authorInterface.DeleteAuthor(authorId);
            return Ok(authors);
        }
    }
}
