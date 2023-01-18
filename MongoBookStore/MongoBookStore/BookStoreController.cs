using MongoBookStore.Interfaces;
using MongoDB.Bson;

namespace MongoBookStore
{
    internal class BookStoreController
    {
        IUI io;
        DAO bookDAO;

        public BookStoreController(IUI io, DAO bookDAO)
        {
            this.io = io;
            this.bookDAO = bookDAO;
        }

        public void Start() // Runs the program
        {
            while (true)
            {
                ObjectId id;
                bool success;
                try
                {
                    switch (Menu())
                    {


                        case 1: // CREATE
                            io.PrintLine("Create new book: ");
                            var book = CreateBook();
                            success = bookDAO.Create(book);
                            if (success)
                            {
                                io.Clear();
                                io.PrintLine("Book has been created. ");
                                io.Delay(3);
                            }
                            break;



                        case 2: // READ
                            io.PrintLine("Select book: ");
                            id = bookDAO.GetID(); // Select book
                            io.Clear();
                            PrintBook(bookDAO.ReadOne<Book>(id)); // Prints the books properties
                            io.PressToContinue();
                            break;



                        case 3: // UPDATE
                            io.PrintLine("Select which book to update: ");
                            id = bookDAO.GetID(); // ID
                            io.Clear();

                            int choice = UpdateMenu(); // Property

                            io.Clear();
                            io.Print("Insert new value >");
                            success = bookDAO.Update<Book>(id, choice, io.GetInput()); // Value
                            if (success)
                            {
                                io.PrintLine("Book updated. ");
                                io.Delay(2);
                            }
                            break;



                        case 4: // DELETE
                            io.PrintLine("Select which book to delete: ");
                            id = bookDAO.GetID();

                            io.Clear();
                            success = bookDAO.Delete(id);
                            if (success)
                            {
                                io.PrintLine("Book deleted. ");
                                io.Delay(2);
                            }
                            break;



                        case 5:
                            io.Exit();
                            break;

                        default:
                            break;
                    }

                }
                catch (Exception ex)
                {
                    io.Clear();
                    io.PrintLine("Failed. \nError message: " + ex.Message);
                    io.Delay(2);
                }
            }
        }

        private int Menu() // Prints menu and returns choice
        {
            io.PrintLine("1. Create book \n2. Select book \n3. Update book \n4. Delete book \n5. Exit");
            io.Print("Choice >");
            int choice = Convert.ToInt32(io.GetInput());
            io.Clear();


            return choice;
        }

        private int UpdateMenu() // Prints update-menu and returns choice
        {
            io.PrintLine("What property would you like to update? ");
            io.PrintLine("1. Title \n2. Author \n3. Amount of pages \n4. Price");
            io.Print("Choice >");
            int choice = Convert.ToInt32(io.GetInput());
            io.Clear();

            return choice;
        }

        private Book CreateBook() // Inputs all book-properties and returns book-object
        {
            io.Print("Title >");
            string title = io.GetInput();

            io.Print("Author >");
            string author = io.GetInput();

            io.Print("Amount of pages >");
            int pages = Convert.ToInt32(io.GetInput());

            io.Print("Price >");
            decimal price = Convert.ToDecimal(io.GetInput());

            return new Book(title, author, pages, price);
        }

        private void PrintBook(Book book) // Prints out all the properties of a book
        {
            io.PrintLine($"Title: {book.Title} \nAuthor: {book.Author} \nAmount of pages: {book.Pages} \nPrice: {book.Price} SEK\n");
        }


    }
}
