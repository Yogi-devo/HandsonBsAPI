using AutoMapper;
using HandsonBsAPI.Data;
using HandsonBsAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandsonBsAPI.Repository
{
    public class BookRepository: IBookRepository
    {
        private readonly BsContext _context;
        private readonly IMapper _mapper;

        public BookRepository(BsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            //1 var records = await _context.Books.ToListAsync();
            //2 var records = await _context.Books.Select(x=> new BookModel() 
            //{ 
            //    Id = x.Id,
            // Name =x.Name,
            // Description = x.Description

            //}).ToListAsync();
            var records = await _context.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(records);
        }
        public async Task<BookModel> GetBookByIdAsync(int id)
        {
            //var records = await _context.Books.Where(x=>x.Id==id).Select(x => new BookModel()
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Description = x.Description

            //}).FirstOrDefaultAsync();
            //return records;   
            var bk = await _context.Books.FindAsync(id);
            return _mapper.Map<BookModel>(bk);
        }

        public async Task<int> AddBookAsync(BookModel bookModel)
        {

            var record = new Books()
            {
                Name = bookModel.Name,
                Description = bookModel.Description
            };
            _context.Books.Add(record);
            await _context.SaveChangesAsync();
            return record.Id;
        }
        public async Task UpdateBookAsync(int BookId, BookModel bookModel)
        {
            //var book = await _context.Books.FindAsync(BookId);
            //if(book!=null)
            //{
            //    book.Name = bookModel.Name;
            //    book.Description = bookModel.Description;
            //    await _context.SaveChangesAsync();
            //}
            var record = new Books()
            {
                Id= BookId,
                Name = bookModel.Name,
                Description = bookModel.Description
            };
            _context.Books.Update(record);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateBookPatchAsync(int BookId, JsonPatchDocument bookModel)
        {
            var book = await _context.Books.FindAsync(BookId);
            if(book!=null)
            {
                bookModel.ApplyTo(book);
                await _context.SaveChangesAsync();
            }
          
            
        }
        public async Task DeleteBookAsync(int bookId)
        {
            //var bk = await  _context.Books.Where(x => x.Id == bookId).FirstOrDefaultAsync();
            //  _context.Books.Remove(bk);
            //  await _context.SaveChangesAsync();
            var bk = new Books()
            { Id = bookId };
            _context.Books.Remove(bk);
            await _context.SaveChangesAsync();
        }
    }
}
