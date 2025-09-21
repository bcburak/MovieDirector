using FluentAssertions;
using Moq;
using MovieDirectorApp.Application.Commands;
using MovieDirectorApp.Application.Commands.Handlers;
using MovieDirectorApp.Domain.Entities;
using MovieDirectorApp.Domain.Interfaces;

namespace MovieDirectorApp.Tests
{
    public class DirectorCommandHandlerTests
    {
        [Fact]
        public async Task Handle_Should_Create_Director_And_Return_Id()
        {
            // Arrange
            var mockRepo = new Mock<IDirectorRepository>();
            mockRepo.Setup(r => r.AddAsync(It.IsAny<Director>()))
                    .Returns(Task.CompletedTask);

            var handler = new DirectorCommandHandler(mockRepo.Object);

            var command = new CreateDirectorCommand
            {
                FirstName = "Steven",
                SecondName = "Spielberg",
                BirthDate = new DateTime(1946, 12, 18)
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNullOrEmpty();
            mockRepo.Verify(r => r.AddAsync(It.IsAny<Director>()), Times.Once);
        }
    }
}
