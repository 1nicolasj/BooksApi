using LivrosApi.Dto.Author;
using LivrosApi.Models;

namespace LivrosApi.Services.Author
{
    public interface IAuthorInterface
    {
        Task<ResponseModel<List<AuthorModel>>> ListAuthors();
        Task<ResponseModel<AuthorModel>> GetAuthorById(int authorId);
        Task<ResponseModel<AuthorModel>> GetAuthorByBookId(int bookId);
        Task<ResponseModel<List<AuthorModel>>> CreateAuthor(AuthorCreateDto authorCreateDto);
        Task<ResponseModel<List<AuthorModel>>> EditAuthor(AuthorEditDto authorEditDto);
        Task<ResponseModel<List<AuthorModel>>> DeleteAuthor(int authorId);
    }
}
