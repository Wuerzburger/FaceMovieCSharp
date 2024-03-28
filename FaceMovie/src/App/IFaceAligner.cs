using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceMovie.src.App
{
    public interface IFaceAligner
    {
        void AlignFaces(string inputDirectory, string outputDirectory, string referenceImagePath);
    }
}
