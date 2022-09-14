namespace userModels;
/*using System.Text.Json;
using System.Text.Json.Serialization;*/

public enum Role //since there are only two possible roles, enum helps in tracking them
{
    Manager,
    Employee
}
public class User
{
    public User() //Default Constructor, if you see this in the data base something has gone wrong
    {
        this.ID = 0;
        this.userName = "DefaultUser_SomeThingHasGoneWrong";
        this.passWord = "1234";
        this.userRole = Role.Employee;
    }

    public User(String userName, String passWord) //used for login
    {
        this.ID = 0;
        this.userName = userName;
        this.passWord = passWord;
        this.userRole = Role.Employee;
    }

    public User(int ID, String userName, String passWord, Role role) //these are just placeholder attributes that does nothing more than the default getter and setters
    {
        this.ID = ID;
        this.userName = userName;
        this.passWord = passWord;
        this.userRole = role;
    }

    public User(String userName, String passWord, Role role) //these are just placeholder attributes that does nothing more than the default getter and setters
    {
        this.ID = 0;
        this.userName = userName;
        this.passWord = passWord;
        this.userRole = role;
    }

    //I am not sure any of the things below should be public, I will change them once I have more details regarding the project
    //[JsonIgnore]
    public int ID {get;set;} //This should check for ID validity
    public string userName{get;set;} //This should search for the userName
    public string passWord{get;set;} //This should check if password matches the userName
    public Role userRole{get;set;} //This is just for storing roles

    public override string ToString() // just print stuff out for convenience 
    {
        return "ID: " + this.ID + ", userName: " + this.userName + ", userRole: " + this.userRole;
    }
}