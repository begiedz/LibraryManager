using LibraryManager.Models;

namespace LibraryManager.Services;

public class BookService : IBookService
{
    private readonly List<Book> _books = [];

    public void AddBook(Book book)
    {
        _books.Add(book);
    }

    public void RemoveBook(Book book)
    {
        _books.Remove(book);
    }

    public List<Book> SearchBooks(string text)
    {
        return _books
            .Where(book =>
                book.Title.Contains(text, StringComparison.OrdinalIgnoreCase) ||
                book.Author.Contains(text, StringComparison.OrdinalIgnoreCase) ||
                book.PublishYear.ToString().Contains(text) ||
                book.Genre.Contains(text, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<Book> SortBooks(string criteria)
    {
        return criteria.ToLower() switch
        {
            "title" => _books.OrderBy(book => book.Title).ToList(),
            "author" => _books.OrderBy(book => book.Author).ToList(),
            "year" => _books.OrderBy(book => book.PublishYear).ToList(),
            "genre" => _books.OrderBy(book => book.Genre).ToList(),
            _ => throw new ArgumentException("Invalid criteria.")
        };
    }

    public IReadOnlyList<Book> GetAllBooks()
    {
        return _books;
    }
}