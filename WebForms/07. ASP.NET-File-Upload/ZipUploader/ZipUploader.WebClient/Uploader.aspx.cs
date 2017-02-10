using System;
using System.IO;
using System.Web.UI;
using ZipUploader.Data;
using ZipUploader.Data.Contracts;

namespace ZipUploader.WebClient
{
    public partial class Uploader : Page
    {
        private const string ZipCompressedExtension = "application/x-zip-compressed";
        private const string ZipExtension = "appication/zip";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            string contentType = this.FileUploadControl.PostedFile.ContentType;
            if (contentType == ZipCompressedExtension || contentType == ZipExtension)
            {
                byte[] fileData = null;
                Stream fileStream = null;
                int length = 0;

                if (this.FileUploadControl.HasFile)
                {
                    length = this.FileUploadControl.PostedFile.ContentLength;
                    fileData = new byte[length + 1];
                    fileStream = this.FileUploadControl.PostedFile.InputStream;
                    fileStream.Read(fileData, 0, length);

                    IZipUploaderContext context = new ZipUploaderContext();
                    context.Files.Add(new Models.Models.File
                    {
                        Content = string.Join("", fileData)
                    });

                    context.SaveChanges();
                    this.ResultLabel.Text = "File has been added to the database.";
                }
            }
            else
            {
                this.ResultLabel.Text = "You can only pick a zip file!";
            }
        }
    }
}