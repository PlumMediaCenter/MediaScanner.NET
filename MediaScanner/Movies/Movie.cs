
namespace Plumb.MediaScanner.Movies
{
    public class Movie
    {

        public Movie(string rootFolderPath, string filePath)
        {
            this.RootFolderPath = rootFolderPath;
            this.FilePath = filePath;
        }

        /// <summary>
        /// Scan for all relevant movie information
        /// </summary>
        public void Scan()
        {
        }

        /// <summary>
        /// The full path to the root folder where this movie was scanned from
        /// </summary>
        public string RootFolderPath;

        /// <summary>
        /// The full path to the movie file
        /// </summary>
        public string FilePath;
        
    }
}