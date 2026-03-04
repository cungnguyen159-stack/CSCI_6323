using BookLibraryAPI.Models;

namespace BookLibraryAPI.Services;

public interface IBookService
{
    List<Book> GetAllBooks();
    Book? GetBookById(int id);
    List<Book> SearchBooks(string? title, string? author);
    Book CreateBook(Book book);
    Book? UpdateBook(int id, Book book);
    bool DeleteBook(int id);
}