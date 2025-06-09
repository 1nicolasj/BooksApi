using LivrosApi.Dto.Relationship;
using LivrosApi.Models;

namespace LivrosApi.Dto.Book
{
    public class BookCreateDto
    {
        public string Title { get; set; }
        public AuthorRelationshipDto Author { get; set; } 
    }
}
