namespace Tests;
using Moq;
using userModels;
using customExceptions;
using Xunit;
using AuthService;
using UserData;
public class AuthServiceTest
{
    [Fact]
    public void RegiserShouldFailIfDuplicateUsername()
    {
        var mockedRepo = new Mock<UserRepository>();
        User userToAdd = new User("Mike", "1234", Role.Employee);
        mockedRepo.Setup(repo => repo.GetUser(userToAdd.userName)).Returns(userToAdd);

        AuthServices AServices = new AuthServices(mockedRepo.Object);

        Assert.Throws<UsernameNotAvailableException>(() => AServices.Register(userToAdd));
        mockedRepo.Verify(repo => repo.GetUser(userToAdd.userName), Times.Once());
    }

    [Fact]
    public void LoginShouldFailIfUsernameNotExist()
    {
        var mockedRepo = new Mock<UserRepository>();
        User userToAdd = new User("Bobby", "1234", Role.Employee);
        mockedRepo.Setup(repo => repo.GetUser(userToAdd.userName)).Throws(new RecordNotFoundException());

        AuthServices AServices = new AuthServices(mockedRepo.Object);

        Assert.Throws<InvalidCredentialsException>(() => AServices.login(userToAdd));
        mockedRepo.Verify(repo => repo.GetUser(userToAdd.userName), Times.Once());
    }

    [Fact]
    public void LoginShouldFailIfPasswordWrong()
    {
        var mockedRepo = new Mock<UserRepository>();
        User userToAdd = new User("Mike", "1234", Role.Employee);
        User userToReturn = new User("Mike", "4321", Role.Employee);
        mockedRepo.Setup(repo => repo.GetUser(userToAdd.userName)).Returns(userToReturn);

        AuthServices AServices = new AuthServices(mockedRepo.Object);

        Assert.Throws<InvalidCredentialsException>(() => AServices.login(userToAdd));
        mockedRepo.Verify(repo => repo.GetUser(userToAdd.userName), Times.Once());
    }
}
