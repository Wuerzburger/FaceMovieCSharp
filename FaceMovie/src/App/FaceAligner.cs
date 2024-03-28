using DlibDotNet;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceMovie.src.App
{
    public class FaceAligner : IFaceAligner
    {
        private readonly IFileSystem _fileSystem;

        public FaceAligner(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public void AlignFaces(string inputDirectory, string outputDirectory, string referenceImagePath)
        {
            // Example logic for face alignment
            var detector = Dlib.GetFrontalFaceDetector();
            var sp = ShapePredictor.Deserialize("shape_predictor_68_face_landmarks.dat");

            foreach (var filePath in _fileSystem.Directory.EnumerateFiles(inputDirectory, "*.jpg"))
            {
                using var image = Dlib.LoadImage<RgbPixel>(filePath);
                var faces = detector.Operator(image);
                foreach (var face in faces)
                {
                    var shape = sp.Detect(image, face);
                    // Perform alignment based on shape landmarks
                }
                // Save aligned image
                Dlib.SaveJpeg(image, _fileSystem.Path.Combine(outputDirectory, _fileSystem.Path.GetFileName(filePath)));
            }
        }
    }
}
