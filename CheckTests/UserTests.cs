using CheckBox.Core.Contracts.entities;
using CheckBox.Core.Entities;
using CheckBox.Services;

namespace CheckTests
{
    public class UserTests
    {
        private readonly IUserService _userService;
        public UserTests(IUserService userService)
        {
            _userService = userService;   
        }
        [Fact]
        public void Create()
        {
            //Arrange
            var sut = new User() { Password = "1234", Email = "Email.teste@xunit.com", Name = "Fulano", Id = new Guid(), Surname = "De tal" };
            //Act
            _userService.Create(sut);
            //Assert
            Assert.
        }
    }
}
