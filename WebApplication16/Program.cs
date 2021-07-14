using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using WebApplication16;
using static System.Linq.Enumerable;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.Path("/", root =>
{
    root.MapGet(() => "Hello, Nested World!");
    root.Path("todos", todos =>
    {
        todos.MapGet(() => Range(1, 4).Select(i => new Todo(i)));
        todos.MapGet("{id:int}", () => new Todo(1));
    });
});

app.Run();

public record Todo(int Id)
{
    public string Name => $"Todo {Id}";
}