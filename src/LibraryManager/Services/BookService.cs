using LibraryManager.Models;

namespace LibraryManager.Services;

public class BookService : IBookService
{
    private readonly List<Book> Books = [];

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public void RemoveBook(Book book)
    {
        Books.Remove(book);
    }

    public List<Book> SearchBooks(string text)
    {
        return Books
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
            "title" => Books.OrderBy(book => book.Title).ToList(),
            "author" => Books.OrderBy(book => book.Author).ToList(),
            "year" => Books.OrderBy(book => book.PublishYear).ToList(),
            "genre" => Books.OrderBy(book => book.Genre).ToList(),
            _ => throw new ArgumentException("Invalid criteria.")
        };
    }
}