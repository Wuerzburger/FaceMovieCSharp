using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceMovie.src.App
{
    public interface IImageProcessor
    {
        void ResizeImages(string inputDirectory, string outputDirectory, int targetSize);
    }
}
