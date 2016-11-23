using System.IO;

namespace Backend.Services
{
    public interface IDatabaseLocator
    {
        string LocateDatabase();
    }

    public class DatabaseLocator : IDatabaseLocator
    {
        private const string DatabaseFilename = "FeedMaster_DB.mdb";

        public string LocateDatabase()
        {
            return LocateRecursively(Directory.GetCurrentDirectory());
        }

        private string LocateRecursively(string currentDirectory)
        {
            var fullFilename = Path.Combine(currentDirectory, DatabaseFilename);
            if (File.Exists(fullFilename))
            {
                return fullFilename;
            }

            var parentDirectory = Directory.GetParent(currentDirectory);
            return parentDirectory == null ? null : LocateRecursively(parentDirectory.FullName);
        }
    }
}
