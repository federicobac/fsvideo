using System.ComponentModel.DataAnnotations;
using Infra;
using LinqToDB;

public class LibraryService(MyDatabaseConnection db)
{ 
    public List<BookDto> GetBooks(int page, int resultsPerPage)
    {
        if(page < 1)
            throw new ValidationException("Page must be 1 or higher");
        if(resultsPerPage < 1)
            throw new ValidationException("Must have 1 or more results per page");
        
        return db.Books.Take(resultsPerPage)
            .LoadWith(b => b.Author)
            .ThenLoad(a => a.BooksWrittenByAuthor)
            .Take(resultsPerPage)
            .Skip((page-1)*resultsPerPage)
            .Select(b => new BookDto(b)
            {
                Author = new AuthorDto(b.Author)
            })
            .ToList();
    }
}