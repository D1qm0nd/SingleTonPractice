using System.Reflection;

namespace PublicationsLib
{
    [Serializable]
    public class Publication
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }

        public Publication(string? title, string? description, string? author)
        {
            Title = title;
            Description = description;
            Author = author;
        }
        public Publication() { }

        public void Show()
        {
            Console.WriteLine($"\nTitle: {Title}\nDescription: {Description}\nAuthor: {Author}\n");
        }
    }
}