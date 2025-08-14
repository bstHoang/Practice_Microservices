using Microsoft.EntityFrameworkCore;
using UserService.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UsersDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();