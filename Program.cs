// using TaskManagerAPI.Services;

// var builder = WebApplication.CreateBuilder(args);

// // ✅ Add Swagger + Controllers + CORS
// builder.Services.AddControllers();
// builder.Services.AddSingleton<TaskService>();
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowAll", policy =>
//     {
//         policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
//     });
// });

// // ✅ Add Swagger service
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// // ✅ Use Swagger middleware (only works because it's now registered)
// app.UseSwagger();
// app.UseSwaggerUI();

// // ✅ Enable CORS and map controllers
// app.UseCors("AllowAll");
// app.MapControllers();
// app.Run();

using TaskManagerAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<TaskService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins(
                "http://localhost:3000",
                "https://taskmanagerfrontend.vercel.app"
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("AllowFrontend");
app.MapControllers();
app.Run();
