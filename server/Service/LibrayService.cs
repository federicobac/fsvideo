using Infra;

public class LibrayService(MyDatabaseConnection db)
{
    public List<Book> GetBooks()
    {
        return db.Books.ToList();
    }
}