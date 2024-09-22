using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSingleton<CosmosClient>(serviceProvider =>
{
    return new CosmosClient("AccountEndpoint=https://springbootproject2.documents.azure.com:443/;AccountKey=TcIupamk2VmP8Be7fyJAZ5qqiOyZjOCLlsdcFNQLEulhrCiyB8EtwRf2TYGcgLGW7SxQQJdhW1AgACDbI1OBjA==;");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();