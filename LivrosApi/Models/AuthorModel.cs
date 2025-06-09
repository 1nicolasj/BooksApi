using System.Text.Json.Serialization;

namespace LivrosApi.Models
{
    public class AuthorModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        [JsonIgnore] // the list of books will not be serialized to JSON
        public ICollection<BookModel> Books { get; set; } = new List<BookModel>(); // Foreign Key to BookModel


    }
}
