using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Metrics;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestIntelexion.Models;
using TestIntelexion.Utils;

namespace TestIntelexion.Services
{
    public  class ImageService
    {
        public ImageService()
        {

        }

        public List<ImagesFile> ReadImagesFiles()
        {
            List<ImagesFile> imagesList = new List<ImagesFile>();
            string delimiter = ConfigurationManager.AppSettings["Delimitador"].ToString();
            string srcpathImgs = ConfigurationManager.AppSettings["imagenessrc"].ToString();
            string dirProcess = ConfigurationManager.AppSettings["compressfile"].ToString();

            DateTime currentDate = DateTime.Now;
            string destinationDirectory = $"{dirProcess}/{currentDate.ToString("yyyy_MM_dd")}";
            int counter = 1;
            if (Directory.Exists(destinationDirectory))
            {
                counter = GetMaxfolio(destinationDirectory, dirProcess);
            } else
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            DirectoryInfo dirImgs = new DirectoryInfo(srcpathImgs);
            List<FileInfo> srcImgsFiles = dirImgs.GetFiles().ToList();

            string dayofweek = DateUtils.GetDayOfWeek(currentDate);
            srcImgsFiles.ForEach(item =>
            {
                imagesList.Add(new ImagesFile(item.CreationTime, counter.ToString("D5"), $"{dayofweek}/{item.Name}", item.FullName,delimiter));
                counter++;
            });

            return imagesList;
        }

        private int GetMaxfolio(string destinationDirectory, string dirProcess)
        {
            int counter = 1;
            DirectoryInfo dirSrcImgs = new DirectoryInfo(destinationDirectory);
            List<FileInfo> compressImgsFiles = dirSrcImgs.GetFiles().ToList();
            string? maxFile = compressImgsFiles.Max(x => x.Name);
            if (maxFile != null)
            {
                Directory.CreateDirectory($"{dirProcess}/temp");
                ZipFile.ExtractToDirectory($"{destinationDirectory}/{maxFile}", $"{dirProcess}/temp");
                List<string> fileContentImgs =  File.ReadAllLines($"{dirProcess}/temp/imgsprocess.meta").ToList();
                counter = fileContentImgs.Max(item =>  int.Parse(item.Substring(5, 5)) );
                counter++;
                Directory.Delete($"{dirProcess}/temp", true);
            }

            return counter;
        }
    }
}
