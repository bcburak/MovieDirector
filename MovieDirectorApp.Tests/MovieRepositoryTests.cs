using MongoDB.Driver;
using Moq;
using MovieDirectorApp.Domain.Entities;
using MovieDirectorApp.Infrastructure.Repositories;

namespace MovieDirectorApp.Tests
{
    public class MovieRepositoryTests
    {

        [Fact]
        public async Task AddAsync_Should_Insert_Movie()
        {
            // Arrange
            var mockCollection = new Mock<IMongoCollection<Movie>>();
            var mockDb = new Mock<IMongoDatabase>();
            mockDb.Setup(d => d.GetCollection<Movie>("Movies", null))
                  .Returns(mockCollection.Object);

            var repo = new MovieRepository(mockDb.Object);
            var movie = new Movie
            {
                Title = "Jurassic Park",
                Year = 1993
            };

            // Act
            await repo.AddAsync(movie);

            // Assert
            mockCollection.Verify(c => c.InsertOneAsync(
                It.IsAny<Movie>(), null, default), Times.Once);
        }
    }
}
