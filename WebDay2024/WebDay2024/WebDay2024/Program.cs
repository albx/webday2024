using WebDay2024;
using WebDay2024.Client.Services;
using WebDay2024.Components;
using WebDay2024.Models;
using WebDay2024.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddScoped<ICommentsService, CommentsServerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(WebDay2024.Client._Imports).Assembly);

#region APIs
app.MapGet(
    "/api/comments",
    () =>
    {
        return Results.Ok(CommentsStore.Comments);
    });

app.MapPost(
    "/api/comments",
    (CommentModel comment) =>
    {
        CommentsStore.Comments.Add(comment);
        return Results.Ok();
    });
#endregion

app.Run();
