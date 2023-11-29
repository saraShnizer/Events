using events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opt=>opt.AddPolicy("my policy",policy=>
{ 
   policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); 
}));

builder.Services.AddSingleton<IDataContext, DataContext>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("my policy");

app.UseAuthorization();

app.MapControllers();

app.Run();
