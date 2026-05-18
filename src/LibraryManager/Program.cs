using LibraryManager.Models;
using LibraryManager.Services;

var bookService = new BookService();

// Books seed
bookService.AddBook(new Book("Pan Tadeusz", "Adam Mickiewicz", 1834, "Epos narodowy"));
bookService.AddBook(new Book("Lalka", "Bolesław Prus", 1890, "Realizm"));
bookService.AddBook(new Book("Quo Vadis", "Henryk Sienkiewicz", 1896, "Historyczna"));
bookService.AddBook(new Book("Ferdydurke", "Witold Gombrowicz", 1937, "Absurdalna"));
bookService.AddBook(new Book("Solaris", "Stanisław Lem", 1961, "Science fiction"));

Console.WriteLine(".NET Library Manager");

while (true)
{
    var choice = DisplayMenu();

    switch (choice)
    {
        case 1:
            DisplayAllBooks();
            break;
        case 2:
            AddBook();
            break;
    }
}

int? DisplayMenu()
{
    Console.WriteLine();
    Console.WriteLine("Menu:");
    Console.WriteLine("1. Show all books");
    Console.WriteLine("2. Add new book");
    Console.WriteLine("3. Edit book");
    Console.WriteLine("4. Delete book");
    Console.WriteLine("5. Exit program");
    Console.Write("Choose action: ");

    string? input = Console.ReadLine();

    if (!int.TryParse(input, out int choice) || choice < 1 || choice > 5)
    {
        Console.WriteLine("Invalid number.");
        return null;
    }

    return choice;
}

void DisplayAllBooks()
{
    var books = bookService.GetAllBooks();

    foreach (var book in books)
        Console.WriteLine(book.GetInfo());
}

void AddBook()
{
    Console.Write("Enter the title: ");
    string? title = Console.ReadLine();

    Console.Write("Enter the author: ");
    string? author = Console.ReadLine();

    Console.Write("Enter the publication year: ");
    string? yearInput = Console.ReadLine();

    if (!int.TryParse(yearInput, out int year))
    {
        Console.WriteLine("Invalid number.");
        return;
    }

    Console.Write("Enter the genre: ");
    var genre = Console.ReadLine();

    bookService.AddBook(new Book(title, author, year, genre));
}