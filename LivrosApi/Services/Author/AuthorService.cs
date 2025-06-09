using System.Net;
using LivrosApi.Data;
using LivrosApi.Dto.Author;
using LivrosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LivrosApi.Services.Author
{
    public class AuthorService : IAuthorInterface
    {
        private readonly AppDbContext _context;
        public AuthorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<AuthorModel>>> CreateAuthor(AuthorCreateDto authorCreateDto)
        {
            var response = new ResponseModel<List<AuthorModel>>();
            try
            {
                var author = new AuthorModel()
                {
                    Name = authorCreateDto.Name,
                    LastName = authorCreateDto.LastName
                };

                _context.Add(author); // adicionando o autor no contexto do banco de dados
                await _context.SaveChangesAsync(); // salvando as alterações no banco de dados
   
                response.Data = await _context.Authors.ToListAsync();
                response.Message = "Autor criado com sucesso!";
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AuthorModel>>> DeleteAuthor(int authorId)
        {
            var response = new ResponseModel<List<AuthorModel>>();

            try
            {

                var author = await _context.Authors
                    .FirstOrDefaultAsync(authorDatabase => authorDatabase.Id == authorId);

                if (author == null)
                {
                    response.Message = "Nenhum registro foi localizado.";
                    return response;
                }

                _context.Authors.Remove(author); // removendo o autor do contexto do banco de dados
                await _context.SaveChangesAsync(); // salvando as alterações no banco de dados

                response.Data = await _context.Authors.ToListAsync(); // retornando a lista de autores atualizada
                response.Message = "Autor removido com sucesso!";
                return response;

            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }

        }

        public async Task<ResponseModel<List<AuthorModel>>> EditAuthor(AuthorEditDto authorEditDto)
        {
            var response = new ResponseModel<List<AuthorModel>>();

            try
            {
                var author = await _context.Authors
                    .FirstOrDefaultAsync(authorDatabase => authorDatabase.Id == authorEditDto.Id);

                if (author == null)
                {
                    response.Message = "Nenhum registro foi localizado.";
                    return response;
                }

                author.Name = authorEditDto.Name;
                author.LastName = authorEditDto.LastName; // atualizando os dados do autor, com os dados do DTO que foram preeenchidos pelo usuario

                _context.Update(author);
                await _context.SaveChangesAsync();

                response.Data = await _context.Authors.ToListAsync();
                response.Message = "Autor atualizado com sucesso!";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<AuthorModel>> GetAuthorByBookId(int bookId)
        {
            var response = new ResponseModel<AuthorModel>();
            try
            {
                var book = await _context.Books
                    .Include(a => a.Author) // include para a model do autor
                    .FirstOrDefaultAsync(bookDatabase => bookDatabase.Id == bookId ); 

                if (book == null)
                {
                    response.Message = "Nenhum registro foi localizado.";
                    return response;
                }

                response.Data = book.Author; // retornando o autor do livro
                response.Message = "Autor localizado com sucesso!";
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<AuthorModel>> GetAuthorById(int authorId)
        {
            var response = new ResponseModel<AuthorModel>();
            try
            {

                var author = await _context.Authors.FirstOrDefaultAsync(authorDatabase => authorDatabase.Id == authorId);
                if(author == null)
                {
                    response.Message = "Nenhum registro foi localizado.";
                    return response;
                }

                response.Data = author;
                response.Message = "Autor localizado!";
                return response;

            }catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AuthorModel>>> ListAuthors()
        {
            var response = new ResponseModel<List<AuthorModel>>();
            try
            { 
                var authors = await _context.Authors.ToListAsync(); // entrando no banco com o _context na tabela Authors e transformando os dados em lista

                response.Data = authors;
                response.Message = "Autores coletados com sucesso.";

                return response;

            } catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
