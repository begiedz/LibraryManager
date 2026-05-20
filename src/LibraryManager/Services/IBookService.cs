using LibraryManager.Models;

namespace LibraryManager.Services;

public interface IBookService
{
    public void AddBook(Book book);
    public void RemoveBook(Book Book);
    public List<Book> SearchBooks(string text);
    public List<Book> SortBooks(string criteria);

    public IReadOnlyList<Book> GetAllBooks();
}