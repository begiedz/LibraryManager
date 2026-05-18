namespace LibraryManager.Models;

public class Book(string title, string author, int publishYear, string genre)
{
    public string Title { get; set; } = title;
    public string Author { get; set; } = author;
    public int PublishYear { get; set; } = publishYear;
    public string Genre { get; set; } = genre;

    public string GetInfo() => $"Title: {Title}, Author: {Author}, Year: {PublishYear}, Genre: {Genre}";
}