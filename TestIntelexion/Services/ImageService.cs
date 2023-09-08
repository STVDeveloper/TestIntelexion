using System;
using System.Collections.Generic;
using System.Configuration;
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

            DirectoryInfo dirImgs = new DirectoryInfo(srcpathImgs);
            List<FileInfo> srcImgsFiles = dirImgs.GetFiles().ToList();

            int counter = 1;
            DateTime currentDate = DateTime.Now;
            string dayofweek = DateUtils.GetDayOfWeek(currentDate);
            srcImgsFiles.ForEach(item =>
            {
                imagesList.Add(new ImagesFile(item.CreationTime, counter.ToString("D5"), $"{dayofweek}/{item.Name}", item.FullName,delimiter));
                counter++;
            });

            return imagesList;
        }
    }
}
