using System.Data.Entity;
using ZipUploader.Data.Contracts;
using ZipUploader.Models.Models;

namespace ZipUploader.Data
{
    public class ZipUploaderContext : DbContext, IZipUploaderContext
    {
        public ZipUploaderContext()
            : base("FileUpload")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ZipUploaderContext>());
        }

        public IDbSet<File> Files { get; set; }

        public void Create()
        {
            this.Files.Add(new File { Content = "test" });
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
