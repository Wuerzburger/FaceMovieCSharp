using ImageMagick;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceMovie.src.App
{
    public class ImageProcessor : IImageProcessor
    {

        private readonly IFileSystem _fileSystem;

        public ImageProcessor(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem ?? new FileSystem();
        }

        public void ResizeImages(string inputDirectory, string outputDirectory, int targetSize)
        {
            var imageFiles = Directory.EnumerateFiles(inputDirectory, "*.jpg");

            foreach (var file in imageFiles)
            {
                using var image = new MagickImage(file);
                image.Resize(new MagickGeometry(targetSize) { Greater = true });
                var outputPath = Path.Combine(outputDirectory, Path.GetFileName(file));
                image.Write(outputPath);
            }
        }
    }
}
