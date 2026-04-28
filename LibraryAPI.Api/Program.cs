using LibraryAPI.Domain.Interfaces;
using LibraryAPI.Domain.Services;
using LibraryAPI.Infrastructure.Configurations;
using LibraryAPI.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration["Mongo:ConnectionString"]
?? throw new Exception("Mongo ConnectionString not found");

var databaseName = builder.Configuration["Mongo:Database"]
?? throw new Exception("Mongo Database not found");

builder.Services.AddSingleton(new MongoDbContext(connectionString, databaseName));

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
//builder.Services.AddScoped<ILoanRepository, LoanRepository>();

builder.Services.AddScoped<AuthorService>();
builder.Services.AddScoped<BookService>();
//builder.Services.AddScoped<LoanService>();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.UseHttpsRedirection();

app.Run();

