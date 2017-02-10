namespace ZipUploader.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<ZipUploader.Data.ZipUploaderContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ZipUploader.Data.ZipUploaderContext context)
        {
        }
    }
}
