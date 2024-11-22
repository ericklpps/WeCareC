using Microsoft.EntityFrameworkCore;
using WeCare.Data;
using WeCare.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "User Id=rm553927;Password=300903;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521)))(CONNECT_DATA=(SID=orcl)));";

builder.Services.AddDbContext<WeCareDbContext>(options =>
    options.UseOracle(connectionString));

builder.Services.AddScoped<IMetaRepository, MetaRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Testar a conexão com o banco de dados
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<WeCareDbContext>();
    try
    {
        Console.WriteLine("Tentando conectar ao banco de dados...");
        dbContext.Database.OpenConnection();
        Console.WriteLine("Conexão bem-sucedida!");
        dbContext.Database.CloseConnection();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao conectar ao banco: {ex.Message}");
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
