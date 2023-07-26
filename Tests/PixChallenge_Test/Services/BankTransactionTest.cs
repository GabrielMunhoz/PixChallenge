using Microsoft.Extensions.Logging;
using Moq;
using PixChallenge_Application.Services;
using PixChallenge_Core.Entities;
using PixChallenge_Core.Interfaces;
using System.Linq.Expressions;

namespace PixChallenge_Test.Services
{
    public class BankTransactionTest
    {
        private readonly BankTransactionService _bankTransactionService;
        private Mock<IBankTransactionRepository> _bankTransactionRepositoryMock;
        private Mock<IAccountHolderRepository> _accountHolderRepositoryMock;
        private Mock<ILogger<BankTransactionService>> _loggerMock;
        public BankTransactionTest()
        {
            _bankTransactionRepositoryMock = new Mock<IBankTransactionRepository>();
            _accountHolderRepositoryMock = new Mock<IAccountHolderRepository>();
            _loggerMock = new Mock<ILogger<BankTransactionService>>();

            _bankTransactionService = new BankTransactionService(_bankTransactionRepositoryMock.Object, _accountHolderRepositoryMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task ProcessPayment_ShouldReturnFalse()
        {
            // Arrange
            var sender = new AccountHolder { Id = Guid.NewGuid(), ValueKey = "sender_key" };

            _accountHolderRepositoryMock
                .Setup(x => x.GetAsync(It.IsAny<Expression<Func<AccountHolder, bool>>>()))
                .ReturnsAsync(sender);

            var transaction = new BankTransaction
            {
                PayeeKey = "payee_key",
                Sender = new AccountHolder { ValueKey = "sender_key" }
            };

            // Act
            var result = await _bankTransactionService.ProcessPayment(transaction);

            // Assert
            Assert.NotEqual(sender, result?.Sender);
        }

        [Fact]
        public async Task ProcessPayment_ShouldReturnTrue()
        {
            // Arrange
            var payee = new AccountHolder { Id = Guid.NewGuid(), ValueKey = "payee_key" };
            var sender = new AccountHolder { Id = Guid.NewGuid(), ValueKey = "sender_key" };

            _accountHolderRepositoryMock
                .Setup(x => x.GetAsync(It.IsAny<Expression<Func<AccountHolder, bool>>>()))                // First call returns the payee
                .ReturnsAsync(sender); // Second call returns the sender

            var transaction = new BankTransaction
            {
                PayeeKey = "payee_key",
                Sender = sender,
                SenderId = sender.Id,
                Value = 100.00m,
                DateProcessed = DateTime.Now,
                Id = new Guid()
            };

            _bankTransactionRepositoryMock
                .Setup(x => x.CreateAsync(It.IsAny<BankTransaction>()))
                .ReturnsAsync(transaction);
            // Act
            var result = await _bankTransactionService.ProcessPayment(transaction);

            // Assert

            Assert.NotNull(result);
            Assert.Equal(payee.ValueKey, transaction.PayeeKey);
            Assert.Equal(sender, result?.Sender);
            Assert.NotNull(result?.Id);
        }

        [Fact]
        public async Task GetByKeyAsync_ShouldReturnRecords()
        {
            //Arrange
            var key = "00000000000";
            var list = new List<BankTransaction> {
                new BankTransaction { PayeeKey = key }
            };

            _bankTransactionRepositoryMock
                .Setup(x => x.Query(It.IsAny<Expression<Func<BankTransaction, bool>>>(), It.IsAny<Expression<Func<BankTransaction, object>>>()))
                .Returns(list.AsQueryable());

            //Act
            var result = await _bankTransactionService.GetByKeyAsync(key);

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.All(result, r => Assert.Equal(key, r.PayeeKey));
        }

    }
}
