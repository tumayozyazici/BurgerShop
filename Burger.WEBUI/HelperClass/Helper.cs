using Microsoft.AspNetCore.Hosting;

namespace Burger.WEBUI.HelperClass
{
    public static class Helper
    {
        public static string AddPhoto(IFormFile file, IWebHostEnvironment _webHostEnvironment)
        {
            string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "burgerImages");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);
            string filePath = Path.Combine(uploadFolder, uniqueFileName);

            using (var filestream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(filestream);
            }

            string relativeFilePath = Path.Combine("/burgerImages", uniqueFileName);
            return relativeFilePath;
        }
    }
}
