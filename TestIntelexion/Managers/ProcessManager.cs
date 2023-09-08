using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestIntelexion.Models;
using TestIntelexion.Services;

namespace TestIntelexion.Managers
{
    public class ProcessManager
    {
        private readonly ImageService imageService;
        private readonly CompressService procesService;
        public ProcessManager()
        {
            imageService = new ImageService();
            procesService = new CompressService();
        }

        public void ProcessImages()
        {
            List<ImagesFile> listimgs = imageService.ReadImagesFiles();
            procesService.CompresImageList(listimgs);
        }
    }
}
