using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Plumb.MediaScanner
{
    public class Utilities
    {

        /// <summary>
        /// Recursively find all files with one of the specified file extensions.
        /// </summary>
        /// <param name="rootFolderPath"></param>
        /// <param name="fileExtensions"></param>
        /// <returns></returns>
        public virtual IEnumerable<string> GetFiles(string rootFolderPath, IEnumerable<string> fileExtensions)
        {
            //find all files with the target extensions
            return this.GetFiles(rootFolderPath, "(\\." + String.Join("\\.", fileExtensions) + ")$");
        }

        /// <summary>
        /// Recursively find all files in a directory that match the pattern
        /// </summary>
        /// <remarks>
        /// Taken from stackoverflow: https://stackoverflow.com/a/2107294/1633757
        /// </remarks>
        /// <param name="rootFolderPath"></param>
        /// <param name="filterRegex"></param>
        /// <returns></returns>
        public virtual IEnumerable<string> GetFiles(string rootFolderPath, string filterRegex)
        {
            var regex = new Regex(filterRegex);
            Queue<string> pending = new Queue<string>();
            pending.Enqueue(rootFolderPath);
            IEnumerable<string> tmp;
            while (pending.Count > 0)
            {
                rootFolderPath = pending.Dequeue();
                try
                {
                    tmp = Directory.EnumerateFiles(rootFolderPath);
                }
                //skip locked folders
                catch (UnauthorizedAccessException)
                {
                    continue;
                }
                foreach (var item in tmp)
                {
                    //if the current file matches the regular expression, return it
                    if (regex.IsMatch(item))
                    {
                        yield return item;
                    }
                }
                tmp = Directory.GetDirectories(rootFolderPath);
                foreach (var dir in tmp)
                {
                    pending.Enqueue(dir);
                }
            }
        }
    }
}
