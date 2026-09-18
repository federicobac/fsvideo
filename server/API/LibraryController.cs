using Infra;
using Microsoft.AspNetCore.Mvc;

public class LibraryController(LibrayService service) : ControllerBase
{
    [HttpGet(nameof(GetBooks))]
    public List<Book> GetBooks(int page, int resultsPerPage)
    {
        return service.GetBooks(page, resultsPerPage);
    }
}