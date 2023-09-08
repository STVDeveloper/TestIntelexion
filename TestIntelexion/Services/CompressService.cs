using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestIntelexion.Models;
using TestIntelexion.Utils;

namespace TestIntelexion.Services
{
    public class CompressService
    {
        public CompressService()
        {

        }

        public void CompresImageList(List<ImagesFile> listImgs)
        {
            string dirProcess = ConfigurationManager.AppSettings["compressfile"].ToString();

            string logfile = ConfigurationManager.AppSettings["logfile"].ToString();
            

            DirectoryInfo dirImgs = new DirectoryInfo(dirProcess);

            Directory.CreateDirectory($"{dirProcess}/temp");
            DateTime currentDate = DateTime.Now;
            string dayofweek = DateUtils.GetDayOfWeek(currentDate);
            Directory.CreateDirectory($"{dirProcess}/temp/{dayofweek}");
            StringBuilder metaFileContent = new StringBuilder();
            StringBuilder logFileContent = new StringBuilder();
            listImgs.ForEach(item =>
            {
                File.Copy(item.SourcePath, $"{dirProcess}/temp/{item.DestPath}");
                metaFileContent.AppendLine(item.ToString());
                logFileContent.AppendLine($"{item.Id}{item.Delimiter}{item.SourcePath}");
            });

            File.WriteAllText($"{dirProcess}/temp/imgsprocess.meta", metaFileContent.ToString());
            string pathZipFile = currentDate.ToString("yyyy_MM_dd_HH_mm_ss");
            ZipFile.CreateFromDirectory($"{dirProcess}/temp", $"{dirProcess}/{pathZipFile}.zip");

            File.WriteAllText($"{logfile}/{pathZipFile}.log", logFileContent.ToString());

            Directory.Delete($"{dirProcess}/temp", true);
        }
    }
}
