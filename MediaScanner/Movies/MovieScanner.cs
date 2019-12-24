using System.Collections.Generic;

namespace Plumb.MediaScanner.Movies
{
    public class MovieScanner
    {
        public MovieScanner()
        {

        }

        public Utilities Utilities = new Utilities();

        public MovieScannerOptions GetDefaultOptions()
        {
            var options = new MovieScannerOptions();
            options.VideoFileExtensions = new[] { "mp4", "mov", "mpegts", "asf", "avi", "mpeg", "flv", "webm", "wmv" };
            return options;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="basePath">The full path to the folder containing the movies</param>
        public IEnumerable<Movie> Scan(string rootFolderPath, MovieScannerOptions options = null)
        {
            //get default options if not specified
            options = options ?? this.GetDefaultOptions();

            //find all movie files with the specified extensions
            var moviePaths = this.Utilities.GetFiles(rootFolderPath, options.VideoFileExtensions);

            //iterate over every movie path
            foreach (var moviePath in moviePaths)
            {
                var movie = new Movie(rootFolderPath, moviePath);
                yield return movie;
            }
        }
    }

    public class MovieScannerOptions
    {
        /// <summary>
        /// Only videos with these file extensions will be included in the scan results.
        /// </summary>
        public IEnumerable<string> VideoFileExtensions;
    }
}
