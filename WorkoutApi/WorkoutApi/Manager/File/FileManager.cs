namespace WorkoutApi.Manager.FileManager
{
    public class FileManager : IFileManager<IFormCollection>
    {
        public string Delete()
        {
            throw new NotImplementedException();
        }

        public (bool,string) Save(IFormCollection formCollection)
        {
            try
            {
                var fileList = formCollection.Files.ToList();

                var folderName = System.IO.Path.Combine("Resources", "File");
                var pathToSave = System.IO.Path.Combine(Directory.GetCurrentDirectory(), folderName);

                var fileName = "";

                foreach (var item in fileList)
                {
                    if (item.Length <= 0)
                    {
                        break;
                    }

                    fileName = Guid.NewGuid().ToString() + "." + item.ContentType.Trim('"').Split('/')[1];

                    var fullPath = System.IO.Path.Combine(pathToSave, fileName);
                    var dbPath = System.IO.Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        item.CopyTo(stream);
                    }
                }

                return (true, fileName != null ? fileName : "");
            }
            catch (Exception ex)
            {
                return (false, $"Internal server error: {ex}");
            }
        }
    }
}
