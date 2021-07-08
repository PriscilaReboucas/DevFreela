using DevFreela.Application.Commands.CreateUser;
using DevFreela.Core.Entities;
using DevFreela.Core.Interfaces.Repositories;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateUserCommandHandlerTests
    {
        [Fact]
        public async Task DataIsValid_Executed_ReturnaValidViewModel() //padrão nomenclatura given_when_then
        {
            //Padrao AAA  
            //Arrange - Preparação dos objetos necessários para o teste unitário
            var useRepository = new Mock<IUserRepository>();
            useRepository.Setup(ur => ur.Add(It.IsAny<User>())).Verifiable();

            var createUserCommand = new CreateUserCommand("Priscila", "priscilaresantos@gmail.com", new DateTime(1988, 1, 21), "123456", "teste");
            var createUserCommandHandler = new CreateUserCommandHandler(useRepository.Object); // se baseia no setup e cria objeto para usar 

            //Act - Realização da operação a ser testada
            var result = await createUserCommandHandler.Handle(createUserCommand, new CancellationToken());

            //Assert - Verificação do resultado da operação
            Assert.NotNull(result);
            Assert.Equal(createUserCommand.Name, result.Name);
            Assert.Equal(createUserCommand.Email, result.Email);
            Assert.Equal(createUserCommand.BirthDate, result.BirthDate);
            useRepository.Verify(ur => ur.Add(It.IsAny<User>()), Times.Once);
        }
    }
}
