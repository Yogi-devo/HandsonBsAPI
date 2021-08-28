using HandsonBsAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HandsonBsAPI.Repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAllBooksAsync();
        Task<BookModel> GetBookByIdAsync(int id);
        Task<int> AddBookAsync(BookModel bookModel);
        Task UpdateBookAsync(int BookId, BookModel bookModel);
        Task UpdateBookPatchAsync(int BookId, JsonPatchDocument bookModel);
        Task DeleteBookAsync(int bookId);
    }
}
