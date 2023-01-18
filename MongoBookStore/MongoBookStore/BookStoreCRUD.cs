using MongoBookStore.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoBookStore
{
    internal class BookStoreCRUD : DAO
    {
        IMongoDatabase _db;
        public BookStoreCRUD(string username, string password)
        {
            MongoClient dbClient = new MongoClient($"mongodb+srv://{username}:{password}@cluster0.j3zvna8.mongodb.net/?retryWrites=true&w=majority\r\n\r\n");
            _db = dbClient.GetDatabase("bookstore");
        }


        public bool Create<Book>(Book book) // Creates book in the database and returns bool if task fails/succeeds
        {
            try
            {
                var collection = _db.GetCollection<Book>("books");
                collection.InsertOne(book);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed. \nError message: " + ex.Message);
                return false;
            }
        }

        public Book ReadOne<Book>(ObjectId objectId) // Returns a selected book
        {
            var collection = _db.GetCollection<Book>("books");
            var filter = Builders<Book>.Filter.Eq("_id", objectId);
            var book = collection.Find(filter).FirstOrDefault();

            return book;
        }

        public bool Update<Book>(ObjectId objectId, int choice, string value) // Updates a property of a book in the collection
        {
            var collection = _db.GetCollection<Book>("books");
            var filter = Builders<Book>.Filter.Eq("_id", objectId);
            UpdateDefinition<Book> update;
            switch (choice)
            {
                case 1: // title
                    update = Builders<Book>.Update.Set("title", value);
                    break;
                case 2: // author
                    update = Builders<Book>.Update.Set("author", value);
                    break;
                case 3: // pages
                    update = Builders<Book>.Update.Set("pages", Convert.ToInt32(value));
                    break;
                case 4: // price
                    update = Builders<Book>.Update.Set("príce", Convert.ToDecimal(value));
                    break;
                default:
                    return false;
            }
            collection.UpdateOne(filter, update);
            return true;
        }

        public bool Delete(ObjectId objectId) // Deletes a book in the collection and returns bool if task fails/succeeds
        {
            try
            {
                var collection = _db.GetCollection<Book>("books");
                var filter = Builders<Book>.Filter.Eq("_id", objectId);
                collection.DeleteOne(filter);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed. \nError message: " + ex.Message);
                return false;
            }
        }



        public ObjectId GetID() // Returns ObjectId of selected book in order to find it in the collection
        {
            List<Book> books = GetAll<Book>();
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {books[i].Title} by {books[i].Author}"); // 1. Kejsaren av portugallien av Selma Lagerlöf
            }

            Console.Write("Select book> ");
            int id = Convert.ToInt32(Console.ReadLine());

            return books[id - 1].Id;
        }
        public List<Book> GetAll<Book>() // Returns a list of all the books in the collection
        {
            var collection = _db.GetCollection<Book>("books");
            List<Book> books = collection.Find(new BsonDocument()).ToList();

            return books;
        }

    }
}
