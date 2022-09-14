using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Mvc;
using UserService;
using AuthService;
using TicketService;
using userModels;
using ticketModels;
using ConnectionFactory;
using Controllers;
using TickeData;
using UserData;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//dependency injection
builder.Services.AddSingleton<ConnectionFactoryClass>(ctx => ConnectionFactoryClass.GetInstance(builder.Configuration.GetConnectionString("ERS")));
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<TicketServices>();
builder.Services.AddScoped<TicketRepository>();
builder.Services.AddScoped<AuthController>();
builder.Services.AddScoped<AuthServices>();
builder.Services.AddScoped<UserController>();
builder.Services.AddScoped<TicketController>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet
    (
        "/user/getallusers", () => 
        {
            var scope = app.Services.CreateScope();
            UserController controller = scope.ServiceProvider.GetRequiredService<UserController>();
            return controller.GetAllUsers();
        }
    );

app.MapPost
    (
        "/register", (User NewUser, AuthController AController) => 
        {
            return AController.Register(NewUser);
        }
    );

app.MapGet
    (
        "/login", (string username, string password, AuthController AController) => 
        {
            return AController.Login(username, password);
        }
    );

app.MapGet
    (
        "/user/username", (string name) => 
        {
            var scope = app.Services.CreateScope();
            UserController controller = scope.ServiceProvider.GetRequiredService<UserController>();
            return controller.GetUser(name);
        }
    );

app.MapGet
    (
        "/user/userid", (int id) => 
        {
            var scope = app.Services.CreateScope();
            UserController controller = scope.ServiceProvider.GetRequiredService<UserController>();
            return controller.GetUser(id);
        }
    );

app.MapPost
    (
        "/ticket/new", (Ticket NewTicket) => 
        {
            var scope = app.Services.CreateScope();
            TicketController controller = scope.ServiceProvider.GetRequiredService<TicketController>();
            return controller.CreateReimbursement(NewTicket);
        }
    );

app.MapPut
    (
        "/ticket/update", (Ticket Ticket2Update) => 
        {
            var scope = app.Services.CreateScope();
            TicketController controller = scope.ServiceProvider.GetRequiredService<TicketController>();
            return controller.UpdateReimbursement(Ticket2Update);
        }
    );

app.MapGet
    (
        "/ticket/status", (Status Status2Get) => 
        {
            var scope = app.Services.CreateScope();
            TicketController controller = scope.ServiceProvider.GetRequiredService<TicketController>();
            return controller.GetReimbursementByStatus(Status2Get);
        }
    );

app.MapGet
    (
        "/ticket/author", (int Author) => 
        {
            var scope = app.Services.CreateScope();
            TicketController controller = scope.ServiceProvider.GetRequiredService<TicketController>();
            return controller.GetReimbursementByAuthor(Author);
        }
    );

app.MapGet
    (
        "/ticket/ticketid", (int ID) => 
        {
            var scope = app.Services.CreateScope();
            TicketController controller = scope.ServiceProvider.GetRequiredService<TicketController>();
            return controller.GetReimbursementByID(ID);
        }
    );

app.Run();
