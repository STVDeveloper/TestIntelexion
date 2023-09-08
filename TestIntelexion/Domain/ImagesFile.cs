using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIntelexion.Models
{
    public class ImagesFile
    {
        public string Id { get; set; }
        public string CreationDateStr { get; set; }
        public DateTime CreationDate { get; set; }
        public string DestPath { get; set; }
        public string SourcePath { get; set; }
        public string Delimiter { get; set; }

        public ImagesFile(DateTime creationDate, string folio, string pathImage, string srcPath, string delimiter)
        {
            CreationDate = creationDate;
            JulianCalendar julianCalendar = new JulianCalendar();

            Id = julianCalendar.GetYear(creationDate).ToString().Substring(2,2) + julianCalendar.GetDayOfYear(creationDate).ToString() + folio ;
            CreationDateStr = creationDate.ToString("yyyy/MM/dd HH:mm:ss");
            SourcePath = srcPath;
            DestPath = pathImage;
            Delimiter = delimiter;
        }

        public override string ToString()
        {
            return $"{Id}{Delimiter}{CreationDateStr}{Delimiter}{DestPath}";
        }
    }
}
