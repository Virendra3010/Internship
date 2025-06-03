using BooksApi.Entities.Entities;
using BooksApi.Entities.Repositories.Interface;
using BooksApi.Models;
using BooksApi.Services.Services.Interface;

namespace BooksApi.Services
{
    // For CRUD on books
    public class BookService : IBookService
    {
        private List<Book> _books;
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            _books = new List<Book>();
        }

        // To Add Book
        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        // To Get All Books
        public List<Book> GetAll()
        {
            return _books;
        }

        // To Get Single Book
        public Book? GetBookById(int id)
        {
            return _books.Find(x => x.Id == id);
        }

        public async Task InsertBook(BookDetails bookDetails)
        {
            await _bookRepository.InsertBook(bookDetails);
        }


        public BookDetails GetBookDetailsById(int id)
        {
            return _bookRepository.GetById(id);
        }

        //  To Update Book
        public bool UpdateBook(int id, Book updatedBook)
        {
            var index = _books.FindIndex(x => x.Id == id);
            if (index == -1) return false;

            updatedBook.Id = id; // Make sure the ID stays the same
            _books[index] = updatedBook;
            return true;
        }

        //  To Delete Book
        public bool DeleteBook(int id)
        {
            var book = _books.Find(x => x.Id == id);
            if (book == null) return false;

            _books.Remove(book);
            return true;
        }
    }
}

    }
}
