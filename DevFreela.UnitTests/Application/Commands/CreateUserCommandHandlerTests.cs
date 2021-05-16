using DevFreela.Application.Commands.CreateUser;
using DevFreela.Core.Entities;
using DevFreela.Core.Interfaces.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateUserCommandHandlerTests
    {
        [Fact]
        public async Task DataIsValid_Executed_ReturnaValidViewModel()
        {
            //Arrange
            var useRepository = new Mock<IUserRepository>();
            useRepository.Setup(ur => ur.Add(It.IsAny<User>())).Verifiable();

            var createUserCommand = new CreateUserCommand("Priscila", "priscilaresantos@gmail.com", new DateTime(1988, 1, 21), "123456", "teste");
            var createUserCommandHandler = new CreateUserCommandHandler(useRepository.Object); // se baseia no setup e cria objeto para usar 
            //Act
            var result = await createUserCommandHandler.Handle(createUserCommand, new CancellationToken());
            //Assert
            Assert.NotNull(result);
            Assert.Equal(createUserCommand.Name, result.Name);
            Assert.Equal(createUserCommand.Email, result.Email);
            Assert.Equal(createUserCommand.BirthDate, result.BirthDate);
            useRepository.Verify(ur => ur.Add(It.IsAny<User>()), Times.Once);
        }
    }
}
