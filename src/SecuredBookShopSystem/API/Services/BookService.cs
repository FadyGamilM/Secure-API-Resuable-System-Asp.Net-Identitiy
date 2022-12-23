using API.DTOs;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class BookService : IBookService
{
    private readonly AppDbContext _context;
    public BookService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<BookToRead>> ListAll()
    {
        var books = await _context.Books.Select(
            book=> new BookToRead { 
                Id= book.Id,
                Title= book.Title,
                AuthorName= book.AuthorName,
            }).ToListAsync();

        return books;
        
    }
}
