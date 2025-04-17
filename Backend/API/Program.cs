using API.Mapping;
using API.Middlewares;
using Data.Abstract;
using Data.Context;
using Data.EntityFramwork;
using Services.Abstract;
using Services.Concrete;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add services to the container.
builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<IProductDal, EfProductDal>();
builder.Services.AddScoped<IProductService, ProductManager>();

builder.Services.AddScoped<ICartDal, EfCartDal>();
builder.Services.AddScoped<ICartService, CartManager>();

builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseMiddleware<ExceptionHandling>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/openapi/v1.json","Demo API");
    });

}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors(opt => {
   opt.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:3000");
});

app.UseAuthorization();

app.MapControllers();

app.Run();
