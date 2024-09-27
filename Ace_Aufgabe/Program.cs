var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.WebHost.UseKestrel(options =>
{
    options.ListenAnyIP(80);  
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
