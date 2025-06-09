using LivrosApi.Dto.Author;
using LivrosApi.Dto.Book;
using LivrosApi.Models;

namespace LivrosApi.Services.Book
{
    public interface IBookInterface
    {
        Task<ResponseModel<List<BookModel>>> ListBooks();
        Task<ResponseModel<BookModel>> GetBookById(int bookId);
        Task<ResponseModel<List<BookModel>>> GetBookByAuthorId(int authorId);
        Task<ResponseModel<List<BookModel>>> CreateBook(BookCreateDto bookCreateDto);
        Task<ResponseModel<List<BookModel>>> EditBook(BookEditDto authorEditDto);
        Task<ResponseModel<List<BookModel>>> DeleteBook(int authorId);
    }
}
