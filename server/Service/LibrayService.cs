using System.ComponentModel.DataAnnotations;
using Infra;

public class LibrayService(MyDatabaseConnection db)
{ 
    public List<Book> GetBooks(int page, int resultsPerPage)
    {
        if(page < 1)
            throw new ValidationException("Page must be 1 or higher");
        if(resultsPerPage < 1)
            throw new ValidationException("Must have 1 or more results per page");
        
        return db.Books.Take(resultsPerPage)
            .Skip((page-1)*resultsPerPage)
            .ToList();
    }
}