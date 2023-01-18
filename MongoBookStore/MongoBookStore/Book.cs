using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoBookStore
{
    public class Book
    {
        [BsonId]
        public ObjectId Id { get; set; } // Id
        [BsonElement("title")]
        public string Title { get; set; } // Title
        [BsonElement("author")]
        public string Author { get; set; } // Author
        [BsonElement("pages")]
        public int Pages { get; set; } // Pages
        [BsonElement("price")]
        public decimal Price { get; set; } // Price

        public Book(string title, string author, int pages, decimal price)
        {
            Title = title;
            Author = author;
            Pages = pages;
            Price = price;
        }
    }
}
