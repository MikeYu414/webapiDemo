using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddHttpClient("ExternalApi", client =>
//{
//    client.BaseAddress = new Uri("https://apisandbox.iras.gov.sg/");
//    client.DefaultRequestHeaders.Add("Accept", "application/json");
//    client.DefaultRequestHeaders.Add("X-IBM-Client-Id", "9cd729c9161bc98b43db8d031e2bcad1");
//    client.DefaultRequestHeaders.Add("X-IBM-Client-Secret", "ca059de6fc014507dfac56d031cf5da7");
//    // 可以添加认证头等
//    // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "token");
//});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGet("/", () => "Hello World!");
app.Run();
