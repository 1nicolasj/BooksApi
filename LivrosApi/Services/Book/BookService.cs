using LivrosApi.Data;
using LivrosApi.Dto.Author;
using LivrosApi.Dto.Book;
using LivrosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LivrosApi.Services.Book
{
    public class BookService : IBookInterface
    {
        private readonly AppDbContext _context;
        public BookService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<List<BookModel>>> CreateBook(BookCreateDto bookCreateDto)
        {
            var response = new ResponseModel<List<BookModel>>();
            try
            {
                
                var author = await _context.Authors
                    .FirstOrDefaultAsync(authorDatabase => authorDatabase.Id == bookCreateDto.Author.Id);

                if (author == null)
                {
                    response.Message = "Nenhum autor foi localizado.";
                    return response;
                }

                var book = new BookModel()
                {
                    Title = bookCreateDto.Title,
                    Author = author // associando o autor ao livro
                };

                _context.Books.Add(book);
                await _context.SaveChangesAsync();

                response.Data = await _context.Books
                    .Include(b => b.Author) // incluindo o autor na resposta
                    .ToListAsync();
                response.Message = "Livro criado com sucesso!";
                response.Status = true;
                

                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }


        public async Task<ResponseModel<List<BookModel>>> DeleteBook(int bookId)
        {
            var response = new ResponseModel<List<BookModel>>();

            try
            {

                var book = await _context.Books
                    .FirstOrDefaultAsync(bookDatabase => bookDatabase.Id == bookId);

                if (book == null)
                {
                    response.Message = "Nenhum registro foi localizado.";
                    return response;
                }

                _context.Books.Remove(book); 
                await _context.SaveChangesAsync(); 

                response.Data = await _context.Books.ToListAsync(); 
                response.Message = "Livro removido com sucesso!";
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<BookModel>>> EditBook(BookEditDto bookEditDto)
        {
            var response = new ResponseModel<List<BookModel>>();

            try
            {
                var book = await _context.Books
                    .Include(a => a.Author) // incluindo o autor na consulta
                    .FirstOrDefaultAsync(bookDatabase => bookDatabase.Id == bookEditDto.Id);

                var author = await _context.Authors
                    .FirstOrDefaultAsync(authorDatabase => authorDatabase.Id == bookEditDto.Author.Id);

                if (book == null)
                {
                    response.Message = "Nenhum livro foi localizado.";
                    return response;
                }

                if (author == null)
                {
                    response.Message = "Nenhum autor foi localizado.";
                    return response;
                }

                book.Title = bookEditDto.Title;
                book.Author = author; // associando o autor ao livro


                _context.Update(book);
                await _context.SaveChangesAsync();

                response.Data = await _context.Books.ToListAsync();
                response.Message = "Livro atualizado com sucesso!";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<BookModel>>> GetBookByAuthorId(int authorId)
        {
            var response = new ResponseModel<List<BookModel>>();
            try
            {
                var book = await _context.Books
                    .Include(a => a.Author) // include para a model do autor
                    .Where(bookDatabase => bookDatabase.Author.Id == authorId)
                    .ToListAsync();

                if (book == null)
                {
                    response.Message = "Nenhum registro foi localizado.";
                    return response;
                }

                response.Data = book; 
                response.Message = "Livros localizados com sucesso!";
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }            
        }

        public async Task<ResponseModel<BookModel>> GetBookById(int bookId)
        {
            var response = new ResponseModel<BookModel>();
            try
            {

                var book = await _context.Books
                    .Include(a => a.Author)
                    .FirstOrDefaultAsync(bookDatabase => bookDatabase.Id == bookId);
                if (book == null)
                {
                    response.Message = "Nenhum registro foi localizado.";
                    return response;
                }

                response.Data = book;
                response.Message = "Livro localizado com sucesso!";
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<BookModel>>> ListBooks()
        {
            var response = new ResponseModel<List<BookModel>>();
            try
            {
                var books = await _context.Books.Include(a => a.Author).ToListAsync(); 

                response.Data = books;
                response.Message = "Livros coletados com sucesso.";

                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
