using API.DTOs;

namespace API.Services;

public interface IBookService
{
    Task<IEnumerable<BookToRead>> ListAll();
}
