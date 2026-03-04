using BookLibraryAPI.Models;

namespace BookLibraryAPI.Services;

public class BookService : IBookService
{
    // In-memory storage (for now, before databases)
    private readonly List<Book> _books = new();
    private int _nextId = 1;

    public BookService()
    {
        // Seed with sample data
        _books.AddRange(new List<Book>
        {
            new Book
            {
                Id = _nextId++,
                Title = "The Pragmatic Programmer",
                Author = "Andrew Hunt and David Thomas",
                ISBN = "978-0201616224",
                PublishedYear = 1999,
                Genre = "Programming",
                IsAvailable = true
            },
            new Book
            {
                Id = _nextId++,
                Title = "Clean Code",
                Author = "Robert C. Martin",
                ISBN = "978-0132350884",
                PublishedYear = 2008,
                Genre = "Programming",
                IsAvailable = true
            },
            new Book
            {
                Id = _nextId++,
                Title = "Design Patterns",
                Author = "Gang of Four",
                ISBN = "978-0201633610",
                PublishedYear = 1994,
                Genre = "Programming",
                IsAvailable = false
            }
        });
    }

    public List<Book> GetAllBooks()
    {
        return _books;
    }

    public Book? GetBookById(int id)
    {
        return _books.FirstOrDefault(b => b.Id == id);
    }

    public List<Book> SearchBooks(string? title, string? author)
    {
        var query = _books.AsEnumerable();

        if (!string.IsNullOrEmpty(title))
        {
            query = query.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrEmpty(author))
        {
            query = query.Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase));
        }

        return query.ToList();
    }

    public Book CreateBook(Book book)
    {
        book.Id = _nextId++;
        _books.Add(book);
        return book;
    }

    public Book? UpdateBook(int id, Book book)
    {
        var existing = _books.FirstOrDefault(b => b.Id == id);
        if (existing == null)
        {
            return null;
        }

        // Update properties
        existing.Title = book.Title;
        existing.Author = book.Author;
        existing.ISBN = book.ISBN;
        existing.PublishedYear = book.PublishedYear;
        existing.Genre = book.Genre;
        existing.IsAvailable = book.IsAvailable;

        return existing;
    }

    public bool DeleteBook(int id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            return false;
        }

        _books.Remove(book);
        return true;
    }
}