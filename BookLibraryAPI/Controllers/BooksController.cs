using Microsoft.AspNetCore.Mvc;
using BookLibraryAPI.Models;
using BookLibraryAPI.Services;

namespace BookLibraryAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    // Constructor injection
    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    // GET: api/books
    [HttpGet]
    public ActionResult<List<Book>> GetAllBooks()
    {
        var books = _bookService.GetAllBooks();
        return Ok(books);
    }

    // GET: api/books/5
    [HttpGet("{id}")]
    public ActionResult<Book> GetBookById(int id)
    {
        var book = _bookService.GetBookById(id);

        if (book == null)
        {
            return NotFound(new { message = $"Book with ID {id} not found" });
        }

        return Ok(book);
    }

    // GET: api/books/search?title=clean&author=martin
    [HttpGet("search")]
    public ActionResult<List<Book>> SearchBooks([FromQuery] string? title, [FromQuery] string? author)
    {
        if (string.IsNullOrEmpty(title) && string.IsNullOrEmpty(author))
        {
            return BadRequest(new { message = "Please provide at least one search parameter (title or author)" });
        }

        var books = _bookService.SearchBooks(title, author);
        return Ok(new
        {
            count = books.Count,
            results = books
        });
    }

    // POST: api/books
    [HttpPost]
    public ActionResult<Book> CreateBook([FromBody] Book book)
    {
        // Validation
        if (string.IsNullOrEmpty(book.Title))
        {
            return BadRequest(new { message = "Title is required" });
        }

        if (string.IsNullOrEmpty(book.Author))
        {
            return BadRequest(new { message = "Author is required" });
        }

        var createdBook = _bookService.CreateBook(book);

        // Return 201 Created with location header
        return CreatedAtAction(
            nameof(GetBookById),
            new { id = createdBook.Id },
            createdBook
        );
    }

    // PUT: api/books/5
    [HttpPut("{id}")]
    public ActionResult<Book> UpdateBook(int id, [FromBody] Book book)
    {
        // Validation
        if (string.IsNullOrEmpty(book.Title))
        {
            return BadRequest(new { message = "Title is required" });
        }

        if (string.IsNullOrEmpty(book.Author))
        {
            return BadRequest(new { message = "Author is required" });
        }

        var updatedBook = _bookService.UpdateBook(id, book);

        if (updatedBook == null)
        {
            return NotFound(new { message = $"Book with ID {id} not found" });
        }

        return Ok(updatedBook);
    }

    // DELETE: api/books/5
    [HttpDelete("{id}")]
    public ActionResult DeleteBook(int id)
    {
        bool deleted = _bookService.DeleteBook(id);

        if (!deleted)
        {
            return NotFound(new { message = $"Book with ID {id} not found" });
        }

        return NoContent();  // 204 No Content
    }

    // GET: api/books/stats
    [HttpGet("stats")]
    public ActionResult GetStatistics()
    {
        var allBooks = _bookService.GetAllBooks();

        return Ok(new
        {
            totalBooks = allBooks.Count,
            availableBooks = allBooks.Count(b => b.IsAvailable),
            checkedOutBooks = allBooks.Count(b => !b.IsAvailable),
            genres = allBooks.Select(b => b.Genre).Distinct().OrderBy(g => g).ToList()
        });
    }
}