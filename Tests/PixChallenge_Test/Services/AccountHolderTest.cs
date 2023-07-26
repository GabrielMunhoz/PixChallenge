using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Moq;
using PixChallenge_Application.Interfaces;
using PixChallenge_Application.Services;
using PixChallenge_Core.Entities;
using PixChallenge_Core.Interfaces;

namespace PixChallenge_Test.Services
{
    public class AccountHolderTest
    {
        private readonly IAccountHolderService _accountHolderService;
        private readonly Mock<IAccountHolderRepository> _accountHolderRepository;
        private readonly Mock<ILogger<AccountHolderService>> _logger;
        public AccountHolderTest()
        {
            _accountHolderRepository = new Mock<IAccountHolderRepository>();
            _logger = new Mock<ILogger<AccountHolderService>>();
            _accountHolderService = new AccountHolderService(_accountHolderRepository.Object, _logger.Object);
        }

        [Fact]
        public void CreateAsync_Succes()
        {
            //Arrange
            _accountHolderRepository
                .Setup(x => x.CreateAsync(It.IsAny<AccountHolder>()))
                .ReturnsAsync(new Mock<AccountHolder>().Object);

            //Act
            var result = _accountHolderService.CreateAsync(It.IsAny<AccountHolder>()).Result;

            //Assert
            Assert.NotNull(result);
        }
    }
}
