using MongoBookStore;
using MongoBookStore.Interfaces;

IUI io = new TextIO(); // Presentation
DAO dao;

BookStoreDb();

void BookStoreDb()
{
    dao = new BookStoreCRUD("secretuser", "secretpassword"); // Data access

    var bookStoreController = new BookStoreController(io, dao); // Business

    bookStoreController.Start();
}

