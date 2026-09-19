using Infra;
using Microsoft.AspNetCore.Mvc;

public class LibraryController(LibraryService service) : ControllerBase
{
    [HttpGet(nameof(GetBooks))]
    public List<BookDto> GetBooks(int page, int resultsPerPage)
    {
        return service.GetBooks(page, resultsPerPage);
    }

    [HttpPost(nameof(CreateBook))]
    public BookDto CreateBook(CreateBookRequestDto dto)
    {
        return service.CreateBook(dto);
    }

}