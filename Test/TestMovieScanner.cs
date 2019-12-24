using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Plumb.MediaScanner;
using Plumb.MediaScanner.Movies;
using Xunit;

namespace Test
{
    public class TestMovieScanner
    {
        public TestMovieScanner()
        {
            var mock = new Mock<Utilities>();
            var thing = mock.Setup(x => x.GetFiles(It.IsAny<string>(), It.IsAny<IEnumerable<string>>()))
                .Returns(() =>
                {
                    return this.FileList;
                });
            this.Scanner = new MovieScanner();
            this.Scanner.Utilities = mock.Object;
        }
        private IEnumerable<string> FileList;
        private MovieScanner Scanner;

        [Fact]
        public void ReturnsMovies()
        {
            this.FileList = new[] { "C:/movies/SomeMovie.mp4" };
            var movies = Scanner.Scan("C:/movies");
            Assert.Equal(1, movies.Count());
        }
    }
}
