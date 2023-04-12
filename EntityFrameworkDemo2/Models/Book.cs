namespace EntityFrameworkDemo.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public required Decimal Price { get; set; }

        public string NormalFeedBack { get; set; }

        public string? FeedBackWithNullable { get; set; }

        public required string FeedBackRequiredKeyword { get; set; }

        public string FeedBackRequiredOldSyntax { get; set; } = null!;

        public string FeedBackWithIntialValueEmpty { get; set; }=String.Empty;

        public Author? Author { get; set; }
    }
}
