using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebDay2024.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient<ICommentsService, CommentsHttpService>(
    client => client.BaseAddress = new(builder.HostEnvironment.BaseAddress));

await builder.Build().RunAsync();
