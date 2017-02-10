using System.Data.Entity;
using ZipUploader.Models.Models;

namespace ZipUploader.Data.Contracts
{
    public interface IZipUploaderContext
    {
        IDbSet<File> Files { get; set; }

        void Create();

        void SaveChanges();
    }
}
