using LivrosApi.Dto.Relationship;
using LivrosApi.Models;

namespace LivrosApi.Dto.Book
{
    public class BookEditDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public AuthorRelationshipDto Author { get; set; }
    }
}
