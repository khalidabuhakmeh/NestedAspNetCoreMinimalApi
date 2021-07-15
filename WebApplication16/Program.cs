using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
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
        todos.Path("{id:int}", todo => 
        {
            todo.MapGet(async ctx =>
            {
                var id = int.Parse(ctx.Request.RouteValues["id"].ToString());
                await ctx.Response.WriteAsJsonAsync(new Todo(id));
            });
            
            todo.MapDelete(async ctx =>
            {
                ctx.Response.StatusCode = StatusCodes.Status202Accepted;
            });
        });
    });
});

app.Run();

public record Todo(int Id)
{
    public string Name => $"Todo {Id}";
}