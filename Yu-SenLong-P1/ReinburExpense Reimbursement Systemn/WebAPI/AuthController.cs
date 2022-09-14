namespace Controllers;
using AuthService;
using userModels;
using customExceptions;

public class AuthController
{
    private readonly AuthServices _AServices;
    public AuthController(AuthServices services)
    {
        _AServices = services;
    }

    public IResult Register(User User2Register)
    {
        if(User2Register.userName == null)
        {
            return Results.BadRequest("Name Cannot Be Null");
        }
        try
        {
            int returnID = _AServices.Register(User2Register); //I think this has to happen in another line for the try catch to work
            return Results.Created($"/user/userid?id={returnID}", returnID);
        }
        catch(UsernameNotAvailableException)
        {
            return Results.Conflict("Username unavailable, please try again");
        }
    }

    public IResult Login(string username, string password)
    {
        if(username == null)
        {
            return Results.BadRequest("Name Cannot Be Null");
        }
        try
        {
            User User2Login = new User(username,password);
            User ReturnUser = _AServices.login(User2Login);
            return Results.Ok(ReturnUser);
        }
        catch(InvalidCredentialsException)
        {
            return Results.Conflict("Please double check your login information and try again");
        }
    }
}