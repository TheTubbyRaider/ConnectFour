using ConnectFour.Components;
using ConnectFour; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();  // Enable Blazor interactive components for real-time game updates

// Register GameState as a singleton to manage game state across components
builder.Services.AddSingleton<GameState>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Map the Razor Components with interactive server-side rendering mode
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
