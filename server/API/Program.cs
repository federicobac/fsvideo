using Infra;
using LinqToDB;

var builder = WebApplication.CreateBuilder(args);

var option = new DataOptions<MyDatabaseConnection>(
        new DataOptions().UseSQLite("Data Source=db.db"));
builder.Services.AddScoped<MyDatabaseConnection>(_ => new MyDatabaseConnection(option));

builder.Services.AddScoped<LibrayService>();
builder.Services.AddControllers();
builder.Services.AddOpenApiDocument();
builder.Services.AddCors();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
        var db = scope.ServiceProvider.GetRequiredService<MyDatabaseConnection>();
        db.CreateTable<Book>(tableOptions: TableOptions.CreateIfNotExists);
        if (db.Books.Count() == 0)
        {
                db.Insert(new Book() 
                {
                        BookId = "1",
                        BookTitle = "book 1",
                        NumberOfPages = 100
                });
        }
}

app.UseCors(config => config
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(_ => true));

app.MapControllers();

app.UseOpenApi();
app.UseSwaggerUi();

app.Run();